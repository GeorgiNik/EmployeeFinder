using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
