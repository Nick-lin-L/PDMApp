using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PDMApp.Models
{
    public partial class pcms_pdm_testContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<work_order_head>(entity =>
            {
                entity.Property(p => p.RowVersion)
                    .HasColumnName("xmin")
                    .HasColumnType("xid")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });
            modelBuilder.Entity<work_order_item>(entity =>
            {
                entity.Property(p => p.RowVersion)
                    .HasColumnName("xmin")
                    .HasColumnType("xid")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });
            modelBuilder.Entity<pdm_namevalue_new>(entity =>
            {
                entity.Property(p => p.RowVersion)
                    .HasColumnName("xmin")
                    .HasColumnType("xid")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });
            modelBuilder.Entity<global_users>(entity =>
            {
                entity.Property(p => p.RowVersion)
                    .HasColumnName("xmin")
                    .HasColumnType("xid")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            // modelBuilder.Entity<work_order_head>().UseXminAsConcurrencyToken();
            // modelBuilder.Entity<work_order_item>().UseXminAsConcurrencyToken();
            // modelBuilder.Entity<pdm_namevalue_new>().UseXminAsConcurrencyToken();
            // modelBuilder.Entity<global_users>().UseXminAsConcurrencyToken();
        }
    }
}