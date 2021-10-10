﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelsClub.Models
{
    public class CompetitionTeamRewardConfiguration : EntityTypeConfiguration<CompetitionTeamReward>
    {
        public CompetitionTeamRewardConfiguration()
        {
            this.ToTable("CompetitionTeamReward", "Competition");
            this.HasKey<int>(x => x.ID);
            this.Property(x => x.CreatedDate).IsRequired();
            this.Property(x => x.AssignedTo).IsRequired();
            this.HasRequired<Competition>(x => x.Competition)
                .WithMany(x=>x.CompetitionTeamRewards)
                .HasForeignKey<int>(x => x.CompetitionID);
           
        }
    }
}
