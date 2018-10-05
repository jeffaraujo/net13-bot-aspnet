﻿using System;
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

        // exemplo: reescrevendo GetProfile
        public Model.UserProfile GetProfile(string _id)
        {
            using(ctx = new Context13NET())
            {
                var user = ctx.UserProfile.FirstOrDefault(u => u._id == _id);
                Model.UserProfile userModel;
                if (user == null)
                    userModel = new Model.UserProfile() { Visitas = 0, _id = _id };
                else
                    userModel = new Model.UserProfile() { Visitas = user.Visitas, _id = user._id };
                
                return userModel;            
            }
        }

        public void SetProfile(Model.UserProfile userProfile, string _id)
        {

            try
            {
                var userContext = new Context.UserProfile() { _id = userProfile._id, Visitas = userProfile.Visitas };

                var user = ctx.UserProfile.FirstOrDefault(u => u._id == userProfile._id);
                if (user != null)
                {
                    ctx.Entry(user).State = System.Data.Entity.EntityState.Detached;
                    ctx.Entry(userContext).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    ctx.Set<Context.UserProfile>().Add(userContext);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Se possivel, reescreva o codigo para evitar o Dispose
        // Por exemplo, podemos remover a propriedade ctx da classe e incluir no metodo
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
