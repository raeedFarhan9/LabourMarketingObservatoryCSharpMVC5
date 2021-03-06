﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LMO_DBEntities : DbContext
    {
        public LMO_DBEntities()
            : base("name=LMO_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<ApplicantToJobOffer> ApplicantToJobOffers { get; set; }
        public virtual DbSet<ApplicantToTraining> ApplicantToTrainings { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyQuestionnaire> CompanyQuestionnaires { get; set; }
        public virtual DbSet<CompanySstatistic> CompanySstatistics { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<JobOffer> JobOffers { get; set; }
        public virtual DbSet<JobSeeker> JobSeekers { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<SeekerQuestionnaire> SeekerQuestionnaires { get; set; }
        public virtual DbSet<SeekerStatistic> SeekerStatistics { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemLicensedCompany> SystemLicensedCompanies { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
    }
}
