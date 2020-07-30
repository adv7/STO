using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTaskOrganizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksViewPage : ContentPage
    {
        public TasksViewPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CurrentTaskList.ItemsSource = await App.DbTaskListController.GetTasksAsync();
        }

        async private void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskView());
        }

        private void RemoveTaskButton_Clicked(object sender, EventArgs e)
        {
            App.DbTaskListController.RemoveTaskAsync(4);
        }
    }
}