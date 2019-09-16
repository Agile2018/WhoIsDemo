using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void WorkMode(int mode)
        {
            AipuFace.Instance.SetWorkMode(mode);
        }

        public void IsRegister(bool option)
        {
            AipuFace.Instance.SetIsRegister(option);
        }

        public void SendFrame(byte[] data, int rows, int cols, int client)
        {
            AipuFace.Instance.SendFrame(data, rows, cols, client);
        }

        public void SendFastFrame(byte[] data, int rows, int cols)
        {
            AipuFace.Instance.SendFastFrame(data, rows, cols);
        }

        public void InitTracking(byte[] data, int rows, int cols)
        {
            AipuFace.Instance.InitTracking(data, rows, cols);
        }

        public void Tracking(byte[] data, int rows, int cols)
        {
            AipuFace.Instance.Tracking(data, rows, cols);
        }

        public void ResfreshBetweenFrame(int value)
        {
            AipuFace.Instance.ResfreshBetweenFrame(value);

        }

        public void SetSequenceFps(int value)
        {
            AipuFace.Instance.SetSequenceFps(value);

        }

        public bool GetStateProccessRecognition()
        {
            return AipuFace.Instance.GetStateProccessRecognition();
        }

        public void ResetIdUser()
        {
            AipuFace.Instance.ResetIdUser();
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

        public void EnableObserverCoordinates(bool enable)
        {
            AipuFace.Instance.EnableObserverCoordinates(enable);
        }

        public bool IsObserverCoordinates()
        {
            return AipuFace.Instance.IsObserverCoordinates();
        }

        public void StopAipu()
        {
            AipuFace.Instance.StopAipu();
        }

        public void ReloadAipu()
        {
            AipuFace.Instance.ReloadAipu();
        }
        public void Terminate()
        {
            AipuFace.Instance.Terminate();
        }

        #endregion
    }
}
