using Evaluacion.Models;

namespace net_evaluation.Models
{
    public class Item
    {
        //Declara campos de los item
        public int itemId { get; set; }
        public string? itemName { get; set; }
        public string? itemType { get; set; }
        public string? description { get; set; }
        public int quantity { get; set; }
        public int userId { get; set; }
    }

}