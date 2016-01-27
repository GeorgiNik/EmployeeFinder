namespace EmployeeFinder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        private ICollection<Company> companies;
        private ICollection<Comment> comments;

        public Employee()
        {
            this.companies=new HashSet<Company>();
            this.comments= new HashSet<Comment>();
        }
        
        public int Id { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        public string EmployeePhoto { get; set; }
        
        public int Rating { get; set; }

        public int RatingsCount { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Company> Companies
        {
            get
            {
                return this.companies;
            }

            set
            {
                this.companies = value;
            }
        }
    }
}