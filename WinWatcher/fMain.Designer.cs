/***
 *     ▄▄▄       ██ ▄█▀ ██▓ ██▓    
 *    ▒████▄     ██▄█▒ ▓██▒▓██▒    
 *    ▒██  ▀█▄  ▓███▄░ ▒██▒▒██░    
 *    ░██▄▄▄▄██ ▓██ █▄ ░██░▒██░    
 *     ▓█   ▓██▒▒██▒ █▄░██░░██████▒
 *     ▒▒   ▓▒█░▒ ▒▒ ▓▒░▓  ░ ▒░▓  ░
 *      ▒   ▒▒ ░░ ░▒ ▒░ ▒ ░░ ░ ▒  ░
 *      ░   ▒   ░ ░░ ░  ▒ ░  ░ ░   
 *          ░  ░░  ░    ░      ░  ░
 *          
 *     Small tool to watch directory activity
 *     For code updates visit repository on https://github.com/sutaj
 */
namespace WinWatcher
{
    partial class fMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                nIcon.Icon.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.watcherLog = new System.Windows.Forms.WebBrowser();
            this.bottomBar = new System.Windows.Forms.StatusStrip();
            this.bottom_count_create = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottom_count_mod = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottom_count_del = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottom_count_ren = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottom_count_proc = new System.Windows.Forms.ToolStripStatusLabel();
            this._optionPanel = new System.Windows.Forms.Panel();
            this.option_logfile = new System.Windows.Forms.CheckBox();
            this.option_scroll = new System.Windows.Forms.CheckBox();
            this.option_countproc = new System.Windows.Forms.CheckBox();
            this.option_recursive = new System.Windows.Forms.CheckBox();
            this.option_watchdir = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bottom_show_options = new System.Windows.Forms.CheckBox();
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.bottomBar.SuspendLayout();
            this._optionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // watcherLog
            // 
            this.watcherLog.AllowNavigation = false;
            this.watcherLog.AllowWebBrowserDrop = false;
            this.watcherLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.watcherLog.IsWebBrowserContextMenuEnabled = false;
            this.watcherLog.Location = new System.Drawing.Point(0, 0);
            this.watcherLog.MinimumSize = new System.Drawing.Size(20, 20);
            this.watcherLog.Name = "watcherLog";
            this.watcherLog.ScriptErrorsSuppressed = true;
            this.watcherLog.Size = new System.Drawing.Size(979, 447);
            this.watcherLog.TabIndex = 0;
            this.watcherLog.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.watcherLog.WebBrowserShortcutsEnabled = false;
            // 
            // bottomBar
            // 
            this.bottomBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.bottomBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bottom_count_create,
            this.bottom_count_mod,
            this.bottom_count_del,
            this.bottom_count_ren,
            this.bottom_count_proc});
            this.bottomBar.Location = new System.Drawing.Point(0, 447);
            this.bottomBar.Name = "bottomBar";
            this.bottomBar.Size = new System.Drawing.Size(979, 22);
            this.bottomBar.TabIndex = 1;
            // 
            // bottom_count_create
            // 
            this.bottom_count_create.Name = "bottom_count_create";
            this.bottom_count_create.Size = new System.Drawing.Size(13, 17);
            this.bottom_count_create.Text = "0";
            // 
            // bottom_count_mod
            // 
            this.bottom_count_mod.Name = "bottom_count_mod";
            this.bottom_count_mod.Size = new System.Drawing.Size(13, 17);
            this.bottom_count_mod.Text = "0";
            // 
            // bottom_count_del
            // 
            this.bottom_count_del.Name = "bottom_count_del";
            this.bottom_count_del.Size = new System.Drawing.Size(13, 17);
            this.bottom_count_del.Text = "0";
            // 
            // bottom_count_ren
            // 
            this.bottom_count_ren.Name = "bottom_count_ren";
            this.bottom_count_ren.Size = new System.Drawing.Size(13, 17);
            this.bottom_count_ren.Text = "0";
            // 
            // bottom_count_proc
            // 
            this.bottom_count_proc.Name = "bottom_count_proc";
            this.bottom_count_proc.Size = new System.Drawing.Size(13, 17);
            this.bottom_count_proc.Text = "0";
            // 
            // _optionPanel
            // 
            this._optionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._optionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._optionPanel.Controls.Add(this.option_logfile);
            this._optionPanel.Controls.Add(this.option_scroll);
            this._optionPanel.Controls.Add(this.option_countproc);
            this._optionPanel.Controls.Add(this.option_recursive);
            this._optionPanel.Controls.Add(this.option_watchdir);
            this._optionPanel.Controls.Add(this.label1);
            this._optionPanel.Location = new System.Drawing.Point(0, 335);
            this._optionPanel.Name = "_optionPanel";
            this._optionPanel.Size = new System.Drawing.Size(979, 112);
            this._optionPanel.TabIndex = 2;
            // 
            // option_logfile
            // 
            this.option_logfile.AutoSize = true;
            this.option_logfile.Location = new System.Drawing.Point(11, 85);
            this.option_logfile.Name = "option_logfile";
            this.option_logfile.Size = new System.Drawing.Size(266, 17);
            this.option_logfile.TabIndex = 5;
            this.option_logfile.Text = "Write also in logfile (saved in exe working directory)";
            this.option_logfile.UseVisualStyleBackColor = true;
            this.option_logfile.CheckedChanged += new System.EventHandler(this.option_logfile_CheckedChanged);
            // 
            // option_scroll
            // 
            this.option_scroll.AutoSize = true;
            this.option_scroll.Checked = true;
            this.option_scroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.option_scroll.Location = new System.Drawing.Point(11, 61);
            this.option_scroll.Name = "option_scroll";
            this.option_scroll.Size = new System.Drawing.Size(148, 17);
            this.option_scroll.TabIndex = 4;
            this.option_scroll.Text = "Log window auto scrolling";
            this.option_scroll.UseVisualStyleBackColor = true;
            this.option_scroll.CheckedChanged += new System.EventHandler(this.option_scroll_CheckedChanged);
            // 
            // option_countproc
            // 
            this.option_countproc.AutoSize = true;
            this.option_countproc.Checked = true;
            this.option_countproc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.option_countproc.Location = new System.Drawing.Point(11, 37);
            this.option_countproc.Name = "option_countproc";
            this.option_countproc.Size = new System.Drawing.Size(180, 17);
            this.option_countproc.TabIndex = 3;
            this.option_countproc.Text = "Monitor running processes count";
            this.option_countproc.UseVisualStyleBackColor = true;
            // 
            // option_recursive
            // 
            this.option_recursive.AutoSize = true;
            this.option_recursive.Checked = true;
            this.option_recursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.option_recursive.Location = new System.Drawing.Point(338, 8);
            this.option_recursive.Name = "option_recursive";
            this.option_recursive.Size = new System.Drawing.Size(128, 17);
            this.option_recursive.TabIndex = 2;
            this.option_recursive.Text = "include subdirectories";
            this.option_recursive.UseVisualStyleBackColor = true;
            this.option_recursive.CheckedChanged += new System.EventHandler(this.option_recursive_CheckedChanged);
            // 
            // option_watchdir
            // 
            this.option_watchdir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.option_watchdir.FormattingEnabled = true;
            this.option_watchdir.Items.AddRange(new object[] {
            "Windows directory",
            "System directory",
            "User directory",
            "Program Files directory",
            "Program Files x86 directory"});
            this.option_watchdir.Location = new System.Drawing.Point(119, 6);
            this.option_watchdir.Name = "option_watchdir";
            this.option_watchdir.Size = new System.Drawing.Size(213, 21);
            this.option_watchdir.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory to watch:";
            // 
            // bottom_show_options
            // 
            this.bottom_show_options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bottom_show_options.AutoSize = true;
            this.bottom_show_options.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bottom_show_options.Checked = true;
            this.bottom_show_options.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bottom_show_options.Location = new System.Drawing.Point(898, 452);
            this.bottom_show_options.Name = "bottom_show_options";
            this.bottom_show_options.Size = new System.Drawing.Size(60, 17);
            this.bottom_show_options.TabIndex = 3;
            this.bottom_show_options.Text = "options";
            this.bottom_show_options.UseVisualStyleBackColor = true;
            this.bottom_show_options.CheckedChanged += new System.EventHandler(this.bottom_show_options_CheckedChanged);
            // 
            // nIcon
            // 
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "notifyIcon1";
            this.nIcon.Visible = true;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 469);
            this.Controls.Add(this.bottom_show_options);
            this.Controls.Add(this._optionPanel);
            this.Controls.Add(this.watcherLog);
            this.Controls.Add(this.bottomBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "WinWatcher";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.bottomBar.ResumeLayout(false);
            this.bottomBar.PerformLayout();
            this._optionPanel.ResumeLayout(false);
            this._optionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser watcherLog;
        private System.Windows.Forms.StatusStrip bottomBar;
        private System.Windows.Forms.ToolStripStatusLabel bottom_count_create;
        private System.Windows.Forms.ToolStripStatusLabel bottom_count_mod;
        private System.Windows.Forms.ToolStripStatusLabel bottom_count_del;
        private System.Windows.Forms.ToolStripStatusLabel bottom_count_ren;
        private System.Windows.Forms.ToolStripStatusLabel bottom_count_proc;
        private System.Windows.Forms.Panel _optionPanel;
        private System.Windows.Forms.CheckBox option_recursive;
        private System.Windows.Forms.ComboBox option_watchdir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox option_countproc;
        private System.Windows.Forms.CheckBox option_scroll;
        private System.Windows.Forms.CheckBox option_logfile;
        private System.Windows.Forms.CheckBox bottom_show_options;
        private System.Windows.Forms.NotifyIcon nIcon;
    }
}

