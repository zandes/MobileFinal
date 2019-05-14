using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    public class Deck
    {
        [PrimaryKey, AutoIncrement]
        public string Name {get; set;}
    }
}
