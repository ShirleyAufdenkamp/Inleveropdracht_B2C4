using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Inleveropdracht_B2C4.Models
{
    public class Data
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string User { get; set; }
        public string Image { get; set; }
        public string Picture { get; set; }
        public string Drink { get; set; }
        public int Count { get; set; }
    }
}
