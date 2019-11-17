using System.Reactive.Subjects;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class HearInvalid
    {
        #region variables
        private readonly AipuObserver aipuObserver;
        public Subject<string> subjectError = new Subject<string>();
        private static readonly HearInvalid instance = new HearInvalid();
        public static HearInvalid Instance => instance;
        #endregion

        #region methods
        public HearInvalid()
        {
            this.aipuObserver = AipuFace.Instance.GetObserver();
            this.aipuObserver.OnError += new AipuObserver
                .MessageErrorDelegate(SendError);
        }

        private void SendError(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                subjectError.OnNext(error);
            }
        }

        #endregion
    }
}
