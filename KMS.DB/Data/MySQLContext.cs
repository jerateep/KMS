using KMS.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KMS.DB.Data
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }
        public MySQLContext(DbContextOptions<MySQLContext> options)
          : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string Constr = "server=localhost;database=KMS;user=root;password=Abc@12345;TreatTinyAsBoolean=true;";
                optionsBuilder.UseMySql(Constr, o => o.EnableRetryOnFailure());
            }
        }
        public DbSet<KMS_User> KMS_User { get; set; }
        public DbSet<KMS_Menu> KMS_Menu { get; set; }
        public DbSet<KMS_UserMenu> KMS_UserMenu { get; set; }
        public DbSet<KMS_UserPermission> KMS_UserPermission { get; set; }
        public DbSet<KMS_Permission> KMS_Permission { get; set; }
        public DbSet<KMS_MSTASSET> KMS_MSTASSET { get; set; }
        public DbSet<KMS_AssetType> KMS_AssetType { get; set; }
        public DbSet<KMS_MSTLocation> KMS_MSTLocation { get; set; }
        public DbSet<KMS_MSTKey> KMS_MSTKey { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
