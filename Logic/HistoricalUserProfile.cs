using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    [BsonIgnoreExtraElements]
    public class HistoricalUserProfile
    {
        public string id { get; set; }

        [BsonExtraElements]
        public BsonDocument userProfile { get; set; }
    }
}