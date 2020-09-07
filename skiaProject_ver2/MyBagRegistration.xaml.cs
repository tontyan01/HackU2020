using System;
using skiaProject_ver2.Models;

using Xamarin.Forms;

namespace skiaProject_ver2
{
    public partial class MyBagRegistration : ContentPage
    {
        public MyBagRegistration()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //listViewに何を入れるか教えてあげるよ
            listView.ItemsSource = await App.Mybagdatabase.GetNotesAsync();
            
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MyBagEntryPage
                {
                    BindingContext = e.SelectedItem as MyBag
                });
            }
        }

        async void OnBagAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyBagEntryPage
            {
                BindingContext = new MyBag()
            });
        }


        async void OnBuyListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuyListPage());

        }
    }
}
