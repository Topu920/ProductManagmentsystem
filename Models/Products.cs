namespace Project_of_Online_Product_Management_System.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }

        public string PhotoPathOfProduct { get; set; }
        public int FreezeProduct { get; set; }

        public int UserId { get; set; }


    }
}
