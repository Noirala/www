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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddSklad.xaml
    /// </summary>
    public partial class AddSklad : Page
    {
        
        public AddSklad(Sklad sk)
        {
            InitializeComponent();
            this.DataContext = this;
            this.CurrentSklad = sk;
        }

        public Sklad CurrentSklad { get; set; }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //if (CurrentSklad.num == 0)
                Core.DB.Sklad.Add(CurrentSklad);
            Core.DB.SaveChanges();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Core.DB.SaveChanges();
        }
    }
}
