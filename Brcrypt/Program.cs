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
        string pathToFile;
        string pathToEncFile;

       

        enum Errors
        {
            tooFewArgs,
            inputFileDontExist,
            encryptionError
        }


        static void Main(string[] args)
        {
            Program brcrypt = new Program();
            if( args.Length != 2)
            {
                brcrypt.ErrorHndlr(Errors.tooFewArgs);       
            }
            brcrypt.pathToFile = args[0];
            brcrypt.pathToEncFile = args[1];

            if( !File.Exists( brcrypt.pathToFile ) )
            {
                brcrypt.ErrorHndlr(Errors.inputFileDontExist);
            }

            System.Console.WriteLine("Reading file {0}...", brcrypt.pathToFile);
            byte[] inputFile = File.ReadAllBytes(brcrypt.pathToFile);

            Brstub brstub = new Brstub();   //make object brstub

            System.Console.WriteLine("Genrating MD5 hash...");
            string inputFileMD5 = brstub.GetMd5Hash(inputFile);  //make MD5 hash of inputFile
            System.Console.WriteLine(inputFileMD5);

            System.Console.WriteLine("Encoding file {0}...", brcrypt.pathToFile);

            var encryptionData = brstub.Encrypt(inputFile);

            byte[] encrypted = encryptionData.Item1;
            byte[] key = encryptionData.Item2;
            byte[] IV = encryptionData.Item3;

            //check encryption

            brstub.Decrypted = brstub.Decrypt(encrypted,key, IV);
            System.Console.WriteLine("Enc:{0}", brstub.GetMd5Hash(encrypted));
            System.Console.WriteLine("Dec:{0}", brstub.GetMd5Hash(brstub.Decrypted) ); 

            if (brstub.CheckMD5(inputFileMD5))
            {
                System.Console.WriteLine("Encrypted succesfull!");

                System.Console.WriteLine("Saving to file {0}", brcrypt.pathToEncFile);
                File.WriteAllBytes(brcrypt.pathToEncFile, encrypted);

                System.Console.WriteLine("Key:{0}", key);
                System.Console.WriteLine("IV:{0}", IV);
                System.Console.WriteLine("MD5:{0}", inputFileMD5);
                
            }
            else
            {
                brcrypt.ErrorHndlr(Errors.encryptionError);
            }



        }

        void ErrorHndlr(Errors error)
        {
            switch (error)
            {
                case Errors.tooFewArgs:
                    System.Console.WriteLine("Too few arguments!");
                    System.Console.WriteLine("Brcrypt.exe [path_to_input_file] [path_to_out_encrypted_file]");
                    System.Environment.Exit(1);
                    break;
                case Errors.inputFileDontExist:
                    System.Console.WriteLine("Input file {0} don't exist.", pathToFile);
                    System.Environment.Exit(2);
                    break;
                case Errors.encryptionError:
                    System.Console.WriteLine("Unknow encryption error.", pathToFile);
                    System.Environment.Exit(3);
                    break;
            }
             
        }
    }

    
}
