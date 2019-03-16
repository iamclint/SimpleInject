using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Windows;


namespace SimpleInject
{
    public partial class SimpleInject : Form
    {
 

        [DllImport("libinj.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Is32Bit(int process_id);
        [DllImport("libinj.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Inject(int process_id, string dll, int method, IntPtr handle = default(IntPtr));
        [DllImport("libinj.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern string getLastError();

        public static BackgroundWorker UpdateThread;
        private ColumnHeader SortingColumn = null;

        private bool[] sortColAsc;


        public SimpleInject()
        {
            InitializeComponent();
            LoadSettings();
            UpdateThread_DoWork(null, null); // initial open don't use background worker its slower at updating the list due to invoking.
            UpdateThread = new BackgroundWorker();
            UpdateThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateThread_DoWork);
            
        }



        private void LoadSettings()
        {
            DllX86.Text =  Properties.Settings.Default.X86;
            DllX64.Text = Properties.Settings.Default.X64;
            hideEmptyTitles.Checked = Properties.Settings.Default.HideEmptyTitles;
            Filters.Text = Properties.Settings.Default.Filters;

            if (sortColAsc == null)
            {
                sortColAsc = new bool[20];
                foreach (ColumnHeader ch in ProcessList.Columns)
                    sortColAsc[ch.Index] = false;
            }
        }

        private bool isValidFile(string file_path)
        {
            if (!File.Exists(file_path))
                return false;
            return true;
        }

        private void UpdateThread_DoWork(object sender, DoWorkEventArgs e)
        {

            bool hasChanged = false;

            foreach (Process p in Process.GetProcesses())
            {
                bool isExisting=false;
                bool isMatching = filterProcess(p);

                if (ProcessList.InvokeRequired)
                    ProcessList.Invoke(new MethodInvoker(delegate { isExisting = ProcessList.Items.ContainsKey(p.Id.ToString()); }));
                else
                    isExisting = ProcessList.Items.ContainsKey(p.Id.ToString());

                if (hideEmptyTitles.Checked && p.MainWindowTitle.Trim() == "")
                    isMatching = false;

                if (!isExisting && isMatching)
                {
                    ListViewItem lvi = new ListViewItem(new[] { p.ProcessName, p.MainWindowTitle, p.Id.ToString(), (Is32Bit(p.Id)?"X86":"X64") });
                    lvi.Name = p.Id.ToString(); //set the key of the item here
                    if (ProcessList.InvokeRequired)
                        ProcessList.Invoke(new MethodInvoker(delegate
                        {
                            ProcessList.Items.Add(lvi);
                        }));
                    else
                        ProcessList.Items.Add(lvi);
                    hasChanged = true;
                }
                else
                {
                    string title = "";
                    if (isExisting)
                    {
                        if (ProcessList.InvokeRequired)
                            ProcessList.Invoke(new MethodInvoker(delegate
                            {
                                title = ProcessList.Items[p.Id.ToString()].SubItems[1].Text;
                            }));
                        else
                            title = ProcessList.Items[p.Id.ToString()].SubItems[1].Text;
                    }

                    if (isExisting && title != p.MainWindowTitle) //if you always update without checking it causes all the items to flicker
                    {
                        if (ProcessList.InvokeRequired)
                            ProcessList.Invoke(new MethodInvoker(delegate
                            {
                                ProcessList.Items[p.Id.ToString()].SubItems[1].Text = p.MainWindowTitle;
                            }));
                        else
                            ProcessList.Items[p.Id.ToString()].SubItems[1].Text = p.MainWindowTitle;
                        hasChanged = true;
                    }

                    if (!isMatching && isExisting)
                    {
                        if (ProcessList.InvokeRequired)
                            ProcessList.Invoke(new MethodInvoker(delegate
                            {
                                ProcessList.Items.RemoveAt(ProcessList.Items[p.Id.ToString()].Index);
                            }));
                        else 
                            ProcessList.Items.RemoveAt(ProcessList.Items[p.Id.ToString()].Index);
                    }
                }
            }
            if (hasChanged)
                if (ProcessList.InvokeRequired)
                {
                    ProcessList.Invoke(new MethodInvoker(delegate {
                        ProcessList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        ProcessList.Columns[3].Width = -2;
                    }));
                }
                else
                {
                    ProcessList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    ProcessList.Columns[3].Width = -2;
                }


        }

        public bool filterProcess(Process p)
        {
            
            string[] filterArr = Filters.Text.Split(';');
            foreach (string filterStr in filterArr)
            {
                if (p.ProcessName.ToLower().IndexOf(filterStr.ToLower()) >= 0)
                    return true;
                if (p.MainWindowTitle.ToLower().IndexOf(filterStr) >= 0)
                    return true;
            }   
            return false;
        }

        private void ProcessListTmr_Tick(object sender, EventArgs e)
        {
            if (!UpdateThread.IsBusy)
                UpdateThread.RunWorkerAsync();
        }

        private void ProcessList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader new_sorting_column = ProcessList.Columns[e.Column];
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (sortColAsc[e.Column])
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                // SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

    


            SortingColumn = new_sorting_column;


            // Create a comparer.
            ProcessList.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

            if (sort_order == SortOrder.Ascending)
                sortColAsc[e.Column] = true;
            else
                sortColAsc[e.Column] = false;

            // Sort.
            ProcessList.Sort();
        }
        private void ProcessList_DoubleClick(object sender, EventArgs e)
        {
            int process_id = int.Parse(ProcessList.SelectedItems[0].SubItems[GetColumnIndex("id")].Text);
            Inject(process_id);
           
        }

        private void Inject(int process_id)
        {
            string balloonText;
            if (Is32Bit(process_id))
            {
                if (isValidFile(DllX86.Text))
                {
                    balloonText = DllX86.Text.Substring(DllX86.Text.LastIndexOf(@"\") + 1, DllX86.Text.Length - DllX86.Text.LastIndexOf(@"\") - 1) + "-> " + ProcessList.SelectedItems[0].SubItems[0].Text.ToString();
                    if (!Inject(process_id, DllX86.Text, 1))
                        NotifyMessage.ShowBalloonTip(3000, "Error", getLastError(), ToolTipIcon.Error);
                    else
                        NotifyMessage.ShowBalloonTip(3000, "Successful Injection", balloonText, ToolTipIcon.Info);

                }
                else
                {
                    NotifyMessage.ShowBalloonTip(3000, "Error", "Invalid file selected!", ToolTipIcon.Error);
                }
            }
            else
            {
                if (isValidFile(DllX64.Text))
                {
                    balloonText = DllX64.Text.Substring(DllX64.Text.LastIndexOf(@"\") + 1, DllX64.Text.Length - DllX64.Text.LastIndexOf(@"\") - 1) + "-> " + ProcessList.SelectedItems[0].SubItems[0].Text.ToString();
                    if (!Inject(process_id, DllX64.Text, 1))
                        NotifyMessage.ShowBalloonTip(3000, "Error", getLastError(), ToolTipIcon.Error);
                    else
                        NotifyMessage.ShowBalloonTip(3000, "Successful Injection", balloonText, ToolTipIcon.Info);
                }
            }
        }

        private int GetColumnIndex(string name)
        {
            foreach (ColumnHeader col in ProcessList.Columns)
            {
                if (col.Text.ToLower() == name.ToLower())
                    return col.Index;
            }
            return -1;
        }

        private void X86Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ld = new System.Windows.Forms.OpenFileDialog();
            {
                var withBlock = ld;
                withBlock.DefaultExt = ".dll";
                withBlock.Filter = "Dll Files|*.dll";
                if (Properties.Settings.Default.X86.LastIndexOf(@"\") > 0)
                    withBlock.InitialDirectory = Properties.Settings.Default.X86.Substring(0, Properties.Settings.Default.X86.LastIndexOf(@"\"));
            }
            if (ld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DllX86.Text = ld.FileName;
                Properties.Settings.Default.X86 = ld.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void X64Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ld = new System.Windows.Forms.OpenFileDialog();
            {
                var withBlock = ld;
                withBlock.DefaultExt = ".dll";
                withBlock.Filter = "Dll Files|*.dll";
                if (Properties.Settings.Default.X64.LastIndexOf(@"\") > 0)
                    withBlock.InitialDirectory = Properties.Settings.Default.X64.Substring(0, Properties.Settings.Default.X64.LastIndexOf(@"\"));
            }
            if (ld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DllX86.Text = ld.FileName;
                Properties.Settings.Default.X64 = ld.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void HideEmptyTitles_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HideEmptyTitles = hideEmptyTitles.Checked;
            Properties.Settings.Default.Save();
        }

        private void Filters_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Filters = Filters.Text;
            Properties.Settings.Default.Save();
        }

        private void InjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int process_id = int.Parse(ProcessList.SelectedItems[0].SubItems[GetColumnIndex("id")].Text);
            Inject(process_id);
        }

        private void ForceClosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int process_id = int.Parse(ProcessList.SelectedItems[0].SubItems[GetColumnIndex("id")].Text);
            Process p = Process.GetProcessById(process_id);
            p.Kill();
        }

        private void ProcessList_DrawColumnHeader(object sender,
                                                  DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkSlateBlue, e.Bounds);
            e.Graphics.DrawLine(Pens.Gray, new Point(e.Bounds.Right-2, e.Bounds.Top+4), new Point(e.Bounds.Right-2, e.Bounds.Bottom-4));
            //e.ForeColor = Color.White;
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }
                sf.Alignment = StringAlignment.Near;

                // Draw the header text.
                using (Font headerFont =
                            new Font("Helvetica", 9, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds.X+4, e.Bounds.Y+3, sf);
                }
            }
           // e.DrawText(TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
        private void ProcessList_DrawItem(object sender,
                                DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}
