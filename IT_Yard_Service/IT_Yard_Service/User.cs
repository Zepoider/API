using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Yard_Service
{
    public class User
    {
        public Guid _id;
        public string _username;
        public string _password { get; set; }

        Utilites util = new Utilites();

        //Constructor for Consol application - semiautomatic :)
        public User()
        {
            this._id = Guid.NewGuid();
            ChangeFields();
        }

        //Constructor for Consol application - manual coding
        public User(string username, string password)
        {
            this._id = Guid.NewGuid();
            this._username = username;
            this._password = password;
        }

        public void DisplayInfo(bool decryption)
        {
            if(decryption)
            {
                Console.WriteLine($"Username - {_username} Password - {Decrypt(_password)}");
            }
            else
                Console.WriteLine($"Username - {_username} Password - {_password}");
        }

        //Fill field :)
        public void ChangeFields()
        {
            Console.WriteLine("Enter username:");
            this._username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            this._password = Encrypt(Console.ReadLine());
        }

        public string Encrypt(string text)
        {
            char[] encryptedText = new char[text.Length];
            string returnValue = null;
            var cell = text.Length - 1;

            for(int i = 0; i < text.Length; i++)
            {
                if(i % 2 == 0)
                {
                    encryptedText[cell] = text[i];
                    cell--;
                }
            }

            cell = 0;

            for(int k = 0; k < text.Length; k++)
            {
                if(k % 2 != 0)
                {
                    encryptedText[cell] = text[k];
                    cell++;
                }
            }

            foreach(var symbol in encryptedText)
            {
                returnValue += symbol;
            }

            return returnValue;
        }

        public string Decrypt(string text)
        {
            char[] decryptedText = new char[text.Length];
            string returnValue = null;
            var cell = text.Length - 1;

            for(int i = 0; i < text.Length; i++)
            {
                if(i % 2 == 0)
                {
                    decryptedText[i] = text[cell];
                    cell--;
                }
            }

            cell = 0;

            for(int k = 0; k < text.Length; k++)
            {
                if(k % 2 != 0)
                {
                    decryptedText[k] = text[cell];
                    cell++;
                }
            }

            foreach(var symbol in decryptedText)
            {
                returnValue += symbol;
            }
            return returnValue;
        }
    }
}

