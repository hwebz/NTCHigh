using EPiServer.Core;
using System.Collections.Generic;

namespace High.Net.Web.ViewModels.Shared
{
    public class MenuItemViewModel
    {
        public ContentReference PageRef { get; set; }
        public string MenuText { get; set; }
        public string Url { get; set; }

        public bool IsActive { get; set; }

        public List<MenuItemViewModel> Children { get; set; }
    }
}