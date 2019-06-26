using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using PCACalc.Models;
using PCACalc.Views;

using Xamarin.Forms;

namespace PCACalc.ViewModels
{
    class PCAViewModel : PCACBaseViewModel
    {
        public ObservableCollection<PCA> PCAs { get; set; }
        public Command LoadPCAsCommand { get; set; }

        public PCAViewModel()
        {
            PCAs = new ObservableCollection<PCA>();
            LoadPCAsCommand = new Command(async () => await ExecuteLoadMedsCommand());

            MessagingCenter.Subscribe<PCADetailPage, PCA>(this, "AddItem", async (obj, item) =>
            {
                var newPCA = item as PCA;

                if(newPCA.ID == 0)
                {
                    PCAs.Add(newPCA);
                }
                else
                {
                    PCAs.Remove(newPCA);
                    PCAs.Add(newPCA);
                }
                    
                await PCADataStore.AddPCAAsync(newPCA);

            });
            MessagingCenter.Subscribe<PCADetailPage, PCA>(this, "DeleteItem", async (obj, item) =>
            {
                var doomedPCA = item as PCA;
                PCAs.Remove(doomedPCA);
                await PCADataStore.DeletePCAAsync(doomedPCA);
            });

            MessagingCenter.Subscribe<PCADetailPage, PCA>(this, "UpdateItem", async (obj, item) =>
            {
                var updatedPCA = item as PCA;
                PCAs.Remove(updatedPCA);
                PCAs.Add(updatedPCA);
                await PCADataStore.AddPCAAsync(updatedPCA);
            });

        }

        async Task ExecuteLoadMedsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                PCAs.Clear();
                var _pcas = await PCADataStore.GetPCAsAsync();
                foreach (var _pca in _pcas)
                {
                    PCAs.Add(_pca);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
