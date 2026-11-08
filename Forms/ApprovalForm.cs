using ClassroomReservationOOP.Data;
using ClassroomReservationOOP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClassroomReservationOOP.Forms
{
    public partial class ApprovalForm : Form
    {
        private readonly User? _currentUser;

       
        public ApprovalForm() : this(null)
        {
        }

        public ApprovalForm(User? currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void ApprovalQueueForm_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            LoadPendingReservations();
        }

        private void SetupGridColumns()
        {
            dgvQueue.AutoGenerateColumns = false;
            dgvQueue.Columns.Clear();

            dgvQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReservationId",
                DataPropertyName = "ReservationId",
                HeaderText = "ID",
                Visible = false
            });

            dgvQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Requester",
                HeaderText = "Requester",
                FillWeight = 22
            });

            dgvQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Role",
                FillWeight = 12
            });

            dgvQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Building",
                HeaderText = "Building",
                FillWeight = 20
            });

            dgvQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Room",
                HeaderText = "Room",
                FillWeight = 14
            });

            dgvQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Date",
                FillWeight = 14
            });

            dgvQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TimeSlot",
                HeaderText = "Time Slot",
                FillWeight = 18
            });
        }

        public void LoadPendingReservations()
        {
            using var db = new AppDbContext();

            var pendingList = db.Reservations
                .Include(r => r.Room)
                    .ThenInclude(room => room!.Building)
                .Include(r => r.User)
                .Where(r => r.Status == "Pending")
                .OrderBy(r => r.Date)
                .ThenBy(r => r.StartTime)
                .Select(r => new
                {
                    ReservationId = r.Id,
                    Requester = r.TeacherName,
                    Role = r.User != null ? r.User.Role : "N/A",
                    Building = (r.Room != null && r.Room.Building != null) ? r.Room.Building.Name : "N/A",
                    Room = r.Room != null ? r.Room.Name : "N/A",
                    Date = r.Date.ToString("yyyy-MM-dd"),
                    TimeSlot = $"{r.StartTime:HH\\:mm} - {r.EndTime:HH\\:mm}"
                })
                .ToList();

            dgvQueue.DataSource = pendingList;

            lblSubtitle.Text = pendingList.Count == 0
                ? "No pending reservations in the queue."
                : $"{pendingList.Count} pending request(s) awaiting review.";
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvQueue.CurrentRow == null)
            {
                MessageBox.Show("Please select a reservation to approve.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservationId = Convert.ToInt32(dgvQueue.CurrentRow.Cells["ReservationId"].Value);
            ApproveReservation(reservationId);
        }

        private void ApproveReservation(int reservationId)
        {
            using var db = new AppDbContext();

            var selectedRes = db.Reservations.Find(reservationId);
            if (selectedRes == null) return;

            // mark approved
            selectedRes.Status = "Approved";

            // auto-reject pending requests 
            var competingRequests = db.Reservations
                .Where(r => r.Id != selectedRes.Id &&
                            r.RoomId == selectedRes.RoomId &&
                            r.Date == selectedRes.Date &&
                            r.StartTime == selectedRes.StartTime &&
                            r.EndTime == selectedRes.EndTime &&
                            r.Status == "Pending")
                .ToList();

            foreach (var competitor in competingRequests)
            {
                competitor.Status = "Rejected";
                competitor.Notes = (competitor.Notes ?? "") + " [Auto-rejected: slot granted to another requester]";
            }

            db.SaveChanges();

            int rejectedCount = competingRequests.Count;
            string msg = rejectedCount > 0
                ? $"Reservation approved for {selectedRes.TeacherName}!\n{rejectedCount} competing request(s) were automatically marked as Rejected."
                : $"Reservation approved for {selectedRes.TeacherName}!";

            MessageBox.Show(msg, "Approval Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadPendingReservations();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvQueue.CurrentRow == null)
            {
                MessageBox.Show("Please select a reservation to reject.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservationId = Convert.ToInt32(dgvQueue.CurrentRow.Cells["ReservationId"].Value);

            using var db = new AppDbContext();
            var res = db.Reservations.Find(reservationId);
            if (res != null)
            {
                res.Status = "Rejected";
                db.SaveChanges();

                MessageBox.Show("Reservation rejected.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingReservations();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingReservations();
        }
    }
}
