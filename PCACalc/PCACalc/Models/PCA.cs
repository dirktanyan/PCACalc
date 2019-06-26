using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PCACalc.Models
{
    [Table("PCA")]
    public class PCA
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string PCADrug { get; set; }
        public int PCAConcn { get; set; }
        public string PCAUnits { get; set; }
        public string PCAFullName
        {
            get
            {
                return $"{PCADrug} {PCAConcn} {PCAUnits}/ml";
            }
        }


    }
}
