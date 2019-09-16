using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ASSLibrary;
using System.Threading;

namespace WhoIsDemo.model
{
    public class AipuObserver: IDisposable
    {
        #region variables
        private Aipu aipu;
        private string errorBiometrics;
        private string userJson;
        private float[] coordinates;
        private IObservable<string> observableError;
        private IObservable<string> observableUser;
        private IObservable<float[]> observableCoordinates;
        IDisposable subscriptionUser;
        IDisposable subscriptionError;
        IDisposable subscriptionCoordinates;
        bool isHearObserverUser = false;
        bool isHearObserverCoordinates = false;
        //private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        public string ErrorBiometrics
        {
            get
            {
                return errorBiometrics;
            }

            set
            {
                errorBiometrics = value;
                OnError(errorBiometrics);
            }
        }

        public string UserJson
        {
            get
            {
                return userJson;
            }

            set
            {
                userJson = value;
                OnUser(userJson);
            }
        }

        public bool IsHearObserverUser { get => isHearObserverUser; set => isHearObserverUser = value; }
        public float[] Coordinates {
            get
            {
                return coordinates;
            }

            set
            {
                coordinates = value;
                OnCoordinates(coordinates);
            }
            
        }

        public bool IsHearObserverCoordinates { get => isHearObserverCoordinates; set => isHearObserverCoordinates = value; }

        public delegate void MessageErrorDelegate(string error);
        public event MessageErrorDelegate OnError;
        public delegate void UserJsonDelegate(string dataUser);
        public event UserJsonDelegate OnUser;
        public delegate void CoordinatesDelegate(float[] coordinateFlow);
        public event CoordinatesDelegate OnCoordinates;
        #endregion

        #region methods
        public AipuObserver(Aipu workAipu)
        {
            this.aipu = workAipu;
            ObserverError();
            
            
        }

        ~AipuObserver()
        {

        }

        public void EnableObserverUser()
        {
            ObserverUser();
            isHearObserverUser = true;
        }

        public void EnableObserverCoordinates(bool enable)
        {
            if (enable)
            {
                ObserverCoordinates();
                IsHearObserverCoordinates = true;
            }
            else
            {
                subscriptionCoordinates.Dispose();
                IsHearObserverCoordinates = false;
            }
        }

        private void ObserverCoordinates()
        {
            observableCoordinates = Observable.Create<float[]>(async observer =>
            {
                observer.OnNext(await GetCoordinatesAsync());

            });
            subscriptionCoordinates = observableCoordinates
                .Where(res => res != null)
                .Delay(TimeSpan.FromSeconds(0.1))
                .Repeat()
                .Subscribe(
                    res => Coordinates = res
                );
        }

        private Task<float[]> GetCoordinatesAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    return aipu.GetCoordinates();
                }
                catch (System.NullReferenceException ex)
                {
                    Console.WriteLine("ERROR NULL AIPU " + ex.Message);
                }
                return null;
            });

        }


        private void ObserverError()
        {
            observableError = Observable.Create<string>(async observer =>
            {
                observer.OnNext(await GetErrorAsync());
                
            });
            subscriptionError = observableError
                .Where(res => res != ErrorBiometrics && res != null)
                .Delay(TimeSpan.FromSeconds(1))
                .Repeat()
                .Subscribe(
                    res => ErrorBiometrics = res
                );
        }

        private Task<string> GetErrorAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    return aipu.GetError;
                }
                catch(System.NullReferenceException ex)
                {
                    Console.WriteLine("ERROR NULL AIPU " + ex.Message);
                }
                return null;
            });

        }

        private void ObserverUser()
        {
            observableUser = Observable.Create<string>(async observer =>
            {
                observer.OnNext(await GetUserAsync());
            });
            subscriptionUser = observableUser
                .Where(res => res != UserJson && !string.IsNullOrEmpty(res))      // res != UserJson &&
                .Delay(TimeSpan.FromSeconds(0.2))
                .Repeat()
                .Subscribe(
                    res => UserJson = res
                ); //.Concat(Observable.Empty<string>().Delay(TimeSpan.FromSeconds(0.2)))

        }

        private Task<string> GetUserAsync()
        {
            return Task.Run(() =>
            {
                //Console.WriteLine("OBSERVANDO-------");
                return aipu.GetUser;
            });

        }

        public void Dispose()
        {
            this.aipu = null;
            if (isHearObserverUser)
            {
                subscriptionUser.Dispose();
            }
            if (IsHearObserverCoordinates)
            {
                subscriptionCoordinates.Dispose();
            }
            subscriptionError.Dispose();            
        }


        #endregion
    }
}
