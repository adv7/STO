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
    public partial class AddTaskView : ContentPage
    {
        public AddTaskView()
        {
            InitializeComponent();
        }

        async private void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void PrioritySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double StepValue = 1.0;
            var newStep = Math.Round(e.NewValue / StepValue);
            PrioritySlider.Value = newStep * StepValue;
        }

        async private void ConfirmationTaskAdd_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TaskDescription.Text))
            {
                TaskDescriptionInfo.IsVisible = false;
                TaskDescriptionEmptyValidation.IsVisible = true;
            }
            else
            {
                await App.DbTaskListController.SaveTaskAsync(new Task
                {
                    _description = TaskDescription.Text,
                    _prioriyty = (byte)PrioritySlider.Value
                });

                await Navigation.PopAsync();
            }
        }
    }
}