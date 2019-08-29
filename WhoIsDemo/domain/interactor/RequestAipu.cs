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

        public bool IsEnableObserverUser()
        {
            return AipuFace.Instance.IsObserverUser();
        }

        public void EnableEarUser()
        {
            AipuFace.Instance.EnableObserverUser();
        }

        public void Terminate()
        {
            AipuFace.Instance.Terminate();
        }

        #endregion
    }
}
