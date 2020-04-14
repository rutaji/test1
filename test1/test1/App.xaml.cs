using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using test1.Models;
using System.IO;

namespace test1
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new Notes());

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
