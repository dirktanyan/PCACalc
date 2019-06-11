﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCACalc.Models;
using PCACalc.Services;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMedPage : ContentPage
    {
        public Med Medication { get; set; }
        private MedsDataAccess dataaccess;
        public NewMedPage()
        {
            InitializeComponent();

            Medication = new Med
            {
                Name = "Medication Name",
                VialSize = 1,
                VialConcentration = 2,
                VialPrice = 1.00M
            };

            dataaccess = new MedsDataAccess();

            BindingContext = this;
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //this.dataaccess.SaveMedication(Medication);
            MessagingCenter.Send(this, "AddItem", Medication);
            await Navigation.PopModalAsync();
        }

    }
}