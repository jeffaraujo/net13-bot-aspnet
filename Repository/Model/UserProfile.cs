using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SimpleBot.Repository.Model
{
    public class UserProfile
    {
        [BsonRequired()]
        [BsonId()]
        [ExcelColumn("_id")]
        public string _id { get; set; }

        [BsonRequired()]
        [BsonElement("Visitas")]
        [ExcelColumn("Visitas")]
        public int Visitas { get; set; }
    }
}