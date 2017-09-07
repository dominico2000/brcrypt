using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Brcrypt
{
    class Program
    {
        public string pathToFile;
        public string pathToEncFile;


        static void Main(string[] args)
        {
            Program brcrypt = new Program();
            if( args.Length != 2)
            {
                System.Console.WriteLine("Brcrypt.exe [path_to_input_file] [path_to_out_encrypted_file]");
                System.Environment.Exit(1);       
            }
            brcrypt.pathToFile = args[0];
            brcrypt.pathToEncFile = args[1];

            Brstub br = new Brstub();

            br.   

                       

        }
    }
}
