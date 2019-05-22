using InventoryApp.Models;
using System;
using System.Windows;




namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        

        public InventoryWindow()
        {
            InitializeComponent();
            // dont shoe this window in the task bar
            ShowInTaskbar = false;
        }

        public InventoryModel Inventory { get; set; }


        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Inventory = new InventoryModel();
           
            Inventory.InventoryDescription = uxIDescription.Text;
            Inventory.CreatedDate = DateTime.Now;




            decimal txtBoxInvertoryPricePerItem;
            if (Decimal.TryParse(uxIPricePerItem.Text, out txtBoxInvertoryPricePerItem))
            {
                Inventory.InventoryPricePerItem = txtBoxInvertoryPricePerItem;

            }
            else
            {

                // Do Nothing

            }


            decimal txtBoxInventoryCostPerItem;
            if (Decimal.TryParse(uxICostPerItem.Text, out txtBoxInventoryCostPerItem))
            {
                Inventory.InventoryCostPerItem = txtBoxInventoryCostPerItem;
            }
            else
            {
                // do Nothing
            }

            //Inventory.InventoryQuantityOnHand = uxIQuantityOnHand.Text;
            int txtBoxInventoryQuantityOnHand;
            if (int.TryParse(uxIQuantityOnHand.Text, out txtBoxInventoryQuantityOnHand))
            {
                Inventory.InventoryQuantityOnHand = txtBoxInventoryQuantityOnHand;
            }
            else
            {
                // do nothing
            }

            int txtBoxInventoryItem;
            if (int.TryParse(uxItem.Text, out txtBoxInventoryItem))
            {
                Inventory.InventoryItem = txtBoxInventoryItem;

            }
            else
            {
                // do something to desable field
                
            }



            Inventory.InventoryValueOfItemAge = (Inventory.InventoryPricePerItem * Inventory.InventoryQuantityOnHand);

            //decimal txtBoxInventoryValueOfItemAge;
            //if (decimal.TryParse(uxValueOfItemAge.Text, out txtBoxInventoryValueOfItemAge))
            //{
            //    Inventory.InventoryValueOfItemAge = txtBoxInventoryValueOfItemAge;
            //}
            //else
            //{
            //    // Do Noting
            //}


            // This is the return valie of ShowDialog() below
            DialogResult = true;
            Close();
        }



        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Inventory != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Inventory = new InventoryModel();
                Inventory.CreatedDate = DateTime.Now;
            }
            uxGrid.DataContext = Inventory;
        }


    }
}
