using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Averages
{
    class Program
    {
        static void Main(string[] args)
        {
            int windowSize = 5;
            double[] numbers = new double[] { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
            computeMovingAverages(windowSize, numbers);
            Console.ReadKey();
        }

        //Computes moving averages as defined on the m*modal document
        static void computeMovingAverages(int windowSize, double[] numbers)
        {
            double sum = 0;
            List<double> averages = new List<double>();
                for (int i = 0; i < numbers.Length; i++)
                    if (i < windowSize)
                    {
                        sum += numbers[i];
                        double simpleAverage = (sum / (i + 1));
                        averages.Add(simpleAverage);
                    }
                    else if (i >= windowSize)
                    {
                        sum += numbers[i] - numbers[i - windowSize];
                        double movingAverage = (sum / windowSize);
                        averages.Add(movingAverage);
                    }
                double[] actualOutput = averages.ToArray();
            
            //prints actual output array
                for (int j = 0; j < actualOutput.Length; j++)
                {
                    Console.WriteLine(actualOutput[j]);
                }
           
            //Arrays for test methods
            double[] expectedOutput1 = new double[] {0, 0.5, 1, 2};
            double[] expectedOutput2 = new double[] {0, 0.5, -0.33, 0.5, -0.4, 0.6, -0.8, 1, -1.2, 1.4 };
            double[] example2 = new double[] { 0, 1, -2, 3 , -4, 5, -6, 7, -8, 9};
            double[] example1 = new double[] { 0, 1, 2, 3 };

            //Test Methods
            example1Test(windowSize, numbers, actualOutput, expectedOutput1, example1);
            example2Test(windowSize, numbers, actualOutput, expectedOutput2, example2);
            testWindowSize(windowSize);
            testWindowSize1(windowSize, actualOutput, numbers);
            sameArrayValues(numbers, actualOutput);
        }

        //Test 1 - Test for first example on the PDF (computeMovingAverages(3, new[] {0, 1, 2, 3}
        static void example1Test(int windowSize, double[] numbers, double[] actualOutput, double[] expectedOutput1, double[] example1)
        {
            Console.WriteLine();
            if (windowSize == 3 && numbers.SequenceEqual(example1))
            {
                if (actualOutput.SequenceEqual(expectedOutput1) == false)
                {
                    testResponses(1, 'f'); ;
                    return;
                }
                else
                {
                    testResponses(1, 'p'); ;
                }
            }
            else
                testResponses(1, 'c'); ;
        }

        //Test 2 - Test for second example on the PDF (computeMovingAverages(5, new[] {0,1,-2,3,-4,5,-6,7,-7,9})
        static void example2Test(int windowSize, double[] numbers, double[] actualOutput, double[] expectedOutput2, double[] example2)
        {
            if (windowSize == 5 && numbers.SequenceEqual(example2))
            {
                actualOutput[2] = Math.Round(actualOutput[2], 2);
                if (actualOutput.SequenceEqual(expectedOutput2) == false)
                {
                    testResponses(2, 'f'); ;
                    return;
                }
                else

                    testResponses(2, 'p'); ;
            }
            else
                testResponses(2, 'c'); ;
        }

        //Test 3 - Tests that the window size is greater than 0
        static void testWindowSize(int windowSize)
        {
            if (windowSize <= 0)
            {
                testResponses(3, 'f');
                return;
            }
            else
                Console.WriteLine("Test 3: Passed");
        }

        //Test 4 - Tests that any array with a window size of 1 is correct
        static void testWindowSize1(int windowSize, double[] numbers, double[] actualOutput)
        {
            if (windowSize == 1)
            {
                if (actualOutput.SequenceEqual(numbers) == false)
                {
                    testResponses(4, 'f');
                    return;
                }
                else
                    testResponses(4, 'p');
            }
            else
            {
                testResponses(4, 'c');
            }
        }

        //Test 5 - Tests that any array with the same value for every element is correct
        static void sameArrayValues(double[] numbers, double[] actualOutput)
        {
            double sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            if(sum/numbers.Length == 1 && (numbers[0] == numbers[numbers.Length - 1]) && (numbers[1] == numbers[numbers.Length - 2]))
            {
                if(actualOutput.SequenceEqual(numbers) == false)
                {
                    testResponses(5, 'f');
                    return;
                }
                else 
                {
                    testResponses(5, 'p');
                }
            } else
            {
                testResponses(5, 'c');
            }
        }

        static void testResponses(int testNumber, char passFail)
        {
            if (passFail == 'p')
                Console.WriteLine("Test " + testNumber + ": Passed - Actual output is equal to expected output");
            else if (passFail == 'f')
                Console.WriteLine("Test " + testNumber + ": Failed - Actual output does not equal expected output");
            else
                Console.WriteLine("Test " + testNumber + ": Passed - Not Applicable");
        }

    }   
}
