using System;

namespace Hello_Exception_stud
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("Observation titmouse flight");
            Bird My_Bird = new Bird("Titmouse", 20);

            //1. Create the skeleton code with the  basic exception handling for the menu in the main method 
            //try - catch
            // 1. begin
            
            try
            {
                try
                {
                    Console.WriteLine(@"Enter number from 1 to 3 to choose exeption 
                                        1. Array overflow exception  
                                        2. Throw my exception
                                        3. user exception
                                        ");
                    uint i = uint.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            int exGet = My_Bird.FlySpeed[10];
                            break;
                        case 2:
                            throw new System.Exception("We throw some exception!");
                        case 3:
                            for (int a = 0; a < My_Bird.FlySpeed[My_Bird.FlySpeed.Length - 1]; a++)
                            {
                                My_Bird.FlyAway(a);
                            }
                            break;
                        default:
                            Console.WriteLine("Dosvidan'ya!");
                            break;

                    }
                }
                catch (BirdFlewAwayException ex){
                    Console.WriteLine(ex.When);
                    Console.WriteLine(ex.Why);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Alarm: Message -  " + ex.Message + " Source - " + ex.Source);
                }
                finally {
                    Console.WriteLine("I'll be back...");
                }
                // 2. end
            }
            // 1. end
            catch (Exception ex) {

            }
        }

    }
}
