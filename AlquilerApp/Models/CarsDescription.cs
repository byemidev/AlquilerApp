using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerApp.Models
{
    public class CarsDescription
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; } 
    }
}
