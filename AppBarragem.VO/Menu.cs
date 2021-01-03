using System;
using System.Collections.Generic;
using System.Text;

namespace AppBarragem.VO
{
    public class Menu
    {
        public int Id { get; set; }
        public string NameOption { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string ImageClass { get; set; }
        public string ParentId { get; set; }
        public string IsParent { get; set; }
        public string Activeli { get; set; }
        public string Status { get; set; }
    }
}
