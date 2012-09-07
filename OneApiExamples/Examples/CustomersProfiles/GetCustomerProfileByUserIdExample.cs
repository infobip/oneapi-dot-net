using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneApi.Config;
using OneApi.Client.Impl;
using OneApi.Model;

namespace OneApi.Examples.CustomerProfiles
{
    class GetCustomerProfileByUserIdExample : ExampleBase
    {
        public static void Execute()
        {
            Configuration configuration = new Configuration(username, password);    
            SMSClient smsClient = new SMSClient(configuration);

            LoginResponse loginResponse = smsClient.CustomerProfileClient.Login();
            if (loginResponse.Verified == false)
            {
                Console.WriteLine("User is not verified!");
                return;
            }

            CustomerProfile customerProfile = smsClient.CustomerProfileClient.GetCustomerProfileByUserId(1);
            Console.WriteLine("Customer Profile: " + customerProfile);
        }
    }
}
