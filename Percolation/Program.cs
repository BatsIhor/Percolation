using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Percolation
{

    public class Percolation
    {
        bool[,] openSites;
        bool[,] fullSites;
        int N;

        // create N-by-N grid, with all sites blocked
        public Percolation(int N)
        {
            this.N = N;
            openSites = new bool[N, N];
            fullSites = new bool[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    openSites[i, j] = false;
                    fullSites[i, j] = false;
                }
            }

            for (int i = 0; i < N; i++)
            {
                fullSites[0, i] = true;
            }


        }

        // open site (row i, column j) if it is not already
        public void open(int i, int j)
        {
            //Check boundaries
            if (i < 0 || i >= N) return;
            if (j < 0 || j >= N) return;

            //if is not open Open it
            if (!isOpen(i, j))
            {
                openSites[i, j] = true;
            }

            //if we have neighbors check if they are not full if they are 

            if (isFull(i + 1, j) || isFull(i, j + 1) || isFull(i - 1, j) || isFull(i, j - 1))
            {
                markAllNieghborsAsFull(i, j);
            }
        }

        private void markAllNieghborsAsFull(int i, int j)
        {
            if (i < 0 || i >= N) return;
            if (j < 0 || j >= N) return;

            if (isOpen(i, j) && !isFull(i, j))
            {
                fullSites[i, j] = true;

                markAllNieghborsAsFull(i + 1, j);
                markAllNieghborsAsFull(i, j + 1);
                markAllNieghborsAsFull(i - 1, j);
                markAllNieghborsAsFull(i, j - 1);
            }
        }

        // does the system percolate?
        public bool percolates()
        {
            for (int j = 0; j < N; j++)
            {
                if (fullSites[N - 1, j]) return true;
            }
            return false;
        }

        // is site (row i, column j) open?
        public bool isOpen(int i, int j)
        {
            if (i < 0 || i >= N) return false;
            if (j < 0 || j >= N) return false;

            return openSites[i, j];
        }

        // is site (row i, column j) full?
        public bool isFull(int i, int j)
        {
            if (i < 0 || i >= N) return false;
            if (j < 0 || j >= N) return false;
            return fullSites[i, j];
        }

        public void Print()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(openSites[i, j] ? 1 : 0);
                }
                PrintFull(i);

                Console.WriteLine();
            }
        }

        void PrintFull(int i)
        {
            Console.Write("\t\t\t");

            for (int j = 0; j < N; j++)
            {
                Console.Write(fullSites[i, j] ? 1 : 0);
            }
        }

    }
    
    public class PercolationStats
    {
        // perform T independent computational experiments on an N-by-N grid
        public PercolationStats(int N, int T)
        {
            Percolation perc = new Percolation(N);
            for (int i = 0; i < T; i++)
            {
                while (!perc.percolates())
                {
                    Random rnd = new Random();
                    int x = rnd.Next(N);
                    int y = rnd.Next(N);

                    perc.open(x, y);
                }
            }
        }

        // sample mean of percolation threshold
        public double mean()
        {
            return 0;
        }

        // sample standard deviation of percolation threshold
        public double stddev()
        {
            return 0;
        }

        // returns lower bound of the 95% confidence interval
        public double confidenceLo()
        {
            return 0;
        }

        // returns upper bound of the 95% confidence interval
        public double confidenceHi()
        {
            return 0;
        }

        // test client, described below
        public static void Main(String[] args) {

            if (args.Count() < 2)
            { 
            }
            int x = int.Parse(args[0]);
            int y = int.Parse(args[1]);

        }
    }


    //class Prgram
    //{
    //    static void Main(string[] args)
    //    {
    //        int N = 100;
    //        Percolation perc = new Percolation(N);

    //        while (!perc.percolates())
    //        {
    //            //Console.WriteLine("Union or x to exit");
    //            //string str1 = Console.ReadLine();
    //            //if (str1 == "x")
    //            //    break;
    //            //string str2 = Console.ReadLine();


    //            //int x = int.Parse(str1);
    //            //int y = int.Parse(str2);

    //            Random rnd = new Random();
    //            int x = rnd.Next(N);
    //            int y = rnd.Next(N);

    //            perc.open(x, y);




    //        }

    //        perc.Print();
    //        Console.ReadLine();

    //        Console.WriteLine("Yes!");
    //        Console.ReadLine();
    //    }
    //}
}
