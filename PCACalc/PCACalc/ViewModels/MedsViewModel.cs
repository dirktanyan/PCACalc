﻿using System;
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
    public class MedsViewModel : PCACBaseViewModel
    {
        public ObservableCollection<Med> Medications { get; set; }
        public Command LoadMedsCommand { get; set; }

        public MedsViewModel()
        {
            Medications = new ObservableCollection<Med>();
            LoadMedsCommand = new Command(async () => await ExecuteLoadMedsCommand());

            MessagingCenter.Subscribe<NewMedPage, Med>(this, "AddItem", async (obj, item) =>
            {
                var newMed = item as Med;

                Medications.Add(newMed);
                              
                await DataStore.AddMedicationAsync(newMed);

            });
            MessagingCenter.Subscribe<MedDetailPage, Med>(this, "DeleteItem", async (obj, item) =>
              {
                  var doomedMed = item as Med;
                  Medications.Remove(doomedMed);
                  await DataStore.DeleteMedication(doomedMed.ID);
              });

            MessagingCenter.Subscribe<MedDetailPage, Med>(this, "UpdateItem", async (obj, item) =>
            {
                var updatedMed = item as Med;
                Medications.Remove(updatedMed);
                Medications.Add(updatedMed);
                await DataStore.AddMedicationAsync(updatedMed);
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
                var _meds = await DataStore.GetMedsAsync();
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
