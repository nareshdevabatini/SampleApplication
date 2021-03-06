﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    
    public partial class AdventureWorksEntities : DbContext
    {
        public AdventureWorksEntities()
            : base("name=AdventureWorksEntities")
        {
            Database.SetInitializer<AdventureWorksEntities>(new CreateDatabaseIfNotExists<AdventureWorksEntities>());
            //this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}", validationErrors.Entry.Entity.GetType().FullName,
                                      validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // throw new UnintentionalCodeFirstException();
        }
    
        
        public DbSet<Customer> Customers { get; set; }
        
    }
}
