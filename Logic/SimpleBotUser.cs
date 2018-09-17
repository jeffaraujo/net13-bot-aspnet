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

        static IRepositoryMDB repository;
        static IRepository repositoryEF;

        static SimpleBotUser()
        {
            repository = new Repository.MDB.RepositoryMDB();
            repositoryEF = new Repository.EF.RepositoryEF();
        }

        //int visitas = 0;
        public static string Reply(Message message)
        {
            try
            {
                var id = message.Id;
                var profile = repositoryEF.GetProfile(id);
                profile._id = id;
                profile.Visitas++;

                repositoryEF.SetProfile(profile, id);

                return $"{message.User} disse '{message.Text}' e mandou {profile.Visitas} mensagens.";
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        
    }
}