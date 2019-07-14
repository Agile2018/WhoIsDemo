﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsDemo.repository
{
    class Disk
    {
        #region methods
        public Disk() { }

        public string ReadTextFile(string strPath)
        {
            StreamReader objStream;
            string strReturn = string.Empty;

            try
            {
                if (File.Exists(strPath))
                {
                    objStream = new StreamReader(strPath, Encoding.Default);
                    strReturn = objStream.ReadToEnd();
                    objStream.Close();
                }

            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new FileNotFoundException("Read File", e);

            }
            return strReturn;
        }

        public void FileDelete(string strPath)
        {
            try
            {
                if (File.Exists(strPath))
                {
                    File.Delete(strPath);
                }

            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new FileNotFoundException("Delete File", e);

            }
        }

        #endregion
    }
}
