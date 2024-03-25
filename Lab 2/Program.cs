//Team Member: Michael Katsaros, Karla Chuprinski, Taiki Tsukahara

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BooksEntities1 dbcontext =
             new BooksEntities1();

            //a. Get a list of all the titles and the authors who wrote them. Sort the result by title.
            var titlesAndAuthors =
                from title in dbcontext.Titles
                from author in title.Authors
                orderby title.Title1//, author.FirstName, author.LastName
                select new { title.Title1, author.FirstName, author.LastName };
            Console.WriteLine("a)");

            foreach (var element in titlesAndAuthors)
            {
                Console.Write(
                   String.Format("\r\n\t" + element.Title1 + " " + element.FirstName + " " + element.LastName));
            } // end foreach
            Console.WriteLine();
            //end of part a

            //b. Get a list of all the titles and the authors who wrote them. Sort the result by title. For each
            //title sort the authors alphabetically by last name, then first name.
            var titlesAndAuthors2 =
                from title in dbcontext.Titles
                from author in title.Authors
                orderby title.Title1, author.LastName, author.FirstName
                select new { title.Title1, author.LastName, author.FirstName };

            Console.WriteLine();
            Console.WriteLine("b)");

            foreach (var element in titlesAndAuthors2)
            {
                Console.Write(
                   String.Format("\r\n\t" + element.Title1 + " " + element.LastName + " " + element.FirstName));
            } // end foreach
            Console.WriteLine();
            //end of part b
             

            var titlesAndAuthors3 =
                from title in dbcontext.Titles
                orderby title.Title1
                select new
                {
                    Title = title.Title1,
                    Authors = from author in title.Authors
                              orderby author.FirstName, author.LastName
                              select author.LastName + " " + author.FirstName
                };

            Console.WriteLine();
            Console.WriteLine("c)");

            foreach (var title in titlesAndAuthors3)
            {
                Console.Write("\r\n\t" + title.Title + ": ");

                foreach (var name in title.Authors)
                {
                    Console.Write("\r\n\t\t" + name);
                } // end inner foreach
            } // end foreach
            // End of part c


        }
    }
}