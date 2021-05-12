using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSchool.Data.DbMappings
{
    public static class DBConstants
    {
        public static int MaxLenghtInNames = 250;
    }
    public class StudentMappingConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Ignore(x => x.IsSenior);
            builder.Property(x => x.StudentName).HasColumnName("Name").HasMaxLength(DBConstants.MaxLenghtInNames);
        }
    }
}
