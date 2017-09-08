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
        private string pathToFile;
        private string pathToEncFile;
        private string pathToKeyFile;

        private string tmpStr;

        enum Errors
        {
            tooFewArgs,
            inputFileDontExist,
            encryptionError,
            savingFileError
        }


        static void Main(string[] args)
        {
            Program brcrypt = new Program();
            //read args
            if ( args.Length != 3)
            {
                brcrypt.ErrorHndlr(Errors.tooFewArgs);       
            }
            brcrypt.pathToFile = args[0];
            brcrypt.pathToEncFile = args[1];
            brcrypt.pathToKeyFile = args[2];

            //check file existance
            if ( !File.Exists( brcrypt.pathToFile ) )
            {
                brcrypt.ErrorHndlr(Errors.inputFileDontExist);
            }

            
            System.Console.WriteLine("Reading file {0}...", brcrypt.pathToFile);
            byte[] inputFile = File.ReadAllBytes(brcrypt.pathToFile);   //read file

            Brstub brstub = new Brstub();   //make object brstub

            System.Console.WriteLine("Genrating MD5 hash...");
            string inputFileMD5 = brstub.GetMd5Hash(inputFile);  //make MD5 hash of inputFile
            //System.Console.WriteLine(inputFileMD5);   //debug

            System.Console.WriteLine("Encoding file {0}...", brcrypt.pathToFile);

            byte[] key = brstub.GenKey();   //generate key
            byte[] encrypted = brstub.Encrypt(inputFile, key);  //encrypted data


            //check encryption

            byte[] decrypted = brstub.Decrypt(encrypted, key);  //decrypted data

            /*tesing line for enc troubles
            System.Console.WriteLine("Enc:{0}", brstub.GetMd5Hash(encrypted));
            System.Console.WriteLine("Dec:{0}", brstub.GetMd5Hash(decrypted));
            */
            

            if (brstub.CheckMD5(decrypted, inputFileMD5))
            {
                System.Console.WriteLine("Encrypted succesfull!");

                System.Console.WriteLine("Saving data to file {0}...", brcrypt.pathToEncFile);
                File.WriteAllBytes(brcrypt.pathToEncFile, encrypted);

                System.Console.WriteLine("Saving key to file {0}...", brcrypt.pathToKeyFile);
                File.WriteAllBytes(brcrypt.pathToKeyFile, key);

                //System.Console.WriteLine("Key:{0}", key);
                System.Console.WriteLine("MD5:{0}", inputFileMD5);


                brcrypt.checkSavedFiles(inputFileMD5);
                
                
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
                    System.Console.WriteLine("Brcrypt.exe [path_to_input_file] [path_to_out_encrypted_file] [path_to_key]");
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
                case Errors.savingFileError:
                    System.Console.WriteLine("Saving data failed!");
                    System.Console.WriteLine("MD5:{0}", tmpStr);
                    break;
            }
             
        }

        void checkSavedFiles(string MD5)
        {
            byte[] encrypted = File.ReadAllBytes(pathToEncFile);
            byte[] key = File.ReadAllBytes(pathToKeyFile);

            Brstub br = new Brstub();

            byte[] decrypted = br.Decrypt(encrypted, key);

            if( br.CheckMD5(decrypted, MD5) )
            {
                System.Console.WriteLine("Saving data succesfull!");                             
            }
            else
            {
                tmpStr = br.GetMd5Hash(decrypted);
                ErrorHndlr(Errors.savingFileError);
               
            }

        }

       
    }
    
}
