using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_of_Online_Product_Management_System.Models
{
    public class Actor
    {

        public int Id { get; set; }

        public string UserType { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
