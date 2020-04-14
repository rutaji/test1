using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test1.Models
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNote : ContentPage
    {
        public AddNote()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                // Uložení poznámky
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.poznamky.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                // Editace poznámky
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (note)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Navigation.PopAsync();
        }

    }
}