using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;
using WhoIsDemo.repository;

namespace WhoIsDemo.presenter
{
    class DiskPresenter
    {
        #region constants
        public const string directoryConfiguration = "configuration";
        public const string files_configuration = "files_configuration";
        public const string directory_train = "train";
        public const string directory_work = "camera";
        public const string file_database = "database.txt";
        public const string file_face = "detect.txt";
        public const string file_video = "video.txt";
        public const string directory = "directory.txt";
        public const string file_identify = "identify.txt";
        public const string file_list_images = "images_temp.txt";
        #endregion

        #region variables
        Disk disk = new Disk(); 
        #endregion

        #region methods
        public DiskPresenter() { }

        public void FileDelete(string stringPath)
        {
            try
            {
                disk.FileDelete(stringPath);

            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public void SaveDetectConfiguration(Detect detect)
        {
            
            try
            {
                string jsonOut = JsonConvert.SerializeObject(detect);
                string pathFile = directoryConfiguration + "/" + file_face;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public void WriteFileOfFiles(string[] content)
        {
            try
            {                
                string pathFile = directoryConfiguration + "/" + file_list_images;
                disk.WriteFileOfFiles(pathFile, content);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public void SaveIdentifyConfiguration(Identify identify)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(identify);
                string pathFile = directoryConfiguration + "/" + file_identify;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public Detect ReadDetectConfiguration()
        {
            Detect detect = new Detect();
            try
            {
                string pathFile = directoryConfiguration + "/" + file_face;
                string content = disk.ReadTextFile(pathFile);
                detect = JsonConvert.DeserializeObject<Detect>(content);
                
            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return detect;
        }

        public Identify ReadIdentifyConfiguration()
        {
            Identify identify = new Identify();
            try
            {
                string pathFile = directoryConfiguration + "/" + file_identify;
                string content = disk.ReadTextFile(pathFile);
                identify = JsonConvert.DeserializeObject<Identify>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return identify;
        }

        public void SaveVideoConfiguration(VideoConfig videoConfig)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(videoConfig);
                string pathFile = directoryConfiguration + "/" + file_video;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public List<Video> ReadListVideo()
        {
            VideoConfig videoConfig = new VideoConfig();
            List<Video> list = new List<Video>();

            try
            {
                string pathFile = directoryConfiguration + "/" + file_video;
                string content = disk.ReadTextFile(pathFile);
                videoConfig = JsonConvert.DeserializeObject<VideoConfig>(content);
                list = videoConfig.videos;
            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(System.NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }
        public VideoConfig ReadVideoConfiguration()
        {
            VideoConfig videoConfig = new VideoConfig();
            try
            {
                string pathFile = directoryConfiguration + "/" + file_video;
                string content = disk.ReadTextFile(pathFile);
                videoConfig = JsonConvert.DeserializeObject<VideoConfig>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return videoConfig;
        }

        public void SaveDatabaseConfiguration(DatabaseConfig databaseConfig)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(databaseConfig);
                string pathFile = directoryConfiguration + "/" + file_database;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public DatabaseConfig ReadDatabaseConfiguration()
        {
            DatabaseConfig databaseConfig = new DatabaseConfig();
            try
            {
                string pathFile = directoryConfiguration + "/" + file_database;
                string content = disk.ReadTextFile(pathFile);
                databaseConfig = JsonConvert.DeserializeObject<DatabaseConfig>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return databaseConfig;
        }

        public void CreateDirectoryWork()
        {
            disk.CreateWorkDirectory(directoryConfiguration);
        }

        public bool VerifyFileOfConfiguration()
        {
            string pathFile = directoryConfiguration + "/" + directory;
            return disk.IsFileExists(pathFile);
        }
        public void CreateContentDirectoryWork()
        {
            FileConfiguration fileConfiguration = new FileConfiguration();
            fileConfiguration.configuration = files_configuration;
            ParamsFile paramsFile = new ParamsFile();
            paramsFile.directory_train = directory_train;
            paramsFile.directory_work = directory_work;
            paramsFile.file_database = file_database;
            paramsFile.file_face = file_face;
            paramsFile.file_video = file_video;
            paramsFile.file_identify = file_identify;
            fileConfiguration.Params = paramsFile;
            try
            {
                string jsonOut = JsonConvert.SerializeObject(fileConfiguration);
                string pathFile = directoryConfiguration + "/" + directory;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }
        }
        #endregion
    }
}
