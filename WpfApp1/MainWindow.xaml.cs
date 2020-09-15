using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            using (DbContext)
                try
                {
                    User dc = new User();
                    var userLogin = (from u in dc.Login
                                     where u.Login == txtLogin.Text
                                     select u).ToArray();
                    var userPass = (from u in dc.users
                                    where u.pas_user == tbPass.Password
                                    select u).ToArray();
                    if (tbLog.Text == userLogin[0].lod_user)
                    {
                        if (tbPass.Password == userPass[0].pas_user)
                        {
                            Window1 w1 = new Window1();
                            w1.Show();
                            this.Hide();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Введите корректные данные");
                }
        }
    }
}
