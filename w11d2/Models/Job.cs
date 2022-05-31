using System.ComponentModel.DataAnnotations;

namespace w11d2.Models
{
    public class Job
    {
        public int Id  { get; set; }

        [Required]
        public int ContractorId  { get; set; }

        [Required]
        public int CompanyId  { get; set; }
    }
}