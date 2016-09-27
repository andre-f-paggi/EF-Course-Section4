﻿using System.Data.Entity.ModelConfiguration;
using Vidzy.Model;

namespace Vidzy.EntityConfigurations
{
    public class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            Property(v => v.Classification)
                .HasColumnType("tinyint");

            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);

            HasMany(v => v.Tags)
                .WithMany(t => t.Videos).Map(m =>
                    {
                        m.ToTable("VideoTags");
                        m.MapLeftKey("VideoId");
                        m.MapRightKey("TagId");
                    });
        }
    }
}