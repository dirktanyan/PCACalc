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
        public SQLiteConnection database;
        public ObservableCollection<PCA> PCAList { get; set; }
        public ObservableCollection<PCABags> PCABagsList { get; set; }

        public PCADataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<PCA>();
            database.CreateTable<PCABags>();

            this.PCAList = new ObservableCollection<PCA>(database.Query<PCA>("SELECT * FROM PCA ORDER BY PCADrug"));
            this.PCABagsList = new ObservableCollection<PCABags>(database.Table<PCABags>());

            // If the table is empty, initialize the collection
            if (!database.Table<PCA>().Any())
            {
                InitializePCAList();
            }

            if (!database.Table<PCABags>().Any())
            {
                InitializePCABagsList();
            }
        }

        private void InitializePCAList()
        {
            this.PCAList.Add(new PCA
            {
                PCADrug = "Morphine",
                PCAConcn = 6,
                PCAUnits= "mg",
            });
        }

        private void InitializePCABagsList()
        {
            this.PCABagsList.Add(new PCABags
            {
                FK_PCAID = PCAList.FirstOrDefault().ID,
                PCASize = 250,
                PCAPrice = 300.00m
            });
        }

        // Get list of PCAs
        public List<PCA> GetPCAList()
        {
            return (from data in database.Table<PCA>() select data).OrderBy(t => t.PCAFullName).ToList();
        }
        public async Task<ObservableCollection<PCA>> GetPCAsAsync()
        {
            return await Task.FromResult(PCAList);
        }

        public async Task<ObservableCollection<PCABags>> GetPCABagsAsync(int intPCAID)
        {
            PCABagsList = new ObservableCollection<PCABags>(database.Query<PCABags>("Select * from PCABags Where FK_PCAID=? ORDER BY PCASize", intPCAID));
            return await Task.FromResult(PCABagsList);
        }

        public async Task<ObservableCollection<PCABags>> GetAllPCABagsAsync()
        {
            PCABagsList = new ObservableCollection<PCABags>(database.Query<PCABags>("Select * from PCABags"));
            return await Task.FromResult(PCABagsList);
        }

        public async Task<bool> AddPCAAsync(PCA pca)
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

        public async Task<bool> AddPCABagAsync(PCABags pcaBagInstance)
        {
            if (pcaBagInstance.ID != 0)
            {
                database.Update(pcaBagInstance);
            }
            else
            {
                database.Insert(pcaBagInstance);
            }

            PCABagsList.Add(pcaBagInstance);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePCAAsync(PCA pcaInstance)
        {
            database.Execute("DELETE FROM PCABags WHERE FK_PCAID=?", pcaInstance.ID);

            database.Delete<PCA>(pcaInstance.ID);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePCABagAsync(PCABags pcaBagInstance)
        {
            database.Delete<PCABags>(pcaBagInstance.ID);
            return await Task.FromResult(true);
        }
    }
}
