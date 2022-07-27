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
    public partial class DeleteID : Form
    {
        public DeleteID()
        {
            InitializeComponent();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            GameVo gameVo = GameDao.DeleteId(this.tb_DeleteId.Text, this.tb_Password.Text);
        }
    }
}
