using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PCACalc.Models
{
    [Table("MedsPCA")]
    public class MedsPCA
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int FK_MedsID { get; set; }
        public int PCASize  { get; set; }

        public decimal PCAPrice { get; set; }


    }
}
