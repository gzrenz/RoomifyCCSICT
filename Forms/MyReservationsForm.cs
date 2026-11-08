using ClassroomReservationOOP.Data;
using ClassroomReservationOOP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClassroomReservationOOP.Forms
{
    public partial class MyReservationsForm : Form
    {
        private readonly User? _currentUser;

        public MyReservationsForm() : this(null)
        {
        }

        public MyReservationsForm(User? user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void MyReservationsForm_Load(object sender, EventArgs e)
        {
            
            if (_currentUser != null)
            {
                lblTitle.Text = "My Reservations";
                lblSubtitle.Text = $"{_currentUser.FullName} ({_currentUser.Role}) — track the status of your requests.";
            }

            SetupGridColumns();
            LoadUserReservations();
        }

        private void SetupGridColumns()
        {
            dgvMyReservations.AutoGenerateColumns = false;
            dgvMyReservations.Columns.Clear();

            
            dgvMyReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false
            });

            dgvMyReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Building",
                HeaderText = "Building",
                FillWeight = 24
            });

            dgvMyReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Room",
                HeaderText = "Room",
                FillWeight = 15
            });

            dgvMyReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Date",
                FillWeight = 17
            });

            dgvMyReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TimeSlot",
                HeaderText = "Time Slot",
                FillWeight = 21
            });

            dgvMyReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                DataPropertyName = "Status",
                HeaderText = "Status",
                FillWeight = 15
            });
        }

    
        public void LoadUserReservations()
        {
            int targetUserId = _currentUser?.Id ?? 0;
            string targetName = _currentUser?.FullName ?? string.Empty;

            using var db = new AppDbContext();

            var list = db.Reservations
                .Include(r => r.Room)
                    .ThenInclude(room => room!.Building)
                .Where(r =>
                    (targetUserId > 0 && r.UserId == targetUserId) ||
                    (targetUserId == 0 && r.TeacherName == targetName))
                .OrderByDescending(r => r.Date)
                .ThenBy(r => r.StartTime)
                .Select(r => new
                {
                    Id = r.Id,
                    Building = (r.Room != null && r.Room.Building != null)
                                ? r.Room.Building.Name
                                : "N/A",
                    Room = r.Room != null ? r.Room.Name : "N/A",
                    Date = r.Date.ToString("yyyy-MM-dd"),
                    TimeSlot = $"{r.StartTime:HH\\:mm} - {r.EndTime:HH\\:mm}",
                    Status = r.Status
                })
                .ToList();

            dgvMyReservations.DataSource = list;

            int approved = list.Count(x => x.Status == "Approved");
            int pending = list.Count(x => x.Status == "Pending");
            int rejected = list.Count(x => x.Status == "Rejected");

            if (list.Count == 0)
            {
                lblSubtitle.Text = "You have no reservations yet. Go to 'Reserve a Room' to submit a request.";
            }
            else
            {
                lblSubtitle.Text = $"{list.Count} reservation(s) — {approved} Approved, {pending} Pending, {rejected} Rejected.";
            }

            ApplyStatusFormatting();
            btnClearRejected.Enabled = list.Any(x => x.Status == "Rejected");
            btnClearRejected.ForeColor = btnClearRejected.Enabled
                ? Color.Crimson
                : Color.Gray;
        }

    
        private void ApplyStatusFormatting()
        {
            foreach (DataGridViewRow row in dgvMyReservations.Rows)
            {
               
                DataGridViewCell? cell = null;

                if (dgvMyReservations.Columns.Contains("colStatus"))
                    cell = row.Cells["colStatus"];
                else if (dgvMyReservations.Columns.Contains("Status"))
                    cell = row.Cells["Status"];
                else if (row.Cells.Count >= 6)
                    cell = row.Cells[5];

                if (cell?.Value == null) continue;

                string status = cell.Value.ToString() ?? "";
                cell.Style.Font = new Font(dgvMyReservations.Font, FontStyle.Bold);

                cell.Style.ForeColor = status switch
                {
                    "Approved" => Color.DarkGreen,
                    "Pending" => Color.DarkOrange,
                    "Rejected" => Color.Crimson,
                    _ => Color.Black
                };
            }
        }

        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserReservations();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvMyReservations.CurrentRow == null)
            {
                MessageBox.Show("Please select a reservation to cancel.",
                    "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservationId = Convert.ToInt32(dgvMyReservations.CurrentRow.Cells["Id"].Value);
            string currentStatus = dgvMyReservations.CurrentRow.Cells["colStatus"].Value?.ToString() ?? "";

            
            if (currentStatus == "Approved")
            {
                MessageBox.Show("This reservation is already approved. Please contact an administrator to cancel it.",
                    "Cannot Cancel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to cancel this reservation request?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using var db = new AppDbContext();
            var res = db.Reservations.Find(reservationId);

            if (res != null)
            {
                db.Reservations.Remove(res);
                db.SaveChanges();

                MessageBox.Show("Reservation cancelled successfully.",
                    "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUserReservations();
            }
        }

        private void btnClearRejected_Click(object sender, EventArgs e)
        {
            if (_currentUser == null) return;

            using var db = new AppDbContext();

            
            var rejected = db.Reservations
                .Where(r => r.UserId == _currentUser.Id && r.Status == "Rejected")
                .ToList();

            if (rejected.Count == 0)
            {
                MessageBox.Show("You have no rejected reservations to clear.",
                    "Nothing to Clear", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            var confirm = MessageBox.Show(
                $"Remove {rejected.Count} rejected reservation(s) from your list?\n\nThis cannot be undone.",
                "Clear Rejected",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            
            db.Reservations.RemoveRange(rejected);
            db.SaveChanges();

            MessageBox.Show($"{rejected.Count} rejected reservation(s) removed.",
                "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadUserReservations();
        }
    }
}
