using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Data.Entity;
using System.Threading;

namespace FBM.Data.Mapping
{
    public class NamedEntityMap<T> : EntityTypeConfiguration<T> where T : NamedEntity
    {
        public NamedEntityMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Desctription).HasColumnType("nvarchar").HasMaxLength(150);
        }
    }
}
