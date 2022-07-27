
namespace Project_CatchMind
{
    partial class DeleteID
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
            this.tb_DeleteId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_DeleteId
            // 
            this.tb_DeleteId.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_DeleteId.Location = new System.Drawing.Point(264, 98);
            this.tb_DeleteId.Name = "tb_DeleteId";
            this.tb_DeleteId.Size = new System.Drawing.Size(245, 31);
            this.tb_DeleteId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "삭제할 아이디를 입력";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Delete.Location = new System.Drawing.Point(375, 296);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(123, 46);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "확인";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "비밀번호 입력";
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(261, 203);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(245, 31);
            this.tb_Password.TabIndex = 1;
            // 
            // DeleteID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 354);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_DeleteId);
            this.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "DeleteID";
            this.Text = "DeleteID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_DeleteId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Password;
    }
}