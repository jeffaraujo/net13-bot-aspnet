using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot.MDB.Entities;
namespace SimpleBot.Repository.Interfaces
{
    public interface IRepositoryMDB
    {
        SimpleBot.MDB.Entities.UserProfile GetProfile(string _id);

        void SetProfile(SimpleBot.MDB.Entities.UserProfile entity, string _id);
    }
}
