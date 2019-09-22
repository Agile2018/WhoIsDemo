﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsDemo.model
{
    public class Database
    {
        #region constant
        private const string TABLE_USER = "user";
        private const string TABLE_IMAGE = "image";
        #endregion
        #region variables
        private string connection;
        private string nameDatabase;
        private MongoClient client;
        private IClientSessionHandle session;
        private IMongoDatabase database;
        private IMongoCollection<PersonDb> users;
        private IMongoCollection<Image> images;
        #endregion

        #region methods
        public Database()
        {
            
        }

        ~Database()
        {
            session.Dispose();
            
        }
        public void Connect()
        {
            try
            {
                client = new MongoClient(connection);
                session = client.StartSession();
                database = session.Client.GetDatabase(nameDatabase);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

            ////var image = client.GetDatabase("dbass").GetCollection<BsonDocument>("image");
            //var image = session.Client.GetDatabase("dbass")
            //    .GetCollection<Image>("image");

            ////var result = image.Find(new BsonDocument()).ToListAsync();
            //var filter = Builders<Image>.Filter.Eq("id_face", 1);
            ////var result = image.Find(filter).ToListAsync();
            //var result = image.Find(filter).Limit(1).SingleAsync();
            //Console.WriteLine(result.Result);
            //foreach (var item in result.Result)
            //{
            //    Console.WriteLine(item.ToString());
            //}
        }

        public void GetUsers()
        {
            try
            {
                users = session.Client.GetDatabase(nameDatabase)
               .GetCollection<PersonDb>(TABLE_USER);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           

        }

        public void GetImages()
        {
            try
            {
                images = session.Client.GetDatabase(nameDatabase)
                .GetCollection<Image>(TABLE_IMAGE);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }

        public async Task<bool> UpdateUser(int idFace, string namePerson, 
            string lastName, string identification)
        {
            var filter = Builders<PersonDb>.Filter.Eq("id_face", idFace);
            var update = Builders<PersonDb>.Update.Set("name", namePerson)
                .Set("lastname", lastName).Set("identification", identification);

            var result = await users.UpdateOneAsync(filter, update);

            return result.ModifiedCount != 0;
        }

        public Image GetImageByUser(int idFace)
        {
            try
            {
                var filter = Builders<Image>.Filter.Eq("id_face", idFace);
                var result = images.Find(filter).Limit(1).SingleAsync();
                return result.Result;
            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (System.AggregateException ax)
            {

                Console.WriteLine(ax.Message);
            }
            return null;
          
        }

        public List<Image> GetImagesOfPepople()
        {
            List<Image> list = new List<Image>();
            try
            {
                var filter = Builders<Image>.Filter.Empty;
                var result = images.Find(filter).ToListAsync();
                return result.Result;
            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (System.AggregateException ax)
            {

                Console.WriteLine(ax.Message);
            }
            return list;
        }

        public List<PersonDb> GetAllPeople()
        {
            List<PersonDb> list = new List<PersonDb>();
            try
            {
                var filter = Builders<PersonDb>.Filter.Empty;
                var result = users.Find(filter).ToListAsync();
                return result.Result;
            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (System.AggregateException ax)
            {

                Console.WriteLine(ax.Message);
            }
            return list;
        }

        public bool DropDatabase()
        {
            try
            {
                session.Client.DropDatabase(nameDatabase);
                return true;
            }
            catch (MongoException exception)
            {

                Console.WriteLine(exception.Message);
                return false;
            }
            
           
        }

        public string Connection { get => connection; set => connection = value; }
        public string NameDatabase { get => nameDatabase; set => nameDatabase = value; }
        #endregion
    }
}
