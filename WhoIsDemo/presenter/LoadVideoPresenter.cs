using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;

namespace WhoIsDemo.presenter
{
    class LoadVideoPresenter
    {
        #region variables
        private int indexVideo;
        private string nameFile;
        private bool isRunVideo = false;
        LoadVideo loadVideo;       
        DefineParamsVideo paramsVideo;
        #endregion

        #region methods
        public LoadVideoPresenter()
        {

        }

        public int IndexVideo {
            get
            {
                return indexVideo;
            }

            set
            {
                indexVideo = value;
                paramsVideo = new DefineParamsVideo(indexVideo);
            }
            
        }
        public string NameFile { get => nameFile; set => nameFile = value; }
        public bool IsRunVideo { get => isRunVideo; set => isRunVideo = value; }

        public void ExecuteLoadVideo()
        {
            loadVideo = new LoadVideo(IndexVideo, NameFile);
            IsRunVideo = true;
        }                

        public void RemoveVideo()
        {
            paramsVideo.RemoveVideo();
        }

        public void WorkMode(int mode)
        {
            paramsVideo.WorkMode(mode);
        }

        public void SendFrame(byte[] data, int rows, int cols)
        {
            paramsVideo.SendFrame(data, rows, cols);
        }
        #endregion
    }
}
