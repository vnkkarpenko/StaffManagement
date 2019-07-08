using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaffManagement.Core.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonnelNumber => $"t000{Id}";
        public double Rate { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int SubdivisionId { get; set; }
        public int PositionId { get; set; }
    }

    public class Subdivision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDateTime { get; set; }
    }

    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDateTime { get; set; }
    }

    public class NewEmployeeViewModel   
    {   
        public int Id { get; set; }  

        [Required]   
        [Display(Name = "Имя")]   
        public string FirstName { get; set; }   
   
        [Required]   
        [Display(Name = "Фамилия")]   
        public string Surname { get; set; }   

        [Required]   
        [Display(Name = "Отчество")]   
        public string Patronymic { get; set; }   

        [Required]   
        [Display(Name = "Дата рождения")]   
        public string BirthDate { get; set; }   

        [Required]   
        [Display(Name = "Подразделение")]   
        public string Subdivision { get; set; }   
        
        [Required]   
        [Display(Name = "Должность")]   
        public string Position { get; set; }

        [Required]   
        [Display(Name = "Ставка")]   
        public double Rate { get; set; }   

        [Required]   
        [EmailAddress]   
        [Display(Name = "Email")]   
        public string Email { get; set; }  

        [Required]   
        [Display(Name = "Статус")]   
        public string Status { get; set; }
    }

    public class TableStaffViewModel   
    {   
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }   
        public string Surname { get; set; }   
        public string Patronymic { get; set; }
        public string BirthDate { get; set; }
        public string PersonnelNumber { get; set; }
        public string Subdivision { get; set; }
        public string Position { get; set; }
        public string Rate { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }  
}
