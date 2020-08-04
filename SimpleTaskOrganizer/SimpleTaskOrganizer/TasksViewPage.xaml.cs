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

        private async void MenuItemDelete_Clicked(object sender, EventArgs e)
        {
            var taskInfo = (sender as MenuItem).CommandParameter as Task;
            App.DbTaskListController.RemoveTaskAsync(taskInfo.ID);

            await Navigation.PushAsync(new WaitingPage());
        }
    }
}