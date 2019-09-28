using System;

using AppVendas.Models;

namespace AppVendas.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel<Item>
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
