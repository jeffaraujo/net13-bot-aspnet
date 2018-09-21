
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using SimpleBot.Repository.Interfaces;


namespace SimpleBot.Repository.MDB
{
    public class RepositoryMDB : IRepository
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

        public Model.UserProfile GetProfile(string _id)
        {
            try
            {
                var col = db.GetCollection<BsonDocument>("UserProfile");

                BsonDocument where = new BsonDocument {
                    { "_id", _id }
                };

                QueryDocument query = new QueryDocument(where);
                var res = col.FindOne(query);

                Model.UserProfile userProfile;

                if (res != null)
                    userProfile = BsonSerializer.Deserialize<Model.UserProfile>(res); //Converte de Bson para objeto (classe)
                else
                    userProfile = new Model.UserProfile() { _id = _id, Visitas = 0 };

                return userProfile;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }

        public void SetProfile(Model.UserProfile profile, string _id)
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