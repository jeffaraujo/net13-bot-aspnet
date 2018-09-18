using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot.Repository.Interfaces
{
    public interface IRepositoryODBC
    {
        ODBC.Entities.UserProfile GetProfile(string _id);

        void SetProfile(SimpleBot.Repository.ODBC.Entities.UserProfile userProfile, string _id);
    }
}
