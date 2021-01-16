using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.ViewModels
{
    public class ToDoItemViewModel : IValidatableObject
    {

        [HiddenInput] 
        public int Id { get; set; }

        [Display(Name = "Task name")] 
        public string Name { get; set; }

        [Display(Name = "Task description")] 
        public string Description { get; set; }

        [Display(Name = "Date and time")] 
        public DateTime? Deadline { get; set; }

        public bool IsCompleted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("Name is required", new[] {nameof(Name)});
            if (Deadline != null && Deadline < DateTime.Now)
                yield return new ValidationResult("Incorect date", new[] {nameof(Deadline)});
        }
    }
}