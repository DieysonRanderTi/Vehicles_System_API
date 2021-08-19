using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

    }
}
