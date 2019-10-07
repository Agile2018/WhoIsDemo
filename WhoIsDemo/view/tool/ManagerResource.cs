using System.Reflection;
using System.Resources;
using System.Threading;

namespace WhoIsDemo.view.tool
{
    class ManagerResource
    {
        #region variables
        private static readonly ManagerResource instance = new ManagerResource();
        public static ManagerResource Instance => instance;
        public ResourceManager resourceManager;
        #endregion

        #region methods
        public ManagerResource() { }

        public void SetResourceManager()
        {
            if (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag == "en-US")
            {
                resourceManager = new ResourceManager("WhoIsDemo.locatable_resources.StringResource",
                    Assembly.GetExecutingAssembly());

            }
            else
            {
                resourceManager = new ResourceManager("WhoIsDemo.locatable_resources.StringResource_es",
                    Assembly.GetExecutingAssembly());
            }
            
        }

        #endregion
    }
}
