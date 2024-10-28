using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Truck
    {
        [Key]
        public int Id { get; set; }
        public Model Model { get; set; }    
        public int Fabricateyear { get; set; }
        public string Chassi_Code { get; set; }
        public string Color { get; set; }
        public Plan Plan { get; set; }
 
    }
}
