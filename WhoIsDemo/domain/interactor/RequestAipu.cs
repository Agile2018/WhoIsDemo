using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class RequestAipu
    {
        #region variables
        private static readonly RequestAipu instance = new RequestAipu();
        public static RequestAipu Instance => instance;
        #endregion
        #region methods
        public RequestAipu() { }        

        public void IsRegister(bool option)
        {
            AipuFace.Instance.SetIsRegister(option);
        }

        //public void SendFrame(byte[] data, int rows, int cols, int client)
        //{
        //    AipuFace.Instance.SendFrame(data, rows, cols, client);
        //}                          

        public void SetSequenceFps(int value)
        {
            AipuFace.Instance.SetSequenceFps(value);

        }        

        public void SetConfigurationDatabase()
        {
            AipuFace.Instance.SetConfigurationDatabase();
        }

        public void TerminateTracking()
        {
            AipuFace.Instance.TerminateTracking();

        }

        public bool IsEnableObserverUser()
        {
            return AipuFace.Instance.IsObserverUser();
        }

        public void EnableEarUser()
        {
            AipuFace.Instance.EnableObserverUser();
        }     
       
        public void ReloadAipu()
        {
            AipuFace.Instance.ReloadAipu();
        }

        public void StopAipu()
        {
            AipuFace.Instance.StopAipu();
        }
        public void Terminate()
        {
            AipuFace.Instance.Terminate();
        }
        public void LoadConfiguration(string nameFileConfiguration)
        {
            AipuFace.Instance.LoadConfiguration(nameFileConfiguration);
        }

        public void InitLibrary()
        {
            AipuFace.Instance.InitLibrary();
        }

        public void SetFileVideo(string file)
        {
            AipuFace.Instance.SetFileVideo(file);
        }

        public void SetNameWindow(string name)
        {
            AipuFace.Instance.SetNameWindow(name);
        }

        public void SetWidthFrame(int value)
        {
            AipuFace.Instance.SetWidthFrame(value);

        }

        public void SetHeightFrame(int value)
        {
            AipuFace.Instance.SetHeightFrame(value);

        }

        public void CaptureFlow(int optionFlow)
        {
            AipuFace.Instance.CaptureFlow(optionFlow);
        }

        public void SetIpCamera(string ip)
        {
            AipuFace.Instance.SetIpCamera(ip);
        }

        public void SetFaceConfidenceThresh(int value)
        {
            AipuFace.Instance.SetFaceConfidenceThresh(value);
        }

        public void SetRefreshInterval(int value)
        {
            AipuFace.Instance.SetRefreshInterval(value);
        }

        public void SetMinEyeDistance(int minDistance)
        {
            AipuFace.Instance.SetMinEyeDistance(minDistance);
        }

        public void SetMaxEyeDistance(int maxDistance)
        {
            AipuFace.Instance.SetMaxEyeDistance(maxDistance);
        }
        

        public void SetClient(int value)
        {
            AipuFace.Instance.SetClient(value);
        }

        public void SetFlagFlow(bool flag)
        {
            AipuFace.Instance.SetFlagFlow(flag);
        }

        public void ShowWindow(int option)
        {
            AipuFace.Instance.ShowWindow(option);
        }

        public void RecognitionFaceFiles(string file, int client)
        {
            AipuFace.Instance.RecognitionFaceFiles(file, client);
        }

        public void SetIsFinishLoadFiles(bool value)
        {
            AipuFace.Instance.SetIsFinishLoadFiles(value);
        }
        public bool GetIsFinishLoadFiles()
        {
            return AipuFace.Instance.GetIsFinishLoadFiles();
        }

        public void ResetLowScore()
        {
            AipuFace.Instance.ResetLowScore();
        }
        public int GetCountLowScore()
        {
            return AipuFace.Instance.GetCountLowScore();
        }
        public void ResetCountNotDetect()
        {
            AipuFace.Instance.ResetCountNotDetect();
        }
        public int GetCountNotDetect()
        {
            return AipuFace.Instance.GetCountNotDetect();
        }

        public void SetDeviceVideo(string device)
        {
            AipuFace.Instance.SetDeviceVideo(device);
        }

        public void SetDeepTrack(string value)
        {
            AipuFace.Instance.SetDeepTrack(value);
        }
        public void ResetCountRepeatUser()
        {
            AipuFace.Instance.ResetCountRepeatUser();
        }
        public int GetCountRepeatUser()
        {
            return AipuFace.Instance.GetCountRepeatUser();
        }
        #endregion
    }
}
