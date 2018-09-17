namespace SimpleBot.Repository.EF.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProfile")]
    public partial class UserProfile
    {
        [StringLength(50)]
        public string Id { get; set; }

        public int Visitas { get; set; }
    }
}
