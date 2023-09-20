using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos 
{
    public class PlatformCreateDto 
    {
        public Guid Id { get;  private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Publisher { get; private set; }

        [Required]
        public string CostType { get; private set; }
        public PlatformCreateDto(string name, string publisher, string costType)
        {
            Id = Guid.NewGuid();
            Name = name;
            Publisher = publisher;
            CostType = costType;
        }
    }
}