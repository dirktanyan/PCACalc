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
        public Command DeletePCA { get; set; }
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
            DeletePCA = new Command(async () =>  
                {
                    MessagingCenter.Send(this, "DeleteItem", thisPCA); // message to PCAViewModel
                    MessagingCenter.Send(this, "UpdatePCAList", thisPCA); // message to PCAvsInjViewModel
                });
        }

        public void SavePCA()
        {
            MessagingCenter.Send(this, "AddItem", thisPCA); // message to PCAViewModel
            MessagingCenter.Send(this, "UpdatePCAList", thisPCA); // message to PCAvsInjViewModel
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

        public string PCADrug
        {
            get { return thisPCA.PCADrug; }
            set
            {
                thisPCA.PCADrug = value;
                OnPropertyChanged(nameof(PCADrug));
            }
        }
        public int ID
        {
            get { return thisPCA.ID; }
            set
            {
                thisPCA.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public int PCAConcn
        {
            get { return thisPCA.PCAConcn; }
            set
            {
                thisPCA.PCAConcn = value;
                OnPropertyChanged(nameof(PCAConcn));
            }
        }
        public string PCAUnits
        {
            get { return thisPCA.PCAUnits; }
            set
            {
                thisPCA.PCAUnits = value;
                OnPropertyChanged(nameof(PCAUnits));
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
