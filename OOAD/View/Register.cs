using OOAD.Service;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OOAD.View
{
    public partial class Register : Form
    {
        private UserService userService;

        public Register()
        {
            InitializeComponent();
            var db = new Model1();
            userService = new UserService(db);
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showPass.Checked ? '\0' : '*';
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void signup_loginHere_Click(object sender, EventArgs e)
        {
            Login lForm = new Login();
            lForm.Show();
            this.Hide();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            string name = signup_name.Text;
            string username = signup_username.Text;
            string password = signup_password.Text;
            string email = signup_email.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.");
                return;
            }
            bool success = userService.Register(name, username, password, email);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công!");
                Login lForm = new Login();
                lForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc email đã tồn tại!");
            }
        }
    }
}
