﻿using PersonApiAssignment.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonApiAssignment.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender value")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Birth place is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Birth place must be between 2 and 100 characters")]
        public required string BirthPlace { get; set; }
    }
}
