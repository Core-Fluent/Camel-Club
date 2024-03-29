﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelsClub.Models
{
    public class UserCamelSpecificationReviewConfiguration : EntityTypeConfiguration<UserCamelSpecificationReview>
    {
        public UserCamelSpecificationReviewConfiguration()
        {

            this.ToTable("UserCamelSpecificationReview", "User");
            this.HasKey<int>(x => x.ID);
            this.Property(x => x.CreatedDate).IsRequired();
            this.Property(x => x.ActualPercentageValue).IsRequired();
            this.HasRequired<User>(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey<int>(x => x.UserID).WillCascadeOnDelete(false);
            this.HasRequired<CamelCompetition>(x => x.CamelCompetition)
               .WithMany(x=>x.UserReviews)
               .HasForeignKey<int>(x => x.CamelCompetitionID).WillCascadeOnDelete(false);
            this.HasRequired<CamelSpecification>(x => x.CamelSpecification)
                .WithMany(x => x.UserReviews)
                .HasForeignKey<int>(x => x.CamelSpecificationID).WillCascadeOnDelete(false);
        }
    }
}
