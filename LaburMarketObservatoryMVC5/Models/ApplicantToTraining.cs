//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaburMarketObservatoryMVC5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class ApplicantToTraining
    {
        public string aspNetUsersId { get; set; }
        public int training_id { get; set; }
        [Display(Name = "������")]
        public string note { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Training Training { get; set; }
    }
}
