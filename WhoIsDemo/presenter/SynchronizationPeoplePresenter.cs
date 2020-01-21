using System;
using System.Collections.Generic;
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
        private List<People> beforePeople = new List<People>();
        private List<People> afterPeople = new List<People>();
        private int skipInit = 0;
        private int skipEnd = 0;
        private int maxLimitCount = 0;
        private int skipIndex = 0;
        private long numberPersons = 0;
        public delegate void ListPeopleDelegate(List<People> list);
        public event ListPeopleDelegate OnListPeople;
        #endregion

        #region methods
        public SynchronizationPeoplePresenter()
        {
            this.synchronizationOfPeopleWithDatabase.OnListPeople += 
                new SynchronizationOfPeopleWithDatabase
                .ListPeopleDelegate(LoadListSyncUp);
            this.maxLimitCount = this.synchronizationOfPeopleWithDatabase.GetMaxLimit();
            InitSkip();
        }

        public List<People> SyncUpPeople {
            get
            {
                return syncUpPeople;
            }

            set
            {
                syncUpPeople = value;
                OnListPeople(syncUpPeople);
            }
        }

        public long NumberPersons { get => numberPersons;}

        private void LoadListSyncUp(List<People> list)
        {
            RefreshListPeople(list);
           
        }

        private void InitSkip()
        {
            
            this.skipEnd = this.maxLimitCount;
            this.skipIndex = this.skipInit;
            this.skipInit = 0;
        }

        public long GetNumbersPersons()
        {
            this.numberPersons = this.synchronizationOfPeopleWithDatabase.GetNumberOfUsers();
            return this.numberPersons;
        }

        private void ChangeSkipInLoad()
        {

            this.skipIndex = this.skipEnd;
            this.skipEnd += this.maxLimitCount;
            this.skipInit += this.maxLimitCount;
        }

        private void ChangeSkipInDownload()
        {
            this.skipEnd -= this.maxLimitCount;
            this.skipInit -= this.maxLimitCount;
            this.skipIndex = this.skipInit;            
            
        }

        private bool UpdateSkip(bool address)
        {
            bool result = true;
            if (address)
            {
                if (this.skipEnd < this.NumberPersons)
                {
                    ChangeSkipInLoad();
                }
                else
                {
                    result = false;
                }
                
            }
            else if (this.skipInit > 0)
            {
                ChangeSkipInDownload();
            }
            else
            {
                result = false;
            }

            return result;
           
        }

        public void GetListPeople(bool address)
        {
            if (UpdateSkip(address))
            {
                Task taskLoadPeoples = TaskLoadPeoples();
            }
            
        }

        private void RefreshListPeople(List<People> list)
        {
            this.syncUpPeople.Clear();
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

            synchronizationOfPeopleWithDatabase.SyncUpDatabase(skipIndex);

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
