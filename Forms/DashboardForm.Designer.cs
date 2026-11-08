namespace ClassroomReservationOOP.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogout = new Button();
            btnAdminQueue = new Button();
            btnRoomSchedule = new Button();
            btnMyBookings = new Button();
            btnReservations = new Button();
            pnlContent = new Panel();
            lblUserInfo = new Label();
            pnlSidebar = new FlowLayoutPanel();
            pnlContent.SuspendLayout();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Location = new Point(3, 287);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 65);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAdminQueue
            // 
            btnAdminQueue.Location = new Point(3, 216);
            btnAdminQueue.Name = "btnAdminQueue";
            btnAdminQueue.Size = new Size(220, 65);
            btnAdminQueue.TabIndex = 0;
            btnAdminQueue.Text = "Approval Queue";
            btnAdminQueue.UseVisualStyleBackColor = true;
            btnAdminQueue.Click += btnAdminQueue_Click;
            // 
            // btnRoomSchedule
            // 
            btnRoomSchedule.Location = new Point(3, 145);
            btnRoomSchedule.Name = "btnRoomSchedule";
            btnRoomSchedule.Size = new Size(220, 65);
            btnRoomSchedule.TabIndex = 0;
            btnRoomSchedule.Text = "Reservation Records";
            btnRoomSchedule.UseVisualStyleBackColor = true;
            btnRoomSchedule.Click += btnRoomSchedule_Click;
            // 
            // btnMyBookings
            // 
            btnMyBookings.Location = new Point(3, 74);
            btnMyBookings.Name = "btnMyBookings";
            btnMyBookings.Size = new Size(220, 65);
            btnMyBookings.TabIndex = 0;
            btnMyBookings.Text = "Scheduled Today";
            btnMyBookings.UseVisualStyleBackColor = true;
            btnMyBookings.Click += btnMyBookings_Click;
            // 
            // btnReservations
            // 
            btnReservations.Location = new Point(3, 3);
            btnReservations.Name = "btnReservations";
            btnReservations.Size = new Size(220, 65);
            btnReservations.TabIndex = 0;
            btnReservations.Text = "Reserve Room";
            btnReservations.UseVisualStyleBackColor = true;
            btnReservations.Click += btnReservations_Click;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(lblUserInfo);
            pnlContent.Dock = DockStyle.Right;
            pnlContent.Location = new Point(232, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1170, 653);
            pnlContent.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Location = new Point(16, 9);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(68, 20);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "User Info";
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(btnReservations);
            pnlSidebar.Controls.Add(btnMyBookings);
            pnlSidebar.Controls.Add(btnRoomSchedule);
            pnlSidebar.Controls.Add(btnAdminQueue);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(226, 653);
            pnlSidebar.TabIndex = 1;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1402, 653);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlContent);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += DashboardForm_Load;
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnLogout;
        private Button btnAdminQueue;
        private Button btnMyBookings;
        private Button btnReservations;
        private Panel pnlContent;
        private Label lblUserInfo;
        private Button btnRoomSchedule;
        private FlowLayoutPanel pnlSidebar;
    }
}