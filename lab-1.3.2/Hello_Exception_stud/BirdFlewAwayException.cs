using System;

namespace Hello_Exception_stud
{
    //Create the BirdFlewAwayException class, derived from ApplicationException  with two properties  
    public class BirdFlewAwayException : ApplicationException {
        public DateTime When { get; set; }
        public string Why { get; set; }
        public BirdFlewAwayException() { }
        public BirdFlewAwayException(string message, string wh, DateTime tm) : base (message) {
            When = tm;
            Why = wh;
        }
    }
        //When
        //Why

    //Create constructors

}
