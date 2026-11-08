using ClassroomReservationOOP.Data;
using ClassroomReservationOOP.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClassroomReservationOOP.Forms
{
    public partial class RoomDetailForm : Form
    {
        private readonly Room _room;
        private readonly DateOnly _date;
        private readonly (TimeOnly Start, TimeOnly End, string Display) _slot;
        private readonly User? _currentUser;

       
        public RoomDetailForm(Room room, DateOnly date,
                              (TimeOnly Start, TimeOnly End, string Display) slot,
                              User? currentUser = null)
        {
            InitializeComponent();
            _room = room;
            _date = date;
            _slot = slot;
            _currentUser = currentUser;

            lblHeader.Text = $"{_room.Name} — {_date:MMM dd, yyyy}";
        }

        private void RoomDetailForm_Load(object sender, EventArgs e)
        {
            LoadSlotDetails();
        }

        private void LoadSlotDetails()
        {
            using var db = new AppDbContext();

            // check if slot is already approved by someone else
            var approvedBooking = db.Reservations.FirstOrDefault(r =>
                r.RoomId == _room.Id &&
                r.Date == _date &&
                r.StartTime == _slot.Start &&
                r.EndTime == _slot.End &&
                r.Status == "Approved");

            // number of other pending reservation for this slot
            int pendingCount = db.Reservations.Count(r =>
                r.RoomId == _room.Id &&
                r.Date == _date &&
                r.StartTime == _slot.Start &&
                r.EndTime == _slot.End &&
                r.Status == "Pending");

            bool isApproved = approvedBooking != null;
            bool isAdmin = _currentUser?.Role == "Admin";

            lblSlotInfo.Text = _slot.Display;

          
            if (isAdmin)
            {
                lblStatus.Text = isApproved
                    ? $"Booked by {approvedBooking!.TeacherName} (Approved)"
                    : $"Available — {pendingCount} pending request(s)";
                lblStatus.ForeColor = isApproved ? Color.Crimson : Color.DarkSlateBlue;

                btnReserve.Enabled = false;
                btnReserve.BackColor = SystemColors.ControlLight;
            }
            else if (isApproved)
            {
                lblStatus.Text = $"This slot is already approved for {approvedBooking!.TeacherName}.";
                lblStatus.ForeColor = Color.Crimson;

                btnReserve.Enabled = false;
                btnReserve.BackColor = SystemColors.ControlLight;
            }
            else
            {
                lblStatus.Text = pendingCount > 0
                    ? $"Available — {pendingCount} other request(s) awaiting approval."
                    : "Available — ready to reserve.";
                lblStatus.ForeColor = pendingCount > 0 ? Color.DarkGoldenrod : Color.DarkGreen;

                btnReserve.Enabled = true;
                btnReserve.BackColor = Color.SeaGreen;
                btnReserve.ForeColor = Color.White;
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();

            int? userId = _currentUser?.Id;

            // don't allow duplicate requests
            bool alreadyRequested = db.Reservations.Any(r =>
                r.RoomId == _room.Id &&
                r.Date == _date &&
                r.StartTime == _slot.Start &&
                r.EndTime == _slot.End &&
                r.UserId == userId &&
                r.Status != "Rejected");

            if (alreadyRequested)
            {
                MessageBox.Show(
                    "You have already submitted a request for this room and time slot.",
                    "Duplicate Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reservation = new Reservation
            {
                RoomId = _room.Id,
                UserId = userId,
                Date = _date,
                StartTime = _slot.Start,
                EndTime = _slot.End,
                TeacherName = _currentUser?.FullName ?? "Unknown User",
                Status = "Pending",
                Notes = $"Requested by {_currentUser?.Role}: {_currentUser?.FullName}"
            };

            db.Reservations.Add(reservation);
            db.SaveChanges();

            MessageBox.Show(
                $"Your request for {_room.Name} ({_slot.Display}) on {_date:MMM dd, yyyy} has been submitted.\n\nStatus: PENDING ADMIN APPROVAL.",
                "Request Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
