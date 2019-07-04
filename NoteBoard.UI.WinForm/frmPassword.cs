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
    public partial class frmPassword : Form
    {
        PasswordController _passwordController; 
        Password _pass;
        public frmPassword(Password password)
        {
            InitializeComponent();
            _pass = password;
            _passwordController = new PasswordController();
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            if (txtEskiSifre.Text!=_pass.PasswordText)
            {
                MessageBox.Show("Lütfen eski şifrenizi doğru giriniz");
                return;
            }
            else if (txtYeniSifre.Text!=txtYeniSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor");
                return;
            }

            Password newPassword = new Password();
            newPassword.PasswordText = txtYeniSifre.Text;
            newPassword.UserID = _pass.UserID;

            try
            {
                bool result = _passwordController.Add(newPassword);
                if (result)
                {
                    MessageBox.Show("Şifre güncellendi");
                }
                else
                {
                    MessageBox.Show("Şifre güncellenemedi");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
