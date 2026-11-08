using ClassroomReservationOOP.Data;
using ClassroomReservationOOP.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClassroomReservationOOP.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            cmbRole.Items.AddRange(new string[] { "Student", "Teacher" });
            cmbRole.SelectedIndex = 0; // default to student
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "Student";

           
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();

            // prevent duplicate usernames
            if (db.Users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                MessageBox.Show("That username is already taken. Please choose another.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new User
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Email = email,
                Role = role
            };

            db.Users.Add(newUser);
            db.SaveChanges();

            MessageBox.Show($"Account created successfully as {role}!\nYou can now log in.", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
