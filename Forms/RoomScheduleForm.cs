using ClassroomReservationOOP.Data;
using ClassroomReservationOOP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClassroomReservationOOP.Forms
{
    public partial class RoomScheduleForm : Form
    {
        public RoomScheduleForm()
        {
            InitializeComponent();
        }

        private void RoomScheduleForm_Load(object sender, EventArgs e)
        {
            
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Approved", "Pending", "Rejected" });
            cmbStatusFilter.SelectedIndex = 0;

            
            dtpScheduleDate.Value = DateTime.Today;

            SetupGridColumns();
            LoadSchedule();
        }

        private void SetupGridColumns()
        {
            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.Columns.Clear();

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TimeSlot",
                HeaderText = "Time Slot",
                FillWeight = 18
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Building",
                HeaderText = "Building",
                FillWeight = 22
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Room",
                HeaderText = "Room",
                FillWeight = 15
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Requester",
                HeaderText = "Reserved By",
                FillWeight = 22
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Role",
                FillWeight = 11
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                DataPropertyName = "Status",
                HeaderText = "Status",
                FillWeight = 12
            });
        }

        public void LoadSchedule()
        {
            var selectedDate = DateOnly.FromDateTime(dtpScheduleDate.Value);
            string selectedFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";

            using var db = new AppDbContext();

          
            var query = db.Reservations
                .Include(r => r.Room)
                    .ThenInclude(room => room!.Building)
                .Include(r => r.User)
                .Where(r => r.Date == selectedDate);

            
            if (selectedFilter != "All")
            {
                query = query.Where(r => r.Status == selectedFilter);
            }

            var scheduleList = query
                .OrderBy(r => r.StartTime)
                .ThenBy(r => r.Room != null ? r.Room.BuildingId : 0)
                .ThenBy(r => r.Room != null ? r.Room.Name : "")
                .Select(r => new
                {
                    TimeSlot = $"{r.StartTime:HH\\:mm} - {r.EndTime:HH\\:mm}",
                    Building = (r.Room != null && r.Room.Building != null) ? r.Room.Building.Name : "N/A",
                    Room = r.Room != null ? r.Room.Name : "N/A",
                    Requester = r.TeacherName,
                    Role = r.User != null ? r.User.Role : "N/A",
                    Status = r.Status
                })
                .ToList();

            dgvSchedule.DataSource = scheduleList;

           
            int approvedCount = scheduleList.Count(s => s.Status == "Approved");
            int pendingCount = scheduleList.Count(s => s.Status == "Pending");
            int rejectedCount = scheduleList.Count(s => s.Status == "Rejected");

            lblSummary.Text = $"{scheduleList.Count} total records for {selectedDate:MMM dd, yyyy} " +
                              $"({approvedCount} Approved, {pendingCount} Pending, {rejectedCount} Rejected)";

         
            ApplyStatusFormatting();
        }

        private void ApplyStatusFormatting()
        {
            foreach (DataGridViewRow row in dgvSchedule.Rows)
            {
                
                DataGridViewCell? cell = null;

                if (dgvSchedule.Columns.Contains("colStatus"))
                    cell = row.Cells["colStatus"];
                else if (dgvSchedule.Columns.Contains("Status"))
                    cell = row.Cells["Status"];
                else if (row.Cells.Count >= 6)
                    cell = row.Cells[5]; 

                if (cell == null || cell.Value == null) continue;

                string status = cell.Value.ToString() ?? "";
                cell.Style.Font = new Font(dgvSchedule.Font, FontStyle.Bold);

                if (status == "Approved")
                {
                    cell.Style.ForeColor = Color.DarkGreen;
                }
                else if (status == "Pending")
                {
                    cell.Style.ForeColor = Color.DarkOrange;
                }
                else if (status == "Rejected")
                {
                    cell.Style.ForeColor = Color.Crimson;
                }
            }
        }

        private void dtpScheduleDate_ValueChanged(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpScheduleDate.Value = DateTime.Today;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSchedule();
        }
    }
}
