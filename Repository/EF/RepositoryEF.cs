using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBot.Repository.EF.Context;
using SimpleBot.Repository.Interfaces;

namespace SimpleBot.Repository.EF
{
    public class RepositoryEF: IRepository, IDisposable 
    {
        private Context13NET ctx;

        public RepositoryEF()
        {
            ctx = new Context13NET();
        }

        public UserProfile GetProfile(string _id)
        {
            return ctx.Set<UserProfile>().Find(new object[] { _id });
        }

        public void SetProfile(UserProfile userProfile, string _id)
        {
            var up = GetProfile(_id);
            if (up != null)
            {
                ctx.Entry(userProfile).State = System.Data.Entity.EntityState.Modified;
            }else
            {
                ctx.Set<UserProfile>().Add(userProfile);
            }
            ctx.SaveChanges();
        }

        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}