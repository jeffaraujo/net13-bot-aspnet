using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;


namespace SimpleBot
{
    public class SimpleBotUser
    {

        //int visitas = 0;
        public static string Reply(Message message)
        {
            var id = message.Id;
            var profile = GetProfile(id);
            profile.Visitas++;

            SetProfile(profile);

            return $"{message.User} disse '{message.Text}' e mandou {profile.Visitas} mensagens.";
        }

        public static UserProfile GetProfile(string id)
        {

            string connectionString = "mongodb://localhost:27017";

            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase db = client.GetDatabase("13net"); //Cria o DataBase

            var col = db.GetCollection<BsonDocument>("UserProfile");
            var filtro = Builders<BsonDocument>.Filter.Eq("id", id);
            var res = col.Find(filtro).FirstOrDefault();
            

            return res;
        }



        public static void SetProfile(UserProfile profile)
        {
            string connectionString = "mongodb://localhost:27017";

            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase db = client.GetDatabase("13net"); //Cria o DataBase
            var doc = new BsonDocument
            {
                { "id", profile.Id },
                { "Visitas", profile.Visitas }
            };

            var col = db.GetCollection<BsonDocument>("UserProfile");
            col.InsertOne(doc);


        }
    }
}