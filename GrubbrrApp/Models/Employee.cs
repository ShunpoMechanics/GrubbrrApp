using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrubbrrApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Birth Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Join Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? JoinDate { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string Role { get; set; }
        public string Skills { get; set; }
        public string Hobbies { get; set; }

        public enum GenderTypes {
        Male,
        Female
        }

        [NotMapped]
        public virtual IList<Skill> SkillsArr { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }

        [NotMapped]
        public virtual IList<Hobby> HobbiesArr { get; set; }

        public Employee() { }
    }
}