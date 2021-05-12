using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSchool.Data.DbMappings
{
    public class ProfessorMappingConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(x => x.ProfessorName).HasColumnName("Name").HasMaxLength(DBConstants.MaxLenghtInNames);
            builder.Ignore(x => x.IsSenior);

        }
    }
}
