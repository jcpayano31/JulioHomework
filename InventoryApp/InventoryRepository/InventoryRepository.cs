using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDB;

namespace InventoryRepository
{
    public class InventoryModel 
    {
        public int InventoryItem { get; set; }
        public string  InventoryDescription { get; set; }
        public decimal InventoryPricePerItem { get; set; }
        public int InventoryQuantityOnHand { get; set; }
        public decimal InventoryCostPerItem { get; set; }
        public decimal InventoryValueOfItemAge{ get; set; }
        public System.DateTime CreatedDate { get; set; }

       
    }

    public class InventoryRepository
    {
        public InventoryModel Add(InventoryModel inventoryModel)
        {
            var inventoryDb = ToDbModel(inventoryModel);

            DatabaseManager.Instance.Inventories.Add(inventoryDb);
            DatabaseManager.Instance.SaveChanges();

            inventoryModel = new InventoryModel
            {
                InventoryItem = inventoryDb.InventoryItem,
                InventoryDescription = inventoryDb.InventoryDescription,
                InventoryPricePerItem = inventoryDb.InventoryPricePerItem,
                InventoryCostPerItem = inventoryDb.InventoryCostPerItem,
                InventoryQuantityOnHand = inventoryDb.InventoryQuantityOnHand,
                InventoryValueOfItemAge = inventoryDb.InventoryValueOfItemAge,
                CreatedDate = inventoryDb.Inventory_CreatedDate,
                

            };
            return inventoryModel;
        }


        public List<InventoryModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Inventories
              .Select(t => new InventoryModel
              {


                  InventoryItem = t.InventoryItem,
                  InventoryDescription = t.InventoryDescription,
                  InventoryPricePerItem = t.InventoryPricePerItem,
                  InventoryQuantityOnHand = t.InventoryQuantityOnHand,
                  InventoryCostPerItem = t.InventoryCostPerItem,
                  InventoryValueOfItemAge = t.InventoryValueOfItemAge,
                  CreatedDate = t.Inventory_CreatedDate,

              }).ToList();

            return items;
        }




        public bool Update(InventoryModel inventoryModel)
        {
            var original = DatabaseManager.Instance.Inventories.Find(inventoryModel.InventoryItem);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(inventoryModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }
            return false;

        }


        public bool Remove(int inventoryItem)
        {
            var items = DatabaseManager.Instance.Inventories.Where(t => t.InventoryItem == inventoryItem);

            if (items.Count() ==0)
            {
                return false;
            }
            DatabaseManager.Instance.Inventories.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;

        }



        private Inventory ToDbModel(InventoryModel inventoryModel)
        {
            var inventoryDb = new Inventory
            {
                InventoryItem = inventoryModel.InventoryItem,
                InventoryDescription = inventoryModel.InventoryDescription,
                InventoryPricePerItem = inventoryModel.InventoryPricePerItem,
                InventoryQuantityOnHand = inventoryModel.InventoryQuantityOnHand,
                InventoryCostPerItem = inventoryModel.InventoryCostPerItem,
                InventoryValueOfItemAge = inventoryModel.InventoryValueOfItemAge,
                Inventory_CreatedDate = inventoryModel.CreatedDate,

            };

            return inventoryDb;
        }
    }
}
