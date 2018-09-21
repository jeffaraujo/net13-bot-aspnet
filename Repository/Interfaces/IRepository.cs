using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot.Repository.EF.Context;

namespace SimpleBot.Repository.Interfaces
{
    public interface IRepository
    {
        Model.UserProfile GetProfile(string _id);

        void SetProfile(Model.UserProfile userProfile, string _id);
        
    }
}
