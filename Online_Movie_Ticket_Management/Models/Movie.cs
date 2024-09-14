using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Movie_Ticket_Management.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        //Relationships
        public List<Actor_Movie>? Actors_Movies { get; set; }

        //Cinema
       

        //Producer
        public int ProducerId { get; set; }
      
        public Producer? Producer { get; set; }
    }
}
