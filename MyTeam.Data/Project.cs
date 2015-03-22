//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTeam.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Project
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Team")]
        public int FK_Team { get; set; }
        [Required]
        [MaxLength(49)]
        public string Title { get; set; }
        [Required]
        [MaxLength(49)]
        public string Description { get; set; }
        public string Status { get; set; }
        [Display(Name = "% Complete")]
        [Range(0, 100, ErrorMessage="Must be between 0 and 100")]
        public int PercentageCompleted { get; set; }
        [Display(Name = "Date Started")]
        [DataType(DataType.Date)]
        public System.DateTime StartDate { get; set; }


        [Required]
        //[Display(Name = "Date Due")]
        public Nullable<System.DateTime> EndDate { get; set; }
        
        
        
        
        [Display(Name = "Days Until Due")]
        public Nullable<int> Duration { get; set; }
    }
}
