namespace SimpleInject
{
    partial class SimpleInject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleInject));
            this.DllX86 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.x86Browse = new System.Windows.Forms.Button();
            this.x64Browse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DllX64 = new System.Windows.Forms.TextBox();
            this.ProcessList = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProcessor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.injectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enumerateModulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceClosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Filters = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProcessListTmr = new System.Windows.Forms.Timer(this.components);
            this.hideEmptyTitles = new System.Windows.Forms.CheckBox();
            this.NotifyMessage = new System.Windows.Forms.NotifyIcon(this.components);
            this.lvContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // DllX86
            // 
            this.DllX86.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DllX86.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DllX86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DllX86.ForeColor = System.Drawing.Color.White;
            this.DllX86.Location = new System.Drawing.Point(42, 12);
            this.DllX86.Name = "DllX86";
            this.DllX86.Size = new System.Drawing.Size(711, 20);
            this.DllX86.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "x86";
            // 
            // x86Browse
            // 
            this.x86Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.x86Browse.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.x86Browse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.x86Browse.Location = new System.Drawing.Point(759, 10);
            this.x86Browse.Name = "x86Browse";
            this.x86Browse.Size = new System.Drawing.Size(29, 23);
            this.x86Browse.TabIndex = 2;
            this.x86Browse.Text = "...";
            this.x86Browse.UseVisualStyleBackColor = false;
            this.x86Browse.Click += new System.EventHandler(this.X86Browse_Click);
            // 
            // x64Browse
            // 
            this.x64Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.x64Browse.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.x64Browse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.x64Browse.Location = new System.Drawing.Point(759, 36);
            this.x64Browse.Name = "x64Browse";
            this.x64Browse.Size = new System.Drawing.Size(29, 23);
            this.x64Browse.TabIndex = 5;
            this.x64Browse.Text = "...";
            this.x64Browse.UseVisualStyleBackColor = false;
            this.x64Browse.Click += new System.EventHandler(this.X64Browse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "x64";
            // 
            // DllX64
            // 
            this.DllX64.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DllX64.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DllX64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DllX64.ForeColor = System.Drawing.Color.White;
            this.DllX64.Location = new System.Drawing.Point(42, 38);
            this.DllX64.Name = "DllX64";
            this.DllX64.Size = new System.Drawing.Size(711, 20);
            this.DllX64.TabIndex = 3;
            // 
            // ProcessList
            // 
            this.ProcessList.AllowColumnReorder = true;
            this.ProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProcessList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colTitle,
            this.colId,
            this.colProcessor});
            this.ProcessList.ContextMenuStrip = this.lvContext;
            this.ProcessList.ForeColor = System.Drawing.Color.White;
            this.ProcessList.FullRowSelect = true;
            this.ProcessList.Location = new System.Drawing.Point(12, 64);
            this.ProcessList.MultiSelect = false;
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.OwnerDraw = true;
            this.ProcessList.Size = new System.Drawing.Size(776, 316);
            this.ProcessList.TabIndex = 6;
            this.ProcessList.UseCompatibleStateImageBehavior = false;
            this.ProcessList.View = System.Windows.Forms.View.Details;
            this.ProcessList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ProcessList_ColumnClick);
            this.ProcessList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ProcessList_DrawColumnHeader);
            this.ProcessList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ProcessList_DrawItem);
            this.ProcessList.DoubleClick += new System.EventHandler(this.ProcessList_DoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 48;
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 603;
            // 
            // colId
            // 
            this.colId.Text = "ID";
            // 
            // colProcessor
            // 
            this.colProcessor.Text = "x86/x64";
            this.colProcessor.Width = 61;
            // 
            // lvContext
            // 
            this.lvContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.injectToolStripMenuItem,
            this.enumerateModulesToolStripMenuItem,
            this.forceClosToolStripMenuItem});
            this.lvContext.Name = "lvContext";
            this.lvContext.Size = new System.Drawing.Size(181, 70);
            // 
            // injectToolStripMenuItem
            // 
            this.injectToolStripMenuItem.Name = "injectToolStripMenuItem";
            this.injectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.injectToolStripMenuItem.Text = "&Inject";
            this.injectToolStripMenuItem.Click += new System.EventHandler(this.InjectToolStripMenuItem_Click);
            // 
            // enumerateModulesToolStripMenuItem
            // 
            this.enumerateModulesToolStripMenuItem.Name = "enumerateModulesToolStripMenuItem";
            this.enumerateModulesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enumerateModulesToolStripMenuItem.Text = "&Enumerate Modules";
            // 
            // forceClosToolStripMenuItem
            // 
            this.forceClosToolStripMenuItem.Name = "forceClosToolStripMenuItem";
            this.forceClosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.forceClosToolStripMenuItem.Text = "&Force close";
            this.forceClosToolStripMenuItem.Click += new System.EventHandler(this.ForceClosToolStripMenuItem_Click);
            // 
            // Filters
            // 
            this.Filters.AccessibleDescription = "a";
            this.Filters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Filters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Filters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Filters.Location = new System.Drawing.Point(52, 404);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(736, 20);
            this.Filters.TabIndex = 7;
            this.Filters.TextChanged += new System.EventHandler(this.Filters_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Filters";
            // 
            // ProcessListTmr
            // 
            this.ProcessListTmr.Enabled = true;
            this.ProcessListTmr.Interval = 500;
            this.ProcessListTmr.Tick += new System.EventHandler(this.ProcessListTmr_Tick);
            // 
            // hideEmptyTitles
            // 
            this.hideEmptyTitles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hideEmptyTitles.AutoSize = true;
            this.hideEmptyTitles.ForeColor = System.Drawing.Color.White;
            this.hideEmptyTitles.Location = new System.Drawing.Point(14, 381);
            this.hideEmptyTitles.Name = "hideEmptyTitles";
            this.hideEmptyTitles.Size = new System.Drawing.Size(103, 17);
            this.hideEmptyTitles.TabIndex = 9;
            this.hideEmptyTitles.Text = "Hide empty titles";
            this.hideEmptyTitles.UseVisualStyleBackColor = true;
            this.hideEmptyTitles.CheckedChanged += new System.EventHandler(this.HideEmptyTitles_CheckedChanged);
            // 
            // NotifyMessage
            // 
            this.NotifyMessage.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyMessage.Icon")));
            this.NotifyMessage.Text = "Simple Inject";
            this.NotifyMessage.Visible = true;
            // 
            // SimpleInject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(800, 435);
            this.Controls.Add(this.hideEmptyTitles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Filters);
            this.Controls.Add(this.ProcessList);
            this.Controls.Add(this.x64Browse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DllX64);
            this.Controls.Add(this.x86Browse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DllX86);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimpleInject";
            this.Text = "Simple Inject";
            this.lvContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DllX86;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button x86Browse;
        private System.Windows.Forms.Button x64Browse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DllX64;
        private System.Windows.Forms.ListView ProcessList;
        private System.Windows.Forms.TextBox Filters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colProcessor;
        private System.Windows.Forms.Timer ProcessListTmr;
        private System.Windows.Forms.CheckBox hideEmptyTitles;
        private System.Windows.Forms.NotifyIcon NotifyMessage;
        private System.Windows.Forms.ContextMenuStrip lvContext;
        private System.Windows.Forms.ToolStripMenuItem injectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceClosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enumerateModulesToolStripMenuItem;
    }
}

