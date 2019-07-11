using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class HearFrame
    {
        #region variables
        private readonly AipuObserver aipuObserver;
        public Subject<Bitmap> subjectFrame = new Subject<Bitmap>();
        #endregion

        #region methods
        public HearFrame(int indexVideo)
        {
            this.aipuObserver = HeapAipuVideo
               .Instance.GetObserver(indexVideo);
            this.aipuObserver.OnFrame += new AipuObserver
                .FrameDelegate(SendFrame);
        }

        private void SendFrame(Bitmap frame)
        {
            if (frame != null)
            {
                subjectFrame.OnNext(frame);
            }
        }
        #endregion
    }
}
