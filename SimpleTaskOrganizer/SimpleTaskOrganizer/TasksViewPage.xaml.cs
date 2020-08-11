using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (App.DbTaskListController.GetUnfinishedTasksAsync().Result.Count == 0)
            {
                CurrentTaskList.IsVisible = false;
                NoTaskView.IsVisible = true;
            }
            else
            {
                CurrentTaskList.ItemsSource = await App.DbTaskListController.GetUnfinishedTasksAsync();
                CurrentTaskList.IsVisible = true;
                NoTaskView.IsVisible = false;
            }
            base.OnAppearing();
        }

        private async void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage());
        }

        private async void MenuItemDelete_Clicked(object sender, EventArgs e)
        {
            var taskInfo = (sender as MenuItem).CommandParameter as Task;
            await App.DbTaskListController.RemoveTaskAsync(taskInfo);

            await Navigation.PushAsync(new WaitingPage());
        }

        private async void CurrentTaskList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var taskInfo = e.SelectedItem as Task;

            await Navigation.PushAsync(new EditTaskPage(taskInfo));
        }

        private async void TaskComplitedButton_Clicked(object sender, EventArgs e)
        {
            var taskInfo = (sender as Button).CommandParameter as Task;

            taskInfo._isCompleted = true;
            taskInfo._completedDate = DateTime.Today;
            await App.DbTaskListController.UpdateTaskAsync(taskInfo);

            await Navigation.PushAsync(new WaitingPage());
        }
    }
}