using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Contracts.Generic
{
    public class MenuConstractResponse
    {
        public MenuConstractResponse()
        {
            MenuItem = new List<Item>();
        }
        public List<Item> MenuItem { get; set; }
    }
    public class Item
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }

    }
}
