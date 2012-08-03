using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneApi.Model;

namespace OneApi.Client.Impl
{
    public interface CustomerProfileClient
    {
        /// <summary>
        /// Get configured user customer profile </summary>
        /// <returns> CustomerProfile </returns>
        CustomerProfile GetCustomerProfile();

        /// <summary>
        /// User Login </summary>
        /// <returns> LoginResponse </returns>
        LoginResponse Login();

        /// <summary>
        /// User Logout </summary>
        void Logout();
    }
}
