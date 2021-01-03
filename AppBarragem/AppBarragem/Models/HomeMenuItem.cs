using System;
using System.Collections.Generic;
using System.Text;

namespace AppBarragem.Models
{
    public enum MenuItemType
    {
        Browse,
        About, 
        Mapa
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
