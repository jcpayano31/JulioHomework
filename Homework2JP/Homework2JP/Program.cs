using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;




namespace Homework2JP
{
   
        
    class Program
        
    {
        static void Main(string[] args)
        {

            var users = new UserRepository().GetUsers();

            Console.WriteLine("Display all passwords that are 'hello'");
            var filteredList = users.Where(b =>b.Password == "hello" );
               
            foreach (var user in filteredList)
                 Console.WriteLine(user.Name+ "  " + user.Password);

            Console.ReadLine();




            Console.WriteLine("Delete any password lower-case");
            var filteredList1 = users.Where(b => b.Password.ToLower() != b.Name.ToLower());

            foreach (var user in filteredList1)
                Console.WriteLine(user.Name + "  " + user.Password);

            Console.ReadLine();


            //var filteredList3 = users.Where(b => b.Password == "hello").Select(b => b.Password != "hello").First();
            //foreach (var user in filteredList3)
            //    Console.WriteLine(filteredList3.Name + "  " + filteredList3.Password);
            Console.WriteLine("Delete first user that he passwor 'hello'  and Print the remaining user");
            var fielted = from element in users
                          group element by element.Password
                          into groups
                          select groups.OrderBy(p => p.Password == "hello").First(); //.First();
            foreach (var user in fielted)

            Console.WriteLine(user.Name + " " + user.Password);                     
               

            Console.ReadLine();

        }

    }
}
