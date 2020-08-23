using System.ComponentModel.DataAnnotations.Schema;

namespace GrubbrrApp.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
    }
}