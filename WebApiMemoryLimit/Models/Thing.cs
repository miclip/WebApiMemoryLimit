using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiMemoryLimit.Models
{
    public class Thing
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Description { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}