using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace ItemsApitest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var itemsApi = service.GetItemsApi();
                var parameters = new Dictionary<object, object>();
                var itemsList = itemsApi.GetItems(parameters);
                var items = itemsList;
                var itemId = items[1].item_id;
                foreach (var item in items)
                    Console.WriteLine("Item id:{0},\nName:{1},\ndescription:{2},\nRate:{3}\n", item.item_id, item.name, item.description, item.rate);
                var item1 = itemsApi.Get(itemId);
                Console.WriteLine("Item id:{0},\nName:{1},\ndescription:{2},\nRate:{3}\n", item1.item_id, item1.name, item1.description, item1.rate);
                var newItemInfo = new LineItem()
                {
                    name="computer hardware21",
                    rate=1500
                };
                var newItem = itemsApi.Create(newItemInfo);
                Console.WriteLine("Item id:{0},\nName:{1},\ndescription:{2},\nRate:{3}\n", newItem.item_id, newItem.name, newItem.description, newItem.rate);
                var updateInfo = new LineItem()
                {
                    description = "ram of 1gb"
                };
                var updatedItem = itemsApi.Update(newItem.item_id, updateInfo);
                Console.WriteLine("Item id:{0},\nName:{1},\ndescription:{2},\nRate:{3}\n", updatedItem.item_id, updatedItem.name, updatedItem.description, updatedItem.rate);
                var deleteMsg = itemsApi.Delete(updatedItem.item_id);
                Console.WriteLine(deleteMsg);
                var inactiveMsg = itemsApi.MarkAsInactive(itemId);
                Console.WriteLine(inactiveMsg);
                var activeMsg = itemsApi.MarkAsActive(itemId);
                Console.WriteLine(activeMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
