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
        private static readonly HearUser instance = new HearUser();
        public static HearUser Instance => instance;
        #endregion

        #region methods
        public HearUser()
        {
            this.aipuObserver = AipuFace.Instance.GetObserver();
            this.aipuObserver.OnUser += new AipuObserver
                .UserJsonDelegate(SendUser);
        }

        private void SendUser(string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
                Console.WriteLine("WHOIS USER: " + user);
                subjectUser.OnNext(user);
            }
        }

        #endregion
    }
}
