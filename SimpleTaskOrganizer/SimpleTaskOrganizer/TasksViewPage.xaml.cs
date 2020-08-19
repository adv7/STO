using System;
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
            await Navigation.PushAsync(new TaskCreator(null));
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

            await Navigation.PushAsync(new TaskCreator(taskInfo));
        }

        private async void TaskComplitedButton_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure it's complited?", "Yes", "No");
            if (response)
            {
                var taskInfo = (sender as Button).CommandParameter as Task;
                taskInfo._isCompleted = true;
                taskInfo._completedDate = DateTime.Today;
                await App.DbTaskListController.UpdateTaskAsync(taskInfo);

                await Navigation.PushAsync(new WaitingPage());
            }
        }
    }
}