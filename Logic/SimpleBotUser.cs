using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Repository.Interfaces;

namespace SimpleBot
{
    public class SimpleBotUser
    {

        static IRepository repository;
        static SimpleBotUser()
        {
            repository = new Repository.MDB.RepositoryMDB();
        }

        //int visitas = 0;
        public static string Reply(Message message)
        {
            try
            {
                var id = message.Id;
                var profile = repository.GetProfile(id);
                profile._id = id;
                profile.Visitas++;

                repository.SetProfile(profile, id);

                return $"{message.User} disse '{message.Text}' e mandou {profile.Visitas} mensagens.";
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        
    }
}