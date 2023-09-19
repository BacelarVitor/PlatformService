namespace PlatformService.Dtos 
{
    public class PlatformReadDto
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Publisher { get; private set; }
        public string CostType { get; private set; }
        public PlatformReadDto(Guid id, string name, string publisher, string costType)
        {
            Id = id;
            Name = name;
            Publisher = publisher;
            CostType = costType;
        }
    }
}