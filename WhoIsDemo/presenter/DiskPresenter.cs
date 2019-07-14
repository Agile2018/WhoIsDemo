using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.repository;

namespace WhoIsDemo.presenter
{
    class DiskPresenter
    {
        #region constants

        #endregion

        #region variables
        Disk disk = new Disk(); 
        #endregion

        #region methods
        public DiskPresenter() { }

        public void FileDelete(string stringPath)
        {
            try
            {
                disk.FileDelete(stringPath);

            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);

            }
        }
        #endregion
    }
}
