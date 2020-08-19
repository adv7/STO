using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTaskOrganizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaitingPage : ContentPage
    {
        public WaitingPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Navigation.PopAsync();
        }
    }
}