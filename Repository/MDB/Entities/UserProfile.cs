using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBot.MDB.Entities
{
    
    public class UserProfile
    {
        [BsonRequired()]
        [BsonId()]
        public string _id { get; set; }

        [BsonRequired()]
        [BsonElement("Visitas")]
        public int Visitas { get; set; }


    }
}