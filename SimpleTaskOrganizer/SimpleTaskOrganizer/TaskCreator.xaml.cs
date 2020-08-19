using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTaskOrganizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskCreator : ContentPage
    {
        private Task _task;
        private bool _isNewTask = true;

        public TaskCreator(Task task)
        {
            InitializeComponent();

            _task = task;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_task != null)
            {
                _isNewTask = false;
                PrioritySlider.Value = _task._prioriyty;
                TaskDescription.Text = _task._description;
            }
            else
            {
                _isNewTask = true;
                PrioritySlider.Value = 3;
                _task = new Task();
            }
        }

        private void PrioritySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double StepValue = 1.0;
            var newStep = Math.Round(e.NewValue / StepValue);
            PrioritySlider.Value = newStep * StepValue;
        }

        private async void ConfirmationTaskEdit_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TaskDescription.Text))
            {
                TaskDescriptionInfo.IsVisible = false;
                TaskDescriptionEmptyValidation.IsVisible = true;
            }
            else
            {
                _task._description = TaskDescription.Text;
                _task._prioriyty = (byte)PrioritySlider.Value;

                if (_isNewTask) 
                    await App.DbTaskListController.SaveTaskAsync(_task);
                else 
                    await App.DbTaskListController.UpdateTaskAsync(_task);

                await Navigation.PopAsync();
            }
        }
    }
}