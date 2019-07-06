using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace PCACalc.Models
{
    [Table("Meds")]
    public class Med : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        private string _name;
        [NotNull]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                this._name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private decimal _vialprice;
        public decimal VialPrice
        {
            get
            {
                return _vialprice;
            }

            set
            {
                this._vialprice = value;
                OnPropertyChanged(nameof(VialPrice));
            }
        }
        private float _vialconc;
        public float VialConcentration
        {
            get
            {
                return _vialconc;
            }

            set
            {
                this._vialconc = value;
                OnPropertyChanged(nameof(VialConcentration));
            }
        }


        // Assuming all sizes are in milliliters (ml) for now
        private float _vialsize;
        public float VialSize
        {
            get
            {
                return _vialsize;
            }

            set
            {
                this._vialsize = value;
                OnPropertyChanged(nameof(VialSize));
            }
        }
        private string _vialunits;
        public string VialUnits {
            get
            {
                return _vialunits;
            }
            set
            {
                this._vialunits = value;
                OnPropertyChanged(nameof(VialUnits));
            }
        }
        public string FullMedName
        {
            get
            {
                return $"{ Name } { VialConcentration } {VialUnits}/ml {VialSize}ml";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
