using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CatchMind
{
    public partial class mb_lg_log : Form
    {
        public mb_lg_log()
        {
            InitializeComponent();
            this.Size = new Size(300, 600);
        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            GameVo gameVo = GameDao.SignIn(this.tb_NicName.Text, this.tb_Id.Text, this.tb_Pw.Text, this.tb_PwCheck.Text);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteID delete = new DeleteID();
            delete.ShowDialog();
        }
    }
}
