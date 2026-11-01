using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterprisePOS.Data.Repositories;
using EnterprisePOS.Domain.Class;

namespace EnterprisePOS.Services.Service
{
    public class SalesService
    {
        private readonly SalesRepository _salesRepository;
        private readonly UserAdministrationRepository _userRepository;

        public SalesService()
        {
            _salesRepository = new SalesRepository();
            _userRepository = new UserAdministrationRepository();
        }

        public int SaveSale(OrderRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.UserId <= 0)
            {
                throw new UnauthorizedAccessException(
                    "Invalid user session.");
            }

            bool hasPermission = _userRepository.HasPermission(
                request.UserId,
                "Orders.Create");

            if (!hasPermission)
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to create orders.");
            }

            return _salesRepository.SaveSale(request);
        }

        public bool HasPermission(int userId, string permissionCode)
        {
            return _userRepository.HasPermission(userId, permissionCode);
        }

        public string VoidSale(int orderId, int userId)
        {
            if (orderId <= 0)
            {
                throw new ArgumentException("Invalid order ID.");
            }

            if (userId <= 0)
            {
                throw new UnauthorizedAccessException(
                    "Invalid user session.");
            }

            bool hasPermission = _userRepository.HasPermission(
                userId,
                "Orders.Void");

            if (!hasPermission)
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to void orders.");
            }

            return _salesRepository.VoidSale(orderId, userId);
        }
    }

}