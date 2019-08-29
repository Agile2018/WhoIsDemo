using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsDemo.model
{
    public class Configuration
    {
        #region variables
        private static readonly Configuration instance = new Configuration();
        public static Configuration Instance => instance;

        internal List<Video> ListVideo { get => listVideo; set => listVideo = value; }
        public string VideoDefault { get => videoDefault; set => videoDefault = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        private List<Video> listVideo = new List<Video>();
        private string videoDefault;
        private int width = 320;
        private int height = 240;

        #endregion

        #region constants

        #endregion

        #region methods
        public Configuration() { }
        #endregion

    }
}
