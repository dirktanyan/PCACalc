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
    public class PCADataAccess
    {
        private SQLiteConnection database;
        public ObservableCollection<MedsPCA> PCAList { get; set; }
        public ObservableCollection<MedsPCA> PCAByMedID { get; set; }

        public PCADataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<MedsPCA>();

            this.PCAList = new ObservableCollection<MedsPCA>(database.Table<MedsPCA>());

            //if (!database.Table<MedsPCA>().Any())
            //{
            //    InitializePCA();
            //}
        }

        public async Task<ObservableCollection<MedsPCA>> GetMedsPCAAsync(int intMedID)
        {
            PCAByMedID = new ObservableCollection<MedsPCA>(database.Query<MedsPCA>("Select * from MedsPCA Where FK_MedsID=?", intMedID));
            return await Task.FromResult(PCAByMedID);
        }

        public async Task<bool> AddPCAAsync(MedsPCA pca)
        {
            if (pca.ID != 0)
            {
                database.Update(pca);
            }
            else
            {
                database.Insert(pca);
            }

            PCAList.Add(pca);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePCAAsync(MedsPCA pcaInstance)
        {
            database.Delete<MedsPCA>(pcaInstance.ID);
            return await Task.FromResult(true);
        }
    }
}
