﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace JobsInABA.DAL.Entities
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class JobsInABAEntities : DbContext
{
    public JobsInABAEntities()
        : base("name=JobsInABAEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BusinessAddress> BusinessAddresses { get; set; }

    public virtual DbSet<BusinessEmail> BusinessEmails { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<BusinessImage> BusinessImages { get; set; }

    public virtual DbSet<BusinessPhone> BusinessPhones { get; set; }

    public virtual DbSet<BusinessUserMap> BusinessUserMaps { get; set; }

    public virtual DbSet<ClassType> ClassTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<JobApplication> JobApplications { get; set; }

    public virtual DbSet<JobApplicationState> JobApplicationStates { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<TypeCode> TypeCodes { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<UserEmail> UserEmails { get; set; }

    public virtual DbSet<UserImage> UserImages { get; set; }

    public virtual DbSet<UserPhone> UserPhones { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<User> Users { get; set; }

}

}

