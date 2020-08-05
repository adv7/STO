using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTaskOrganizer
{
    public partial class App : Application
    {
        static DbTaskListController dbTaskListController;

        public static DbTaskListController DbTaskListController
        {
            get
            {
                if (dbTaskListController == null)
                {
                    dbTaskListController = new DbTaskListController(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.db3"));
                }
                return dbTaskListController;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new AddTaskView());
            MainPage = new NavigationPage(new TabbedMainPage())
            {
                BarBackgroundColor = Color.FromHex("#202020"),
                BarTextColor = Color.FromHex("#C8C8C8")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
