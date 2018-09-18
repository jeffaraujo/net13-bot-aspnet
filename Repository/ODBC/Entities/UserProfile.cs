using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel.Attributes;
namespace SimpleBot.Repository.ODBC.Entities
{
    public class UserProfile
    {
        [ExcelColumn("_id")]
        public string _id { get; set; }
        [ExcelColumn("Visitas")]
        public int Visitas { get; set; }
    }
}