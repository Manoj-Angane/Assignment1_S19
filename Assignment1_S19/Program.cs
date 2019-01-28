/*
Developer:  Manoj Angane
Date:       January,1,2019
Course:     ISM6225    
*/
using System;

namespace Assignment1_S19
{
    class Program
    {
        static void Main(string[] args)				//Same main function except partition for each output and welcome and exit notes.
        {
            Console.WriteLine("Hello!!!!\n\n*******************Output of Prime Function********************");
            int a = 5, b = 15;
            printPrimeNumbers(a, b);

            Console.WriteLine("\n\n*******************Output of Series Function*******************");
            int n1 = 5;
            double r1 = Math.Round(getSeriesResult(n1), 3);									//used Math.Round method to returning decimal rounding off to 3 places
            Console.WriteLine("The sum of the series is:                            " + r1);

            Console.WriteLine("\n\n*******************Output of Dec2Bin Function******************");
            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is:       " + r2);

            Console.WriteLine("\n\n*******************Output of Bin2Dec Function******************");
            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is:       " + r3);

            Console.WriteLine("\n\n*******************Output of Triangle Function*****************");
            int n4 = 5;
            printTriangle(n4);

            Console.WriteLine("\n*******************Output of Frequency Function*****************");
            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            Console.WriteLine("\n\nThank you!, Press any key to continue");
            Console.ReadKey(true);
        }//end of main
        public static long decimalToBinary(long n)
        {
            try
            {

                long bin = 0;	//output variable
                int i = 1;      //Decimal Place Variable

                while (n != 0)
                {
                    long reminder = n % 2;
                    bin += reminder * i;	//save reminder with adjust position
                    n = n / 2;				//right shift number origional number
                    i = i * 10;				//left shift decimal place
                }
                return bin;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()  :" + e.Message);
                return 0;
            }
        }//end of decimal to  binary
        public static long binaryToDecimal(long n)
        {
            try
            {
                int i = 0;			//Decimal Place Variable
                long dec = 0;		//output variable
                while (n != 0)
                {
                    long reminder = n % 10;		//fetch decimal place value
                    int x = 2;					//variable for binary
                    dec += reminder * power(x, i);	//use of power method with reminder
                    i += 1;							//left shift position variable
                    n = n / 10;						//right shift original varaiable
                }
                return dec;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal() :" + e.Message);
                return 0;
            }

        }//end of decimal to  binary
        public static int isPrime(int n)		//Prime function to return 1 if Prime else 0
        {
            try
            {
                int Prime = 1;
                //Any number is prime only if it is not divisible by any number less than or half of that number(except 1).
                for (int i = 2; i <= n / 2; i++)
                {
                    if (n % i == 0)
                    {
                        Prime = 0;
                    }
                }
                if (n == 1)//handling spl case when n=1 as it not Prime.
                {
                    Prime = 0;
                }
                return Prime;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing isPrime() :" + e.Message);
                return 0;
            }
        }//end of isPrime
        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                int Prime;
                int first_line = 1;
                Console.Write("Prime Number Between " + x + " and " + y + " :                     ");
                for (int i = x; i <= y; i++)		//simple to run from x to y
                {
                    Prime = isPrime(i);				//call of isPrime function
                    if (Prime == 1)
                    {
                        if (first_line == 0)
                        {
                            Console.Write(",");
                        }
                        Console.Write(i);       //print output on sameline
                        first_line = 0;
                    }
                }
                Console.WriteLine("");				//Print to move nextline
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers() :" + e.Message);
            }
        }// end of Print Prime
        public static void computeFrequency(int[] a)
        {
            try
            {
                Array.Sort(a);					//sort array in ascending
                int num = 0;					//number of hold index
                int count = 0;					//number to hold count
                for (int i = 0; i < a.Length; i++) //long to run length of array times
                {
                    if (i == 0)						//when its 1st run
                    {
                        Console.WriteLine("Number   Frequency");
                        num = a[i];					//saving 1st value from array
                        count = 1;
                    }
                    else if (a[i] == num)			//if match increase count
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine(num + "    " + count);	//whenever number doesn't match print
                        num = a[i];
                        count = 1;
                    }

                }
                Console.WriteLine(num + "    " + count);			//print last saved index and count
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing computeFrequency() :" + e.Message);
            }
        }//end of frequency
        public static void printTriangle(int n)
        {
            try
            {
                Console.WriteLine("Print Triangle with index :                          " + n);
                for (int i = 1; i <= n; i++)						//outer loop for moving vertically
                {
                    for (int j = n - i; j > 0; j--)						//loop for printing space for moving horizontally
                    {
                        Console.Write(" ");
                    }
                    for (int k = (2 * i - 1); k > 0; k--)				//loop for print "*"
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine("");
                }//end of outer loop
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing printTriangle() :" + e.Message);
            }
        }//end of print triangle
        public static double getSeriesResult(int n)		//Tried Recursive program for making series from n to 1
        {
            try
            {
                int mult_fact = 1;
                double fact_ = 0;
                if (n % 2 == 1)								//if clause from sign
                {
                    mult_fact = 1;
                }
                else
                {
                    mult_fact = -1;
                }
                fact_ = fact(n);
                if (n != 1)								//if clause for recursive call
                {
                    return ((fact_ * mult_fact) / (n + 1)) + getSeriesResult(n - 1);
                }
                else									//clause for stoping recursive when n=1
                {
                    return 1.00 / 2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing getSeriesResult() :" + e.Message);
                return 0;
            }
        }//end of get series
        public static int fact(int n)					//Tried Recursive program for factorial
        {
            try
            {
                if (n == 1)
                {
                    return 1;							//return 1 when n=1
                }
                else
                {
                    return n * fact(n - 1);				//recursive calls
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing fact() :" + e.Message);
                return 0;
            }
        }//end of fact
        public static long power(int n, int p)			//method to return n raise p power
        {
            try
            {
                long mult_ = 1;
                for (int i = 1; i <= p; i++) 			//multipling n with n for p times
                {
                    mult_ *= n;
                }
                return mult_;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing Power() :" + e.Message);
                return 0;
            }
        }//end of Power
    }
}
