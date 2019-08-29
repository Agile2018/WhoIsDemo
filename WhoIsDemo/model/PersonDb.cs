using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsDemo.model
{
    public class PersonDb
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("id_face")]
        public int Id_face { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("lastname")]
        public string Lastname { get; set; }
        [BsonElement("identification")]
        public string Identification { get; set; }

    }
}
