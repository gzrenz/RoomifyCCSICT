namespace ClassroomReservationOOP.Forms
{
    partial class MyReservationsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.DataGridView dgvMyReservations;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;

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
            lblTitle = new Label();
            lblSubtitle = new Label();
            dgvMyReservations = new DataGridView();
            btnRefresh = new Button();
            btnCancel = new Button();
            btnClearRejected = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMyReservations).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(16, 44, 87);
            lblTitle.Location = new Point(28, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(203, 32);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "My Reservations";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(30, 58);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(329, 20);
            lblSubtitle.TabIndex = 4;
            lblSubtitle.Text = "Track the status of your room reservation requests.";
            // 
            // dgvMyReservations
            // 
            dgvMyReservations.AllowUserToAddRows = false;
            dgvMyReservations.AllowUserToDeleteRows = false;
            dgvMyReservations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMyReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyReservations.BackgroundColor = Color.White;
            dgvMyReservations.BorderStyle = BorderStyle.Fixed3D;
            dgvMyReservations.ColumnHeadersHeight = 35;
            dgvMyReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMyReservations.Location = new Point(30, 92);
            dgvMyReservations.MultiSelect = false;
            dgvMyReservations.Name = "dgvMyReservations";
            dgvMyReservations.ReadOnly = true;
            dgvMyReservations.RowHeadersVisible = false;
            dgvMyReservations.RowHeadersWidth = 51;
            dgvMyReservations.RowTemplate.Height = 30;
            dgvMyReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyReservations.Size = new Size(815, 395);
            dgvMyReservations.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(30, 502);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 38);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "⟳ Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.DarkOrange;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(470, 502);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 38);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel Request";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClearRejected
            // 
            btnClearRejected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearRejected.BackColor = Color.IndianRed;
            btnClearRejected.Cursor = Cursors.Hand;
            btnClearRejected.FlatStyle = FlatStyle.Flat;
            btnClearRejected.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearRejected.ForeColor = Color.White;
            btnClearRejected.Location = new Point(665, 502);
            btnClearRejected.Name = "btnClearRejected";
            btnClearRejected.Size = new Size(180, 38);
            btnClearRejected.TabIndex = 3;
            btnClearRejected.Text = "Clear Rejected";
            btnClearRejected.UseVisualStyleBackColor = false;
            btnClearRejected.Click += btnClearRejected_Click;
            // 
            // MyReservationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(875, 560);
            Controls.Add(btnClearRejected);
            Controls.Add(btnCancel);
            Controls.Add(btnRefresh);
            Controls.Add(dgvMyReservations);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Name = "MyReservationsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "My Reservations";
            Load += MyReservationsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMyReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnClearRejected;
    }
}
