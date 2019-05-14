using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardView : ContentPage
	{

		public CardView ()
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

        public void OnAddToDeckClicked(object sender, EventArgs e)
        {
            Models.DeckCard temp = new Models.DeckCard
            {
                Name = Name.Text,
                Type_Line = Type.Text,
                CMC = CMC.Text,
                Image = CardImage.Source.ToString().Remove(0, 5),
                Set_Name = Set.Text,
                Purchase = Purchase.Text,
                DeckName = DeckName.Text
            };
            App.Database.SaveCardAsync(temp);

            Navigation.PopAsync();

        }
    }
}