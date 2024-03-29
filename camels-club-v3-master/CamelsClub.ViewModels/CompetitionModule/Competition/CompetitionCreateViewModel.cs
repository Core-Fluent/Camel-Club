﻿using CamelsClub.Models;
using CamelsClub.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CamelsClub.ViewModels
{
    public class CompetitionCreateViewModel
    {

        [Required(ErrorMessageResourceType = typeof(Localization.Shared.Resource), ErrorMessageResourceName = "RequiredFieldValidation")]
        public string NameArabic { get; set; }
        public CompetitionType CompetitionType { get; set; }
        public string NameEnglish { get; set; }
        [Required(ErrorMessageResourceType = typeof(Localization.Shared.Resource), ErrorMessageResourceName = "RequiredFieldValidation")]
        public string Address { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Localization.Shared.Resource), ErrorMessageResourceName = "RequiredFieldValidation")]
        public int CamelsCount { get; set; }
        [Required(ErrorMessageResourceType = typeof(Localization.Shared.Resource), ErrorMessageResourceName = "RequiredFieldValidation")]
        public DateTime From { get; set; }
        [Required(ErrorMessageResourceType = typeof(Localization.Shared.Resource), ErrorMessageResourceName = "RequiredFieldValidation")]
        public DateTime To { get; set; }
        [Required(ErrorMessageResourceType = typeof(Localization.Shared.Resource), ErrorMessageResourceName = "RequiredFieldValidation")]
        public DateTime CompetitorsEndJoinDate { get; set; }
        public string Image { get; set; }
        [IgnoreDataMember]
        public int UserID { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Localization.Shared.Resource), ErrorMessageResourceName = "RequiredFieldValidation")]
        public int CategoryID { get; set; }
        public string ConditionText { get; set; }

        public decimal RefereesVotePercentage { get; set; }
        public decimal PeopleVotePercentage { get; set; }
        public int MinimumCompetitorsCount { get; set; }
        public int MaximumCompetitorsCount { get; set; }
        public int MinimumRefereesCount { get; set; }
        public int MaximumRefereesCount { get; set; }
        public int MinimumCheckersCount { get; set; }
        public int MaximumCheckersCount { get; set; }
        public bool ShowReferees { get; set; }
        public bool ShowCheckers { get; set; }
        public bool ShowCompetitors { get; set; }
        public VoteType VoteType { get; set; }
        public List<CompetitionInviteCreateViewModel> Invites { get; set; }
        public List<CompetitionRewardCreateViewModel> Rewards { get; set; }
        public List<CompetitionTeamRewardCreateViewModel> TeamRewards { get; set; }
        public List<CompetitionRefereeCreateViewModel> Referees { get; set; }
        public List<CompetitionConditionCreateViewModel> Conditions { get; set; }
        public List<CompetitionCheckerCreateViewModel> Checkers { get; set; }
        public List<CompetitionSpecificationCreateViewModel> Specifications { get; set; }
    }

    public static partial class CamelExtensions
    {
        public static Competition ToModel(this CompetitionCreateViewModel viewModel)
        {
            return new Competition
            {
                NameArabic = viewModel.NameArabic,
                NamEnglish = viewModel.NameEnglish,
                Address = viewModel.Address,
                CamelsCount = viewModel.CamelsCount,
                ConditionText = viewModel.ConditionText,
                From = viewModel.From,
                To = viewModel.To,
                CompetitorsEndJoinDate = viewModel.CompetitorsEndJoinDate,
                CategoryID = viewModel.CategoryID,
                UserID = viewModel.UserID,
                CompetitionType = (int)viewModel.CompetitionType,
                Image = viewModel.Image,
                MaximumCompetitorsCount = viewModel.MaximumCompetitorsCount,
                MinimumCompetitorsCount = viewModel.MinimumCompetitorsCount,
                MaximumCheckersCount = viewModel.MaximumCheckersCount,
                MinimumCheckersCount = viewModel.MinimumCheckersCount,
                MaximumRefereesCount = viewModel.MaximumRefereesCount,
                MinimumRefereesCount = viewModel.MinimumRefereesCount,
                ShowCheckers = viewModel.ShowCheckers,
                ShowCompetitors = viewModel.ShowCompetitors,
                ShowReferees = viewModel.ShowReferees,
                PeopleVotePercentage = viewModel.PeopleVotePercentage,
                RefereesVotePercentage = viewModel.RefereesVotePercentage,
                VoteType = (int)viewModel.VoteType
                
            };
        }
    }
}
