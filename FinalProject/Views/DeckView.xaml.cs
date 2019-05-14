using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; 

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FinalProject.Services;
using FinalProject.Models;
using FinalProject.Views;

namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeckView : ContentPage
	{
		public DeckView ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            DeckNames.ItemsSource = await App.Database.GetAllDecksAsync();
        }

        async void OnDecksClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeckView());
        }

        async void OnSearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchView());
        }
        
        async void OnDeckSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var deck = (DeckCard)e.SelectedItem;
            //if(deck != null)
            //{
                await Navigation.PushAsync(new DeckList(deck.DeckName));
                //{
                //    BindingContext = App.Database.GetAllDecksAsync(/*deck.DeckName*/)
                //});
            //}
        }

	}
}