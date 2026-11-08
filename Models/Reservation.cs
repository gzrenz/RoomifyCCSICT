
namespace ClassroomReservationOOP.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; } = null!;
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }   
        public TimeOnly EndTime { get; set; }    
        public string TeacherName { get; set; } = string.Empty;  
        public string? Notes { get; set; }
        public string Status { get; set; } = "Approved";   
        public int? UserId { get; set; }                  
        public User? User { get; set; } = null!;
    }
}
