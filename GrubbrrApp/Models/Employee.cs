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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string Role { get; set; }
        public string Skills { get; set; }
        public string Hobbies { get; set; }

        //[NotMapped]
        //public int[] SkillsArr {
        //    get
        //    {
        //        string[] tab = Skills.Split(',');
        //        return new int[] { int.Parse(tab[0]), int.Parse(tab[1]) };
        //    }
        //    set
        //    {
        //        Skills = string.Format("{0},{1}", value[0], value[1]);
        //    }
        //}

        //[NotMapped]
        //public int[] HobbiesArr {
        //    get
        //    {
        //        string[] tab = Hobbies.Split(',');
        //        return new int[] { int.Parse(tab[0]), int.Parse(tab[1]) };
        //    }
        //    set
        //    {
        //        Hobbies = string.Format("{0},{1}", value[0], value[1]);
        //    }
        //}

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