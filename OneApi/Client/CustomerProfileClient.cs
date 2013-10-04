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
		/// User Login </summary>
		/// <returns> LoginResponse </returns>
		LoginResponse Login();

		/// <summary>
		/// User Logout </summary>
		void Logout();

		/// <summary>
		/// Get logged user customer profile </summary>
		/// <returns> CustomerProfile </returns>
		CustomerProfile GetCustomerProfile();

		/// <summary>
		/// Get logged user customer profiles list </summary>
		/// </summary>
		/// <returns>CustomerProfile[]</returns>
		CustomerProfile[] GetCustomerProfiles();

		/// <summary>
		/// Retrieve specific user customer profile by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns> CustomerProfile </returns>
		CustomerProfile GetCustomerProfileByUserId(int id);

		/// <summary>
		/// Get logged user account balance </summary>
		/// </summary>
		/// <returns> AccountBalance </returns>
		AccountBalance GetAccountBalance();

		/// <summary>
		/// Get all reseller clients/subaccounts </summary>
		/// </summary>
		/// <returns> CustomerProfileList </returns>
		CustomerProfile[] GetClients();

		/// <summary>
		/// Add funds to (top-up) reseller client/subaccount </summary>
		/// </summary>
		/// <returns> int </returns>
		AddClientFundsResponse AddClientFunds(string currencyCode, string accountKey, string description, decimal ammount);
	}
}
