
using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Platform 
    {
        [Key]
        [Required]
        public Guid Id { get; private set; }
        
        [Required]
        public string Name { get; private set; }
        
        [Required]
        public string Publisher { get; private set; }
        
        [Required]
        public string CostType { get; private set; }

        public Platform(Guid id, string name, string publisher, string costType)
        {
            Id = id;
            Name = name;
            Publisher = publisher;
            CostType = costType;
        }
    }
}