using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WhoIsDemo.domain.interactor;

namespace WhoIsDemo.presenter
{
    class HearFramePresenter
    {
        #region variables
        HearFrame hearFrame;
        IDisposable subscriptionFrame;
        public Subject<Bitmap> subjectFrame = new Subject<Bitmap>();
        #endregion

        #region methods
        public HearFramePresenter(int indexVideo)
        {
            hearFrame = new HearFrame(indexVideo);
            SubscriptionReactive();
        }

        private void SubscriptionReactive()
        {
            subscriptionFrame = hearFrame.subjectFrame.Subscribe(
                frame => LaunchFrame(frame),
                () => Console.WriteLine("Operation Completed."));
        }

        private void LaunchFrame(Bitmap frame)
        {
            subjectFrame.OnNext(frame);
        }
        #endregion
    }
}
