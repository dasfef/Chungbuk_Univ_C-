namespace Production_Management
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.btnPlanQuery = new System.Windows.Forms.Button();
            this.lstProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPlanDelete = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbWorkCenter = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPlanAdd = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnComplete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "생산년도";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(65, 13);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(76, 20);
            this.cmbYear.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "생산월";
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(217, 13);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(42, 20);
            this.cmbMonth.TabIndex = 3;
            // 
            // btnPlanQuery
            // 
            this.btnPlanQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlanQuery.Location = new System.Drawing.Point(275, 12);
            this.btnPlanQuery.Name = "btnPlanQuery";
            this.btnPlanQuery.Size = new System.Drawing.Size(88, 23);
            this.btnPlanQuery.TabIndex = 4;
            this.btnPlanQuery.Text = "생산계획조회";
            this.btnPlanQuery.UseVisualStyleBackColor = true;
            this.btnPlanQuery.Click += new System.EventHandler(this.btnPlanQuery_Click);
            // 
            // lstProducts
            // 
            this.lstProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lstProducts.GridLines = true;
            this.lstProducts.HideSelection = false;
            this.lstProducts.Location = new System.Drawing.Point(8, 43);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(524, 237);
            this.lstProducts.TabIndex = 5;
            this.lstProducts.UseCompatibleStateImageBehavior = false;
            this.lstProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "생산계획번호";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "품 목";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "작 업 장";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "생산수량";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "시작일";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "종료일";
            this.columnHeader6.Width = 100;
            // 
            // btnPlanDelete
            // 
            this.btnPlanDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlanDelete.Location = new System.Drawing.Point(407, 12);
            this.btnPlanDelete.Name = "btnPlanDelete";
            this.btnPlanDelete.Size = new System.Drawing.Size(125, 23);
            this.btnPlanDelete.TabIndex = 6;
            this.btnPlanDelete.Text = "선택된 생산계획삭제";
            this.btnPlanDelete.UseVisualStyleBackColor = true;
            this.btnPlanDelete.Click += new System.EventHandler(this.btnPlanDelete_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSummary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSummary.Location = new System.Drawing.Point(9, 16);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(88, 23);
            this.btnSummary.TabIndex = 7;
            this.btnSummary.Text = "생산실적조회";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(8, 48);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(274, 197);
            this.txtSummary.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "품       목";
            // 
            // cmbItem
            // 
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(80, 14);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(156, 20);
            this.cmbItem.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "작  업  장";
            // 
            // cmbWorkCenter
            // 
            this.cmbWorkCenter.FormattingEnabled = true;
            this.cmbWorkCenter.Location = new System.Drawing.Point(80, 42);
            this.cmbWorkCenter.Name = "cmbWorkCenter";
            this.cmbWorkCenter.Size = new System.Drawing.Size(156, 20);
            this.cmbWorkCenter.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlanDelete);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbMonth);
            this.groupBox1.Controls.Add(this.btnPlanQuery);
            this.groupBox1.Controls.Add(this.lstProducts);
            this.groupBox1.Location = new System.Drawing.Point(11, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 292);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSummary);
            this.groupBox2.Controls.Add(this.txtSummary);
            this.groupBox2.Location = new System.Drawing.Point(11, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 251);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPlanAdd);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmbItem);
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Controls.Add(this.txtQty);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbWorkCenter);
            this.groupBox3.Location = new System.Drawing.Point(305, 302);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 156);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(80, 99);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(156, 21);
            this.dtpStart.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "생산시작일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "수       량";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(80, 68);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 21);
            this.txtQty.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnComplete);
            this.groupBox4.Controls.Add(this.dtpEnd);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(305, 458);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 95);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "생산시작일";
            // 
            // btnPlanAdd
            // 
            this.btnPlanAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlanAdd.Location = new System.Drawing.Point(80, 127);
            this.btnPlanAdd.Name = "btnPlanAdd";
            this.btnPlanAdd.Size = new System.Drawing.Size(156, 23);
            this.btnPlanAdd.TabIndex = 17;
            this.btnPlanAdd.Text = "생산계획등록";
            this.btnPlanAdd.UseVisualStyleBackColor = true;
            this.btnPlanAdd.Click += new System.EventHandler(this.btnPlanAdd_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(80, 26);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(156, 21);
            this.dtpEnd.TabIndex = 16;
            // 
            // btnComplete
            // 
            this.btnComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComplete.Location = new System.Drawing.Point(80, 53);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(156, 23);
            this.btnComplete.TabIndex = 18;
            this.btnComplete.Text = "생산완료등록";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 563);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Production Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnPlanQuery;
        private System.Windows.Forms.ListView lstProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnPlanDelete;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWorkCenter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPlanAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label7;
    }
}

