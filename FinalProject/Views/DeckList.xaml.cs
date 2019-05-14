using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeckList : ContentPage
    {
        public DeckList()
        {
            InitializeComponent();
        }

        async void OnDecksClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeckView());
        }

        async void OnSearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchView());
        }

        public DeckList(string DeckName)
        {
            InitializeComponent();
            Testing(DeckName);
        }

        async void Testing(string DeckName)
        {
            DeckCards.ItemsSource = await App.Database.GetDeckCardsAsync(DeckName);
        }

        public void OnBuyClicked(object sender, EventArgs e)
        {

            var SItem = (DeckCard)((Button)sender).CommandParameter;
            UriKind kind = 0;
            System.Uri.TryCreate(SItem.Purchase, kind, out Uri Uri);
            Device.OpenUri(Uri);
        }
    }
}