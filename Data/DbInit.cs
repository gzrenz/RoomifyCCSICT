using ClassroomReservationOOP.Data;
using ClassroomReservationOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassroomReservationOOP.Data
{
    public static class DbInit
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Create Fake Buildings & Rooms
            if (!context.Buildings.Any())
            {
                var buildingA = new Building
                {
                    Name = "Building A (IT & Engineering)",
                    Rooms = new List<Room>
                    {
                        new Room { Name = "Lab 101" },
                        new Room { Name = "Lab 102" },
                        new Room { Name = "Room 201" },
                        new Room { Name = "Room 202" }
                    }
                };

                var buildingB = new Building
                {
                    Name = "Building B (General Academics)",
                    Rooms = new List<Room>
                    {
                        new Room { Name = "Lecture Hall B1" },
                        new Room { Name = "Lecture Hall B2" },
                        new Room { Name = "Room 301" },
                        new Room { Name = "Room 302" }
                    }
                };

                context.Buildings.AddRange(buildingA, buildingB);
                context.SaveChanges();
            }

           
            // fake accounts for testing:
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Username = "admin", Password = "123", FullName = "System Admin", Role = "Admin", Email = "admin@college.edu" },
                    new User { Username = "teacher", Password = "123", FullName = "Prof. Alan Smith", Role = "Teacher", Email = "teacher@college.edu" },
                    new User { Username = "student", Password = "123", FullName = "Juan Dela Cruz", Role = "Student", Email = "student@college.edu" }
                );
                context.SaveChanges();
            }


            // Fake reservations for testing
            if (!context.Reservations.Any())
            {
                var rooms = context.Rooms.Take(2).ToList();
                var teacher = context.Users.FirstOrDefault(u => u.Role == "Teacher");

                if (rooms.Count >= 2 && teacher != null)
                {
                    var today = DateOnly.FromDateTime(DateTime.Today);

                    context.Reservations.AddRange(
                        new Reservation
                        {
                            RoomId = rooms[0].Id,
                            UserId = teacher.Id,
                            Date = today,
                            StartTime = new TimeOnly(7, 0),
                            EndTime = new TimeOnly(8, 30),
                            TeacherName = teacher.FullName,
                            Status = "Approved",
                            Notes = "CS101 Lecture"
                        },
                        new Reservation
                        {
                            RoomId = rooms[1].Id,
                            UserId = teacher.Id,
                            Date = today,
                            StartTime = new TimeOnly(7, 0),
                            EndTime = new TimeOnly(8, 30),
                            TeacherName = "Dr. Clara Johnson",
                            Status = "Approved",
                            Notes = "Physics Lab"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
