using System;
using System.ComponentModel;
using Xamarin.Forms;
using skiaProject_ver2.Models;
using System.Collections.Generic;
using System.Linq;


namespace skiaProject_ver2
{
    [DesignTimeVisible(true)]
    public partial class BuyListPage : ContentPage
    {
        public BuyListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<ShoppingLineup> Items = await App.Database.GetNotesAsync();
            var checkedItems = Items.Where(x => x.isChecked == true).ToList();
            //listViewに何を入れるか教えてあげる

            list.ItemsSource = checkedItems;


        }
        async void OnCulculationButtonClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new SkiaPage1());

        }
        
        async void OnNotePageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotesPage());
            
        }
    }
}
