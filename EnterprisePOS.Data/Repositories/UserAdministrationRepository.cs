using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnterprisePOS.Data.Repositories
{
    public class UserAdministrationRepository : DatabaseRepository
    {
        // Get users with optional search, role, and status filters
        public List<usp_User_ListResult> GetUsers(
            int actorUserId,
            string search = null,
            int? roleId = null,
            bool? isActive = null)
        {
            using (var db = CreateContext())
            {
                return db.usp_User_List(
                    actorUserId,
                    search,
                    roleId,
                    isActive
                ).ToList();
            }
        }

        public List<usp_Role_ListResult> GetRoles(int actorUserId)
        {
            using (var db = CreateContext())
            {
                return db.usp_Role_List(actorUserId).ToList();
            }
        }

        public List<usp_RolePermission_ListResult> GetRolePermissions(
            int actorUserId,
            int roleId)
        {
            using (var db = CreateContext())
            {
                return db.usp_RolePermission_List(
                    actorUserId,
                    roleId
                ).ToList();
            }
        }

        public bool HasPermission(int userId, string permissionCode)
        {
            using (var db = CreateContext())
            {
                var result = db.usp_User_HasPermission(
                    userId,
                    permissionCode
                ).FirstOrDefault();

                return result != null && result.HasPermission == true;
            }
        }

        public List<usp_AuditLog_ListResult> GetAuditHistory(
            int actorUserId,
            string search = null)
        {
            using (var db = CreateContext())
            {
                return db.usp_AuditLog_List(
                    actorUserId,
                    search
                ).ToList();
            }
        }

        public void InsertAuditLog(
            int actorUserId,
            string action,
            int? targetUserId = null,
            string details = null)
        {
            using (var db = CreateContext())
            {
                db.usp_AuditLog_Insert(
                    actorUserId,
                    action,
                    targetUserId,
                    details
                );
            }
        }

        public void SetUserStatus(
            int actorUserId,
            int targetUserId,
            bool isActive)
        {
            using (var db = CreateContext())
            {
                db.usp_User_SetStatus(
                    actorUserId,
                    targetUserId,
                    isActive
                );
            }
        }

        // Create a new user and return the generated UserId
        public int CreateUser(
            int actorUserId,
            string username,
            string passwordHash,
            string salt,
            string firstName,
            string middleName,
            string lastName,
            int roleId)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException(
                    "Username is required.",
                    nameof(username)
                );

            username = username.Trim();

            try
            {
                using (var db = CreateContext())
                {
                    var result = db.usp_User_Create(
                        actorUserId,
                        username,
                        passwordHash,
                        salt,
                        firstName,
                        middleName,
                        lastName,
                        roleId
                    );

                    var userIdResult = result.FirstOrDefault();

                    if (userIdResult == null)
                    {
                        throw new InvalidOperationException(
                            "The database did not return the new UserId."
                        );
                    }

                    return Convert.ToInt32(userIdResult.UserId);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.IndexOf(
                    "Username already exists",
                    StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new InvalidOperationException(
                        "Username already exists. Please choose another username.",
                        ex
                    );
                }

                throw;
            }
        }

        // Reset a user's password
        public void ResetPassword(
            int actorUserId,
            int targetUserId,
            string passwordHash,
            string salt)
        {
            using (var db = CreateContext())
            {
                db.usp_User_ResetPassword(
                    actorUserId,
                    targetUserId,
                    passwordHash,
                    salt
                );
            }
        }

        public void UpdateUser(
            int actorUserId,
            int targetUserId,
            string username,
            string firstName,
            string middleName,
            string lastName,
            int roleId)
        {
            using (var db = CreateContext())
            {
                db.usp_User_Update(
                    actorUserId,
                    targetUserId,
                    username,
                    firstName,
                    middleName,
                    lastName,
                    roleId
                );
            }
        }
    }
}