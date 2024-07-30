using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Web.Models
{
    public class ShippersBaseModel
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    
    }
}
