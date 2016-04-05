using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_3_1_lab
{
    class CatchExceptionClass
    {
        public void CatchExceptionMethod()
        {
            try
            {
                MyArray ma = new MyArray();

                // 3) replace second elevent of array by 0

                int[] arr = new int[4] { 1, 4, 8, 5 };
                ma.Assign(arr, 4);
                arr[1] = 0;
            }
           
                // 8) catch all other exceptions here
            catch (Exception ex)
            {
                // 9) print System.Exception properties:
                // HelpLink, Message, Source, StackTrace, TargetSite
                Console.WriteLine("exeption HelpLink", ex.HelpLink);
                Console.WriteLine("exeption Message", ex.Message);
                Console.WriteLine("exeption Source", ex.Source);
                Console.WriteLine("exeption StackTrace", ex.StackTrace);
                Console.WriteLine("exeption TargetSite", ex.TargetSite);
            }

            // 10) add finally block, print some message
            // explain features of block finally
            finally
            {
                Console.WriteLine("Press and key to exit...");
            }
        }
    }
}
