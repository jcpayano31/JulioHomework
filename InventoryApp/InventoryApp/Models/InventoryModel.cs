using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Models
{
    public class InventoryModel
    {
        public int InventoryItem { get; set; }
        public string InventoryDescription { get; set; }
        public decimal InventoryPricePerItem { get; set; }
        public int InventoryQuantityOnHand { get; set; }
        public decimal InventoryCostPerItem { get; set; }
        public decimal InventoryValueOfItemAge { get; set; }
        public System.DateTime CreatedDate { get; set; }



        public InventoryRepository.InventoryModel ToRepositoryModel()
        {
            
            var repositoryModel = new InventoryRepository.InventoryModel
            {
                InventoryItem = InventoryItem,
                InventoryDescription = InventoryDescription,
                InventoryCostPerItem = InventoryCostPerItem,
                InventoryPricePerItem = InventoryPricePerItem,
                InventoryQuantityOnHand = InventoryQuantityOnHand,
                InventoryValueOfItemAge = InventoryValueOfItemAge,
                CreatedDate = DateTime.Now,
            };
            return repositoryModel;

        }

        public static InventoryModel ToModel(InventoryRepository.InventoryModel repositoryModel)
        {
            var inventoryModel = new InventoryModel
            {
                InventoryItem = repositoryModel.InventoryItem,
                InventoryDescription = repositoryModel.InventoryDescription,
                InventoryCostPerItem = repositoryModel.InventoryCostPerItem,
                InventoryPricePerItem = repositoryModel.InventoryPricePerItem,
                InventoryQuantityOnHand = repositoryModel.InventoryQuantityOnHand,
                InventoryValueOfItemAge = repositoryModel.InventoryValueOfItemAge,
                CreatedDate=DateTime.Now,

            };
            return inventoryModel;

        }
    }
}

