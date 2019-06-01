﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCACalc;
using System.Diagnostics;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConcentrationPage : ContentPage
    {
        private string unitOfMeasure = "mg";
        public ConcentrationPage()
        {
            InitializeComponent();
        }

        private bool checkEntries()
        {
            if(BasalEntry.Text != null)
            {
                if(BolusEntry.Text != null)
                {
                    if(BolusMinEntry.Text != null)
                    {
                        if(BagVolumeEntry.Text != null)
                        {
                            return true;
                        } else { return false; }
                    } else { return false; }
                } else { return false; }
            } else { return false; }
        }
        private void CalcConcentration(object sender, EventArgs e)
        {
            double totalPerHour;
            double totalPerDay;
            double totalPerDS;
            double bagVolume;
            double suggestedConcentration;

            if (checkEntries() == true)
            {
                try
                {
                    totalPerHour = Calculations.CalcTPH(double.Parse(BasalEntry.Text), double.Parse(BolusEntry.Text), double.Parse(BolusMinEntry.Text));
                    TPHEntry.Text = totalPerHour.ToString() + unitOfMeasure;

                    totalPerDay = totalPerHour * 24;
                    TPDEntry.Text = totalPerDay.ToString() + unitOfMeasure;

                    totalPerDS = totalPerDay * StepDays.Value;
                    TP5DEntry.Text = totalPerDS.ToString() + unitOfMeasure;

                    bagVolume = double.Parse(BagVolumeEntry.Text);
                    suggestedConcentration = Math.Round(totalPerDS / bagVolume, 0);


                    SugConcEntry.Text = suggestedConcentration.ToString() + unitOfMeasure;
                }
                catch
                {
                    //Don't do anything, just don't crash
                }
            }
        }

        private void selectUOM(object sender, ToggledEventArgs e)
        {
            if (sender.Equals(SwitchMG))
            {
                if (SwitchMG.IsToggled == true)
                {
                    SwitchMCG.IsToggled = false;
                    unitOfMeasure = "mg";
                    BasalMeasure.Text = "mg";
                    BolusMeasure.Text = "mg";
                }
                else
                {
                    SwitchMCG.IsToggled = true;
                    unitOfMeasure = "mcg";
                    BasalMeasure.Text = "mcg";
                    BolusMeasure.Text = "mcg";
                }
            }
            else
            {
                if(SwitchMCG.IsToggled == true)
                {
                    SwitchMG.IsToggled = false;
                    unitOfMeasure = "mcg";
                    BasalMeasure.Text = "mcg";
                    BolusMeasure.Text = "mcg";
                }
                else
                {
                    SwitchMG.IsToggled = true;
                    unitOfMeasure = "mg";
                    BasalMeasure.Text = "mg";
                    BolusMeasure.Text = "mg";
                }
            }
        }

        private void StepDays_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            CalcConcentration(sender, e);
        }
    }
}