using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;

namespace WhoIsDemo.presenter
{
    public class SynchronizationPeoplePresenter
    {
        #region variables
        private static readonly SynchronizationPeoplePresenter instance = 
            new SynchronizationPeoplePresenter();
        public static SynchronizationPeoplePresenter Instance => instance;
        SynchronizationOfPeopleWithDatabase synchronizationOfPeopleWithDatabase = 
            new SynchronizationOfPeopleWithDatabase();
        private List<People> syncUpPeople = new List<People>();

        #endregion

        #region methods
        public SynchronizationPeoplePresenter()
        {
            this.synchronizationOfPeopleWithDatabase.OnListPeople += 
                new SynchronizationOfPeopleWithDatabase
                .ListPeopleDelegate(LoadListSyncUp);
        }

        public List<People> SyncUpPeople { get => syncUpPeople; set => syncUpPeople = value; }

        private void LoadListSyncUp(List<People> list)
        {
            SyncUpPeople = list;
        }

        public async Task TaskLoadPeoples()
        {

            await Task.Run(() =>
            {
                LoadPeoples();

            });

        }
        private void LoadPeoples()
        {

            synchronizationOfPeopleWithDatabase.SyncUpDatabase();

        }
        public void AddPeople(People people)
        {
            SyncUpPeople.Add(people);
        }

        public async Task TaskUpdateImagePeople(int idFace, string img)
        {

            await Task.Run(() =>
            {
                UpdateImagePeople(idFace, img);

            });

        }

        private void UpdateImagePeople(int idFace, string img)
        {
            try
            {
                var index = syncUpPeople.FindIndex(p => p.Id_face == idFace);
                if (index != 0)
                {
                    this.syncUpPeople[index].Image = img;
                    
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task TaskUpdateDataPeople(People people)
        {

            await Task.Run(() =>
            {
                UpdateDataPeople(people);

            });

        }
        private void UpdateDataPeople(People people)
        {
            try
            {
                var index = syncUpPeople.FindIndex(p => p.Id_face == people.Id_face);
                if (index != 0)
                {
                    this.syncUpPeople[index].Name = people.Name;
                    this.syncUpPeople[index].Lastname = people.Lastname;
                    this.syncUpPeople[index].Identification = people.Identification;
                }
                
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);               
            }
            

        }

        public void ClearListPeople()
        {
            syncUpPeople.Clear();
        }

        #endregion
    }
}
