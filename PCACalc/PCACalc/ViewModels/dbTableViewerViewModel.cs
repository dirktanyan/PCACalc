using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PCACalc.Models;
using PCACalc.Services;
using Xamarin.Forms;

namespace PCACalc.ViewModels
{
    public class dbTableViewerViewModel : PCACBaseViewModel
    {
        public ObservableCollection<PCABags> BagList { get; set; }
        public Command LoadBagsCommand { get; set; }

        public dbTableViewerViewModel()
        {
            BagList = new ObservableCollection<PCABags>();
            LoadBagsCommand = new Command(async () => await ExecuteLoadBagsCommand());
        }

        async Task ExecuteLoadBagsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                BagList.Clear();
                var _bags = await PCADataStore.GetAllPCABagsAsync();
                foreach (var _bag in _bags)
                {
                    BagList.Add(_bag);
                }
            }
            catch (Exception ex)
            {
                //do nothing, just don't crash
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
