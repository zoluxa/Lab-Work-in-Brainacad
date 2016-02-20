using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_1_4_lab
{
    class Program
    {
        // 1) declare enum ComputerType
       public enum CompType { desktop, laptop, server };


        // 2) declare struct Computer
        struct Computer
        {
           public int CPU;
           public double freq;
           public int memory;
           public int HDD;
           public CompType type;

          
        }
        
        static void Main(string[] args)
        {
            
            // 3) declare jagged array of computers size 4 (4 departments)
            Computer[][] dep = new Computer[4][];


            // 4) set the size of every array in jagged array (number of computers)
                 
            //RV: Why loop and then multiple if? What is the benefit of this loop? Just hardcode the indexes for initialization. dep[0][0] =, dep[0][1] = ...dep[4][3] =        
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    //RV: Here is null reference exception. This is because you access dep[i] array elements before creating the instance array itself.
                    //RV: Jagged array is array of arrays. So every department array has to be initialized first.  
                    //RV: For example here you have to do the foolowing: dep[i] = new Computer[5];, because department number 0 contains 5 computers                    
                    dep[i][0] = new Computer() { CPU = 4, freq = 2.5, memory = 6, HDD = 500}; dep[i][0].type = CompType.desktop;
                    dep[i][1] = new Computer() { CPU = 4, freq = 2.5, memory = 6, HDD = 500}; dep[i][1].type = CompType.desktop;
                    dep[i][2] = new Computer() { CPU = 2, freq = 1.7, memory = 4, HDD = 250}; dep[i][2].type = CompType.laptop;
                    dep[i][3] = new Computer() { CPU = 2, freq = 1.7, memory = 4, HDD = 250}; dep[i][3].type = CompType.laptop;
                    dep[i][4] = new Computer() { CPU = 8, freq = 3, memory = 16, HDD = 2000}; dep[i][4].type = CompType.server;

                }
                else if (i == 1)
                {
                    dep[i][0] = new Computer() { CPU = 2, freq = 1.7, memory = 4, HDD = 250}; dep[i][0].type = CompType.laptop;
                    dep[i][1] = new Computer() { CPU = 2, freq = 1.7, memory = 4, HDD = 250}; dep[i][1].type = CompType.laptop;
                    dep[i][2] = new Computer() { CPU = 2, freq = 1.7, memory = 4, HDD = 250}; dep[i][2].type = CompType.laptop;
                }
                else if (i == 2)
                {
                    dep[i][0] = new Computer() { CPU = 2, freq = 1.7, memory = 4, HDD = 250 }; dep[i][0].type = CompType.laptop; 
                    dep[i][1] = new Computer() { CPU = 2, freq = 1.7, memory = 4, HDD = 250 }; dep[i][1].type = CompType.laptop;
                    dep[i][2] = new Computer() { CPU = 4, freq = 2.5, memory = 6, HDD = 500 }; dep[i][2].type = CompType.desktop;
                    dep[i][3] = new Computer() { CPU = 4, freq = 2.5, memory = 6, HDD = 500 }; dep[i][3].type = CompType.desktop;
                    dep[i][4] = new Computer() { CPU = 4, freq = 2.5, memory = 6, HDD = 500 }; dep[i][4].type = CompType.desktop;
                }
                else if (i == 3)
                {
                    dep[i][0] = new Computer() { CPU = 2, freq = 1.7, memory = 4, HDD = 250 }; dep[i][0].type = CompType.laptop;
                    dep[i][1] = new Computer() { CPU = 4, freq = 2.5, memory = 6, HDD = 500 }; dep[i][0].type = CompType.desktop;
                    dep[i][2] = new Computer() { CPU = 8, freq = 3, memory = 16, HDD = 2000 }; dep[i][0].type = CompType.server;
                    dep[i][3] = new Computer() { CPU = 8, freq = 3, memory = 16, HDD = 2000 }; dep[i][0].type = CompType.server;
                }
            }
            
            // 5) init111ialize array
            // Note: use loops and if-else statements
            int laptopCount = 0;
            int desktopCount = 0;
            int serverCount = 0;
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < dep[i].Length; j++)
                {
                    switch (dep[i][j].type)
                    {
                        case CompType.desktop:
                            desktopCount++;
                            break;
                        case CompType.laptop:
                            laptopCount++;
                            break;
                        case CompType.server:
                            serverCount++;
                            break;
                    }
                }

            }
            Console.WriteLine("Number of computers:\n Desktop {0}\nLaptop {1}\nServer {2}", laptopCount, desktopCount, serverCount);
            Console.ReadKey();

            // 7) count total number of all computers
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)
            Console.WriteLine("Total number of computers: ", laptopCount + desktopCount + serverCount);
            Console.ReadKey();

            //RV: Parts 8, 9 and 10 are also needed

            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements



            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions


            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements

        }
    }
}
