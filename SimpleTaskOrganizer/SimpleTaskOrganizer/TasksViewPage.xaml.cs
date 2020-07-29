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

        async private void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskView());
        }
    }
}