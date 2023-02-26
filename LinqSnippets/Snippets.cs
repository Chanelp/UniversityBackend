using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LinqSnippets
{

    public class Snippets
    {

        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            // 1. SELECT * of cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi (SELECT AUDI's
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }

        }

        // 3. Number Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each Number multiplied by 3
            // take all numbers, but 9
            // Order numbers by ascending

            var processedNumberList =
                numbers
                .Select(n => n * 3) // { 3, 6, 9, etc }
                .Where(n => n != 9) // { all but the 9 }
                .OrderBy(n => n); // { at the end, we order }


        }

        static public void SearchEmployee()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. First of all elements
            var first = textList.First();

            // 2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"
            var jtext = textList.First(text => text.Contains("j"));

            // 4. First element that contains "z" or default | "" or element that contains "z"
            var firstOrDefaulttext = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. Last element that contains "z" or default 
            var lastOrDefaulttext = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single Values
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] othersNumbers = { 0, 2, 6 };

            // Obtain { 4, 8 }
            var myEvenNumbers = evenNumbers.Except(othersNumbers); // {4, 8}

        }

        static public void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinión 1, text 1",
                "Opinión 2, text 2",
                "Opinión 3, text 3",
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "martin@imaginagroup.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Ana",
                            Email = "ana@imaginagroup.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Lucas",
                            Email = "lucas@imaginagroup.com",
                            Salary = 2000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Jessica",
                            Email = "jessi@imaginagroup.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "maria@imaginagroup.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Luis",
                            Email = "luis@imaginagroup.com",
                            Salary = 2000
                        }
                    }
                }
            };

            // Obtain all Employees of all Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if any list is empty
            bool hasEnterprise = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise=> enterprise.Employees.Any());

            // All enterprises al least has an employee with more than 1000EU of salary
            bool hasEmployeeSalaryMoreThanOrEqual1000 = 
                enterprises.Any(enterprise => 
                    enterprise.Employees.Any(employee => employee.Salary > 1000));
        }

        static public void linqCollection()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN - elementos compartidos entre las listas
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            // OUTER JOIN - LEFT | ELEMENTOS FUERA/quedan/diferentes DE LA PRIMERA LISTA
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondEle in secondList.Where(el => el == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondEle };


            // OUTER JOIN - RIGHT | ELEMENTOS FUERA/quedan/diferentes DE LA SEGUNDA LISTA
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            // UNIÓN - lo que no está repetido
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            // SKIP

            var skipTwoFirstvalues = myList.Skip(2);

            var skipLastTwovalues = myList.SkipLast(2);

            var skipWhile = myList.SkipWhile(num => num < 4);

            // TAKE

            var takeFirstTwoValues = myList.Take(2);

            var takeLastTwoValues = myList.TakeLast(2);

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);
        }

        // Paging with Skip & Take
        static public IEnumerable<T> GetPage<T> (IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // Variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 8, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Average: {0}", numbers.Average());

            foreach(int number in aboveAverage)
            {
                Console.WriteLine("Query: Number {0} Square {1} ", number, Math.Pow(number, 2));
            }

        }

        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);

            // { "1 = one", "2 = two", ... }
        }

    }
}