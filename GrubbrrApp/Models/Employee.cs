using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrubbrrApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public string JoinDate { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string Role { get; set; }
        public string Skills { get; set; }
        public string Hobbies { get; set; }

        //public virtual ICollection<Skill> Skills { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }
        //public virtual ICollection<Hobby> Hobbies { get; set; }

        public Employee() { }
    }
}