using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    public class DeckCard
    {
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public String Name { get; set; }
        public String Type_Line { get; set; }
        public String CMC { get; set; }
        public String Set_Name { get; set; }
        public bool Owned { get; set; }
        public string Image {get; set;}
        public string Purchase {get; set;}
        public string DeckName {get; set;}
    }
}
