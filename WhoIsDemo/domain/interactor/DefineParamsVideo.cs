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

        public void RemoveVideo()
        {
            HeapAipuVideo.Instance.RemoveVideo(indexVideo);
        }

        public void WorkMode(int mode)
        {
            HeapAipuVideo.Instance.SetWorkMode(indexVideo, mode);
        }

        public void SendFrame(byte[] data, int rows, int cols)
        {
            HeapAipuVideo.Instance.SetFrame(indexVideo, data, rows, cols);
        }
        #endregion
    }
}
