using System.ComponentModel.DataAnnotations;

namespace MultiShop.ViewModels.Slider
{
    public class SliderVM
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string imgUrl { get; set; }
        public string CreatedBy { get; set; }
    }
}
