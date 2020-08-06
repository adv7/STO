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
    public partial class EditTaskPage : ContentPage
    {
        private Task _task;

        public EditTaskPage(Task task)
        {
            InitializeComponent();

            _task = task;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            PrioritySlider.Value = _task._prioriyty;
            TaskDescription.Text = _task._description;
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

                await App.DbTaskListController.UpdateTaskAsync(_task);

                await Navigation.PopAsync();
            }
        }
    }
}