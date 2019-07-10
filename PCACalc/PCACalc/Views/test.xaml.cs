using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class test : ContentPage
    {
        public test()
        {
            DataModel mydatamodel = new DataModel();
            InitializeComponent();
        }

        public class DataModel
        {

            public ObservableCollection<ChartDataPoint> HighTemperature { get; set; }

            public DataModel()
            {

                HighTemperature = new ObservableCollection<ChartDataPoint>();

                HighTemperature.Add(new ChartDataPoint("Jan", 42));
                HighTemperature.Add(new ChartDataPoint("Feb", 44));
                HighTemperature.Add(new ChartDataPoint("Mar", 53));
                HighTemperature.Add(new ChartDataPoint("Apr", 64));
                HighTemperature.Add(new ChartDataPoint("May", 75));
                HighTemperature.Add(new ChartDataPoint("Jun", 83));
                HighTemperature.Add(new ChartDataPoint("Jul", 87));
                HighTemperature.Add(new ChartDataPoint("Aug", 84));
                HighTemperature.Add(new ChartDataPoint("Sep", 78));
                HighTemperature.Add(new ChartDataPoint("Oct", 67));
                HighTemperature.Add(new ChartDataPoint("Nov", 55));
                HighTemperature.Add(new ChartDataPoint("Dec", 45));

            }

        }
    }
}