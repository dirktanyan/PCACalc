using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PCACalc.Models;
using PCACalc.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PCACalc.Views;
using System.Diagnostics;

namespace PCACalc.ViewModels
{
    public class PCADetailViewModel : INotifyPropertyChanged
    {
        public PCA thisPCA { get; set; }
        public PCADataAccess PCADataStore = new PCADataAccess();
        public ObservableCollection<PCABags> thisPCABagList { get; set; }
        public Command LoadAssocPCABags { get; set; }
        public PCADetailViewModel(PCA pca = null)
        {
            if (pca == null)
            {
                thisPCA = new PCA();
            }
            else
            {
                thisPCA = pca;
            }

            thisPCABagList = new ObservableCollection<PCABags>();

            LoadAssocPCABags = new Command(async () => await LoadAssociatedPCABags());
        }

        public async Task<bool> AddUpdatePCABag(PCABags bag)
        {
            if (bag.ID == 0)
            {
                thisPCABagList.Add(bag);
            }
            else
            {
                thisPCABagList.Remove(bag);
                thisPCABagList.Add(bag);
            }

            await PCADataStore.AddPCABagAsync(bag);
            return await Task.FromResult(true);
        } 

        public async Task<bool> DeletePCABag(PCABags doomedPCA)
        {
            await PCADataStore.DeletePCABagAsync(doomedPCA);
            return await Task.FromResult(true);
        }
        async Task LoadAssociatedPCABags()
        {
            try
            {
                thisPCABagList.Clear();
                var _pcas = await PCADataStore.GetPCABagsAsync(thisPCA.ID);
                foreach (var _pca in _pcas)
                {
                    thisPCABagList.Add(_pca);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
