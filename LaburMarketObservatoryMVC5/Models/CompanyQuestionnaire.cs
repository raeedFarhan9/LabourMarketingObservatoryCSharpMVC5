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
    
    public partial class CompanyQuestionnaire
    {
        public int comp_qus_id { get; set; }
        public string aspNetUsersId { get; set; }
        [Display(Name = "������ �������")]
        public int Comunication { get; set; }
        [Display(Name = "�������� ������� ����������")]
        public int analysis_skills { get; set; }
        [Display(Name = "������� ������� ������")]
        public int leaning { get; set; }
        [Display(Name = "�������� ��������")]
        public int leadership { get; set; }
        [Display(Name = "������ ��� ����� ������")]
        public int problem_solving { get; set; }
        [Display(Name = "�������� ��� ������")]
        public int efficiency { get; set; }
        [Display(Name = "������ �������")]
        public int practical_experience { get; set; }
        [Display(Name = "��� ���� �����")]
        public int high_pay { get; set; }
        [Display(Name = "����� ���� ����")]
        public int accepting_without_desier { get; set; }
        [Display(Name = "������")]
        public int emigration { get; set; }
        [Display(Name = "������� ��� �������� �������")]
        public int focus_on_practice { get; set; }
        [Display(Name = "����� ������ ������")]
        public int update_content { get; set; }
        [Display(Name = "����� ��� ������")]
        public int team_team_work { get; set; }
        [Display(Name = "����� �����")]
        public Nullable<System.DateTime> compQuestionnair_publishDate_ { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
