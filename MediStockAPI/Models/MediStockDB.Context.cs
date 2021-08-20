﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediStockAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MediStock_DBEntities : DbContext
    {
        public MediStock_DBEntities()
            : base("name=MediStock_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Barcode> Barcodes { get; set; }
        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<Call_ItemsUsed> Call_ItemsUsed { get; set; }
        public virtual DbSet<CallCancelReason> CallCancelReasons { get; set; }
        public virtual DbSet<CallStatu> CallStatus { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Checklist> Checklists { get; set; }
        public virtual DbSet<ChecklistItem> ChecklistItems { get; set; }
        public virtual DbSet<ChecklistItemType> ChecklistItemTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTitle> EmployeeTitles { get; set; }
        public virtual DbSet<InspectionChecklist> InspectionChecklists { get; set; }
        public virtual DbSet<InspectionType> InspectionTypes { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<InterviewType> InterviewTypes { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryCategory> InventoryCategories { get; set; }
        public virtual DbSet<ItemsChecklist> ItemsChecklists { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }
        public virtual DbSet<JobPosition> JobPositions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<PriceHistory> PriceHistories { get; set; }
        public virtual DbSet<QualificationType> QualificationTypes { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<StockTake> StockTakes { get; set; }
        public virtual DbSet<StockTakeTotal> StockTakeTotals { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleCall> VehicleCalls { get; set; }
        public virtual DbSet<VehicleInspection> VehicleInspections { get; set; }
        public virtual DbSet<VehicleInventory> VehicleInventories { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<Write_OffReason> Write_OffReason { get; set; }
        public virtual DbSet<Written_OffInventory> Written_OffInventory { get; set; }
    }
}
