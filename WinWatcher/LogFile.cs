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
using System.IO;
using static WinWatcher.OptVars;

namespace WinWatcher
{
    internal static class LogFile
    {
        private static string _LogFILE = null;
        internal static string LogFILE
        {
            get { return _LogFILE; }
            set { _LogFILE = value; }
        }

        internal static bool NewLog()
        {
            bool isOK = false;
            DateTime _dt = DateTime.Now;
            try
            {
                if (!Directory.Exists(WorkingDir))
                {
                    Directory.CreateDirectory(WorkingDir);
                }

                LogFILE = string.Format("log-{0}{1}{2}.{3}{4}{5}.log", _dt.Year.ToString("0000"), _dt.Month.ToString("00"), _dt.Day.ToString("00"),
                                                                                    _dt.Hour.ToString("00"), _dt.Minute.ToString("00"), _dt.Second.ToString("00"));

                string LogMSG = $"{TimeStamp()} {Environment.NewLine}\tLog file created...{Environment.NewLine}\t{Environment.UserName} on {Environment.MachineName}, {Environment.OSVersion}.{Environment.NewLine}{sep}{Environment.NewLine}";

                using (FileStream fs = new FileStream($"{WorkingDir}\\{LogFILE}", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(LogMSG);
                    sw.Close();
                }
                isOK = true;
            }
            catch (Exception ex)
            {
                isOK = false;
                System.Windows.Forms.MessageBox.Show($"Error creating log file.{Environment.NewLine}Ex:{ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return isOK;
        }

        public static bool AddEntry(string msg, bool nl = false)
        {
            bool isOK = false;
            string newL = null;

            if (nl)
            {
                newL = Environment.NewLine;
            }
            else
            {
                newL = null;
            }

            try
            {
                if (LogFILE == null)
                {
                    // file dosn't exist, create new one
                    NewLog();
                }
                // add entry
                string LogMSG = string.Format("{2}{0} - {1}", TimeStamp(), msg, newL);
                Console.WriteLine("{2}{0} - {1}", TimeStamp(), msg, newL);
                using (FileStream fs = new FileStream($"{WorkingDir}\\{LogFILE}", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(LogMSG);
                    sw.Close();
                }
                isOK = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error writing log file.{Environment.NewLine}Ex:{ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                isOK = false;
            }
            return isOK;
        }

    }
}
