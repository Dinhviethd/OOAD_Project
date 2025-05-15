using OOAD.Service;
using System;
using System.Windows.Forms;

namespace OOAD.View
{
    public partial class Login : Form
    {
        private UserService userService;
        public static Login log = new Login();
        public static User user = new User();
        public Login()
        {
            InitializeComponent();
            var db = new Model1();
            userService = new UserService(db);
            log = this;
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }
        private void login_registerHere_Click(object sender, EventArgs e)
        {
            Register sForm = new Register();
            sForm.Show();
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = login_username.Text;
            string password = login_password.Text;

            User user_temp = userService.Login(username, password);

            if (user_temp != null)
            {
                user = user_temp;
                MessageBox.Show("Đăng nhập thành công!");
                Layout lay = new Layout();
                lay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
            }
        }
    }
}
