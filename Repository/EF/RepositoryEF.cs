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

        public SimpleBot.Repository.EF.Context.UserProfile GetProfile(string _id)
        {
            try
            {
                Context.UserProfile user = ctx.UserProfile.FirstOrDefault(u => u._id == _id);

                if (user == null)
                    user = new Context.UserProfile() { Visitas = 0, _id = _id };

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SetProfile(SimpleBot.Repository.EF.Context.UserProfile userProfile, string _id)
        {

            try
            {
                var user = ctx.UserProfile.FirstOrDefault(u => u._id == userProfile._id);
                if (user != null)
                {
                    ctx.Entry(userProfile).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    ctx.Set<SimpleBot.Repository.EF.Context.UserProfile>().Add(userProfile);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
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