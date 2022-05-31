using System.ComponentModel.DataAnnotations;

namespace w11d2.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class CompanyJobVM : Company
    {
        public int JobId { get; set; }
    }
}