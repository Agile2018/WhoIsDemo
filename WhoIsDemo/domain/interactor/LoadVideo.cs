using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class LoadVideo
    {
        #region variables

        #endregion

        #region methods
        public LoadVideo(int indexVideo, string nameFile)
        {
            HeapAipuVideo.Instance.InitLibrary(indexVideo);
            HeapAipuVideo.Instance.LoadConfiguration(indexVideo, nameFile);

        }
        #endregion

    }
}
