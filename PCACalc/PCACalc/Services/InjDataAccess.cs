using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using PCACalc.Models;
using System.Threading.Tasks;

namespace PCACalc.Services
{
    public class InjDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Med> MedsList { get; set; }

        public InjDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Med>();

            this.MedsList = new ObservableCollection<Med>(database.Table<Med>());

            // If the table is empty, initialize the collection
            if (!database.Table<Med>().Any())
            {
                InitializeMedication();
            }
        }

        private void InitializeMedication()
        {
            this.MedsList.Add(new Med
            {
                Name = "Morphine",
                VialConcentration = 4,
                VialSize= 1,
                VialPrice = 2.85M
                
            });
        }

        public async Task<IEnumerable<Med>> GetMedsAsync()
        {
            return await Task.FromResult(MedsList);
        }

        public Med GetMedication(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Med>().
                    FirstOrDefault(med => med.ID == id);
            }
        }

        public async Task<bool> DeleteMedication(int medID)
        {
            database.Delete<Med>(medID);
            return await Task.FromResult(true);
        }

        //public int SaveMedication(Med medinstance)
        //{
        //    lock (collisionLock)
        //    {
        //        if (medinstance.ID != 0)
        //        {
        //            database.Update(medinstance);
        //            return medinstance.ID;
        //        }
        //        else
        //        {
        //            database.Insert(medinstance);
        //            return medinstance.ID;
        //        }
        //    }
        //}

        public async Task<bool> AddMedicationAsync(Med med)
        {
            if (med.ID != 0)
            {
                database.Update(med);
            }
            else
            {
                database.Insert(med);
            }
            MedsList.Add(med);
            return await Task.FromResult(true);
        }
    }
}
