using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Line_Scheduling
{
    class AssemblyLine
    {
        public AssemblyLine(int n, int e1, int e2, int x1, int x2, int[,] S, int[,] T)
        {
            /*Where T is the transfer times between stations
             * S is the processing times at each stations
             e1 and e2 are the entry times at stations 1 and 2
             x1 and x2 are the exit times are stations 1 and 2.*/

            this.e1 = e1;
            this.e2 = e2;
            this.x1 = x1;
            this.x2 = x2;
            this.n = n;
            this.S = S;
            this.T = T;


        }
        public int n { get; set; }
        public int e1 { get; set; }
        public int e2 { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int[,] S { get; set; }
        public int[,] T { get; set; }


        public void getMinProductionTime()
        {
            string station1trace = "";
            string station2trace = "";
            string temp;

            int[] station1 = new int[n];
            int[] station2 = new int[n];


            int i;

            //Time taken to leave station1 in Assembly line 1
            station1[0] = e1 + S[0, 0];
            station1trace += "\nEntry -> Line 1 Station 1 ->";

            //Time taken to leave station1 in Assmebly line 1
            station2[0] = e2 + S[1, 0];
            station2trace += "\nEntry -> Line 2 Station 1 ->";

            for (i = 1; i < n; i++)
            {
                station1[i] = Math.Min(station1[i - 1] + S[0, i], station2[i - 1] + T[1, i] + S[0, i]);
                if ((station1[i - 1] + S[0, i]) <= (station2[i - 1] + T[1, i] + S[0, i]))
                {
                    temp = station1trace;
                    station1trace += " Line 1 station " + (i + 1) + " -> ";

                }
                else
                {
                    temp = station1trace;
                    station1trace = station2trace + " Transfer to Line 1 Station " + (i + 1) + " -> ";
                }
                station2[i] = Math.Min(station2[i - 1] + S[1, i], station1[i - 1] + T[0, i] + S[1, i]);
                if ((station2[i - 1] + S[1, i]) <= (station1[i - 1] + T[0, i] + S[1, i]))
                {
                    station2trace += " Line 2 station " + (i + 1) + " ->";
                }
                else
                {
                    station2trace = temp + " Transfer to Line 2 Station " + (i + 1) + " ->";
                }
            }
            station1trace += " Exit";
            station2trace += " Exit";
            //Consider exit and return time
            if ((station1[n - 1] + x1) < (station2[n - 1] + x2))
            {
                Console.WriteLine("\nThe minimum production time is " + (station1[n - 1] + x1));
                Console.WriteLine("The trace of the minimum production path is " + station1trace);
            }
            else
            {
                Console.WriteLine("\nThe minimum production time is " + (station2[n - 1] + x2));
                Console.WriteLine("The trace of the minimum production path is " + station2trace);
            }
        }

    }
}
