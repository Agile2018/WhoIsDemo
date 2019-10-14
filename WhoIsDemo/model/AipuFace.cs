using ASSLibrary;
using System;
using System.Runtime.InteropServices;

namespace WhoIsDemo.model
{
    class AipuFace
    {
        #region constant
        private const int reset = 1;
        private const int finish = 0;
        #endregion
        #region variables
        Aipu aipu;
        AipuObserver aipuObserver;
        private bool isLoadConfiguration = false;
        private bool isStopAipu = false;
        private bool isTracking = false;
        private static readonly AipuFace instance = new AipuFace();
        public static AipuFace Instance => instance;

        public bool IsLoadConfiguration { get => isLoadConfiguration; set => isLoadConfiguration = value; }
        public bool IsStopAipu { get => isStopAipu; set => isStopAipu = value; }
        public bool IsTracking { get => isTracking; set => isTracking = value; }
        #endregion

        #region methods
        public AipuFace()
        {
            aipu = new Aipu();
            aipuObserver = new AipuObserver(aipu);
        }

        public void LoadConfiguration(string nameFileConfiguration)
        {
            try
            {
                aipu.LoadConfiguration(nameFileConfiguration);
                IsLoadConfiguration = true;
            }
            catch (SEHException sehException)
            {
                throw new Exception(sehException.Message);
                
            }
        }

        public void InitLibrary()
        {
            aipu.InitLibrary();
        }

        public void SetWorkMode(int mode)
        {
            aipu.SetWorkMode(mode);
            
        }

        public void ResfreshBetweenFrame(int value)
        {
            aipu.ResfreshBetweenFrame(value);

        }

        public void SetSequenceFps(int value)
        {
            if (value != 0)
            {
                aipu.SetSequenceFps(value);
            }
            

        }

        public bool GetStateProccessRecognition()
        {
            return aipu.GetStateProccessRecognition;
        }

        public void ResetIdUser()
        {
            aipu.ResetIdUser();
        }

        public void SetConfigurationDatabase()
        {
            aipu.SetConfigurationDatabase();
        }

        public void TerminateTracking()
        {
            if (isTracking)
            {
                aipu.TerminateTracking();
            }
            
            isTracking = false;
        }

        public void SetIsRegister(bool option)
        {
            aipu.SetIsRegister(option);
        }

        public void ResetLowScore()
        {
            aipu.ResetLowScore();
        }
        public int GetCountLowScore()
        {
            return aipu.GetCountLowScore;
        }
        public void ResetCountRepeatUser()
        {
            aipu.ResetCountRepeatUser();
        }
        public int GetCountRepeatUser()
        {
            return aipu.GetCountRepeatUser;
        }

        public void ResetCountNotDetect()
        {
            aipu.ResetCountNotDetect();
        }
        public int GetCountNotDetect()
        {
            return aipu.GetCountNotDetect;
        }

        public void SendFrame(byte[] data, int rows, int cols, int client)
        {
            aipu.SetFrame(data, rows, cols, client);

        }

        public void SendFastFrame(byte[] data, int rows, int cols)
        {
            aipu.SetFastFrame(data, rows, cols);
        }

        public void InitTracking(byte[] data, int rows, int cols)
        {
            aipu.InitTracking(data, rows, cols);
            isTracking = true;
        }

        public void Tracking(byte[] data, int rows, int cols)
        {
            aipu.Tracking(data, rows, cols);
        }

        public AipuObserver GetObserver()
        {
            return aipuObserver;
        }

        public void EnableObserverUser()
        {
            aipuObserver.EnableObserverUser();
        }

        public void EnableObserverCoordinates(bool enable)
        {
            aipuObserver.EnableObserverCoordinates(enable);
        }

        public bool IsObserverUser()
        {
            return aipuObserver.IsHearObserverUser;
        }

        public bool IsObserverCoordinates()
        {
            return aipuObserver.IsHearObserverCoordinates;
        }

        public void StopAipu()
        {
            if (IsLoadConfiguration && !IsStopAipu)
            {
                aipu.Terminate(reset);
                IsStopAipu = true;
            }
        }

        public void ReloadAipu()
        {
            if (IsLoadConfiguration && IsStopAipu)
            {
                aipu.Reset();
                IsStopAipu = false;
            }
        }
        public void Terminate()
        {
            if (IsLoadConfiguration)
            {
                aipu.Terminate(finish);
                aipu.Dispose();
                aipuObserver.Dispose();
                IsLoadConfiguration = false;
            }
        }
        #endregion
    }
}
