using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test1.Models
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notes : ContentPage
    {
        public Notes()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<note>();
            var files = Directory.EnumerateFiles(App.FolderPath, "*.poznamky.txt");
            foreach (var filename in files)
            {
                notes.Add(new note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }
            listView.ItemsSource = notes
            .OrderBy(d => d.Date)
            .ToList();
        }
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNote
            {
                BindingContext = new note()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddNote
                {
                    BindingContext = e.SelectedItem as note
                });
            }
        }


    }
}