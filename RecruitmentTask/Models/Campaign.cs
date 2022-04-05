using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RecruitmentTask.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Keywords { get; set; }
        [Required]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        [DisplayName("Bid Amount")]
        public decimal BidAmount { get; set; }
        [Required]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        [DisplayName("Campaign Fund")]
        public decimal CampaignFund { get; set; }
        [Required] 
        public Status Status { get; set; } = Status.On;
        public string Town { get; set; } = "None";
        [Required]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal Radius { get; set; }
    }

}
