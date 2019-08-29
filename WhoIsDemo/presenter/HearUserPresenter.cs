using Newtonsoft.Json;
using System;
using System.Reactive.Subjects;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;

namespace WhoIsDemo.presenter
{
    class HearUserPresenter
    {
        #region variables        
        IDisposable subscriptionUser;
        int idVideo = 0;

        public Subject<Person> subjectUser = new Subject<Person>();

        public int IdVideo { get => idVideo; set => idVideo = value; }

        #endregion

        #region methods

        public HearUserPresenter()
        {           
            SubscriptionReactive();
        }

        private void SubscriptionReactive()
        {
            subscriptionUser = HearUser.Instance.subjectUser.Subscribe(
                usr => LaunchUser(usr), 
                () => Console.WriteLine("Operation Completed."));
        }

        private void LaunchUser(string user)
        {
            Person person;
            try
            {
                
                person = JsonConvert.DeserializeObject<Person>(user);
                int idVid = Convert.ToInt16(person.Params.Client);
                if (idVid == IdVideo)
                {
                    subjectUser.OnNext(person);
                }
                             
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool EnableObserverUser()
        {
            bool result = false;
            if (AipuFace.Instance.IsLoadConfiguration)
            {
                if (!RequestAipu.Instance.IsEnableObserverUser())
                {
                    RequestAipu.Instance.EnableEarUser();
                }
                result = true;
            }
            return result;
        }

        #endregion
    }
}
