
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using SimpleBot.Repository.Interfaces;


namespace SimpleBot.Repository.MDB
{
    public class RepositoryMDB : IRepositoryMDB
    {
        const string connectionString = "mongodb://localhost:27017";
        const string databasename = "DB13NET";
        MongoClient client;
        MongoDatabase db;

        public RepositoryMDB()
        {
            client = new MongoClient(connectionString);
            db = client.GetServer().GetDatabase(databasename); //Cria o DataBase
        }

        public SimpleBot.MDB.Entities.UserProfile GetProfile(string _id)
        {
            try
            {
                var col = db.GetCollection<BsonDocument>("UserProfile");

                BsonDocument where = new BsonDocument {
                    { "_id", _id }
                };

                QueryDocument query = new QueryDocument(where);
                var res = col.FindOne(query);

                SimpleBot.MDB.Entities.UserProfile userProfile;

                if (res != null)
                    userProfile = BsonSerializer.Deserialize<SimpleBot.MDB.Entities.UserProfile>(res); //Converte de Bson para objeto (classe)
                else
                    userProfile = new SimpleBot.MDB.Entities.UserProfile() { _id = _id, Visitas = 0 };

                return userProfile;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }


        }

        public void SetProfile(SimpleBot.MDB.Entities.UserProfile profile, string _id)
        {

            try
            {
                var doc = new BsonDocument
                {
                    { "_id", profile._id },
                    { "Visitas", profile.Visitas }
                };

                var col = db.GetCollection<BsonDocument>("UserProfile");
                col.Save(doc);

            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
    }


}