namespace ClassroomReservationOOP.Forms
{
    partial class MainReservationForm
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
            label1 = new Label();
            lblMonthYear = new Label();
            btnPrevMonth = new Button();
            btnNextMonth = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            pnlDays = new FlowLayoutPanel();
            pnlTimeBlocks = new FlowLayoutPanel();
            lblSelectedDayTitle = new Label();
            lblRoomsTitle = new Label();
            grpBuildingA = new GroupBox();
            lstUnavailableA = new ListBox();
            lstAvailableA = new ListBox();
            label9 = new Label();
            grpBuildingB = new GroupBox();
            lstUnavailableB = new ListBox();
            lstAvailableB = new ListBox();
            label10 = new Label();
            label11 = new Label();
            flowLayoutPanel1.SuspendLayout();
            grpBuildingA.SuspendLayout();
            grpBuildingB.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 30);
            label1.Name = "label1";
            label1.Size = new Size(225, 20);
            label1.TabIndex = 2;
            label1.Text = "Select date and time to continue";
            // 
            // lblMonthYear
            // 
            lblMonthYear.AutoSize = true;
            lblMonthYear.Location = new Point(88, 69);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new Size(130, 20);
            lblMonthYear.TabIndex = 2;
            lblMonthYear.Text = "November 2, 2026";
            // 
            // btnPrevMonth
            // 
            btnPrevMonth.Location = new Point(51, 65);
            btnPrevMonth.Name = "btnPrevMonth";
            btnPrevMonth.Size = new Size(26, 29);
            btnPrevMonth.TabIndex = 3;
            btnPrevMonth.Text = "<";
            btnPrevMonth.UseVisualStyleBackColor = true;
            btnPrevMonth.Click += btnPrevMonth_Click;
            // 
            // btnNextMonth
            // 
            btnNextMonth.Location = new Point(229, 65);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(26, 29);
            btnNextMonth.TabIndex = 3;
            btnNextMonth.Text = ">";
            btnNextMonth.UseVisualStyleBackColor = true;
            btnNextMonth.Click += btnNextMonth_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(label8);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Controls.Add(label7);
            flowLayoutPanel1.Location = new Point(20, 109);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(280, 25);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 0;
            label2.Text = "Sun";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 0);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 0;
            label3.Text = "Mon";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 0);
            label4.Name = "label4";
            label4.Size = new Size(33, 20);
            label4.TabIndex = 0;
            label4.Text = "Tue";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 0);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 0;
            label5.Text = "Wed";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(171, 0);
            label8.Name = "label8";
            label8.Size = new Size(33, 20);
            label8.TabIndex = 0;
            label8.Text = "Thu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(210, 0);
            label6.Name = "label6";
            label6.Size = new Size(25, 20);
            label6.TabIndex = 0;
            label6.Text = "Fri";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(241, 0);
            label7.Name = "label7";
            label7.Size = new Size(30, 20);
            label7.TabIndex = 0;
            label7.Text = "Sat";
            // 
            // pnlDays
            // 
            pnlDays.Location = new Point(20, 149);
            pnlDays.Name = "pnlDays";
            pnlDays.Size = new Size(280, 275);
            pnlDays.TabIndex = 5;
            pnlDays.Paint += pnlDays_Paint;
            // 
            // pnlTimeBlocks
            // 
            pnlTimeBlocks.AutoScroll = true;
            pnlTimeBlocks.FlowDirection = FlowDirection.TopDown;
            pnlTimeBlocks.Location = new Point(327, 82);
            pnlTimeBlocks.Margin = new Padding(0);
            pnlTimeBlocks.Name = "pnlTimeBlocks";
            pnlTimeBlocks.Size = new Size(267, 493);
            pnlTimeBlocks.TabIndex = 6;
            pnlTimeBlocks.WrapContents = false;
            // 
            // lblSelectedDayTitle
            // 
            lblSelectedDayTitle.AutoSize = true;
            lblSelectedDayTitle.Location = new Point(327, 30);
            lblSelectedDayTitle.Name = "lblSelectedDayTitle";
            lblSelectedDayTitle.Size = new Size(147, 20);
            lblSelectedDayTitle.TabIndex = 2;
            lblSelectedDayTitle.Text = "Available Time Slots:";
            lblSelectedDayTitle.Click += lblSelectedDayTitle_Click;
            // 
            // lblRoomsTitle
            // 
            lblRoomsTitle.AutoSize = true;
            lblRoomsTitle.Location = new Point(327, 53);
            lblRoomsTitle.Name = "lblRoomsTitle";
            lblRoomsTitle.Size = new Size(235, 20);
            lblRoomsTitle.TabIndex = 9;
            lblRoomsTitle.Text = "Available Rooms (Click to Inspect)";
            // 
            // grpBuildingA
            // 
            grpBuildingA.Controls.Add(lstUnavailableA);
            grpBuildingA.Controls.Add(lstAvailableA);
            grpBuildingA.Controls.Add(label9);
            grpBuildingA.Location = new Point(620, 65);
            grpBuildingA.Name = "grpBuildingA";
            grpBuildingA.Size = new Size(250, 533);
            grpBuildingA.TabIndex = 10;
            grpBuildingA.TabStop = false;
            grpBuildingA.Text = "IT Building";
            // 
            // lstUnavailableA
            // 
            lstUnavailableA.FormattingEnabled = true;
            lstUnavailableA.Location = new Point(14, 313);
            lstUnavailableA.Name = "lstUnavailableA";
            lstUnavailableA.Size = new Size(214, 204);
            lstUnavailableA.TabIndex = 10;
            // 
            // lstAvailableA
            // 
            lstAvailableA.FormattingEnabled = true;
            lstAvailableA.Location = new Point(14, 51);
            lstAvailableA.Name = "lstAvailableA";
            lstAvailableA.Size = new Size(214, 204);
            lstAvailableA.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 271);
            label9.Name = "label9";
            label9.Size = new Size(87, 20);
            label9.TabIndex = 9;
            label9.Text = "Unavailable";
            label9.Click += label9_Click;
            // 
            // grpBuildingB
            // 
            grpBuildingB.Controls.Add(lstUnavailableB);
            grpBuildingB.Controls.Add(lstAvailableB);
            grpBuildingB.Controls.Add(label10);
            grpBuildingB.Location = new Point(898, 65);
            grpBuildingB.Name = "grpBuildingB";
            grpBuildingB.Size = new Size(251, 533);
            grpBuildingB.TabIndex = 10;
            grpBuildingB.TabStop = false;
            grpBuildingB.Text = "RM Building";
            // 
            // lstUnavailableB
            // 
            lstUnavailableB.FormattingEnabled = true;
            lstUnavailableB.Location = new Point(15, 313);
            lstUnavailableB.Name = "lstUnavailableB";
            lstUnavailableB.Size = new Size(214, 204);
            lstUnavailableB.TabIndex = 13;
            // 
            // lstAvailableB
            // 
            lstAvailableB.FormattingEnabled = true;
            lstAvailableB.Location = new Point(15, 49);
            lstAvailableB.Name = "lstAvailableB";
            lstAvailableB.Size = new Size(214, 204);
            lstAvailableB.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 271);
            label10.Name = "label10";
            label10.Size = new Size(87, 20);
            label10.TabIndex = 11;
            label10.Text = "Unavailable";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(767, 30);
            label11.Name = "label11";
            label11.Size = new Size(241, 20);
            label11.TabIndex = 9;
            label11.Text = "Double Click to View Room Details";
            // 
            // MainReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 653);
            Controls.Add(grpBuildingB);
            Controls.Add(grpBuildingA);
            Controls.Add(pnlTimeBlocks);
            Controls.Add(label11);
            Controls.Add(lblRoomsTitle);
            Controls.Add(pnlDays);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnNextMonth);
            Controls.Add(btnPrevMonth);
            Controls.Add(lblMonthYear);
            Controls.Add(lblSelectedDayTitle);
            Controls.Add(label1);
            Name = "MainReservationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Room Reservation";
            Load += MainReservationForm_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            grpBuildingA.ResumeLayout(false);
            grpBuildingA.PerformLayout();
            grpBuildingB.ResumeLayout(false);
            grpBuildingB.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label lblMonthYear;
        private Button btnPrevMonth;
        private Button btnNextMonth;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label6;
        private Label label7;
        private FlowLayoutPanel pnlDays;
        private FlowLayoutPanel pnlTimeBlocks;
        private Label lblSelectedDayTitle;
        private Label lblRoomsTitle;
        private GroupBox grpBuildingA;
        private GroupBox grpBuildingB;
        private ListBox lstUnavailableA;
        private ListBox lstAvailableA;
        private Label label9;
        private ListBox lstUnavailableB;
        private ListBox lstAvailableB;
        private Label label10;
        private Label label11;
    }
}