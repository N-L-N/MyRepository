using ProperDiet.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDiet.Models.Entity
{
    public class User
    {
        public int Id { get; set; } 

        public string Name { get; set; } 

        public string Password { get; set; }

        public int HumanId { get; set; }
    }
}
