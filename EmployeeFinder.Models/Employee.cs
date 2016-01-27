using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFinder.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        private ICollection<Company> companies;
        public Employee()
        {
            this.companies=new HashSet<Company>();
        }
        [Key]
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
