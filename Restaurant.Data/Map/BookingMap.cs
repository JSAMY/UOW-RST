using Restaurant.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Map
{
    public class BookingMap : EntityTypeConfiguration<Booking>
    {
        public BookingMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.PhoneNum).IsRequired();
            Property(t => t.PreferredDateTime).IsRequired();
            Property(t => t.TableNo);
            Property(t => t.CreatedAt).IsRequired();

            ToTable("Booking");
        }
    }
}
