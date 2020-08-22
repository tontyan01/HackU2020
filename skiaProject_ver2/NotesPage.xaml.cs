﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using skiaProject_ver2.Models;

namespace skiaProject_ver2
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnGoButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SkiaPage1
            {
                //BindingContext = new Note()
            });
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}
