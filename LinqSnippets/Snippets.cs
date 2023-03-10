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

        // ZIP
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);

            // { "1 = one", "2 = two", ... }
        }

        // REPEAT & RANGE
        static public void repeatRangeLinq()
        {
            // Generate collection from 1 - 1000
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            // Repeat a value
            IEnumerable<string> fiveXs = Enumerable.Repeat("F", 5);
        }

        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Name = "Chanel",
                    Id = 1,
                    Grade = 100,
                    Certified = true
                },
                new Student
                {
                    Name = "Juan",
                    Id = 2,
                    Grade = 98,
                    Certified = false
                },
                new Student
                {
                    Name = "Ana",
                    Id = 3,
                    Grade = 97,
                    Certified = true
                },
                new Student
                {
                    Name = "Alvaro",
                    Id = 4,
                    Grade = 89,
                    Certified = false
                },
                new Student
                {
                    Name = "Miguel",
                    Id = 5,
                    Grade = 90,
                    Certified = true
                }
            };

            var certifiedStudents = from student in classRoom
                                    where student.Certified == true
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var approvedStudentsName = from student in classRoom
                                       where student.Grade >= 50 && student.Certified == true
                                       select student.Name;
        }

        // ALL
        static public void AllLinq()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(n => n < 10); // True
            bool allAreBiggerOrEqualThan2 = numbers.All(n => n >= 2); // False

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true
        }

        // Aggregate
        static public void aggregateQueries()
        {
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // Sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            string[] words = { "hello,", "my", "name", "is", "Chanel" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);
        }

        // Distinct
        static public void distinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            IEnumerable<int> distinctValues = numbers.Distinct();
        }

        // GroupBy
        static public void groupByExamples()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // We will have two groups:
            // 1. The group that doesn't fit the condition (odd numbers)
            // 2. The group that fits the condition (even numbers)

            foreach(var group in grouped)
            {
                Console.WriteLine("-----------");
                foreach(var value in group)
                {
                    Console.WriteLine(value); // odd 1, 3, 5, 7, 9 ... even 2, 4, 6, 8 (first the odds and then the even)
                }
            }

            // Another Example
            var classRoom = new[]
            {
                new Student
                {
                    Name = "Chanel",
                    Id = 1,
                    Grade = 100,
                    Certified = true
                },
                new Student
                {
                    Name = "Juan",
                    Id = 2,
                    Grade = 98,
                    Certified = false
                },
                new Student
                {
                    Name = "Ana",
                    Id = 3,
                    Grade = 97,
                    Certified = true
                },
                new Student
                {
                    Name = "Alvaro",
                    Id = 4,
                    Grade = 89,
                    Certified = false
                },
                new Student
                {
                    Name = "Miguel",
                    Id = 5,
                    Grade = 90,
                    Certified = true
                }
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified);

            // We obtain two groups
            // 1- Not certified students
            // 2-Certified students

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("----------- {0} -----------", group.Key); // -- Certified -- true or false
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }

        }

        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "Flowers",
                    Content = "Tulipanes",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Title = "My first comment",
                            Content = "Wow, beauty",
                            Created = DateTime.Now,
                        },
                        new Comment()
                        {
                            Id = 2,
                            Title = "My first comment",
                            Content = "Wow, beauty",
                            Created = DateTime.Now,
                        }
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "Flowers",
                    Content = "Tulipanes",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Title = "My first comment",
                            Content = "Wow, beauty",
                            Created = DateTime.Now,
                        },
                        new Comment()
                        {
                            Id = 4,
                            Title = "My first comment",
                            Content = "Wow, beauty",
                            Created = DateTime.Now,
                        }
                    }
                },
                new Post()
                {
                    Id = 3,
                    Title = "Flowers",
                    Content = "Tulipanes",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 5,
                            Title = "My first comment",
                            Content = "Wow, beauty",
                            Created = DateTime.Now,
                        },
                        new Comment()
                        {
                            Id = 6,
                            Title = "My first comment",
                            Content = "Wow, cuties",
                            Created = DateTime.Now,
                        }
                    }
                }
            };

            // Ejemplo con clases-Valores que están relacionados

            var commentsContent = posts.SelectMany(
                post => post.Comments, 
                (post, comment) => new { postId = post.Id, CommentContent = comment.Content });
        }


    }
}