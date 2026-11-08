using ClassroomReservationOOP.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassroomReservationOOP.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly User _currentUser;
        private Form? _activeForm = null;

        public DashboardForm(User user)
        {
            InitializeComponent();
            _currentUser = user;

           
            lblUserInfo.Text = $"{_currentUser.FullName}\n({_currentUser.Role})";

          
            ConfigureRoleAccess();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (_currentUser.Role == "Admin")
            {
                btnAdminQueue.PerformClick(); // admin lands on approval queue
            }
            else
            {
                btnReservations.PerformClick();   // teachers and students on room reservation
            }
        }

        
        private void LoadForm(Form childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
                _activeForm.Dispose();
            }

            _activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void LoadFormIntoContent(Form childForm)
        {
           
            if (_activeForm != null)
            {
                _activeForm.Close();
                _activeForm.Dispose();
            }

            _activeForm = childForm;

            
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

           
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;

            
            childForm.BringToFront();
            childForm.Show();
        }

        // Sidebar Buttons 

        private void btnReservations_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnReservations);
            LoadFormIntoContent(new MainReservationForm(_currentUser));
        }

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnMyBookings);
            LoadFormIntoContent(new MyReservationsForm(_currentUser));
        }

        private void btnRoomSchedule_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnRoomSchedule);
            LoadFormIntoContent(new RoomScheduleForm());
        }

        private void btnAdminQueue_Click(object sender, EventArgs e)
        {   
            HighlightActiveButton(btnAdminQueue);
            LoadFormIntoContent(new ApprovalForm(_currentUser));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Retry; 
                this.Close();
            }
        }

        private void HighlightActiveButton(Button activeButton)
        {
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button btn && btn != btnLogout)
                {
                    btn.BackColor = Color.FromArgb(30, 41, 59); 
                    btn.ForeColor = Color.White;
                }
            }

            activeButton.BackColor = Color.FromArgb(51, 65, 85); 
            activeButton.ForeColor = Color.CornflowerBlue;
        }


        private void SetActiveButton(Button activeButton)
        {
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button btn && btn != btnLogout)
                {
                    btn.BackColor = Color.FromArgb(30, 41, 59);
                    btn.ForeColor = Color.White;
                }
            }

            activeButton.BackColor = Color.FromArgb(51, 65, 85);
            activeButton.ForeColor = Color.SkyBlue;
        }

        private void ConfigureRoleAccess()
        {
            bool isAdmin = _currentUser.Role == "Admin";
            bool isTeacherOrStudent = !isAdmin;
   
            
            btnAdminQueue.Visible = isAdmin;         // Admin only
            btnMyBookings.Visible = isTeacherOrStudent; // Teacher & Student only
            btnReservations.Visible = true;               // Everyone 
            btnRoomSchedule.Visible = true;              // Everyone 
            
            btnReservations.Text = isAdmin ? "View Rooms & Calendar" : "Reserve a Room";

            
            int currentY = 120; 
            int buttonHeight = 45;
            int spacing = 8;

           
            Button[] navButtons = new Button[]
            {
            btnAdminQueue,
            btnReservations,
            btnMyBookings,
            btnRoomSchedule
            };

            foreach (var btn in navButtons)
            {
                if (btn.Visible)
                {
                    btn.Location = new Point(btn.Location.X, currentY);
                    currentY += buttonHeight + spacing;
                }
            }
        }

    }
}
