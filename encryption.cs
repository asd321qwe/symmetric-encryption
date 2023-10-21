using System;
using System.Text;

class Program
{

    static string Encrypt(string text, string key)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] encryptedBytes = new byte[textBytes.Length];

        for (int i = 0; i < textBytes.Length; i++)
        {
            encryptedBytes[i] = (byte)(textBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return Convert.ToBase64String(encryptedBytes);
    }

    static string Decrypt(string encryptedText, string key)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] decryptedBytes = new byte[encryptedBytes.Length];

        for (int i = 0; i < encryptedBytes.Length; i++)
        {
            decryptedBytes[i] = (byte)(encryptedBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return Encoding.UTF8.GetString(decryptedBytes);
    }
    static void Main()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Encrypt");
        Console.WriteLine("2. Decrypt");

        string choice = Console.ReadLine();

        string text;
        string key;

        if (choice == "1")
        {
            Console.Write("Enter the original text: ");
            text = Console.ReadLine();
            Console.Write("Enter the encryption key: ");
            key = Console.ReadLine();
            string encryptedText = Encrypt(text, key);
            Console.WriteLine("Encrypted Text: " + encryptedText);
        }
        else if (choice == "2")
        {
            Console.Write("Enter the encrypted text: ");
            text = Console.ReadLine();
            Console.Write("Enter the decryption key: ");
            key = Console.ReadLine();
            string decryptedText = Decrypt(text, key);
            Console.WriteLine("Decrypted Text: " + decryptedText);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select 1 to Encrypt or 2 to Decrypt.");
        }
        Console.ReadLine();
    }
}
