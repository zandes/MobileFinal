using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        //public int ID { get; set; }
        public String Name { get; set; }
        public String Type_Line { get; set; }
        public String CMC { get; set; }
        public String Set_Name { get; set; }
        public bool Owned { get; set; }

        //[ForeignKey(typeof(Deck))]
        //public int DeckID { get; set; }

        //[ManyToOne]
        public Deck Deck { get; set; }

        //[ForeignKey(typeof(ImageURIs))]
        //public int ImageID { get; set; }

        //[ManyToOne]
        public ImageURIs Image_URIs { get; set; }

        //[ForeignKey(typeof(PurchaseUris))]
        //public int PurchaseID { get; set; }

        //[ManyToOne]
        public PurchaseUris Purchase_URIs { get; set; }
    }
}
