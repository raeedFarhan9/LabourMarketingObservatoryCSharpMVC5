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
    
    public partial class CompanySstatistic
    {
        public int statistic_id { get; set; }
        public string aspNetUsersId { get; set; }
        public Nullable<System.DateTime> statistic_date { get; set; }
        public Nullable<bool> statistic_isActive { get; set; }
        public double statistic_certificate { get; set; }
        public double statistic_specialization { get; set; }
        public double statistic_comunication1 { get; set; }
        public double statistic_comunication2 { get; set; }
        public double statistic_comunication3 { get; set; }
        public double statistic_analysis_skills1 { get; set; }
        public double statistic_analysis_skills2 { get; set; }
        public double C_statistic_analysis_skills3 { get; set; }
        public double statistic_leaning1 { get; set; }
        public double statistic_leaning2 { get; set; }
        public double statistic_leaning3 { get; set; }
        public double statistic_leadership1 { get; set; }
        public double statistic_leadership2 { get; set; }
        public double statistic_leadership3 { get; set; }
        public double statistic_problem_solving1 { get; set; }
        public double statistic_problem_solving2 { get; set; }
        public double statistic_problem_solving3 { get; set; }
        public double statistic_efficiency1 { get; set; }
        public double statistic_efficiency2 { get; set; }
        public double statistic_efficiency3 { get; set; }
        public double statistic_practical_experience1 { get; set; }
        public double statistic_practical_experience2 { get; set; }
        public double statistic_practical_experience3 { get; set; }
        public double statistic_high_pay1 { get; set; }
        public double statistic_high_pay2 { get; set; }
        public double statistic_high_pay3 { get; set; }
        public double statistic_accepting_without_desier1 { get; set; }
        public double statistic_accepting_without_desier2 { get; set; }
        public double statistic_accepting_without_desier3 { get; set; }
        public double statistic_emigration1 { get; set; }
        public double statistic_emigration2 { get; set; }
        public double statistic_emigration3 { get; set; }
        public double statistic_focus_on_practice1 { get; set; }
        public double statistic_focus_on_practice2 { get; set; }
        public double statistic_focus_on_practice3 { get; set; }
        public double statistic_update_content1 { get; set; }
        public double statistic_update_content2 { get; set; }
        public double statistic_update_content3 { get; set; }
        public double statistic_team_work1 { get; set; }
        public double statistic_team_work2 { get; set; }
        public double statistic_team_work3 { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}