namespace Online_Movie_Ticket_Management.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
