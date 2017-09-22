using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.HighConcrete.ViewModels
{
    public class HowAreWeDoingModel : PageViewModel<HowAreWeDoingPage>
    {
        public HowAreWeDoingModel(HowAreWeDoingPage currentPage)
            : base(currentPage)
        {
            this.HowAreWeDoingForm = new HowAreWeDoingForm();
        }

        public HowAreWeDoingForm HowAreWeDoingForm{ get; set; }

    }

    public class HowAreWeDoingForm
    {
        [Display(Name = "It was easy to find what I was looking for.")]
        public string EasyToFind { get; set; }

        [Display(Name = "I was able to accomplish everything I wanted to do.")]
        public string Accomplishment { get; set; }

        [Display(Name = "I would recommend this site to others.")]
        public string Recommendation { get; set; }

        [Display(Name = "What would you recommend to make this site work better for you?")]
        public string RecommendationComment { get; set; }
    }
}
