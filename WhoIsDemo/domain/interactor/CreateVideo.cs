using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    public class CreateVideo
    {
        #region variables
        int indexVideo;
        public delegate void IndexVideoDelegate(int index);
        public event IndexVideoDelegate OnNewIndex;
        public int IndexVideo {
            get
            {
                return indexVideo;
            }

            set
            {
                indexVideo = value;
                OnNewIndex(indexVideo);
            }
        }

        #endregion

        #region methods

        public CreateVideo()
        {

        }
        public void ExecuteCreate()
        {
            IndexVideo = HeapAipuVideo.Instance.CreateFlowVideo();


        }
        #endregion
    }
}
