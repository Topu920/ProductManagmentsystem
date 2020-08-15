using Microsoft.AspNetCore.Http;

namespace Project_of_Online_Product_Management_System.ViewModels
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }

        public IFormFile ProductPhoto { get; set; }
        public int FreezeProduct { get; set; }
    }
}
