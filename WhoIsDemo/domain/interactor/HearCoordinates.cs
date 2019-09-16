using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class HearCoordinates
    {
        #region variables
        private readonly AipuObserver aipuObserver;
        public Subject<float[]> subjectCoordinates = new Subject<float[]>();
        private static readonly HearCoordinates instance = new HearCoordinates();
        public static HearCoordinates Instance => instance;
        #endregion

        #region methods

        public HearCoordinates()
        {
            this.aipuObserver = AipuFace.Instance.GetObserver();
            this.aipuObserver.OnCoordinates += new AipuObserver
                .CoordinatesDelegate(SendCoordinates);
        }

        private void SendCoordinates(float[] coordinateFlow)
        {
            if (coordinateFlow != null)
            {
                subjectCoordinates.OnNext(coordinateFlow);
            }
        }

        #endregion
    }
}
