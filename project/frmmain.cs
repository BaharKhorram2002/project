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
    public partial class frmmain : Form
    {
        public frmmain()
        {
           
            InitializeComponent();
            frmdefault frmdefault = new frmdefault();
            frmdefault.MdiParent = this;
            frmdefault.Show();
        }

        private void btnInsertBW_Click(object sender, EventArgs e)
        {
            
        l: foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmmain")
                {
                    f.Close();
                    break;
                    // btnopenInsertBaseMoen_Click(sender, e);
                    goto l;
                }


            }
            frminsertbasem child = new frminsertbasem();
            child.MdiParent = this;
            child.Show();
        }

        private void btnInsertBM_Click(object sender, EventArgs e)
        {
        l: foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmmain")
                {
                    f.Close();
                    break;
                    // btnopenInsertBaseMoen_Click(sender, e);
                    goto l;
                }


            }
            frmInsertBaseMoen child = new frmInsertBaseMoen();
            child.MdiParent = this;
            child.Show();
        }

        private void btnInsertSW_Click(object sender, EventArgs e)
        {
        l: foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmmain")
                {
                    f.Close();
                    break;
                    // btnopenInsertBaseMoen_Click(sender, e);
                    goto l;
                }


            }
            frmsanad_W child = new frmsanad_W();
            child.MdiParent = this;
            child.Show();
        }

        private void btsInsertSM_Click(object sender, EventArgs e)
        {
        l: foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmmain")
                {
                    f.Close();
                    break;
                    // btnopenInsertBaseMoen_Click(sender, e);
                    goto l;
                }


            }
            frmsanad_M child = new frmsanad_M();
            child.MdiParent = this;
            child.Show();
        }

        private void btnsoratHesab_Click(object sender, EventArgs e)
        {
        l: foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmmain")
                {
                    f.Close();
                    break;
                    // btnopenInsertBaseMoen_Click(sender, e);
                    goto l;
                }


            }
            frmSoratHesabWM child = new frmSoratHesabWM();
            child.MdiParent = this;
            child.Show();
        }

        private void btnKholaseM_Click(object sender, EventArgs e)
        {
        l: foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmmain")
                {
                    f.Close();
                    break;
                    // btnopenInsertBaseMoen_Click(sender, e);
                    goto l;
                }


            }
            frmKholaseVaziatM child = new frmKholaseVaziatM();
            child.MdiParent = this;
            child.Show();
        }

        private void btnKholaseW_Click(object sender, EventArgs e)
        {
        l: foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmmain")
                {
                    f.Close();
                    break;
                    // btnopenInsertBaseMoen_Click(sender, e);
                    goto l;
                }


            }
            frmKholaseVaziatW child = new frmKholaseVaziatW();
            child.MdiParent = this;
            child.Show();
        }

        private void btnmainpage_Click(object sender, EventArgs e)
        {
        l: foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmmain")
                {
                    f.Close();
                    break;
                    // btnopenInsertBaseMoen_Click(sender, e);
                    goto l;
                }


            }
            frmdefault child = new frmdefault();
            child.MdiParent = this;
            child.Show();
        }

        
    }
}
