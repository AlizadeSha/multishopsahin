using System.ComponentModel.DataAnnotations;

namespace MultiShop.ViewModels.Slider
{
    public class CreateSliderVm
    {
        [MaxLength(32, ErrorMessage = "Başlıq 32 simvoldan çox ola bilməz"), Required]
        public string Title { get; set; }
        [MaxLength(32, ErrorMessage = "Başlıq 32 simvoldan çox ola bilməz"), Required]
        public string Subtitle { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string CreatedBy { get; set; }


    }
}
