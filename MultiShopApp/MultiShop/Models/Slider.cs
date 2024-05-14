using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class Slider : BaseEntity
    {
        [MaxLength(32),Required]
  

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string imgUrl { get; set; }
        public string CreatedBy { get; set; } 
        public int Order {  get; set; }

    }
}
