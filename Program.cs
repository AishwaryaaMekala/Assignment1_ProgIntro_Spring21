//AishwaryaaMekala
//U90883364

using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_ProgIntro_Spring21
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the number of rows for the triangle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3: Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check:");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                                    { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);
        }


        private static void printTriangle(int n)
        {
            try
            {
                //looping for rows until nth row
                for (int i = 1; i <= n; i++)
                {
                    //holds result of following loops in string data type
                    String res = "";
                    //looping for spaces before *per row(n - row number)
                    for (int j = 1; j <= n - i; j++)
                    {
                        //print spaces before * in every row
                        res = res + " ";
                    }
                    //looping for stars per row(2 * row number - 1)
                    for (int j = 1; j <= 2 * i - 1; j++)
                    {
                        //print the no.of stars equal to the ith odd integer
                        res = res + "*";
                    }
                    //print one row per line / each row in new line
                    Console.WriteLine(res);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        private static void printPellSeries(int n2)
        {
            try
            {
                //Holds first(n-1 position from current pell number),second(n - 2 position from current pell number) and most recent pell numbers in the series
                int PellMinusOne = 1;
                int PellMinusTwo = 0;
                int PellNumber = 0;
                //Prints first and second pell numbers
                Console.Write(PellMinusTwo + " ");
                Console.Write(PellMinusOne + " ");
                //Starting from third number and looping until remaining(n2-3) numbers are found
                for (int i = 3; i < n2; i++)
                {
                    //Calculating the nth number of the series
                    PellNumber = (2 * PellMinusOne) + PellMinusTwo;

                    //Prints pell number
                    Console.Write(PellNumber + " ");

                    //Assigns(n - 1)th number as (n- 2)th number for next loop
                    PellMinusTwo = PellMinusOne;

                    //Assigns nth number as (n- 1) th number for next loop
                    PellMinusOne = PellNumber;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private static bool squareSums(int n3)
        {
            try
            {
                //looping for 2 integers whose sqaure is less than n3
                for (int a = 0; a * a <= n3; a++)
                    for (int b = 0; b * b <= n3; b++)
                        //check if our number n3 equals sum of squares of the 2 numbers of the loop
                        if (n3 == a * a + b * b)
                        {
                            //prints boolean value true if condition is satisfied
                            return true;
                        }
                //prints boolean value false if condition is not satisfied
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private static int diffPairs(int[] arr, int k)
        {
            try
            {
                //Sorting the array first for ease
                Array.Sort(arr);

                //Creating a dictionary

                Dictionary<int, int> added = new Dictionary<int, int>();
                //looping for i starting from 0th element and increment iterations as long as it is less than length of our array
                for (int i = 0; i < arr.Length; i++)
                {
                    //looping for j starting from i+1th element and increment iterations as long as it is less than length of our array
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        //Check if difference between ith and jth element, if equals k
                        //Add such element pairs to the dictionary created
                        if (arr[j] - arr[i] == k)
                        {
                            //Adding key in case it doesn't exist already
                            if (!(added.Keys.ToList().Contains(arr[i])))
                            {
                                added.Add(arr[i], arr[j]);
                            }
                            break;
                        }
                    }
                }
                //Returning count(size) of map keys
                return added.Keys.ToList().Count();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }


        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                int count = 0;
                int len = emails.Count; //declaring length of List emails
                                        //create new list of string datatype to store finalized email IDs
                List<string> emailsFinal = new List<string>();
                //looping for all emails in the list starting from 0th element
                for (int i = 0; i < len; i++)
                {
                    string fulladdress = emails[i];
                    string local = fulladdress.Split('@')[0]; //split input address to obtain local name part before @
                    string local2 = local.Split('+')[0]; // take local name part before '+' i.e., ignore string part after +

                    string domain = fulladdress.Split('@')[1]; // split input address to obtain domain name after @
                    string[] string_array = local2.Split(" ");
                    local2 = local2.Replace(".", ""); //remove all '.' s
                    local2 = local2.Replace(" ", ""); //remove all spaces
                    fulladdress = local2 + "@" + domain; //Merging the local2 and domain parts computed from fulladdress
                    emailsFinal.Add(fulladdress); // Adding elements to the list emailsFinal that we created
                }
                List<string> uniqueList = emailsFinal.Distinct().ToList(); //creating new list out of emailsFinal list which holds only distinct email IDs
                count = uniqueList.Count;
                return count; //returns count of email IDs in uniqueList that actually receive the emails
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        private static string DestCity(string[,] paths)
        {
            try
            {
                //create two new lists of string datatype to store source cities and destination cities
                List<string> scity = new List<string>();
                List<string> dcity = new List<string>();

                //declaring variable len which equals paths array length divided by 2 (6/2 = 3)
                int len = (paths.Length) / 2;

                //looping for ath element starting from 0th one incrementing each time
                for (int a = 0; a < len; a++)
                {
                    scity.Add(paths[a, 0]); //appends new elements[ath element, 0th item] from paths to scity array
                    dcity.Add(paths[a, 1]); //appends new elements[ath element, 1th item] from paths to dcity array
                }
                //check for each element in dcity to see if it exits in scity. If it does not, return that element
                foreach (var x in dcity)
                {
                    if (!scity.Contains(x))
                        return x;
                }
                return ""; //returns the string result
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}














