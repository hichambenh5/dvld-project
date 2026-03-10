using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using DVLD_Buisness;


namespace DVLD.Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";
            string usernameandpassord = Username + "#||#" + Password;
            string valueName = "usernameandpassord";
            try
            {
                Registry.SetValue(keyPath,valueName,usernameandpassord , RegistryValueKind.String);
                return true;
            }
            catch 
            {
                
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";
            string valueName = "usernameandpassord";
            try
            {
                string line = Registry.GetValue(keyPath, valueName,null) as string;
                if (line != null)
                {
                    string[] valueData = line.Split(new string[] { "#||#" }, StringSplitOptions.None);
                    if (valueData.Length == 2)
                    {
                        Username = valueData[0];
                        Password = valueData[1];
                        return true;
                    }
                }
                else
                    return false;
            }
            catch
            {
                
                return false;
            }
            return false;
        }
    }
}
