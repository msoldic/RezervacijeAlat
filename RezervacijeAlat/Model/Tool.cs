using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RezervacijeAlat.Model
{
    public class Tool
    {
        [Key]
        public int ID { get; set; }
        public string ToolType { get; set; }
        public int PriceRentPerDay { get; set; }
    }
}
