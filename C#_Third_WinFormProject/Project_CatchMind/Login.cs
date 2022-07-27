using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CatchMind
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Size = new Size(1050, 750);
        }

        private void lg_btn_member_Click(object sender, EventArgs e)
        {
            mb_lg_log mb = new mb_lg_log();
            mb.ShowDialog();
        }
        private void lg_btn_check_Click(object sender, EventArgs e)
        {
            GameVo gameVo = GameDao.login(this.lg_tb_id.Text, this.lg_tb_pw.Text);
            if(gameVo != null)
            {
                GameClient gm = new GameClient();
                gm.ShowDialog();
            }
            else
            {
                MessageBox.Show("사용자가 없습니다");
            }
        }
    }
}
