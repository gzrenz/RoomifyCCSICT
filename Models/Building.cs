namespace ClassroomReservationOOP.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Room> Rooms { get; set; } = new();
    }
}
