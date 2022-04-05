using System.ComponentModel.DataAnnotations;

namespace RecruitmentTask.Models
{
    public class EmeraldAccount
    {
        [Key]
        public int Id { get; set; }
        public decimal Funds { get; set; } = 10000;
    }
}
