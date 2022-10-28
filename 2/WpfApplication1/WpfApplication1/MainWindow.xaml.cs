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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            int luku = rng.Next(1, 100);
           {
                if (!LstNames.Items.Contains(luku))
                {
                    LstNames.Items.Add(luku.ToString()+" Lisättiin");
                    TxtName.Items.Add(luku);
                }
            } 
        }

        private void Pertti_Click_1(object sender, RoutedEventArgs e)
        {
            LstNames.Items.Add("Nappia "+ Pertti.Content.ToString()+" Painettiin "+ DateTime.Now.ToString() );
            MessageBox.Show($" Hei {Pertti.Content}");
        }

        private void Simo_Click(object sender, RoutedEventArgs e)
        {
            LstNames.Items.Add("Nappia " + Simo.Content.ToString() + " Painettiin " + DateTime.Now.ToString());
            MessageBox.Show($" Hei {Simo.Content}");
        }

        private void Raimo_Click(object sender, RoutedEventArgs e)
        {
            LstNames.Items.Add("Nappia " + Raimo.Content.ToString() + " Painettiin " + DateTime.Now.ToString());
            MessageBox.Show($" Hei {Raimo.Content}");
        }

        private void Keijo_Click(object sender, RoutedEventArgs e)
        {
            LstNames.Items.Add("Nappia " + Keijo.Content.ToString() + " Painettiin " + DateTime.Now.ToString());
            MessageBox.Show($" Hei {Keijo.Content}");
        }


    

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
           
            TxtName.Items.RemoveAt(TxtName.SelectedIndex);

        }


        private void LisLeave_mouse(object sender, MouseEventArgs e)
        {
            LstNames.Items.Add($"Hiiri lähti {DateTime.Now.ToString()}");
        }

        private void Listnames_mouse(object sender, MouseEventArgs e)
        {
            LstNames.Items.Add($"Hiiri palasi {DateTime.Now.ToString()}");
        }

        private void ListMove_mouse(object sender, MouseEventArgs e)
        {
            LstNames.Items.Add($"Hiiri liikkui {DateTime.Now.ToString()}");
        }
    }
}
