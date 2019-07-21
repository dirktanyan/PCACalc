using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using PCACalc.Models;
using PCACalc.Views;

using Xamarin.Forms;

namespace PCACalc.ViewModels
{
    public class InjViewModel : PCACBaseViewModel
    {
        public ObservableCollection<Med> Medications { get; set; }
        public Command LoadMedsCommand { get; set; }

        public InjViewModel()
        {
            Medications = new ObservableCollection<Med>();
            LoadMedsCommand = new Command(async () => await ExecuteLoadMedsCommand());

            MessagingCenter.Subscribe<InjDetailViewModel, Med>(this, "AddItem", async (obj, item) =>
            {
                var newMed = item as Med;

                Medications.Add(newMed);
                              
                await InjDataStore.AddMedicationAsync(newMed);

            });
            MessagingCenter.Subscribe<InjDetailViewModel, Med>(this, "DeleteItem", async (obj, item) =>
              {
                  var doomedMed = item as Med;
                  Medications.Remove(doomedMed);
                  await InjDataStore.DeleteMedication(doomedMed.ID);
              });

            MessagingCenter.Subscribe<InjDetailViewModel, Med>(this, "UpdateItem", async (obj, item) =>
            {
                var updatedMed = item as Med;
                Medications.Remove(updatedMed);
                Medications.Add(updatedMed);
                await InjDataStore.AddMedicationAsync(updatedMed);
            });

        }

        async Task ExecuteLoadMedsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Medications.Clear();
                var _meds = await InjDataStore.GetMedsAsync();
                foreach (var _med in _meds)
                {
                    Medications.Add(_med);
                }
            }
            catch(Exception ex)
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
