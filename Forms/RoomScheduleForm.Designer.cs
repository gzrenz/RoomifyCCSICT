namespace ClassroomReservationOOP.Forms
{
    partial class RoomScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpScheduleDate;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView dgvSchedule;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblHeader = new Label();
            lblDate = new Label();
            dtpScheduleDate = new DateTimePicker();
            lblStatusFilter = new Label();
            cmbStatusFilter = new ComboBox();
            btnToday = new Button();
            btnRefresh = new Button();
            lblSummary = new Label();
            dgvSchedule = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(16, 44, 87);
            lblHeader.Location = new Point(25, 18);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(266, 32);
            lblHeader.TabIndex = 8;
            lblHeader.Text = "Daily Room Schedules";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9.5F);
            lblDate.Location = new Point(26, 62);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(45, 21);
            lblDate.TabIndex = 7;
            lblDate.Text = "Date:";
            // 
            // dtpScheduleDate
            // 
            dtpScheduleDate.CustomFormat = "MMM dd, yyyy (dddd)";
            dtpScheduleDate.Font = new Font("Segoe UI", 9.5F);
            dtpScheduleDate.Format = DateTimePickerFormat.Custom;
            dtpScheduleDate.Location = new Point(75, 59);
            dtpScheduleDate.Name = "dtpScheduleDate";
            dtpScheduleDate.Size = new Size(220, 29);
            dtpScheduleDate.TabIndex = 6;
            dtpScheduleDate.ValueChanged += dtpScheduleDate_ValueChanged;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new Font("Segoe UI", 9.5F);
            lblStatusFilter.Location = new Point(410, 62);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(55, 21);
            lblStatusFilter.TabIndex = 4;
            lblStatusFilter.Text = "Status:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 9.5F);
            cmbStatusFilter.Location = new Point(470, 59);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(140, 29);
            cmbStatusFilter.TabIndex = 3;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // btnToday
            // 
            btnToday.FlatStyle = FlatStyle.Flat;
            btnToday.Font = new Font("Segoe UI", 9F);
            btnToday.Location = new Point(305, 59);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(75, 29);
            btnToday.TabIndex = 5;
            btnToday.Text = "Today";
            btnToday.UseVisualStyleBackColor = true;
            btnToday.Click += btnToday_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(755, 57);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(95, 31);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "⟳ Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSummary.ForeColor = Color.DimGray;
            lblSummary.Location = new Point(26, 100);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(172, 20);
            lblSummary.TabIndex = 1;
            lblSummary.Text = "Showing all reservations...";
            // 
            // dgvSchedule
            // 
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.BackgroundColor = Color.White;
            dgvSchedule.BorderStyle = BorderStyle.Fixed3D;
            dgvSchedule.ColumnHeadersHeight = 35;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSchedule.Location = new Point(25, 128);
            dgvSchedule.MultiSelect = false;
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.RowHeadersWidth = 51;
            dgvSchedule.RowTemplate.Height = 30;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.Size = new Size(825, 410);
            dgvSchedule.TabIndex = 0;
            // 
            // RoomScheduleForm
            // 
            ClientSize = new Size(875, 560);
            Controls.Add(dgvSchedule);
            Controls.Add(lblSummary);
            Controls.Add(btnRefresh);
            Controls.Add(cmbStatusFilter);
            Controls.Add(lblStatusFilter);
            Controls.Add(btnToday);
            Controls.Add(dtpScheduleDate);
            Controls.Add(lblDate);
            Controls.Add(lblHeader);
            Name = "RoomScheduleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reservation Records";
            Load += RoomScheduleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
