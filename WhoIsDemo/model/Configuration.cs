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
        public const int templateHeight = 400;
        public const int templateWidth = 640;
        public const float scalingFontSize = 0.4f;
        public const float incrementHeight = 20;
        public const int VIDEO_TYPE_CAMERA = 3;
        public const int VIDEO_TYPE_IP = 1;
        public const int VIDEO_TYPE_FILE = 2;
        public const string DESC_TYPE_CAMERA = "CAM";
        public const string DESC_TYPE_IP = "IP";
        public const string DESC_TYPE_FILE = "FILE";
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
        public float FactorScalingSizeFont { get => factorScalingSizeFont; set => factorScalingSizeFont = value; }
        public float FactorScalingIncrementHeight { get => factorScalingIncrementHeight; set => factorScalingIncrementHeight = value; }
        public List<int> ListTimeRefreshEntryControl { get => listTimeRefreshEntryControl; set => listTimeRefreshEntryControl = value; }
        public int TimeRefreshEntryControl { get => timeRefreshEntryControl; set => timeRefreshEntryControl = value; }
        public int MaxEyeTrack { get => maxEyeTrack; set => maxEyeTrack = value; }
        public int MinEyeTrack { get => minEyeTrack; set => minEyeTrack = value; }
        public int RefreshIntervalTrack { get => refreshIntervalTrack; set => refreshIntervalTrack = value; }
        public int ConfidenceTrack { get => confidenceTrack; set => confidenceTrack = value; }
        public int VideoTypeDefault { get => videoTypeDefault; set => videoTypeDefault = value; }
        public string DeepTrack { get => deepTrack; set => deepTrack = value; }
        public int TrackMode { get => trackMode; set => trackMode = value; }
        public int TrackSpeed { get => trackSpeed; set => trackSpeed = value; }
        public int TrackMotion { get => trackMotion; set => trackMotion = value; }

        private List<Video> listVideo = new List<Video>();
        private List<int> listHeightResolution = new List<int>();
        private List<int> listWidthResolution = new List<int>();
        private List<int> listTimeRefreshEntryControl = new List<int>();
        private int timeRefreshEntryControl = 0; 
        private string videoDefault;
        private int videoTypeDefault;
        private int width = 320;
        private int height = 240;
        private int resolutionWidthDefault = 640;
        private int resolutionHeightDefault = 400;
        private int areaDefault = 640 * 400;
        private int maximumResolutionAccepted = 1920;
        private int widthReal = 640;
        private int heightReal = 400;
        private string connectDatabase;
        private string nameDatabase;
        private float factorScalingHeightText = 1;
        private float factorScalingWidthText = 1;
        private int coordinatesXText = 450;
        private int coordinatesYText = 40;
        private float factorScalingSizeFont = 0.4f;
        private float factorScalingIncrementHeight = 1;
        private int maxEyeTrack = 200;
        private int minEyeTrack = 20;
        private int refreshIntervalTrack = 2000;
        private int confidenceTrack = 450;
        private string deepTrack = "false";
        private int trackMode = 0;
        private int trackSpeed = 0;
        private int trackMotion = 0;

        #endregion

        #region constants

        #endregion

        #region methods
        public Configuration()
        {
            ListWidthResolution.Add(640);
            ListHeightResolution.Add(360);
            ListWidthResolution.Add(800);
            ListHeightResolution.Add(450);
            ListWidthResolution.Add(1280);
            ListHeightResolution.Add(720);
            ListWidthResolution.Add(1584);
            ListHeightResolution.Add(891);
            ListWidthResolution.Add(1920);
            ListHeightResolution.Add(1080);

            ListTimeRefreshEntryControl.Add(0);
            ListTimeRefreshEntryControl.Add(1);
            ListTimeRefreshEntryControl.Add(5);
            ListTimeRefreshEntryControl.Add(10);
            ListTimeRefreshEntryControl.Add(15);
            ListTimeRefreshEntryControl.Add(20);
            ListTimeRefreshEntryControl.Add(25);
            ListTimeRefreshEntryControl.Add(30);

        }

        public void CalculeArea()
        {
            areaDefault = resolutionWidthDefault * resolutionHeightDefault;
        }


        #endregion

    }
}
