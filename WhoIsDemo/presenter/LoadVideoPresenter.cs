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
        RunVideo runVideo;
        StopVideo stopVideo;
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
            
        }

        public void RunVideo()
        {
            runVideo = new RunVideo(IndexVideo);
            IsRunVideo = true;
        }

        public void StopVideo()
        {
            stopVideo = new StopVideo(IndexVideo);
            IsRunVideo = false;
        }

        public void LapseRead(int lapse)
        {
            paramsVideo.DefineLapseRead(lapse);
        }

        public void IndexWriteImage(int index)
        {
            paramsVideo.IndexWriteImage(index);
        }

        public void RemoveVideo()
        {
            paramsVideo.RemoveVideo();
        }

        #endregion
    }
}
