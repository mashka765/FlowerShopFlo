namespace FlowerShop
{
    partial class OrderDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtSellerId = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtCompletionDate = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtDeliveryAddress = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.cmbOrderStatus = new System.Windows.Forms.ComboBox();
            this.btnAddDetails = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код заказа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(164, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Код продавца";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(297, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Код клиента";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(21, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата формления";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(167, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата выполнения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(21, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Телефон";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(21, 273);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Адрес доставки";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(21, 353);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Статус заказа";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(21, 433);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Сумма заказа";
            // 
            // txtOrderId
            // 
            this.txtOrderId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.txtOrderId.Location = new System.Drawing.Point(24, 67);
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(64, 22);
            this.txtOrderId.TabIndex = 9;
            // 
            // txtSellerId
            // 
            this.txtSellerId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.txtSellerId.Location = new System.Drawing.Point(166, 67);
            this.txtSellerId.Margin = new System.Windows.Forms.Padding(4);
            this.txtSellerId.Name = "txtSellerId";
            this.txtSellerId.Size = new System.Drawing.Size(64, 22);
            this.txtSellerId.TabIndex = 10;
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.txtUserId.Location = new System.Drawing.Point(300, 67);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(64, 22);
            this.txtUserId.TabIndex = 11;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.txtOrderDate.Location = new System.Drawing.Point(24, 151);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(107, 22);
            this.txtOrderDate.TabIndex = 12;
            // 
            // txtCompletionDate
            // 
            this.txtCompletionDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.txtCompletionDate.Location = new System.Drawing.Point(166, 151);
            this.txtCompletionDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompletionDate.Name = "txtCompletionDate";
            this.txtCompletionDate.Size = new System.Drawing.Size(100, 22);
            this.txtCompletionDate.TabIndex = 13;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.txtPhone.Location = new System.Drawing.Point(24, 230);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(152, 22);
            this.txtPhone.TabIndex = 14;
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.txtDeliveryAddress.Location = new System.Drawing.Point(25, 313);
            this.txtDeliveryAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.Size = new System.Drawing.Size(317, 22);
            this.txtDeliveryAddress.TabIndex = 15;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.txtTotalAmount.Location = new System.Drawing.Point(25, 464);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(152, 22);
            this.txtTotalAmount.TabIndex = 16;
            // 
            // cmbOrderStatus
            // 
            this.cmbOrderStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(202)))), ((int)(((byte)(162)))));
            this.cmbOrderStatus.FormattingEnabled = true;
            this.cmbOrderStatus.Location = new System.Drawing.Point(25, 391);
            this.cmbOrderStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOrderStatus.Name = "cmbOrderStatus";
            this.cmbOrderStatus.Size = new System.Drawing.Size(160, 24);
            this.cmbOrderStatus.TabIndex = 17;
            // 
            // btnAddDetails
            // 
            this.btnAddDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(131)))), ((int)(((byte)(103)))));
            this.btnAddDetails.Location = new System.Drawing.Point(116, 541);
            this.btnAddDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDetails.Name = "btnAddDetails";
            this.btnAddDetails.Size = new System.Drawing.Size(226, 56);
            this.btnAddDetails.TabIndex = 18;
            this.btnAddDetails.Text = "Добавить детали";
            this.btnAddDetails.UseVisualStyleBackColor = false;
            this.btnAddDetails.Click += new System.EventHandler(this.btnAddDetails_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(131)))), ((int)(((byte)(103)))));
            this.btnCancel.Location = new System.Drawing.Point(45, 619);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 56);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(131)))), ((int)(((byte)(103)))));
            this.btnSave.Location = new System.Drawing.Point(275, 619);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 56);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(476, 698);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddDetails);
            this.Controls.Add(this.cmbOrderStatus);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtDeliveryAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtCompletionDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtSellerId);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderDetailsForm";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.OrderDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtSellerId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtCompletionDate;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.Button btnAddDetails;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}