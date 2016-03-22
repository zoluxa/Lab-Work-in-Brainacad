using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {

        static void Main(string[] args)
        {
            // Change to your number of menuitems.

            FootballTeams MyCode = new FootballTeams();
            const int maxMenuItems = 3;
            int selector = 0;
            bool good = false;
            while (selector != maxMenuItems)
            {
                Console.Clear();
                DrawTitle();
                DrawMenu(maxMenuItems);
                good = int.TryParse(Console.ReadLine(), out selector);
                if (good)
                {
                    switch (selector)
                    {
                        case 1:
                            Console.WriteLine("// code for case 1 here");
                            MyCode.AddTeams();
                            break;
                        case 2:
                            Console.WriteLine("// code for case 2 here");
                            MyCode.ListInit();
                            break;
                        case 3:
                            Console.WriteLine("// code for case 2 here");
                            MyCode.Delete();
                            break;
                        case 4:
                            Console.WriteLine("// code for case 2 here");
                            MyCode.TeamSearch();
                            break;
                        // possibly more cases here
                        default:
                            if (selector != maxMenuItems)
                            {
                                ErrorMessage();
                            }
                            break;
                    }
                }
                else
                {
                    ErrorMessage();
                }
                Console.ReadKey();
            }
            

        }
        private static void ErrorMessage()
        {
            Console.WriteLine("Typing error, press key to continue.");
        }
        private static void DrawStarLine()
        {
            Console.WriteLine("**********************************************************************");
        }
        private static void DrawTitle()
        {
            DrawStarLine();
            Console.WriteLine("+++                       Menu Airport                             +++");
            DrawStarLine();
        }
        private static void DrawMenu(int maxitems)
        {
            DrawStarLine();
            Console.WriteLine("Football Manager");
            Console.WriteLine();
            Console.WriteLine("1. Add a Football team");
            Console.WriteLine("2. List the Football teams");
            Console.WriteLine("3. Search for a Football team");
            Console.WriteLine("4. Delete a team");
            Console.WriteLine("5. Exit program");
            DrawStarLine();
            Console.WriteLine("Make your choice: type 1, 2,... or {0} for exit", maxitems);
            DrawStarLine();
            
        }

    }
    class FootballTeams
    {


        public FootballTeams() { }

        List<string> teams;
        public void ListInit() { }
        
        public void AddTeams()
        {
            Console.WriteLine("Enter a team to be added: ");
            string userinput = Console.ReadLine();
            if (teams.Count < 10)
            {
                if (userinput != "Colchester")
                {
                    teams.Add(userinput);
                    foreach (var item in teams)
                        Console.Write(item.ToString() + " ");
                }
                else
                    Console.Write("NOT ALLOWED");
            }
            else
                Console.Write("MAXIMUM LIMIT REACHED");
        }


        public void DisplayTeams()
        {
            foreach (var item in teams)
                Console.Write(item.ToString() + " ");
        }

        public void TeamSearch()
        {
            Console.WriteLine("Please enter the team you wish to search for: ");
            string userinput = Console.ReadLine();
            if (teams.Contains(userinput))
                Console.WriteLine("Success, team " + userinput);
        }

        public void Delete()
        {
            Console.WriteLine("Enter a team you wish to delete: ");
            string userinput = Console.ReadLine();
            teams.Remove(userinput);
            foreach (var item in teams)
                Console.Write(item.ToString() + " ");
        }
    }



}
