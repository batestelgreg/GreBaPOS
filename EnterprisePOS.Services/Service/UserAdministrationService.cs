using EnterprisePOS.Data;
using EnterprisePOS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprisePOS.Services.Service
{
    public class UserAdministrationService
    {
        private readonly UserAdministrationRepository _repository;

        public UserAdministrationService()
        {
            _repository = new UserAdministrationRepository();
        }

        public bool HasPermission(int userId, string permissionCode)
        {
            return _repository.HasPermission(userId, permissionCode);
        }

        private void EnsurePermission(int actorUserId)
        {
            if (!_repository.HasPermission(actorUserId, "Users.Manage"))
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to manage users.");
            }
        }

        public List<usp_User_ListResult> GetUsers(
            int actorUserId,
            string search = null,
            int? roleId = null,
            bool? isActive = null)
        {
            EnsurePermission(actorUserId);
            return _repository.GetUsers(
    actorUserId, search, roleId, isActive);
        }

        public List<usp_Role_ListResult> GetRoles(int actorUserId)
        {
            EnsurePermission(actorUserId);
            return _repository.GetRoles(actorUserId);
        }

        public List<usp_RolePermission_ListResult> GetRolePermissions(
            int actorUserId,
            int roleId)
        {
            EnsurePermission(actorUserId);
            return _repository.GetRolePermissions(actorUserId, roleId);
        }

        public List<usp_AuditLog_ListResult> GetAuditHistory(
            int actorUserId,
            string search = null)
        {
            EnsurePermission(actorUserId);
            return _repository.GetAuditHistory(actorUserId, search);
        }

        public void SetUserStatus(
            int actorUserId,
            int targetUserId,
            bool isActive)
        {
            EnsurePermission(actorUserId);

            _repository.SetUserStatus(
                actorUserId, targetUserId, isActive);
        }


        public int CreateUser(
            int actorUserId,
            string username,
            string password,
            string firstName,
            string middleName,
            string lastName,
            int roleId)
        {
            EnsurePermission(actorUserId);

            username = username?.Trim();
            firstName = firstName?.Trim();
            lastName = lastName?.Trim();
            middleName = string.IsNullOrWhiteSpace(middleName)
                ? null
                : middleName.Trim();

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.");

            if (username.Length > 50)
                throw new ArgumentException(
                    "Username cannot exceed 50 characters.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.");

            if (password.Length < 8)
                throw new ArgumentException(
                    "Password must contain at least 8 characters.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");

            if (roleId <= 0)
                throw new ArgumentException("Select a valid role.");

            string salt = PasswordHasher.GenerateSalt();
            string hash = PasswordHasher.ComputeHash(salt, password);

            return _repository.CreateUser(
                actorUserId,
                username,
                hash,
                salt,
                firstName,
                middleName,
                lastName,
                roleId);
        }

        public void ResetPassword(
            int actorUserId,
            int targetUserId,
            string newPassword)
        {
            EnsurePermission(actorUserId);

            if (targetUserId <= 0)
                throw new ArgumentException("Select a valid user.");

            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("New password is required.");

            string salt = PasswordHasher.GenerateSalt();
            string hash = PasswordHasher.ComputeHash(salt, newPassword);

            _repository.ResetPassword(
                actorUserId, targetUserId, hash, salt);
        }

        public void InsertAuditLog(
            int actorUserId,
            string action,
            int? targetUserId = null,
            string details = null)
        {
            EnsurePermission(actorUserId);

            _repository.InsertAuditLog(
                actorUserId, action, targetUserId, details);
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
            EnsurePermission(actorUserId);

            username = username?.Trim();
            firstName = firstName?.Trim();
            lastName = lastName?.Trim();
            middleName = string.IsNullOrWhiteSpace(middleName)
                ? null
                : middleName.Trim();

            if (targetUserId <= 0)
                throw new ArgumentException("Select a valid user.");

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.");

            if (username.Length > 50)
                throw new ArgumentException(
                    "Username cannot exceed 50 characters.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");

            if (roleId <= 0)
                throw new ArgumentException("Select a valid role.");

            _repository.UpdateUser(
                actorUserId,
                targetUserId,
                username,
                firstName,
                middleName,
                lastName,
                roleId);
        }
    }
}