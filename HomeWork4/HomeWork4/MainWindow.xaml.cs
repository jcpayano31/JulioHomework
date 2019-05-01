using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace HomeWork4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }

        public int zipcode
        {
            get
            {
                return int.Parse(uxZipcode.Text);
            }
            set
            {
                uxZipcode.Text = zipcode.ToString();
            }

        }


        private void uxZipcode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);



        }


        private void uxZipcode_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            //// string zipCodePattern = @"^\d{2}\s?\d{2}$";

            string zipCodePattern = @"^\d{4}$";

            bool isZipValid = Regex.IsMatch(uxZipcode.Text, zipCodePattern);
            if (!isZipValid)
            {


                uxSubmit.IsEnabled = false;

            }
            else
            {
                uxSubmit.IsEnabled = true;

            };



        }



        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting Sic Code: " + uxZipcode.Text);
        }

        private void uxZipcode_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));

                Regex regex = new Regex("[^0-9]+");
                if (regex.IsMatch(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
