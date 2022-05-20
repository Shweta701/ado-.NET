using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.ViewModel
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Department name can not empty!")]

        [MaxLength(ErrorMessage ="Name must be 3 Char")]
        public string Name { get; set; }
    }
}