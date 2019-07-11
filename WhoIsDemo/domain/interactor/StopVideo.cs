using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class StopVideo
    {
        #region variables

        #endregion

        #region methods
        public StopVideo(int indexVideo)
        {
            HeapAipuVideo.Instance.StopVideo(indexVideo);
        }
        #endregion
    }
}
