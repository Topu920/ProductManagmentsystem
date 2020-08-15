namespace Project_of_Online_Product_Management_System.Models
{
    public class CommentTable
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }
        public string Comments { get; set; }
    }
}
