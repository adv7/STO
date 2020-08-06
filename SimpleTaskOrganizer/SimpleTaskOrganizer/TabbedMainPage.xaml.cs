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
    public partial class TabbedMainPage : TabbedPage
    {
        public TabbedMainPage()
        {
            InitializeComponent();

            this.BarBackgroundColor = Color.White;
            this.BarTextColor = Color.FromHex("#696969");
            this.Children.Add(new TasksViewPage());
            this.Children.Add(new StatisticsPage());
        }
    }
}