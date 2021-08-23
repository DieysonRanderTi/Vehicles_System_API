using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Entities
{
    [DataContract]
    public class CarModel
    {
        [Key]
        [DataMember(Name ="id")]
        public int Id { get; set; }

        [DataMember(Name ="description")]
        public string Description { get; set; }

    }
}
