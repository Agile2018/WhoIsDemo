using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class DefineParamsVideo
    {
        #region variables
        private int indexVideo;
        #endregion

        #region methods
        public DefineParamsVideo(int index)
        {
            indexVideo = index;
        }

        public void DefineLapseRead(int lapse)
        {
            HeapAipuVideo.Instance.LapseReadImage(indexVideo, lapse);
        }

        public void IndexWriteImage(int index)
        {
            HeapAipuVideo.Instance.IndexWriteImage(indexVideo, index);
        }

        public void RemoveVideo()
        {
            HeapAipuVideo.Instance.RemoveVideo(indexVideo);
        }
        #endregion
    }
}
