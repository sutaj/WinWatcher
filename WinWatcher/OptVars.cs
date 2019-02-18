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

namespace WinWatcher
{
    internal static class OptVars
    {
        #region priv
        private static string watchDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        private static string workingDir = $"{Environment.CurrentDirectory}\\logs";
        private static string scanFileFilter = "*.*";
        private static int count_mod = 0;
        private static int count_global = 0;
        private static int count_create = 0;
        private static int count_del = 0;
        private static int count_ren = 0;
        #endregion

        /// <summary>
        /// Directory to watch
        /// </summary>
        internal static string WatchDir { get => watchDir; set => watchDir = value; }
        internal static string WorkingDir { get => workingDir; }
        internal static string TimeStamp()
        {
            DateTime _date = DateTime.Now;
            return $"{_date.Year}-{_date.Month,2:00}-{_date.Day,2:00} {_date.Hour,2:00}:{_date.Minute,2:00}:{_date.Second,2:00}";
        }
        internal static string sep { get => "----------------------------------------------------------------------------";  }

        internal static int _count_global { get => count_global; set => count_global = value; }
        internal static int _count_create { get => count_create; set => count_create = value; }
        internal static int _count_del { get => count_del; set => count_del = value; }
        internal static int _count_ren { get => count_ren; set => count_ren = value; }
        internal static int _count_mod { get => count_mod; set => count_mod = value; }
        /// <summary>
        /// File type filter to watch. Default "*.*" - for all files
        /// </summary>
        internal static string ScanFileFilter { get => scanFileFilter; set => scanFileFilter = value; }

        #region enum
        internal enum Actions
        {
            Delete,
            Rename,
            Err,
            Create,
            Change
        }

        internal enum Dirs
        {
            Windows,
            System,
            UserDir,
            ProgramFiles,
            ProgramFilesx86
        }
        #endregion

    }
}
