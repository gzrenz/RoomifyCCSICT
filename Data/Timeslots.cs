namespace ClassroomReservationOOP.Data
{
    public static class TimeSlots
    {
        public static readonly List<(TimeOnly Start, TimeOnly End, string Display)> All = new()
        {
            (new TimeOnly(7, 0),  new TimeOnly(8, 30),  "07:00 - 08:30"),
            (new TimeOnly(8, 30), new TimeOnly(10, 0),  "08:30 - 10:00"),
            (new TimeOnly(10, 0), new TimeOnly(11, 30), "10:00 - 11:30"),
            (new TimeOnly(11, 30), new TimeOnly(13, 0), "11:30 - 13:00"),
            (new TimeOnly(13, 0), new TimeOnly(14, 30), "13:00 - 14:30"),
            (new TimeOnly(14, 30), new TimeOnly(16, 0), "14:30 - 16:00"),
            (new TimeOnly(16, 0), new TimeOnly(17, 30), "16:00 - 17:30")
        };
    }
}