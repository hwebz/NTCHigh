using High.Net.Models.Shared.ListPropertyModel;
using System.Collections.Generic;

namespace High.Net.Web.ViewModels.NewResidential
{
    public class FooterViewModel
    {
        public FooterViewModel()
        {
            FooterInforList = new List<TextInformationModel>();
            LeftIconLinksList = new List<IconLinkModel>();
            RightIconLinksList = new List<IconLinkModel>();
            BottomBarText = string.Empty;
        }
        public IEnumerable<TextInformationModel> FooterInforList { get; set; }

        public IEnumerable<IconLinkModel> LeftIconLinksList { get; set; }

        public IEnumerable<IconLinkModel> RightIconLinksList { get; set; }

        public string BottomBarText { get; set; }
    }
}