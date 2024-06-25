using InvetorySystem.Core.Models.UnitModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InventorySystem.EF.Data.Config
{
    internal class UnitConfig : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}
