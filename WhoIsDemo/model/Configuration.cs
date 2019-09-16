using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsDemo.model
{
    public class Configuration
    {
        #region constants
        public const int templateHeight = 360;
        public const int templateWidth = 640;
        #endregion
        #region variables
        private static readonly Configuration instance = new Configuration();
        public static Configuration Instance => instance;

        internal List<Video> ListVideo { get => listVideo; set => listVideo = value; }
        public string VideoDefault { get => videoDefault; set => videoDefault = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int ResolutionWidthDefault { get => resolutionWidthDefault; set => resolutionWidthDefault = value; }
        public int ResolutionHeightDefault { get => resolutionHeightDefault; set => resolutionHeightDefault = value; }
        public int AreaDefault { get => areaDefault;}
        public int MaximumResolutionAccepted { get => maximumResolutionAccepted; }
        public List<int> ListWidthResolution { get => listWidthResolution; set => listWidthResolution = value; }
        public List<int> ListHeightResolution { get => listHeightResolution; set => listHeightResolution = value; }
        public int WidthReal { get => widthReal; set => widthReal = value; }
        public int HeightReal { get => heightReal; set => heightReal = value; }
        public string ConnectDatabase { get => connectDatabase; set => connectDatabase = value; }
        public string NameDatabase { get => nameDatabase; set => nameDatabase = value; }
        public float FactorScalingHeightText { get => factorScalingHeightText; set => factorScalingHeightText = value; }
        public float FactorScalingWidthText { get => factorScalingWidthText; set => factorScalingWidthText = value; }
        public int CoordinatesXText { get => coordinatesXText; set => coordinatesXText = value; }
        public int CoordinatesYText { get => coordinatesYText; set => coordinatesYText = value; }

        private List<Video> listVideo = new List<Video>();
        private List<int> listHeightResolution = new List<int>();
        private List<int> listWidthResolution = new List<int>();
        private string videoDefault;
        private int width = 320;
        private int height = 240;
        private int resolutionWidthDefault = 640;
        private int resolutionHeightDefault = 480;
        private int areaDefault = 640 * 480;
        private int maximumResolutionAccepted = 1280;
        private int widthReal = 640;
        private int heightReal = 480;
        private string connectDatabase;
        private string nameDatabase;
        private float factorScalingHeightText = 1;
        private float factorScalingWidthText = 1;
        private int coordinatesXText = 450;
        private int coordinatesYText = 40;
        #endregion

        #region constants

        #endregion

        #region methods
        public Configuration()
        {
            ListWidthResolution.Add(640);
            ListHeightResolution.Add(480);
            ListWidthResolution.Add(800);
            ListHeightResolution.Add(450);
            ListWidthResolution.Add(1280);
            ListHeightResolution.Add(720);
        }

        public void CalculeArea()
        {
            areaDefault = resolutionWidthDefault * resolutionHeightDefault;
        }


        #endregion

    }
}
