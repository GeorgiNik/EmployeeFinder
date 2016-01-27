using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFinder.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        private ICollection<Employee> employees; 
        public Company()
        {
            this.employees=new HashSet<Employee>();
        }
        public int Id { get; set; }


        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }


        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Address { get; set; }


        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get
            {
                return this.employees;
            }

            set
            {
                this.employees = value;
            }
        }


    }
}
