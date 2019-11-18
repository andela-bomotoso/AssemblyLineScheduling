using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Line_Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
        
                Console.Write("How many Stations are in the Assembly Lines? ");
                int n = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the entry time at Assembly line 1: ");
                int e1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the entry time at Assembly line 2: ");
                int e2 = Convert.ToInt32(Console.ReadLine());

                int[,] S = new int[2, n];
                int[,] T = new int[2, n];

                /* int[,] S = { {4, 5, 3, 2},
                          {2, 10, 1, 4} };

                 int[,] T = { {0, 7, 4, 5},
                          {0, 9, 2, 8} };*/


                for (int i = 0; i < n; i++)
                {
                    Console.Write("Processing Time at Line 1 Station " + (i + 1) + ": ");
                    S[0, i] = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Processing Time at Line 2 Station " + (i + 1) + ": ");
                    S[1, i] = Convert.ToInt32(Console.ReadLine());

                    if (i > 0)
                    {
                        Console.Write("Transfer Time to Line 1 Station " + (i + 1) + ": ");
                        T[1, i] = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Transfer Time to Line 2 Station " + (i + 1) + ": ");
                        T[0, i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.Write("Enter the exit time at Assembly Line 1: ");
                int x1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the exit time at Assembly Line 2: ");
                int x2 = Convert.ToInt32(Console.ReadLine());

            AssemblyLine assemblyLine = new AssemblyLine(n, e1, e2, x1, x2, S, T);
                assemblyLine.getMinProductionTime();
            }
        }
    }

