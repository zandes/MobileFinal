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
    public partial class SearchResultsView : ContentPage
    {
        public SearchResultsView()
        {
            InitializeComponent();
        }

        public SearchResultsView(string search)
        {
            InitializeComponent();
            SearchedCards(search);
        }

        async void SearchedCards(string search)
        {
            SearchResults.ItemsSource = await CardSearch(search);
        }

        async void OnDecksClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeckView());
        }

        async void OnSearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchView());
        }

        async Task<IEnumerable<Card>> CardSearch(String search)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync(search);
            var responseObject = JObject.Parse(response);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Card>>(responseObject["data"].ToString()));
        }

        async void OnCardSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CardView
                {
                    BindingContext = e.SelectedItem as Card
                });
            }
        }
    }
}