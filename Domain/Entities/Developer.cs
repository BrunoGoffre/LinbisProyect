namespace Domain.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProyectId { get; set; }
        public DateTimeOffset AddedDate { get; set; }
        public int CostByDay { get; set; }
    }
}
