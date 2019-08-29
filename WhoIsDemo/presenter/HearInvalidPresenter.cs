using System;
using System.Reactive.Subjects;
using WhoIsDemo.domain.interactor;

namespace WhoIsDemo.presenter
{
    class HearInvalidPresenter
    {
        #region variables        
        IDisposable subscriptionInvalidMessage;
        
        public Subject<string> subjectError = new Subject<string>();
        private static readonly HearInvalidPresenter instance = new HearInvalidPresenter();
        public static HearInvalidPresenter Instance => instance;
        #endregion

        #region methods      
        public HearInvalidPresenter()
        {            
            SubscriptionReactive();
        }

        private void SubscriptionReactive()
        {
            subscriptionInvalidMessage = HearInvalid.Instance.subjectError.Subscribe(
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
