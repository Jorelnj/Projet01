using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet01
{
    public class UserRepoInMemory : IUserRepository
    {
        private static List<User> data;

        public UserRepoInMemory()
        {
            if (data == null)
                data = new List<User>
                {
                    new User("Jorel", "hello", "Director"),
                    new User("Hostiane", "morning", "Secretary"),
                    new User("Gaetan", "morning", "Secretary")
                };
        }
        public void Add(User user, Action<IEnumerable<User>> callBack)
        {
            data.Add(user);
            if (callBack != null)
                callBack(data);
        }

        public void Delete(User user, Action<IEnumerable<User>> callBack)
        {
            data.Remove(user);
            if (callBack != null)
                callBack(data);
        }

        public void Delete(IEnumerable<User> users, Action<IEnumerable<User>> callBack)
        {
            foreach(User u in users)
            {
                data.Remove(u);
            }
            if (callBack != null)
                callBack(data);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate, Action<IEnumerable<User>> callBack)
        {
            var users = data.Where(predicate).ToArray();
            if (callBack != null)
                callBack(users);
            return users;
        }

        public IEnumerable<User> GetAll()
        {
            return data;
            //throw new NotImplementedException();
        }

        public void Set(User oldUser, User newUser, Action<IEnumerable<User>> callBack)
        {
            data[data.IndexOf(oldUser)] = newUser;
            if (callBack != null)
                callBack(data);
        }
    }
}
