using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Yard_Service
{
    public class Utilites
    {

        User[] usersList = null;
        bool _databaseIsCreated;

        public void MainMenu()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Add new users, type (1)");
                Console.WriteLine("See all users, type (2)");
                Console.WriteLine("Delete user, type (3)");
                Console.WriteLine("Edit user, type (4)");
                Console.WriteLine("See all users with decrypted password, type (5)");
                Console.WriteLine("Exit program, type (6)");

                int choiseNumber = Convert.ToInt32(CheckIn(true, true, false));

                if(choiseNumber == 1)
                {
                    AddUsers();
                }
                else if(choiseNumber == 2)
                {
                    AllUsers(false);
                    Console.ReadKey();
                    MainMenu();
                }
                else if(choiseNumber == 3)
                {
                    DeleteUser();
                }
                else if(choiseNumber == 4)
                {
                    UpdateUser();
                }
                else if(choiseNumber == 5)
                {
                    DecryptedList();
                }

                break;
            }
        }

        public void AddUsers()
        {
            Console.WriteLine("How many users you want add?");
            int usersNumber = Convert.ToInt32(CheckIn(true, false, false));
            var repo = new Repository();

            for(int i = 0; i < usersNumber; i++)
            {
                var user = new User();
                repo.Insert(user);
            }

            _databaseIsCreated = true;
            Console.ReadKey();
            MainMenu();
        }

        public void DeleteUser()
        {
            AllUsers(false);
            if(_databaseIsCreated)
            {
                Console.WriteLine("Enter number of user for delete");
                int user = Convert.ToInt32(CheckIn(true, false, true));
                var repo = new Repository();
                repo.Delete(usersList[user - 1]._id);
            }
            Console.ReadKey();
            MainMenu();
        }

        public void UpdateUser()
        {
            AllUsers(false);
            if(_databaseIsCreated)
            {
                Console.WriteLine("Enter number of user for update");
                int user = Convert.ToInt32(CheckIn(true, false, true));
                var repo = new Repository();
                repo.Update(usersList[user - 1]._id);
            }
            Console.ReadKey();
            MainMenu();
        }

        public void AllUsers(bool encrypt)
        {
            var repo = new Repository();
            usersList = repo.All();
            int k = 0;

            if(_databaseIsCreated)
            {
                for(int i = 0; i < usersList.Length; i++)
                {
                    Console.Write($"# {++k} ");
                    usersList[i].DisplayInfo(encrypt);
                }
            }
            else
            {
                Console.WriteLine("Database is missing");
            }
        }

        public void DecryptedList()
        {
            AllUsers(true);
            Console.ReadKey();
            MainMenu();
        }

        public string CheckIn(bool number, bool menu, bool depositoryOperation)
        {
            string enteredText;

            while(true)
            {
                enteredText = Console.ReadLine();
                bool validCheck = false;

                foreach(char symbol in enteredText)
                {
                    if(number && !char.IsDigit(symbol))
                    {
                        Console.WriteLine("You entered not a number");
                        validCheck = false;
                        break;
                    }

                    if(menu && (enteredText.Length != 1 || Convert.ToInt32(char.GetNumericValue(symbol)) < 1 || Convert.ToInt32(char.GetNumericValue(symbol)) > 6))
                    {
                        Console.WriteLine("You entered to small or too large number");
                        validCheck = false;
                        break;
                    }

                    { validCheck = true; }
                }

                if(!menu && validCheck)
                {
                    if(depositoryOperation && number && (usersList.Length < 0 || Convert.ToInt32(enteredText) > usersList.Length))
                    {
                        Console.WriteLine("You are out of database range, reenter number");
                        validCheck = false;
                    }
                }

                if(validCheck)
                {
                    break;
                }
            }
            return enteredText;
        }
    }
}
