using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTaskOrganizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksViewPage : ContentPage
    {
        private int _selectedTaskID;

        public TasksViewPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CurrentTaskList.ItemsSource = await App.DbTaskListController.GetTasksAsync();
        }

        private async void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskView());
        }

        private async void RemoveTaskButton_Clicked(object sender, EventArgs e)
        {
            App.DbTaskListController.RemoveTaskAsync(_selectedTaskID);
            await Navigation.PushAsync(new WaitingPage());
        }

        private void CurrentTaskList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var taskInfo = e.SelectedItem as Task;
            _selectedTaskID = taskInfo.ID;
        }
    }
}