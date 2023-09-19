using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos 
{
    public class PlatformCreateDto 
    {
        private Guid Id { get;  set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Publisher { get; private set; }

        [Required]
        public string CostType { get; private set; }
        public PlatformCreateDto(string name, string publisher, string costType)
        {
            Id = new Guid();
            Name = name;
            Publisher = publisher;
            CostType = costType;
        }
    }
}