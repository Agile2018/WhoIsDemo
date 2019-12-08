using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WhoIsDemo.repository
{
    public enum RegistryHive
    {
        Wow64,
        Wow6432
    }

    class RegistryValueDataReader
    {
        #region constants
        public const string PATH_KEY = "SOFTWARE\\ASS\\WhoIs";
        public const string NAME_KEY_DATABASE = "Database";
        public const string INTEGRATED_SECURITY_KEY = "Integrated_Security";
        public const string PASSWORD_KEY = "Password";
        public const string SERVER_NAME_KEY = "ServerName";
        public const string USER_KEY = "User";
        public const string PORT_KEY1 = "Port1";
        public const string PORT_KEY2 = "Port2";
        public const string PORT_KEY3 = "Port3";
        public const string PORT_KEY4 = "Port4";
        public const string URL_SERVER_KEY = "Urlserver";
        public const string LEVEL_RESOLUTION = "Level_Resolution";
        public const string REFRESH_ENTRY_CONTROL = "Refresh_Entry_Control";
        public const string IP_CAMERA_KEY = "IPCamera";
        public const string TITLE_PRINT_KEY = "title_print";
        public const string BUILDING_KEY = "building";
        public const string DIRECTORY_KEY = "directory";
        public const string MAXEYE_KEY = "max_eye";
        public const string MINEYE_KEY = "min_eye";
        public const string REFRESH_INTERVAL_KEY = "refresh_interval";
        public const string CONFIDENCE_KEY = "confidence";
        public const string DEEPTRACK_KEY = "deep_track";
        public const string TRACKMODE_KEY = "mode_track";
        public const string TRACKSPEED_KEY = "speed_track";
        public const string TRACKMOTION_KEY = "motion_track";

        private static readonly int KEY_WOW64_32KEY = 0x200;
        private static readonly int KEY_WOW64_64KEY = 0x100;
        private static readonly UIntPtr HKEY_LOCAL_MACHINE = (UIntPtr)0x80000002;
        private static readonly int KEY_QUERY_VALUE = 0x1;
        #endregion

        #region methods
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyEx")]
        static extern int RegOpenKeyEx(
             UIntPtr hKey,
             string subKey,
             uint options,
             int sam,
             out IntPtr phkResult);


        [DllImport("advapi32.dll", SetLastError = true)]
        static extern int RegQueryValueEx(
                    IntPtr hKey,
                    string lpValueName,
                    int lpReserved,
                    out uint lpType,
                    IntPtr lpData,
                    ref uint lpcbData);

        private static int GetRegistryHiveKey(RegistryHive registryHive)
        {
            return registryHive == RegistryHive.Wow64 ? KEY_WOW64_64KEY :
                KEY_WOW64_32KEY;
        }

        private static UIntPtr GetRegistryKeyUIntPtr(RegistryKey registry)
        {
            if (registry == Registry.LocalMachine)
            {
                return HKEY_LOCAL_MACHINE;
            }

            return UIntPtr.Zero;
        }

        public string[] ReadRegistryValueData(RegistryHive registryHive,
            RegistryKey registryKey, string subKey, string valueName)
        {
            string[] instanceNames = new string[0];

            int key = GetRegistryHiveKey(registryHive);
            UIntPtr registryKeyUIntPtr = GetRegistryKeyUIntPtr(registryKey);

            IntPtr hResult;

            int res = RegOpenKeyEx(registryKeyUIntPtr, subKey, 0,
                KEY_QUERY_VALUE | key, out hResult);

            if (res == 0)
            {
                uint type;
                uint dataLen = 0;

                RegQueryValueEx(hResult, valueName, 0, out type,
                    IntPtr.Zero, ref dataLen);

                byte[] databuff = new byte[dataLen];
                byte[] temp = new byte[dataLen];

                List<String> values = new List<string>();

                GCHandle handle = GCHandle.Alloc(databuff, GCHandleType.Pinned);
                try
                {
                    RegQueryValueEx(hResult, valueName, 0, out type,
                        handle.AddrOfPinnedObject(), ref dataLen);
                }
                finally
                {
                    handle.Free();
                }

                int i = 0;
                int j = 0;

                while (i < databuff.Length)
                {
                    if (databuff[i] == '\0')
                    {
                        j = 0;
                        string str = Encoding.Default.GetString(temp).Trim('\0');

                        if (!string.IsNullOrEmpty(str))
                        {
                            values.Add(str);
                        }

                        temp = new byte[dataLen];
                    }
                    else
                    {
                        temp[j++] = databuff[i];
                    }

                    ++i;
                }

                instanceNames = new string[values.Count];
                values.CopyTo(instanceNames);
            }

            return instanceNames;
        }

        public void setKeyValueRegistry(string strNameSubKey,
         string strNameKey, object objValue)
        {

            try
            {
                RegistryKey regSet = Registry.CurrentUser.CreateSubKey(strNameSubKey);
                regSet.SetValue(strNameKey, objValue);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
        }

        public string getKeyValueRegistry(string strNameSubKey,
         string strNameKey)
        {
            string strValueKey = string.Empty;

            RegistryKey regSet = Registry.CurrentUser.CreateSubKey(strNameSubKey);
            if (regSet != null)
            {
                try
                {
                    strValueKey = (string)regSet.GetValue(strNameKey);
                    if (strValueKey == null)
                        strValueKey = string.Empty;
                }
                catch (System.UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return strValueKey;
        }
        #endregion
    }
}
