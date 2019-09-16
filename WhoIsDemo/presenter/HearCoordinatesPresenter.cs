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
    class HearCoordinatesPresenter
    {
        #region variables        
        IDisposable subscriptionCoordinates;
        int idVideo = 0;

        public Subject<float[]> subjectCoordinates = new Subject<float[]>();

        public int IdVideo { get => idVideo; set => idVideo = value; }

        #endregion

        #region methods

        public HearCoordinatesPresenter()
        {
            SubscriptionReactive();
        }

        private void SubscriptionReactive()
        {
            subscriptionCoordinates = HearCoordinates.Instance.subjectCoordinates.Subscribe(
                coor => LaunchCoordinates(coor),
                () => Console.WriteLine("Operation Completed."));
        }

        private void LaunchCoordinates(float[] coordinateFlow)
        {
            subjectCoordinates.OnNext(coordinateFlow);
        }

        public void EnabledCoordinates(bool option)
        {
            if (AipuFace.Instance.IsLoadConfiguration)
            {
                if (!RequestAipu.Instance.IsObserverCoordinates() && option)
                {
                    RequestAipu.Instance.EnableObserverCoordinates(option);
                }
                else if (RequestAipu.Instance.IsObserverCoordinates() && !option)
                {
                    RequestAipu.Instance.EnableObserverCoordinates(option);
                }
                
            }
        }



        #endregion
    }
}
