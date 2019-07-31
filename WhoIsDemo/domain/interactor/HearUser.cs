using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class HearUser
    {
        #region variables
        private readonly AipuObserver aipuObserver;
        public Subject<string> subjectUser = new Subject<string>();

        #endregion

        #region methods
        public HearUser(int indexVideo)
        {
            this.aipuObserver = HeapAipuVideo
                .Instance.GetObserver(indexVideo);
            this.aipuObserver.OnUser += new AipuObserver
                .UserJsonDelegate(SendUser);

        }

        private void SendUser(string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
                
                subjectUser.OnNext(user);
            }
        }

        #endregion
    }
}
