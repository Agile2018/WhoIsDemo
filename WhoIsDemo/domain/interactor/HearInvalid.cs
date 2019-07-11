using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class HearInvalid
    {
        #region variables
        private readonly AipuObserver aipuObserver;
        public Subject<string> subjectError = new Subject<string>();
        #endregion

        #region methods
        public HearInvalid(int indexVideo)
        {            
            this.aipuObserver = HeapAipuVideo
                .Instance.GetObserver(indexVideo);
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
