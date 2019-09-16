using Emgu.CV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsDemo.presenter
{
    class QueueMatPresenter
    {
        #region variables
        private Queue queue = new Queue();
        private Mat lastFrame;
        private IObservable<Mat> observableFrame;
        IDisposable subscriptionFrame;
        public delegate void MatFrameDelegate(Mat frame);
        public event MatFrameDelegate OnMatFrame;
        #endregion

        #region methods
        public QueueMatPresenter()
        {

        }

        public void EnabledObserver()
        {
            ObserverMat();
        }

        public Mat LastFrame {
            get
            {
                return lastFrame;
            }

            set
            {
                lastFrame = value;
                OnMatFrame(lastFrame);
                RemoveQueue();
            }
        }

        public void AddMatToQueue(Mat frame)
        {
            if (queue.Count == 10)
            {
                queue.Clear();

            }
            else
            {
                queue.Enqueue(frame);
            }
            //queue.Enqueue(frame);
            //Console.WriteLine("QUEUE INSIDE");
        }

        public void RemoveQueue()
        {
            if (queue.Count != 0)
            {
                queue.Dequeue();
            }
            
        }

        private void ObserverMat()
        {
            observableFrame = Observable.Create<Mat>(async observer =>
            {
                observer.OnNext(await GetMatAsync());

            });
            subscriptionFrame = observableFrame
                .Where(res => res != null)
                .Delay(TimeSpan.FromSeconds(0.03))
                .Repeat()
                .Subscribe(
                    res => LastFrame = res
                );
        }

        private Task<Mat> GetMatAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    return (Mat)queue.Peek();
                }
                catch (System.NullReferenceException ex)
                {
                    Console.WriteLine("ERROR NULL Mat " + ex.Message);
                }
                catch(System.InvalidOperationException ex)
                {
                    Console.WriteLine("ERROR QUEUE EMPTY " + ex.Message);
                }
                return null;
            });

        }

        #endregion
    }
}
