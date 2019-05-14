using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using System.Linq;

namespace FinalProject.Services
{
    public class CardCall //: ICardCall
    {
        public async void GetCards()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://api.scryfall.com/cards/search?q=c%3Awhite+cmc%3D1");
            var responseObject = JObject.Parse(response);
            IList<JToken> results = responseObject["responseData"]["results"].Children().ToList();
            IList<Card> searchResults = new List<Card>();
            foreach(JToken result in results)
            {
                Card card = result.ToObject<Card>();
                searchResults.Add(card);
            }

            //return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Card>>(responseObject["data"]["response"].ToString()));
        }
    }
}
