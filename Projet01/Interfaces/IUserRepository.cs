using Projet01.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Projet01.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user, Action<IEnumerable<User>> callBack);
        IEnumerable<User> GetAll();
        void Delete(User user, Action<IEnumerable<User>> callBack);
        void Delete(IEnumerable<User> user, Action<IEnumerable<User>> callBack);
        void Set(User oldUser, User newUser, Action<IEnumerable<User>> callBack);
        IEnumerable<User> Find(Func<User, bool> predicate, Action<IEnumerable<User>> callBack);
    }
}