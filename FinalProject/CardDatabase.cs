using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using SQLite;

namespace FinalProject
{
    public class CardDatabase
    {
        readonly SQLiteAsyncConnection database;

        public CardDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            //database.CreateTableAsync<Card>().Wait();
            database.CreateTableAsync<DeckCard>().Wait();
            //database.CreateTableAsync<PurchaseUris>().Wait();
            //database.CreateTableAsync<ImageURIs>().Wait();
            //SaveDeckAsync(new Deck() { Name = "Deck 1" });
            //SaveDeckAsync(new Deck() { Name = "Deck 2" });

            //SaveCardAsync(new Card() { Name = "Jace", CMC = "3", Type_Line = "Spell", Set_Name = "Unstable", Owned = false });
            //SaveCardAsync(new Card() { Name = "Jace2", CMC = "3", Type_Line = "Spell2", Set_Name = "Unstable2", Owned = false });
            //SaveCardAsync(new Card() { Name = "Jace3", CMC = "3", Type_Line = "Spell3", Set_Name = "Unstable3", Owned = false });
            //SaveCardAsync(new Card() { Name = "Jace4", CMC = "3", Type_Line = "Spell4", Set_Name = "Unstable4", Owned = false });
            //SaveCardAsync(new DeckCard() {DeckName = "Deck1"});
        }

        internal async Task<List<Card>> GetAllCardsAsync()
        {
            return await database.Table<Card>().ToListAsync();
        }

        internal async Task<List<DeckCard>> GetAllDecksAsync()
        {
            return await database.QueryAsync<DeckCard>("SELECT DISTINCT [DeckName] FROM [DeckCard] ORDER BY [DeckName]");
        }

        internal async Task<List<DeckCard>> GetDeckCardsAsync(string DeckName)
        {
            try
            {
                return await database.QueryAsync<DeckCard>("SELECT * FROM [DeckCard] WHERE [DeckName] = '" + DeckName + "'");
            }
            catch(SQLiteException e)
            {
                Console.WriteLine("ERROR IS HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + e.Message + " " + e.StackTrace);
            }

            return await database.QueryAsync<DeckCard>("SELECT [DeckName] FROM [DeckCard]");
        }

        public Task<int> SaveCardAsync(DeckCard card)
        {
            return database.InsertAsync(card);   
        }

        public Task<int> SaveDeckAsync(Deck deck)
        {
            return database.InsertAsync(deck);
        }
    }
}
