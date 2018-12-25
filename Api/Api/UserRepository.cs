using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api
{
    public class UserRepository
    {
        public static Dictionary<Guid, User> _users = new Dictionary<Guid, User>();

        public User[] All()
        {
            return _users.Values.ToArray();
        }

        //If user don't exist, insert him to dictionary.Otherwice, send error message
        public void Insert(User user)
        {
            if (!_users.ContainsKey(user._id))
            {
                _users.Add(user._id, user);
                Console.WriteLine($"User {user._username} added");
            }
            else
            {
                Console.WriteLine("User is already exist");
            }
        }

        //Take user ID, and remove user with that ID from dictionary
        public void Delete(Guid userId)
        {
            if (_users.ContainsKey(userId))
            {
                _users.Remove(userId);
                Console.WriteLine("User removed");
            }
            else
            {
                Console.WriteLine("User dosn't exist");
            }

        }

        //Check dictionary for user ID, if don't find, send error message 
        public User Get(Guid userId)
        {
            User userResult = null;

            if (!_users.ContainsKey(userId))
            {
                Console.WriteLine("Don't find any user");
                return userResult;
            }

            _users.TryGetValue(userId, out userResult);
            return userResult;
        }

        //Update exist User
        public void Update(Guid userId)
        {
            var updateUser = Get(userId);
            updateUser.ChangeFields();
            _users.Remove(userId);
            _users.Add(userId, updateUser);
            Console.WriteLine("User updated");
        }
    }
}
