using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace OneApi.Examples
{
    public class OneApiExamples
	{

        private static Dictionary<string, string> projectClasses = new Dictionary<string, string>();

        static void Main(string[] args)
		{        
            int i = 1;
            WriteNamespaceClasses("OneApi.Examples.CustomerProfiles", ref i);
            WriteNamespaceClasses("OneApi.Examples.SmsMessaging", ref i);
            WriteNamespaceClasses("OneApi.Examples.Hlr", ref i);
            WriteNamespaceClasses("OneApi.Examples.Ussd", ref i);
            WriteNamespaceClasses("OneApi.Examples.Async", ref i);
            WriteNamespaceClasses("OneApi.Examples.ConfigFile", ref i);
                
            Console.WriteLine("");
            Console.WriteLine("Enter the example number and press 'Enter' key:");
           
            string exampleNumber = Console.ReadLine();

            bool isCorrectNumberEntered = false;
            string selectedClassName = "";

            while (isCorrectNumberEntered == false) 
            {        
                if (projectClasses.TryGetValue(exampleNumber, out selectedClassName))
                {
                    isCorrectNumberEntered = true;                                   
                } else {
                    Console.WriteLine("");
                    Console.WriteLine("Please enter correct example number:");
                    exampleNumber = Console.ReadLine();
                }
            }
       
            Type t  = Type.GetType(selectedClassName);
            MethodInfo method = t.GetMethod("Execute", BindingFlags.Static | BindingFlags.Public);

            method.Invoke(null, null);

            Console.WriteLine("");
            Console.ReadKey();
		}

        private static void WriteNamespaceClasses(string @namespace, ref int i)
        {
            Console.WriteLine("");
            Console.WriteLine(@namespace + ":");
  
            var q = from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @namespace
                    select t;

            foreach (var c in q)
            {
                Console.WriteLine(i.ToString() + " - " + c.Name);
                projectClasses.Add(i.ToString(), c.FullName);
                i++;
            }
        }    
	}

}