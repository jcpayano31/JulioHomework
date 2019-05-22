using System.Windows;
using System.Linq;
using InventoryApp.Models;
using System.Windows.Controls;

    


namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

            LoadInventory();
        }


        private void LoadInventory()
        {
            var inventory = App.InventoryRepository.GetAll();

            uxInventoryList.ItemsSource = inventory
                .Select(t => InventoryModel.ToModel(t)).ToList();

            // OR
            //var uiInventoryModelList = new List<InventoryModel>();
            //foreach (var repositoryInventoryModel in inveentory)
            //{
            //    This is the .Select(t => ... )
            //    var uiInventoryModel = InventoryModel.ToModel(repositoryInventoryModel);
            //
            //    uiInventoryModelList.Add(uiInventoryModel);
            //}

            //uxInventoryList.ItemsSource = uiInventoryModelList;


        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new InventoryWindow();

            if (window.ShowDialog() == true)
            {
                var uiInventoryModel = window.Inventory;


                var repositoryInventoryModel = uiInventoryModel.ToRepositoryModel();


                App.InventoryRepository.Add(repositoryInventoryModel);

                LoadInventory();

            }

        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new InventoryWindow();
            window.Inventory = selectedInventory;

            if (window.ShowDialog()== true)
            {
                App.InventoryRepository.Update(window.Inventory.ToRepositoryModel());
                LoadInventory();
            }

        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled=(selectedInventory != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
                
        }



        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.InventoryRepository.Remove(selectedInventory.InventoryItem);
            selectedInventory = null;
            LoadInventory();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedInventory != null);

            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }


        // Exercise 1: Inventory List - sort columns
        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);

            // Grab the Tag from the column header
            string sortBy = column.Tag.ToString();

            // Clear out any previous  column sorting
            uxInventoryList.Items.SortDescriptions.Clear();

            // sort the uxInventoryList by the column header tag (sortBy)
            // if you want to do Descending, look at the homework :) and SortAdorner

            var sortDescription = new System.ComponentModel.SortDescription(sortBy, System.ComponentModel.ListSortDirection.Ascending);
            uxInventoryList.Items.SortDescriptions.Add(sortDescription);
           
        }

        private InventoryModel selectedInventory;

         private void uxInventoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedInventory = (InventoryModel)uxInventoryList.SelectedValue;
        }

        private void uxFileClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
