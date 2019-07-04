using NoteBoard.BLL;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteBoard.UI.WinForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            _userController = new UserController();
        }
        UserController _userController;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            User currentUser = _userController.GetLogin(txtKullaniciAdi.Text,txtSifre.Text);

            if (currentUser!=null)
            {
                if (currentUser.UserRole==UserRole.Standart)
                {
                    frmMain frm = new frmMain(currentUser);
                    frm.Owner = this;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    frmAdmin frm = new frmAdmin();
                    frm.Owner = this;
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Hatali giriş bilgileri");
            }
        }

        public void SorunCozenMethod()
        {
            _userController = new UserController();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.Owner = this;
            frm.Show();
        }
    }
}
