using System;
using Urho;
using Urho.Forms;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using skiaProject_ver2.Simulation;
using skiaProject_ver2.Models;

namespace skiaProject_ver2
{

    public class UrhoPage : ContentPage
    {
        UrhoSurface urhoSurface;
        Charts urhoApp;

        public UrhoPage()
        {
            urhoSurface = new UrhoSurface();
            urhoSurface.VerticalOptions = LayoutOptions.FillAndExpand;
            Title = " UrhoSharp + Xamarin.Forms";
            var picker = new Picker { Title = "Select a layer"};
            var pikeritemID = new List<string>() { "1", "2", "3"};
			picker.SelectedIndex = 1;
			picker.ItemsSource = pikeritemID;
			picker.SelectedIndexChanged += (sender, e) =>
			{
				int selectedIndex = picker.SelectedIndex;
				if (selectedIndex != -1)
				{
                    this.PikerID = picker.Items[selectedIndex];
                    System.Console.WriteLine("PikerID in urhopage");
                    System.Console.WriteLine(picker.Items[selectedIndex]);
                    //getpikerLayer();
                    System.Console.WriteLine(PikerID);
					if (this.PikerID != null)
					{
						urhoApp.pikerLayer = this.PikerID;
						System.Console.WriteLine("starturhoApp");
						System.Console.WriteLine(this.PikerID);
						System.Console.WriteLine(urhoApp.pikerLayer);
						urhoApp.Simulation();
					}
                }
			};

			Content = new StackLayout
            {
                Padding = new Thickness(12, 12, 12, 40),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    urhoSurface,
                    new Label { Text = "Layer", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                    picker,
                }
            };
        }

		public string PikerID
		{
			get;
			set;
		}

		public int layer = 0;

		protected override void OnDisappearing()
        {
            UrhoSurface.OnDestroy();
            base.OnDisappearing();
        }

        protected override async void OnAppearing()
        {
			StartUrhoApp();  
        }

        async void StartUrhoApp()
        {
			urhoApp = await urhoSurface.Show<Charts>(new ApplicationOptions(assetsFolder: null) { Orientation = ApplicationOptions.OrientationType.LandscapeAndPortrait });
		}
	}
}
