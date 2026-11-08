using ClassroomReservationOOP.Data;
using ClassroomReservationOOP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassroomReservationOOP.Forms
{
    public partial class MainReservationForm : Form

    {
        private DateTime _currentDate;
        private readonly User? _currentUser;
        public DateOnly SelectedDate { get; private set; }
        public (TimeOnly Start, TimeOnly End, string Display)? SelectedSlot { get; private set; }

        public MainReservationForm(User? currentUser = null)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _currentDate = DateTime.Today;

            if (_currentUser != null)
            {
                this.Text = $"Classroom Reservation — {_currentUser.FullName} ({_currentUser.Role})";
            }


            lstAvailableA.DisplayMember = "Name";
            lstUnavailableA.DisplayMember = "Name";
            lstAvailableB.DisplayMember = "Name";
            lstUnavailableB.DisplayMember = "Name";

           
            lstAvailableA.DoubleClick += RoomList_DoubleClick;
            lstUnavailableA.DoubleClick += RoomList_DoubleClick;
            lstAvailableB.DoubleClick += RoomList_DoubleClick;
            lstUnavailableB.DoubleClick += RoomList_DoubleClick;
        }

        private void MainReservationForm_Load(object sender, EventArgs e)
        {
            LoadCalendar();
        }

        private void LoadCalendar()
        {
            lblMonthYear.Text = _currentDate.ToString("MMMM yyyy");
            pnlDays.SuspendLayout();
            pnlDays.Controls.Clear();

            DateTime firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            int totalDays = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            int panelWidth = pnlDays.ClientSize.Width > 50 ? pnlDays.ClientSize.Width : pnlDays.Width;
            int cellWidth = Math.Max(40, (panelWidth - 14) / 7);
            int cellHeight = 38;


            for (int i = 0; i < startDayOfWeek; i++)
            {
                Panel emptySlot = new Panel
                {
                    Size = new Size(cellWidth, cellHeight),
                    Margin = new Padding(1)
                };
                pnlDays.Controls.Add(emptySlot);
            }

            RadioButton? todayButton = null;


            for (int day = 1; day <= totalDays; day++)
            {
                RadioButton dayButton = new RadioButton
                {
                    Appearance = Appearance.Button,
                    Text = day.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(cellWidth, cellHeight),
                    Margin = new Padding(1),
                    FlatStyle = FlatStyle.Flat,
                    Tag = day
                };

                dayButton.FlatAppearance.BorderSize = 1;
                dayButton.FlatAppearance.CheckedBackColor = Color.SteelBlue;
                dayButton.FlatAppearance.BorderColor = Color.LightGray;


                bool isToday = (_currentDate.Year == DateTime.Today.Year &&
                                _currentDate.Month == DateTime.Today.Month &&
                                day == DateTime.Today.Day);

                if (isToday)
                {
                    dayButton.Font = new Font(dayButton.Font, FontStyle.Bold);
                    dayButton.ForeColor = Color.DarkBlue;
                    todayButton = dayButton;
                }

                dayButton.CheckedChanged += DayButton_CheckedChanged;
                pnlDays.Controls.Add(dayButton);
            }

            pnlDays.ResumeLayout();


            if (todayButton != null)
            {
                todayButton.Checked = true;
            }
            else
            {

                pnlTimeBlocks.Controls.Clear();
                lblSelectedDayTitle.Text = "Please select a day";
            }
        }


        private void DayButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                rb.ForeColor = Color.White;
                int day = (int)rb.Tag;
                SelectedDate = new DateOnly(_currentDate.Year, _currentDate.Month, day);


                LoadDayTimeBlocks(SelectedDate);
            }
            else if (sender is RadioButton uncheckedRb)
            {
                uncheckedRb.ForeColor = Color.Black;
            }
        }

        private void pnlDays_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(-1);
            LoadCalendar();
        }


        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            LoadCalendar();
        }

        private void LoadDayTimeBlocks(DateOnly date)
        {
            lblSelectedDayTitle.Text = $"Available Slots: {date:MMM dd, yyyy}";
            pnlTimeBlocks.SuspendLayout();
            pnlTimeBlocks.Controls.Clear();

            using var db = new AppDbContext();

            
            int totalRooms = db.Rooms.Count();


            var dayReservations = db.Reservations
                .Where(r => r.Date == date && r.Status == "Approved")
                .ToList();

            foreach (var slot in TimeSlots.All)
            {
                
                int bookedCount = dayReservations.Count(r =>
                    r.StartTime == slot.Start && r.EndTime == slot.End);

                int availableCount = totalRooms - bookedCount;
                bool hasAvailableRooms = availableCount > 0;

                int buttonWidth = pnlTimeBlocks.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;
                RadioButton slotButton = new RadioButton
                {
                    Appearance = Appearance.Button,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(buttonWidth, 46),
                    Margin = new Padding(3, 4, 3, 4),
                    Tag = slot,  
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand
                };

                if (hasAvailableRooms)
                {
                    slotButton.Text = $"  {slot.Display}   •   Available ({availableCount} room{(availableCount > 1 ? "s" : "")})";
                    slotButton.BackColor = Color.FromArgb(240, 248, 255);
                    slotButton.ForeColor = Color.FromArgb(16, 44, 87);
                    slotButton.FlatAppearance.BorderColor = Color.FromArgb(70, 130, 180);
                    slotButton.FlatAppearance.BorderSize = 1;
                    slotButton.FlatAppearance.CheckedBackColor = Color.FromArgb(53, 89, 143);
                }
                else
                {
                    slotButton.Text = $"  {slot.Display}   •   Fully Booked";
                    slotButton.BackColor = Color.FromArgb(245, 245, 245);
                    slotButton.ForeColor = Color.DimGray;
                    slotButton.FlatAppearance.BorderColor = Color.Gainsboro;
                    slotButton.FlatAppearance.BorderSize = 1;
                    slotButton.FlatAppearance.CheckedBackColor = Color.LightSlateGray;
                }

                slotButton.CheckedChanged += TimeSlotButton_CheckedChanged;
                pnlTimeBlocks.Controls.Add(slotButton);
            }

            pnlTimeBlocks.ResumeLayout();
        }

        private void TimeSlotButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                rb.ForeColor = Color.White;


                SelectedSlot = ((TimeOnly Start, TimeOnly End, string Display))rb.Tag;


                LoadBuildingsAndRooms(SelectedDate, SelectedSlot.Value);
            }
            else if (sender is RadioButton uncheckedRb)
            {
                uncheckedRb.ForeColor = uncheckedRb.Text.Contains("Fully Booked")
                    ? Color.DimGray
                    : Color.FromArgb(16, 44, 87);
            }
        }

        
        private void LoadBuildingsAndRooms(DateOnly date, (TimeOnly Start, TimeOnly End, string Display) slot)
        {
            lblRoomsTitle.Text = $"Rooms for {date:MMM dd, yyyy} at {slot.Display}:";

           
            lstAvailableA.Items.Clear();
            lstUnavailableA.Items.Clear();
            lstAvailableB.Items.Clear();
            lstUnavailableB.Items.Clear();

            using var db = new AppDbContext();


            var bookedRoomIds = db.Reservations
                .Where(r => r.Date == date &&
                            r.StartTime == slot.Start &&
                            r.EndTime == slot.End &&
                            r.Status == "Approved")
                .Select(r => r.RoomId)
                .ToHashSet();


            var buildings = db.Buildings
                .Include(b => b.Rooms)
                .ToList();

            var buildingA = buildings.FirstOrDefault(b => b.Name.Contains("Building A"));
            var buildingB = buildings.FirstOrDefault(b => b.Name.Contains("Building B"));

           
            if (buildingA != null)
            {
                grpBuildingA.Text = buildingA.Name;
                foreach (var room in buildingA.Rooms)
                {
                    if (bookedRoomIds.Contains(room.Id))
                        lstUnavailableA.Items.Add(room);
                    else
                        lstAvailableA.Items.Add(room);
                }
            }

           
            if (buildingB != null)
            {
                grpBuildingB.Text = buildingB.Name;
                foreach (var room in buildingB.Rooms)
                {
                    if (bookedRoomIds.Contains(room.Id))
                        lstUnavailableB.Items.Add(room);
                    else
                        lstAvailableB.Items.Add(room);
                }
            }
        }

        
        private void RoomList_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ListBox lb && lb.SelectedItem is Room selectedRoom)
            {
                
                OpenRoomDetail(selectedRoom);
            }
        }

        private void OpenRoomDetail(Room room)
        {
            // slot must be selected before a room can be opened
            if (!SelectedSlot.HasValue) return;

            using var detailForm = new RoomDetailForm(room, SelectedDate, SelectedSlot.Value, _currentUser);

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                // eefresh so the new slot shows pending count
                LoadDayTimeBlocks(SelectedDate);
                LoadBuildingsAndRooms(SelectedDate, SelectedSlot.Value);
            }
        }


        private void lblSelectedDayTitle_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
