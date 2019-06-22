using Kingsland.MofParser;
using System;

namespace Kingsland.FileFormat.Mof.Tests
{

    class Program
    {

        static void Main(string[] args)
        {

            const string filename = @"C:\Users\t-jospic\source\repos\schema-to-swagger\schema-to-swagger\input\schema.mof";
            Console.WriteLine("loading: "+filename);

            // parse the mof file
            /*var instances = PowerShellDscHelper.ParseMofFileInstances(filename); */

            PowerShellDscHelper.ParseMofFileInstances(filename);

       /*     // display the instances
            foreach (var instance in instances)
            {
                Console.WriteLine("--------------------------");
                if (string.IsNullOrEmpty(instance.Alias))
                {
                    Console.WriteLine(string.Format("instance of {0}", instance.ClassName));
                }
                else
                {
                    Console.WriteLine(string.Format("instance of {0} as ${1}", instance.ClassName, instance.Alias));
                }
                foreach(var property in instance.Properties)
                {
                    Console.WriteLine("    {0} = {1}", property.Key.PadRight(14), property.Value.ToString());
                }
                Console.WriteLine("--------------------------");
            }
*/
        }

    }

}