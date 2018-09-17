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
        SimpleBot.Repository.EF.Context.UserProfile GetProfile(string _id);

        void SetProfile(SimpleBot.Repository.EF.Context.UserProfile userProfile, string _id);
        
    }
}
