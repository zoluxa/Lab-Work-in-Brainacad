using System;

namespace Hello_Exception_stud
{
    //Create the Bird class with the fields, properties, constructors and the method
    //The public void FlyAway( int incrmnt ) method generates custom exception 
    class Bird {

        //Create fields and properties
        public int[] FlySpeed = { 5, 15, 25, 35 };
        public int NormalSpeed { get; set; }
        public string Nick { get; set; }
        private bool BirdFlewAway;
        //Create constructors
        public Bird() {}
        public Bird(string name, int speed)
        {
            NormalSpeed = speed;
            Nick = name;
        }
        //Implement Method public void FlyAway( int incrmnt ) which check Bird state by reading field  BirdFlewAway
        // check BirdFlewAway
        // if true 
        public void FlyAway(int incrmnt) {
            if (BirdFlewAway)
            {
                Console.WriteLine("Bird {0} flew away... Goodbuy bird!", Nick);
            }
            else
            {
                if (NormalSpeed >= FlySpeed[3])
                {
                    BirdFlewAway = true;
                    NormalSpeed = 0;
                    BirdFlewAwayException ex = new BirdFlewAwayException(string.Format("{0} flew with incredible speed!", Nick), "Oh! Startle.", DateTime.Now);
                    ex.HelpLink = "http://en.wikipedia.org/wiki/Tufted_titmouse";
                    throw ex;
                }
                else {
                    Console.WriteLine("Bird speed - {0}", NormalSpeed);
                }
                Console.WriteLine("Bird  ");
            }
        }
        // write the message to console
        // else

        // increment the Bird speed by method argument
        // check the condition (NormalSpeed >= FlySpeed[3]) 
        // If it's true 

        // BirdFlewAway = true and we generate custom exception    BirdFlewAwayException(string.Format("{0} flew with incredible speed!", Nick), "Oh! Startle.", DateTime.Now)
        // with HelpLink = "http://en.wikipedia.org/wiki/Tufted_titmouse" else  console.writeline about Bird speed 
    }
}
