using Evaluacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_evaluation.Models;

namespace Evaluacion.Controllers
{
[ApiController]
    [Route("[controller]")]

    public class ItemController : ControllerBase
    {
        //Lista predeterminada de archivos de oficina
        private static List<Item> itemsList = new List<Item>()
        {

            new Item() { itemId = 1001, itemName = "CPU", itemType = DepartmentName.IT, description = "CPU data", quantity = 3, userId = 3},
            new Item() { itemId = 1002, itemName = "GPU", itemType = DepartmentName.IT, description = "GPU data", quantity = 5, userId = 4},

            new Item() { itemId = 1003, itemName = "Phone", itemType = DepartmentName.Sales, description = "Phone data", quantity = 11, userId = 1},
            new Item() { itemId = 1004, itemName = "Contact List", itemType = DepartmentName.Sales, description = "Contact List data", quantity = 5, userId = 1},

            new Item() { itemId = 1005, itemName = "Stappler", itemType = DepartmentName.HR, description = "Stappler data", quantity = 7, userId = 2},
            new Item() { itemId = 1006, itemName = "Employees List", itemType = DepartmentName.HR, description = "Employee list data", quantity = 2, userId = 2},

            new Item() { itemId = 1007, itemName = "CNC", itemType = DepartmentName.Production, description = "CNC data", quantity = 1, userId = 4},
            new Item() { itemId = 1008, itemName = "3D Printer", itemType = DepartmentName.Production, description = "3D printer data", quantity = 2, userId = 3},
        };

        //Get All Items
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(itemsList);
        }

        //Add new item
        [HttpPost("add")]
        public IActionResult Add(Item item)
        {
            var itemsListCount = itemsList.Count();
            item.itemId = 1000 + 1 + itemsListCount;
            itemsList.Add(item);
            return Ok(item);
        }

        //Get Specific Item
        [HttpGet("getItem/{id}")]
        public IActionResult GetItem(int id)
        {
            try
            {
                var item = itemsList.First(item => item.itemId == id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                
                return Ok(ex.Message);
            }
        }

        //Update Item
        [HttpPatch("updateItem")]
        public IActionResult UpdateItem(Item item)

        {
            try
            {
                foreach(var objeto in itemsList)
                {
                    if(objeto.itemId == item.itemId)
                    {

                        objeto.itemName = item.itemName;
                        objeto.itemType = item.itemType;
                        objeto.description = item.description;
                        objeto.quantity = item.quantity;
                        objeto.userId = item.userId;

                    }
                    
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                
                return Ok(ex.Message);
            }
        }

        [HttpDelete("deleteItem/{id}")]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                
                foreach(var item in itemsList)
                {
                    if(item.itemId == id)
                    {
                        itemsList.Remove(item);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                
                return Ok(ex.Message);
            }
        }
    
        //Get By User
        [HttpGet("itemByUser/{userId}")]
        public IActionResult GetItemByUser(int userId)
        {
            try
            {
                List<Item> listByUser = new List<Item>();
                foreach(var item in itemsList)
                {
                    if(item.userId == userId)
                    {
                        listByUser.Add(item);
                    }
                }
                return Ok(listByUser);
            }
            catch (Exception ex)
            {
                
                return Ok(ex.Message);
            }
        }
    
        //Get Item By Department
        [HttpGet("itemByDepartment/{departmentName}")]
        public IActionResult ItemByDepartmentName(string departmentName)
        {
            try
            {
                List<Item> listByDepartment = new List<Item>();
                foreach(var item in itemsList)
                {
                    if(item.itemType == departmentName)
                    {
                        listByDepartment.Add(item);
                    }
                }
                return Ok(listByDepartment);
            }
            catch (Exception ex)
            {
                
                return Ok(ex.Message);
            }
        }
    }
}
