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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            //var db = new rlarEntities();


            var sm = Core.DB.StroyMaterial.ToList();
            var sk = Core.DB.Sklad.ToList();

            _myElements = sm;
            _skElements = sk;

        }
        private List<Sklad> _skElements;

        public List<Sklad> SKElements
        {
            get
            {
                return _skElements;
            }
            set
            {
                _skElements = value;
            }
        } 

        private List<StroyMaterial> _myElements;

        public List<StroyMaterial> MyElements
        {
            get
            {
                return _myElements;
            }
            set
            {
                _myElements = value;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddStroyMaterial( new StroyMaterial() ));
        }

        private void MainListView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem as StroyMaterial);
            Core.DB.StroyMaterial.Remove(item);
            Core.DB.SaveChanges();
            MessageBox.Show(item.Title + " deleted");
        }

        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainFrame.Navigate(new AddStroyMaterial((sender as ListView).SelectedItem as StroyMaterial));
        }

        private void Add_Sklad_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddSklad(new Sklad()));
        }

        private void SKListView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem as Sklad);
            Core.DB.Sklad.Remove(item);
            Core.DB.SaveChanges();
            MessageBox.Show(item.adress + " deleted");
        }

        private void SKListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainFrame.Navigate(new AddSklad((sender as ListView).SelectedItem as Sklad));
        }
    }
}
