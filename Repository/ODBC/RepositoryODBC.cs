using SimpleBot.Repository.Interfaces;
using SimpleBot.Repository.ODBC.Entities;
using System;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel.Query;
using LinqToExcel;

namespace SimpleBot.Repository.ODBC
{
    public class RepositoryODBC : IRepositoryODBC
    {
        string connectionString = @"Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};" +
                                  @"DBQ=C:\Users\jeffa\Source\Repos\net13-bot-aspnet\App_Data\Excel13NET.xlsx;ReadOnly=0;";

        string filePath = @"C:\Users\jeffa\Source\Repos\net13-bot-aspnet\App_Data\Excel13NET.xlsx";
        OdbcConnection odbcConnection;
        OdbcCommand odbcCommand;
        
        public RepositoryODBC()
        {
            odbcConnection = new OdbcConnection(connectionString);

        }


        public Entities.UserProfile GetProfile(string _id)
        {

            var excel = new ExcelQueryFactory(filePath);
            excel.AddMapping<Entities.UserProfile>(x => x._id, "_id");
            excel.AddMapping<Entities.UserProfile>(x => x.Visitas, "Visitas");

            var qry = (from c in excel.Worksheet<Entities.UserProfile>("UserProfile")
                      where c._id == _id
                      select c).FirstOrDefault();
            
            Entities.UserProfile user = new Entities.UserProfile() { _id = _id, Visitas = 0 };

            if (qry != null)
            { 
                user._id = qry._id;
                user.Visitas = qry.Visitas;
            }


            return user;

        }

        public void SetProfile(Entities.UserProfile userProfile, string _id)
        {
            try
            {
                var u = GetProfile(userProfile._id);
                string query = "";
                
                if (u.Visitas == 0)
                    query = "insert into [UserProfile$]  (Visitas, [_id]) values (?,?);";
                else
                    query = "update [UserProfile$] set Visitas = ? where [_id] = ?;";

                using (var cnn = odbcConnection)
                {
                    cnn.ConnectionString = connectionString;
                    using (var cmd = new OdbcCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("?", userProfile.Visitas);
                        cmd.Parameters.AddWithValue("?", userProfile._id);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                


            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}