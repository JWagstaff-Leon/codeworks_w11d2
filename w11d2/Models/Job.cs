using System.ComponentModel.DataAnnotations;

namespace w11d2.Models
{
    public class Job
    {
        public int Id;

        [Required]
        public int ContractorId;

        [Required]
        public int CompanyId;
    }
}