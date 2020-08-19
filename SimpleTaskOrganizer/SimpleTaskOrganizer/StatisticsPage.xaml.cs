using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;

namespace SimpleTaskOrganizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        private List<Entry> entries = new List<Entry>();
        private int _complitedTasksNumberInLastSevenDays = 0;

        public StatisticsPage()
        {
            InitializeComponent();

            FillChartWithLastSevenDaysData();
            Chart1.Chart = new BarChart() { Entries = (IEnumerable<ChartEntry>)entries };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NumberOfTaskCompleted.Text = _complitedTasksNumberInLastSevenDays.ToString();          
        }

        private void FillChartWithLastSevenDaysData()
        {
            var dayDate = DateTime.Today;
            for (int i = 7; i >= 1; i--)
            {
                var showedDay = dayDate.AddDays(-i);

                entries.Add(new Entry(App.DbTaskListController.GetNumberOfFinishedTaskInDate(showedDay))
                {
                    Label = dayDate.AddDays(-i).ToString("dd/MM"),
                    Color = SKColor.Parse("#202020"),
                    ValueLabel = App.DbTaskListController.GetNumberOfFinishedTaskInDate(showedDay).ToString()
                });

                _complitedTasksNumberInLastSevenDays += App.DbTaskListController.GetNumberOfFinishedTaskInDate(showedDay);
            }
        }
    }
}