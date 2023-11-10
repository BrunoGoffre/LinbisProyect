namespace Domain.Entities
{
    public class Proyect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }     
        public DateTimeOffset addedDate { get; set; }
        public int EffortRequiredInDays { get; set; }
    }
}