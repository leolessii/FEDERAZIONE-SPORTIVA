using CoreFederazione;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFederazione
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Federazione federazione;
        public string password;
        public MainWindow()
        {
            InitializeComponent();
            federazione = new Federazione(TxtNome.Text);
            password = pwb.Password;
        }

        private void btn_LogIn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            if(!string.IsNullOrEmpty(password))
            {
                window.Show();
                this.Close();
            }
        }
    }
}