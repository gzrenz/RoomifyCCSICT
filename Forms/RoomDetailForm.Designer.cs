namespace ClassroomReservationOOP.Forms
{
    partial class RoomDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSlotCaption;
        private System.Windows.Forms.Label lblSlotInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSlotCaption = new System.Windows.Forms.Label();
            this.lblSlotInfo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnReserve = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(16, 44, 87);
            this.lblHeader.Location = new System.Drawing.Point(25, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(370, 30);
            this.lblHeader.Text = "Room Details";
            // 
            // lblSlotCaption
            // 
            this.lblSlotCaption.AutoSize = true;
            this.lblSlotCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSlotCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblSlotCaption.Location = new System.Drawing.Point(27, 70);
            this.lblSlotCaption.Name = "lblSlotCaption";
            this.lblSlotCaption.Size = new System.Drawing.Size(130, 20);
            this.lblSlotCaption.Text = "Selected time slot:";
            // 
            // lblSlotInfo
            // 
            this.lblSlotInfo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSlotInfo.ForeColor = System.Drawing.Color.FromArgb(16, 44, 87);
            this.lblSlotInfo.Location = new System.Drawing.Point(25, 95);
            this.lblSlotInfo.Name = "lblSlotInfo";
            this.lblSlotInfo.Size = new System.Drawing.Size(370, 40);
            this.lblSlotInfo.Text = "07:00 - 08:30";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatus.Location = new System.Drawing.Point(27, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(370, 45);
            this.lblStatus.Text = "Checking availability...";
            // 
            // btnReserve
            // 
            this.btnReserve.BackColor = System.Drawing.Color.SeaGreen;
            this.btnReserve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReserve.Enabled = false;
            this.btnReserve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserve.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReserve.ForeColor = System.Drawing.Color.White;
            this.btnReserve.Location = new System.Drawing.Point(27, 210);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(230, 44);
            this.btnReserve.Text = "Reserve Room";
            this.btnReserve.UseVisualStyleBackColor = false;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(267, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 44);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RoomDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(424, 280);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblSlotCaption);
            this.Controls.Add(this.lblSlotInfo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reserve Room";
            this.Load += new System.EventHandler(this.RoomDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
