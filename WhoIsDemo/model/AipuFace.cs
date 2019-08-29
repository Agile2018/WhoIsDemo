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

        private static readonly AipuFace instance = new AipuFace();
        public static AipuFace Instance => instance;

        public bool IsLoadConfiguration { get => isLoadConfiguration; set => isLoadConfiguration = value; }
        public bool IsStopAipu { get => isStopAipu; set => isStopAipu = value; }
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

        public void SetIsRegister(bool option)
        {
            aipu.SetIsRegister(option);
        }

        public void SendFrame(byte[] data, int rows, int cols, int client)
        {
            aipu.SetFrame(data, rows, cols, client);

        }

        public AipuObserver GetObserver()
        {
            return aipuObserver;
        }

        public void EnableObserverUser()
        {
            aipuObserver.EnableObserverUser();
        }

        public bool IsObserverUser()
        {
            return aipuObserver.IsHearObserverUser;
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
