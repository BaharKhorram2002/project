using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertBW_Click(object sender, EventArgs e)
        {
            frminsertbasem frminsertbasem = new frminsertbasem();
            frminsertbasem.Show();
        }

        private void btnInsertBM_Click(object sender, EventArgs e)
        {
            frmInsertBaseMoen frmInsertBaseMoen = new frmInsertBaseMoen();
            frmInsertBaseMoen.Show();
        }

        private void btnInsertSW_Click(object sender, EventArgs e)
        {
            frmsanad_W frmsanad_W = new frmsanad_W();
            frmsanad_W.Show();
        }

        private void btsInsertSM_Click(object sender, EventArgs e)
        {
            frmsanad_M frmsanad_M = new frmsanad_M();
            frmsanad_M.Show();
        }

        private void btnsoratHesab_Click(object sender, EventArgs e)
        {
            frmSoratHesabWM frmSorat = new frmSoratHesabWM();
            frmSorat.Show();
        }

        private void btnKholaseM_Click(object sender, EventArgs e)
        {
            frmKholaseVaziatM frmKholase = new frmKholaseVaziatM();
            frmKholase.Show();
        }

        private void btnKholaseW_Click(object sender, EventArgs e)
        {
            frmKholaseVaziatW frmKholase = new frmKholaseVaziatW();
            frmKholase.Show();
        }
    }
}
