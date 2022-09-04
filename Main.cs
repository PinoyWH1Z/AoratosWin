using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AoratosWin
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        int actedDirsCount = 0;
        int actedFilesCount = 0;
        int actedRegsCount = 0;
        int actedDirsCount_recheck = 0;
        int actedFilesCount_recheck = 0;
        int actedRegsCount_recheck = 0;

        private string getCurrentSID()
        {
            string MySIDs = "";

            try
            {
                Process p = new Process();

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = @"/c whoami /user";

                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                var rx = new Regex(@"S-1-[0-59]-\d{2}-\d{8,10}-\d{8,10}-\d{8,10}-[1-9]\d{3}");
                var matches = rx.Matches(output);

                foreach (Match match in matches)
                {
                    MySIDs = match.ToString();
                }
            }
            catch {
                
            }

            return MySIDs;
        }

        private void cleanTempPrefetchEtc(string DIR)
        {
            foreach (string subDirectory in Directory.GetDirectories(DIR))
            {
                try
                {
                    actedDirsCount += 1;
                    Directory.Delete(subDirectory, true);
                }
                catch
                {
                }
            }

            foreach (string tempfile in Directory.GetFiles(DIR, "*.*", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    actedFilesCount += 1;
                    System.IO.File.Delete(tempfile);
                }
                catch
                {
                    //MessageBox.Show("error on " + tempfile);
                }
            }

        }

        private void cleanTempPrefetchEtc_recheck(string DIR)
        {
            foreach (string subDirectory in Directory.GetDirectories(DIR))
            {
                try
                {
                    actedDirsCount_recheck += 1;
                }
                catch
                {
                }
            }

            foreach (string tempfile in Directory.GetFiles(DIR, "*.*", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    actedFilesCount_recheck += 1;
                }
                catch
                {
                }
            }

        }

        private void removeRegTrace()
        {

            //REMOVE ROOT MUI CACHE
            try
            {
                const string REGISTRY_ROOT = @"Local Settings\Software\Microsoft\Windows\Shell\MuiCache\";
                using (RegistryKey rootKey = Registry.ClassesRoot.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount += 1;
                            rootKey.DeleteValue(currSubKey);
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }

            //REMOVE CURRENT USER MUI CACHE
            try
            {
                const string REGISTRY_ROOT = @"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache\";
                using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount += 1;
                            rootKey.DeleteValue(currSubKey);
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }

            //REMOVE USER MUI CACHE
            try
            {
                string REGISTRY_ROOT = getCurrentSID() + "\\" + @"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache\";
                using (RegistryKey rootKey = Registry.Users.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount += 1;
                            rootKey.DeleteValue(currSubKey);
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }

            //REMOVE IN CURRENT USER COMPAT STORE
            try
            {
                const string REGISTRY_ROOT = @"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store\";
                using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount += 1;
                            rootKey.DeleteValue(currSubKey);
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }

            //REMOVE USER COMPAT STORE
            try
            {
                string REGISTRY_ROOT = getCurrentSID() + "\\" + @"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store\";
                using (RegistryKey rootKey = Registry.Users.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount += 1;
                            rootKey.DeleteValue(currSubKey);
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }
        }
        private void removeRegTrace_recheck()
        {

            //REMOVE ROOT MUI CACHE
            try
            {
                const string REGISTRY_ROOT = @"Local Settings\Software\Microsoft\Windows\Shell\MuiCache\";
                using (RegistryKey rootKey = Registry.ClassesRoot.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount_recheck += 1;
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }

            //REMOVE CURRENT USER MUI CACHE
            try
            {
                const string REGISTRY_ROOT = @"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache\";
                using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount_recheck += 1;
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }

            //REMOVE USER MUI CACHE
            try
            {
                string REGISTRY_ROOT = getCurrentSID() + "\\" + @"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache\";
                using (RegistryKey rootKey = Registry.Users.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount_recheck += 1;
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }

            //REMOVE IN CURRENT USER COMPAT STORE
            try
            {
                const string REGISTRY_ROOT = @"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store\";
                using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount_recheck += 1;
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }

            //REMOVE USER COMPAT STORE
            try
            {
                string REGISTRY_ROOT = getCurrentSID() + "\\" + @"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store\";
                using (RegistryKey rootKey = Registry.Users.OpenSubKey(REGISTRY_ROOT, true))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string currSubKey in valueNames)
                        {
                            actedRegsCount_recheck += 1;
                        }
                        rootKey.Close();
                    }

                }
            }
            catch { }
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void btn_Commence_Click(object sender, EventArgs e)
        {

            //REMOVE TRACES IN REGISTRY
            removeRegTrace();
            removeRegTrace_recheck();

            //REMOVE TRACES IN TEMP AND PREFETCH
            string folderPath = "";

            string[] targetDirs = {
                "%systemdrive%\\Windows\\Temp",
                "%userprofile%\\AppData\\Local\\Temp",
                "%systemdrive%\\Windows\\prefetch"
            };

            foreach (string i in targetDirs)
            {
                try
                {
                    folderPath = Environment.ExpandEnvironmentVariables(i);
                    cleanTempPrefetchEtc(folderPath);
                }
                catch { }
            }

            foreach (string i in targetDirs)
            {
                try
                {
                    folderPath = Environment.ExpandEnvironmentVariables(i);
                    cleanTempPrefetchEtc_recheck(folderPath);
                }
                catch { }
            }

            double total_acted = actedDirsCount + actedFilesCount + actedRegsCount;
            double total_recheck = actedDirsCount_recheck + actedFilesCount_recheck + actedRegsCount_recheck;
            double covered = (total_recheck / total_acted) * 100;
            string strCovered = covered.ToString("0.00");

            MessageBox.Show("Concluded. [ Removed " + strCovered + "% ]", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //reset
            actedDirsCount = 0;
            actedFilesCount = 0;
            actedRegsCount = 0;
            actedDirsCount_recheck = 0;
            actedFilesCount_recheck = 0;
            actedRegsCount_recheck = 0;
        }

        private void lbl_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AoratosWin is a tool that removes traces of executed applications on Windows OS \nwhich can easily be listed with tools such as ExecutedProgramList by Nirsoft.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!IsAdministrator())
                MessageBox.Show("You did not run this tool as Admin, which means the removal of some system-level logs is unfeasible.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
