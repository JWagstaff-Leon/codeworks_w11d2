using System.ComponentModel.DataAnnotations;

namespace w11d2.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }

    public class ContractorJobVM : Contractor
    {
        public int JobId { get; set; }
    } 
}