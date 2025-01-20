using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMetroidRandomizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string difficulty = args[0];
            string inputfile = args[1];
            string outputfile = args[2];

            var MainFunction = new MainFunction();
            MainFunction.CreateRom(difficulty, inputfile, outputfile);
            
        }


    }
}
