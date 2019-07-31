using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;

namespace WhoIsDemo.presenter
{
    class HearUserPresenter
    {
        #region variables
        HearUser hearUser;
        IDisposable subscriptionUser;
        
        public Subject<Person> subjectUser = new Subject<Person>();

        #endregion

        #region methods
        public HearUserPresenter()
        {

        }
        public HearUserPresenter(int indexVideo)
        {
            hearUser = new HearUser(indexVideo);
            SubscriptionReactive();
        }

        private void SubscriptionReactive()
        {
            subscriptionUser = hearUser.subjectUser.Subscribe(
                usr => LaunchUser(usr), 
                () => Console.WriteLine("Operation Completed."));
        }

        private void LaunchUser(string user)
        {
            Person person;
            try
            {
                
                person = JsonConvert.DeserializeObject<Person>(user);                
                subjectUser.OnNext(person);
               

            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
