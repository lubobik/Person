using System;
using System.ComponentModel.DataAnnotations;


namespace Test.Models
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        [StringLength(100)]
        public string Firstname { get; set; }

        [Display(Name = "Name")]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Display(Name = "Employee")]
        public bool isCompany { get; set; }

    }
}
