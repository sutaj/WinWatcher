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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static WinWatcher.OptVars;
using static WinWatcher.LogFile;

namespace WinWatcher
{
    public partial class fMain : Form
    {
        #region common shiet

        FileSystemWatcher TheWatcher = new FileSystemWatcher();
        System.Windows.Forms.Timer TickTock = new System.Windows.Forms.Timer();
        Thread bgThread;

        // 2 small icon easy to use in system web renderer - few kb in memory more, but program can be used offline. SOURCE: https://iconfinder.com - thx!
        string warrning_ico = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACo0lEQVQ4T6WOS0hUURzGvzPOnXGeOoaa4aJ8oUwQqYgv0AQrsZRyEwWV2xJb1KbHIsKilgVBIWkvJLNc9JLMFEWjgvJRNKhYPsbRe3UezsNx7tx7TnQtqdQ2nc3h+/+/7/f/CP7zkX/lxxvLj8kg5uTqZ5fX860LGL9VejHKmnOGykEI/YOXMmpen10LsiZg+mZJpi4984PFagJEHvynAPjR2axtNS8//g1ZBRi9VqY1xpn64/PTM3iHG0RtQLxxCrZur40LSdtTa9tCv0NWARw3CvbHF+1+PLUwhob2bARDIk7uE2ARHRh846jKOdXRui5AeFhs5Eypvui8FMVz8IQTY2OjeNecrOjhrglICzBtPd7i/wX5o8H8/dJGfW7FUd2GeWVvLeqB1+fDVHuSon0zBEM99tuF5/qqVwE8d3du4dLyvqoT1dBI/co+ocgOWZIhNHsVHQ5F4HO3ALvNlVTRgm8/ZisNnI0lfYZCa37Y+x5Gg6QEYndQSHIY7ifLtkUPAQ2E0fl8sqeyIVC0AnDW6aq4rOJHXJoWktsFo0WlBEgKr5xgbzlFL8zIMOsjMNzvxOCAq+pAU7BVQTuvb+b1lXvi6NwAKNVAq1m+eO/OIEBUOFy+abmBPwyyRKHXqND2dMK7t94fRdwXtLVc+ZGrKtMs2OISqCxBx1H4hDHsOp8Nv9eD3rohGM2JCHolQKTQqQF+0o8XXfxp4mvKFtXFuRzlvwBQg9IwjMYw3MM2xBxKBYIBuFodsMQkwOtmYCEKIsowcwydvQKI70Eu48oKwOZGAEYAKiIyEoBLgG1EUKpnpMUpv+ihID8BahVDx6tpEPeV6GpsjK1nUYYgE2VQiUKSGHScCM+8H2AqaA0Efr8acphBEmUwxjAnBHV2PlTzHU6uLGZ/M/MEAAAAAElFTkSuQmCC";
        string error_ico = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACrklEQVQ4T6XRW0jTURwH8O9/czfdTUfegryXohFaGKa0SigV0XBYD4ndKKKkh4LA7KEeKiOCInoqSHrMXJChCIpgCEV5Wc1b0xrYLm7TObXN+T//c8K/JZXaSwfO0/meD9/fORz+c3H/uj9WUnmel0Roc9paGjfKbQjYDlXe1OdnXWWhIByfJm/ldrxsWA9ZF7AdKM/T7Ejri0kAJB4fnF4OHndw564Oc//fyBrAVlqqkCn1A3HF27KYLAqIkEMy1Afr6NyIjoVzM9rbw78jawB7YUmV3pjdEplqgOx0vZgl96/D+9YC2zQ1GTtfmTcEPPuq1SzdMK/fGglBFQ1V3TUxG3p4G9KxYYx6Bcwwotnf3LzwC/mjgaO48qnuSNEJzjUBLi4FqnNXxNzCjUuQWAaxpI3Du3FvU0lv18k1gPtgdYpqd+YXeQLDUs8bSJPSEdX4RMzNnaoC6emGOm4zPnz2YcK3mFqLwNfls9UG7r1lvZri5D3CyACIwwXZbiPUd5tWgLpjIN1dUBgSQeZ5vLY5emq++42rgFMea1JW5L9QJElB3AHQwCykWzKgefRcBALHy0AtVrDIaOgEDlbnLN5PB0xnQrNmsYEnKXMq6oIxVvg4DBahAHgK6poE9IliRTLUD2l8OlhYELeWcDDbHXNH5/06ziMxXFRdPvwAxAcWCIJRBur1QpqWCfW9Z+CYBIGzJtBBC6DSgS0KUBPgWyCEVvdUPecvKFySV22XCdZxQMKBCQzU5UBEXiHUjY9/vkEtSHcnoN8EFhSAMEEMlaLN7QE3U1DElLW5YDY7QAHGE0h4Aup0QVZRA06tRehOA5TxyWAhBoQpuDCFfIlDq9O58gve7BzGYhQLjBdAlkegAB9eBG+3g0IAjU0EkyrAEwECEcSWU8FFdbnfw/0AAs0w44/AI6gAAAAASUVORK5CYII=";
        string _s = "<script>s();</script>";

        #endregion

        public fMain()
        {
            InitializeComponent();
            #region Events
            TheWatcher.Created += watcher_created;
            TheWatcher.Changed += watcher_changed;
            TheWatcher.Deleted += watcher_deleted;
            TheWatcher.Error += watcher_buffer_overflow;
            TheWatcher.Renamed += watcher_renamed;
            watcherLog.DocumentTitleChanged += scroll_window_ev;
            TickTock.Tick += bgTick;
            #endregion

            #region init
            TheWatcher.Filter = ScanFileFilter;
            TheWatcher.IncludeSubdirectories = true;
            TheWatcher.Path = WatchDir;
            TheWatcher.EnableRaisingEvents = true;
            TickTock.Interval = 200; // 5 times per second is fine - small CPU usage
            TickTock.Start();
            #endregion
        }

        private void bgTick(object sender, EventArgs e)
        {
            if (option_countproc.Checked)
            {
                bgThread = new Thread(new ThreadStart(UpdProcessCount));
                // run new thread only when it's not running anymore (threads are not synchronized)
                if (!bgThread.IsAlive)
                {
                    bgThread.Start();
                }
                bottom_count_proc.Visible = true;
            }
            else
            {
                bottom_count_proc.Visible = false;
            }

            //options
            // "real time" switching :P
            switch (option_watchdir.SelectedIndex)
            {
                case 0:
                    WatchDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                    break;
                case 1:
                    WatchDir = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    break;
                case 2:
                    WatchDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    break;
                case 3:
                    WatchDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                    break;
                case 4:
                    WatchDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                    break;
                default:
                    WatchDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                    break;
            }

            if (TheWatcher.Path != WatchDir)
            {
                TheWatcher.Path = WatchDir;
            }
            this.Text = $"WinWatcher - {_count_global} changes in {WatchDir} [recursive:{option_recursive.Checked}]";
        }

        private void watcher_renamed(object sender, RenamedEventArgs e)
        {
            InvokeMessage(Actions.Rename, e.FullPath, e, string.Empty);
        }

        private void watcher_buffer_overflow(object sender, ErrorEventArgs e)
        {
            MessageBox.Show($"ERROR: Buffer Overflow !{Environment.NewLine}Restart application and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (option_logfile.Checked)
            {
                LogFile.AddEntry("\t » ERROR: Buffer Overflow!", true);
            }
        }

        private void watcher_deleted(object sender, FileSystemEventArgs e)
        {
            InvokeMessage(Actions.Delete, e.FullPath, e, string.Empty);
        }

        private void watcher_changed(object sender, FileSystemEventArgs e)
        {
            InvokeMessage(Actions.Change, e.FullPath, e, $"{e.ChangeType}");
        }

        private void watcher_created(object sender, FileSystemEventArgs e)
        {
            InvokeMessage(Actions.Create, e.FullPath, e, string.Empty);
        }

        private void bottom_show_options_CheckedChanged(object sender, EventArgs e)
        {
            _optionPanel.Visible = bottom_show_options.Checked;
        }

        private void option_recursive_CheckedChanged(object sender, EventArgs e)
        {
            TheWatcher.IncludeSubdirectories = option_recursive.Checked;
        }

        private void option_scroll_CheckedChanged(object sender, EventArgs e)
        {
            if (option_scroll.Checked)
            {
                _s = "<script>s();</script>";
            }
            else
            {
                _s = string.Empty;
            }
        }

        private void option_logfile_CheckedChanged(object sender, EventArgs e)
        {
            if (option_logfile.Checked)
            {
                if (!NewLog())
                {
                    option_logfile.Checked = false;
                }
            }
        }

        private void scroll_window_ev(object sender, EventArgs e)
        {
            //watcherLog.Document.Window.ScrollTo(0, watcherLog.Document.Window.Size.Height); // this ain't working, using js
            bottom_count_create.Text = $"Files created: {_count_create}. ";
            bottom_count_del.Text = $"Files deleted: {_count_del}. ";
            bottom_count_mod.Text = $"File modifications: {_count_mod}. ";
            bottom_count_ren.Text = $"Files reanmed: {_count_ren} times. ";
        }

        #region Send message to log window from other thread
        /// <summary>
        /// Output message creation
        /// </summary>
        /// <param name="action">output type</param>
        /// <param name="file">output file</param>
        /// <param name="args">args</param>
        /// <param name="msg">additional text (html tags on)</param>
        private void InvokeMessage(Actions action, string file, FileSystemEventArgs args, string msg)
        {
            string _act = string.Empty;
            string _fileMsg = string.Empty;
            
            FileInfo _fi = new FileInfo(file);
            _count_global++;

            switch (action)
            {
                case Actions.Delete:
                    _act = "deleted";
                    _fileMsg = $"{file} was deleted (exist:{_fi.Exists})";
                    _count_del++;
                    break;
                case Actions.Rename:
                    _fileMsg = $"{file} was renamed";
                    _act = "renamed";
                    _count_ren++;
                    break;
                case Actions.Err:
                    _fileMsg = string.Empty;
                    _act = $"<img src=\"{error_ico}\" align=absmiddle /> ERROR BO! ";
                    break;
                case Actions.Create:
                    try { _fileMsg = $"{file} was created < size={_fi.Length * 1024} kilobytes; attributes={_fi.Attributes} >"; } catch(Exception ex)
                    {
                        _fileMsg = $"{file} was created | Ex:{ex.Message}";
                    }
                    _act = "created";
                    _count_create++;
                    break;
                case Actions.Change:
                    try { _fileMsg = $"{file} was changed"; } catch { }
                    _act = "changed";
                    _count_mod++;
                    break;
                default:
                    _fileMsg = string.Empty;
                    _act = "[unknown]";
                    break;
            }

            try
            {
                //some mess
                this.Invoke((Action)delegate
                {
                    watcherLog.Document.Write($"[{TimeStamp()}]&nbsp;<img src=\"{warrning_ico}\" align=absmiddle /> <b><i>{_fileMsg}</i></b> &nbsp; {args.ChangeType} &nbsp; {msg}<br/>{_s}");
                    if (option_logfile.Checked)
                    {
                        LogFile.AddEntry($"{_fileMsg}\t {args.ChangeType}\t {msg}{(option_countproc.Checked?"\t [proc count: "+_count_proc()+"]":string.Empty)}");
                    }
                    watcherLog.Document.Title = _count_global.ToString();
                });
            }
            catch{}
        }
        #endregion

        #region Update number of active processes
        internal void  UpdProcessCount()
        {
            try
            {
                Process[] _proclst = Process.GetProcesses();
                this.Invoke((Action)delegate
                { bottom_count_proc.Text = $"There are {_proclst.Length} running processes."; });
            }
            catch (Exception ex) {
                if (option_logfile.Checked)
                {
                    LogFile.AddEntry($"\t » ERROR ex: {ex.Message}.");
                }
            }
        }

        private string _count_proc()
        {
            Process[] _proclst = Process.GetProcesses();
            return _proclst.Length.ToString();
        }
        #endregion

        private void fMain_Load(object sender, EventArgs e)
        {
            bottom_show_options.Checked = false;
            watcherLog.Document.Write("<script>function s(){window.scrollTo(0,document.body.scrollHeight);}</script><pre style=\"font-size:11px\">");
            option_watchdir.SelectedIndex = 0;
        }
    }
}
