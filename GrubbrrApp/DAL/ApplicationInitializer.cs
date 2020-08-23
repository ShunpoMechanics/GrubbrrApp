using GrubbrrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrubbrrApp.DAL
{
    public class ApplicationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeContext>
    {
        protected override void Seed(EmployeeContext context)
        {
            var employees = new List<Employee> {
                new Employee{FirstName="Jonathan",LastName="Correa", Address="860 NW 86th Ave", BirthDate=DateTime.Parse("1996-09-24"), JoinDate=DateTime.Parse("2020-08-24"), Gender="Male", About="New applicant looking forward to a excellent opportunity" },
                new Employee{FirstName="John", LastName="Doe", Address="2020 End of Days Ave", BirthDate=DateTime.Parse("1930-12-25"), JoinDate=DateTime.Parse("2002-04-14"), Gender="Male", About= "Seen it all, tired of it." },
                new Employee{FirstName="Jane", LastName="Doe", Address="7345 Fairway Dr", BirthDate=DateTime.Parse("1940-01-01"), JoinDate=DateTime.Parse("2003-05-14"), Gender="Female", About="Happy person, no relation to John stop asking." }
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var skills = new List<Skill> {
                new Skill{SkillName="HTML/CSS"},
                new Skill{SkillName=".NET"},
                new Skill{SkillName="Android"},
                new Skill{SkillName="iOS"},
                new Skill{SkillName="Java"},
                new Skill{SkillName="SQL"},
                new Skill{SkillName="AI"},
                new Skill{SkillName="ML"},
                new Skill{SkillName="XML"},
                new Skill{SkillName="Python"},
                new Skill{SkillName="JavaScript/jQuery"}
                };

            skills.ForEach(s => context.Skills.Add(s));
            context.SaveChanges();

            var roles = new List<Role> {
                new Role{RoleName="Business Analyst"},
                new Role{RoleName="Project Manager"},
                new Role{RoleName="Software Developer"},
                new Role{RoleName="Web Developer"}
                };

            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var hobbies = new List<Hobby> {
                new Hobby{HobbyName="League of Legends"},
                new Hobby{HobbyName="Archery"},
                new Hobby{HobbyName="Painting Miniatures"},
                new Hobby{HobbyName="Axe Throwing"}
            };

            hobbies.ForEach(h => context.Hobbies.Add(h));
            context.SaveChanges();
        }
        
    }
}