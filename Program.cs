using ClassroomReservationOOP.Data;
using ClassroomReservationOOP.Forms;

namespace ClassroomReservationOOP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var db = new AppDbContext())
            {
                DbInit.Initialize(db);
            }

            Application.Run(new LoginForm());
        }
    }
}