using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;

namespace WhoIsDemo.presenter
{
    class CreateVideoPresenter
    {
        #region variables
        CreateVideo createVideo = new CreateVideo();
        public Subject<int> subjectIndex = new Subject<int>();
        #endregion

        #region methods

        public CreateVideoPresenter()
        {
            this.createVideo.OnNewIndex += new CreateVideo.IndexVideoDelegate(SendIndex);
                
        }

        private void SendIndex(int index)
        {
            subjectIndex.OnNext(index);
        }

        public void ExecuteCreate()
        {
            createVideo.ExecuteCreate();
        }

        #endregion
    }
}
