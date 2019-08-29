using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsDemo.model
{
    public class Image
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("id_face")]
        public int id_face { get; set; }

        [BsonElement("data_64")] 
        public string data_64 { get; set; }

        [BsonElement("data_64_aux")] 
        public string data_64_aux { get; set; }
    }
}
