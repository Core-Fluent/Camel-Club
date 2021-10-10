﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelsClub.Models
{
    public class ProfileVideoConfiguration : EntityTypeConfiguration<ProfileVideo>
    {
        public ProfileVideoConfiguration()
        {
            this.ToTable("ProfileVideo", "UserProfile");
            this.HasKey<int>(x => x.ID);
            this.Property(x => x.CreatedDate).IsRequired();
            this.Property(x => x.FileName).IsRequired();
            this.HasRequired<UserProfile>(x => x.UserProfile)
                .WithMany(x => x.ProfileVideos)
                .HasForeignKey<int>(x => x.UserProfileID);
        }
    }
}
