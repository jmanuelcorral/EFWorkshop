using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSchool.Data.DbMappings
{
    public class CourseMappingConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Ignore(x => x.isComplete);
            builder.Property(x => x.CourseName).HasColumnName("Name").HasMaxLength(DBConstants.MaxLenghtInNames);
        }
    }
}
