using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class RunVideo
    {
        #region variables

        #endregion

        #region methods
        public RunVideo(int indexVideo)
        {
            HeapAipuVideo.Instance.RunVideo(indexVideo);
        }
        #endregion
    }
}
