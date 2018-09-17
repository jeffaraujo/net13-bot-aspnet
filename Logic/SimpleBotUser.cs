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

        IRepositoryMDB repository;
        IRepository repositoryEF;

        public SimpleBotUser()
        {
            repository = new Repository.MDB.RepositoryMDB();
            repositoryEF = new Repository.EF.RepositoryEF();
        }

        //int visitas = 0;
        public static string Reply(Message message)
        {
            var simpleBotUser = new SimpleBotUser();
            var id = message.Id;
            UserProfile profile = simpleBotUser.GetProfile(id);
            profile.Id = id;
            profile.Visitas++;

            simpleBotUser.SetProfile(profile);

            return $"{message.User} disse '{message.Text}' e mandou {profile.Visitas} mensagens.";
        }

        public UserProfile GetProfile(string id)
        {
            try
            {

                var user = repository.GetProfile(id);

                return new UserProfile()
                {
                    Id = user._id,
                    Visitas = user.Visitas
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
        public void SetProfile(UserProfile profile)
        {

            try
            {
                var user = new MDB.Entities.UserProfile();
                user._id = profile.Id.ToString();
                user.Visitas = profile.Visitas;

                repository.SetProfile(user, "");

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}