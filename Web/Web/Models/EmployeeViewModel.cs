namespace Erzasoft.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Erzasoft.DataModel.Semestralka;

    public class EmployeeViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Jméno")]
        [Required]
        public string Firstname { get; set; }

        [Display(Name = "Příjmení")]
        [Required]
        public string Lastname { get; set; }

        [Display(Name = "Plat")]
        [Required]
        public decimal Pay { get; set; }

        [Display(Name = "Titul")]        
        public string Title { get; set; }

        [Display(Name = "Datum nástupu")]
        [Required]
        public DateTime StartDate { get; set; }

        public static Expression<Func<Employee, EmployeeViewModel>> ToModel()
        {
            Expression<Func<Employee, EmployeeViewModel>> select =
                s =>
                new EmployeeViewModel
                {
                    Id = s.Id,
                    Firstname = s.Firstname,
                    Lastname = s.Lastname,
                    Pay = s.Pay,
                    Title = s.Title,
                    StartDate = s.StartDate
                };

            return select;
        }


        public static void ToData(Employee employee, EmployeeViewModel model)
        {
            employee.Firstname = model.Firstname;
            employee.Lastname = model.Lastname;
            employee.Pay = model.Pay;
            employee.StartDate = model.StartDate;
            employee.Title = model.Title;
        }
    }
}