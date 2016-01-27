namespace EmployeeFinder.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string Content { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual User User { get; set; }
    }
}