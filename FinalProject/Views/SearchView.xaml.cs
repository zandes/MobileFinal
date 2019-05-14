using FinalProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchView : ContentPage
	{
		public SearchView ()
		{
			InitializeComponent ();
		}

        async void OnDecksClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeckView());
        }

        async void OnSearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchView());
        }

        async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchResultsView(CreateSearchString()));
        }

        public string CreateSearchString()
        {
            string SearchString = "https://api.scryfall.com/cards/search?q=";

            if(CardName.Text != null)
            {
                SearchString += CardName.Text;
            }
            if(CardSet.Text != null)
            {
                if(!SearchString[SearchString.Length - 1].Equals("="))
                {
                    SearchString += "+";
                }
                SearchString += ("set:" + CardSet.Text);
            }
            if(CardType.Text != null)
            {
                if(!SearchString[SearchString.Length - 1].Equals("="))
                {
                    SearchString += "+";
                }
                SearchString += ("t:" + CardType.Text);
            }
            if(CardColor.Text != null)
            {
                if(!SearchString[SearchString.Length - 1].Equals("="))
                {
                    SearchString += "+";
                }
                SearchString += ("c:" + CardColor.Text);
            }
            if(CMC.Text != null)
            {
                if(!SearchString[SearchString.Length - 1].Equals("="))
                {
                    SearchString += "+";
                }
                SearchString += ("cmc:" + CMC.Text);
            }

            return SearchString;
        }
	}
}