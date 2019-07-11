using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;

namespace WhoIsDemo.presenter
{
    class HearInvalidPresenter
    {
        #region variables
        HearInvalid hearInvalid;
        IDisposable subscriptionInvalidMessage;
        public Subject<string> subjectError = new Subject<string>();
        #endregion

        #region methods
        public HearInvalidPresenter() { }
        public HearInvalidPresenter(int indexVideo)
        {
            hearInvalid = new HearInvalid(indexVideo);
            SubscriptionReactive();
        }

        private void SubscriptionReactive()
        {
            subscriptionInvalidMessage = hearInvalid.subjectError.Subscribe(
                msg => LaunchMessage(msg),
                () => Console.WriteLine("Operation Completed."));
        }

        private void LaunchMessage(string message)
        {
            subjectError.OnNext(message);
        }

        #endregion
    }
}
