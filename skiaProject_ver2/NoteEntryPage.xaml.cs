using System;
using System.IO;
using Xamarin.Forms;
using skiaProject_ver2.Models;

namespace skiaProject_ver2
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}
