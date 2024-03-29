﻿using CamelsClub.Data.UnitOfWork;
using CamelsClub.Models;
using CamelsClub.Repositories;
using CamelsClub.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelsClub.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserRoleRepository _repo;
        public UserRoleService(IUnitOfWork unit, IUserRoleRepository repo)
        {
            _unit = unit;
            _repo = repo;
        }
      

        public void InsertUserRole(int userID, Roles roleID)
        {
            _repo.Add(new UserRole { UserID = userID, RoleID = (int)roleID, IsDeleted = false, CreatedBy = userID.ToString(), CreatedDate = DateTime.UtcNow });
        }

        public bool HasRole(int userId, string role)
        {
            bool hasRole = false;
            var connection = "Data Source=camels-club-v2.pivotrs.com;Initial Catalog=camels-club-v2;MultipleActiveResultSets=true;Integrated Security=false; User ID=camels-club-v2;Password=F#1#top@@";
            string sql = "HasRole";
            using (var cnn = new SqlConnection(connection))
            {
                using (var cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@role", role));
                    cmd.Parameters.Add(new SqlParameter("@userID", userId));
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@hasRole",
                        IsNullable = false,
                        DbType = System.Data.DbType.Boolean,
                        Direction = System.Data.ParameterDirection.Output
                    });
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cnn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    hasRole =  (bool)cmd.Parameters["@hasRole"].Value;
                    cnn.Close();
                }
            }

            return hasRole;
            //if (string.IsNullOrEmpty(role))
            //    return false;
            //var User = _repo.GetAll().Where(u => u.UserID == userId).FirstOrDefault();
            //if (User == null)
            //    return false;
            //if (role == "*")
            //    return _repo.GetAll().Where(user => !user.IsDeleted && user.ID == userId).Any();

            //if (role == "User")
            //{
            //    var user = _repo.GetAll().Where(us => us.UserID == userId && us.RoleID == 1).FirstOrDefault();
            //    // var usr = _userRoleModuleRepository.GetAll().Where(ur => ur.UserRole.UserID == userId && ur.UserRole.RoleID==1).FirstOrDefault();
            //    if (user != null)
            //        return true;

            //    return false;
            //}
      
            //List<string> roles = role.ToUpper().Split(',').ToList();

            //if (roles.Count > 0)
            //{
            //    // ReSharper disable once PossibleNullReferenceException
            //    bool hasRole = _repo.GetAll().Where(user => !user.IsDeleted && user.UserID == userId).Where(r => roles.Contains(r.Role.NameEnglish.ToUpper())).Any();

            //    return hasRole;
            //}
            //return false;
        }
    }
}

