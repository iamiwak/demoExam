using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Culteries.Base;

namespace Culteries
{
    public partial class AuthorizationWindow : Window
    {
        Timer _blockTimer = new Timer();
        string _currentCaptcha = "";
        private Random _rnd = new Random(new Guid().GetHashCode());
        private CulteriesEntities _db = SourceCore.DataBase;

        public AuthorizationWindow()
        {
            InitializeComponent();
            CaptchaBlock.Visibility = Visibility.Hidden;
            _blockTimer.Interval = 10000;
            _blockTimer.Elapsed += OnTimerGone;
        }

        private void OnTimerGone(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                AuthorizeButton.IsEnabled = true;
            }));

            _blockTimer.Stop();
        }

        private void OnAuthorizationClick(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text,
                password = UserPasswordBox.Password;

            if (_db.User.FirstOrDefault(u => u.UserLogin == login) == null)
            {
                MessageBox.Show("This user doesn't exist!", "User not found", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CaptchaBlock.Visibility == Visibility.Visible)
            {
                string captcha = CaptchaTextBox.Text;
                if (string.IsNullOrEmpty(captcha) || captcha != _currentCaptcha)
                {
                    MessageBox.Show("You didn't wrote or wrote incorrectly captcha!", "Incorrect captcha", MessageBoxButton.OK, MessageBoxImage.Error);
                    GenerateCaptcha();
                    return;
                }
            }

            User user = _db.User.FirstOrDefault(u => u.UserLogin == login && u.UserPassword == password);
            if (user == null)
            {
                MessageBox.Show("You wrote incorrect password!", "Incorrect password", MessageBoxButton.OK, MessageBoxImage.Error);
                GenerateCaptcha();
                return;
            }

            new MainWindow(user).Show();
            Close();
        }

        private void OnGuestLoginClick(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void GenerateCaptcha()
        {
            if (CaptchaBlock.Visibility == Visibility.Visible)
            {
                AuthorizeButton.IsEnabled = false;
                AuthorizeButton.Opacity = 0.8;
                _blockTimer.Start();
            }

            CaptchaBlock.Visibility = Visibility.Visible;

            TextBlock[] chars =
            {
                FirstCharCaptcha,
                SecondCharCaptcha,
                ThirdCharCaptcha,
                FourthCharCaptcha
            };

            for (int i = 0; i < 4; i++)
            {
                int captchaMargin = _rnd.Next(-15, 15);

                int captchaCharType = _rnd.Next(3);
                int ch = 0;
                if (captchaCharType == 0) ch = _rnd.Next(70, 80);
                else if (captchaCharType == 1) ch = _rnd.Next(65, 91);
                else if (captchaCharType == 2) ch = _rnd.Next(97, 123);

                chars[i].Text = Convert.ToChar(ch).ToString();
                chars[i].Margin = new Thickness(0, captchaMargin, 0, 0);
            }

            _currentCaptcha = chars[0].Text + chars[1].Text + chars[2].Text + chars[3].Text;
        }
    }
}
