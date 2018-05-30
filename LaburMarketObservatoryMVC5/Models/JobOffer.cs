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
    
    public partial class JobOffer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobOffer()
        {
            this.ApplicantToJobOffers = new HashSet<ApplicantToJobOffer>();
            this.Skills = new HashSet<Skill>();
        }
    
        public int advert_id { get; set; }
        public string aspNetUsersId { get; set; }
        [Display(Name = "��� ��������")]
        public Nullable<int> offer_emp_num { get; set; }
        [Display(Name = "��� �������")]
        public string offer_type_of_employment { get; set; }
        [Display(Name = "������� �������")]
        public string offer_certificate { get; set; }
        [Display(Name = "������ ������")]
        public string offer_specialization { get; set; }
        [Display(Name = "��� ����� ������")]
        public Nullable<int> offer_experience_years { get; set; }
        [Display(Name = "�����")]
        public string offer_gender { get; set; }
        [Display(Name = "�����")]
        public Nullable<int> offer_age { get; set; }
        [Display(Name = "�������")]
        public string offer_address { get; set; }
        [Display(Name = "��� ����� �����")]
        public Nullable<int> offer_working_hours { get; set; }
        [Display(Name = "������")]
        public Nullable<double> offer_salary { get; set; }
        [Display(Name = "���� �� �ǿ")]
        public bool offer_active { get; set; }
        [Display(Name = "����� �����")]
        public Nullable<System.DateTime> offer_publishDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicantToJobOffer> ApplicantToJobOffers { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
