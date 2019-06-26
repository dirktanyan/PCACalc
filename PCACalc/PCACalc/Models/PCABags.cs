using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PCACalc.Models
{
    [Table("PCABags")]
    public class PCABags
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int FK_PCAID { get; set; }
        public int PCASize { get; set; }
        public decimal PCAPrice { get; set; }

    }
}
