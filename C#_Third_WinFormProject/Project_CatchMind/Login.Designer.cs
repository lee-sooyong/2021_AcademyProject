
namespace Project_CatchMind
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lg_tb_id = new System.Windows.Forms.TextBox();
            this.lg_tb_pw = new System.Windows.Forms.TextBox();
            this.lg_btn_check = new System.Windows.Forms.Button();
            this.lg_btn_member = new System.Windows.Forms.Button();
            this.lg_btn_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1034, 460);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼매직체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(299, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 33);
            this.label1.TabIndex = 99;
            this.label1.Text = "아이디";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼매직체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(280, 541);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 33);
            this.label2.TabIndex = 98;
            this.label2.Text = "비밀번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lg_tb_id
            // 
            this.lg_tb_id.AcceptsTab = true;
            this.lg_tb_id.Font = new System.Drawing.Font("휴먼매직체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lg_tb_id.Location = new System.Drawing.Point(399, 489);
            this.lg_tb_id.Name = "lg_tb_id";
            this.lg_tb_id.Size = new System.Drawing.Size(299, 44);
            this.lg_tb_id.TabIndex = 1;
            // 
            // lg_tb_pw
            // 
            this.lg_tb_pw.Font = new System.Drawing.Font("휴먼매직체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lg_tb_pw.Location = new System.Drawing.Point(399, 537);
            this.lg_tb_pw.Name = "lg_tb_pw";
            this.lg_tb_pw.PasswordChar = '●';
            this.lg_tb_pw.Size = new System.Drawing.Size(299, 44);
            this.lg_tb_pw.TabIndex = 2;
            // 
            // lg_btn_check
            // 
            this.lg_btn_check.Font = new System.Drawing.Font("휴먼매직체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lg_btn_check.Location = new System.Drawing.Point(720, 489);
            this.lg_btn_check.Name = "lg_btn_check";
            this.lg_btn_check.Size = new System.Drawing.Size(101, 85);
            this.lg_btn_check.TabIndex = 3;
            this.lg_btn_check.Text = "확인";
            this.lg_btn_check.UseVisualStyleBackColor = true;
            this.lg_btn_check.Click += new System.EventHandler(this.lg_btn_check_Click);
            // 
            // lg_btn_member
            // 
            this.lg_btn_member.Font = new System.Drawing.Font("휴먼매직체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lg_btn_member.Location = new System.Drawing.Point(280, 603);
            this.lg_btn_member.Name = "lg_btn_member";
            this.lg_btn_member.Size = new System.Drawing.Size(192, 85);
            this.lg_btn_member.TabIndex = 5;
            this.lg_btn_member.Text = "회원가입";
            this.lg_btn_member.UseVisualStyleBackColor = true;
            this.lg_btn_member.Click += new System.EventHandler(this.lg_btn_member_Click);
            // 
            // lg_btn_exit
            // 
            this.lg_btn_exit.Font = new System.Drawing.Font("휴먼매직체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lg_btn_exit.Location = new System.Drawing.Point(629, 603);
            this.lg_btn_exit.Name = "lg_btn_exit";
            this.lg_btn_exit.Size = new System.Drawing.Size(192, 85);
            this.lg_btn_exit.TabIndex = 4;
            this.lg_btn_exit.Text = "종료";
            this.lg_btn_exit.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1034, 711);
            this.Controls.Add(this.lg_btn_exit);
            this.Controls.Add(this.lg_btn_member);
            this.Controls.Add(this.lg_btn_check);
            this.Controls.Add(this.lg_tb_pw);
            this.Controls.Add(this.lg_tb_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lg_tb_id;
        private System.Windows.Forms.TextBox lg_tb_pw;
        private System.Windows.Forms.Button lg_btn_check;
        private System.Windows.Forms.Button lg_btn_member;
        private System.Windows.Forms.Button lg_btn_exit;
    }
}

