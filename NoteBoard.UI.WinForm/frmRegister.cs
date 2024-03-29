﻿using NoteBoard.BLL;
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
    public partial class frmRegister : Form
    {
        UserController _userController;
        public frmRegister()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text!=txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor.");
                return;
            }

            User newUser = new User();
            newUser.FirstName = txtAdi.Text;
            newUser.LastName = txtSoyadi.Text;
            newUser.UserName = txtKullaniciAdi.Text;
            newUser.Passwords.Add (new Password()
            {
                PasswordText= txtSifre.Text
            });
            newUser.UserRole = UserRole.Standart;

            try
            {
                bool result = _userController.Add(newUser);
                if (result)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    this.Owner.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }                
    }
}
