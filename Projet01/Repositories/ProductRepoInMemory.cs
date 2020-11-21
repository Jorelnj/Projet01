using Projet01.Interfaces;
using Projet01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet01.Repositories
{
    public class ProductRepoInMemory : IProductRepository
    {
        private static List<Product> data;
        private static List<string> dataBase;

        public ProductRepoInMemory()
        {
            if (data == null)
                data = new List<Product>
                {
                    new Product("J01", "Telephone", 3000, 19.25F),
                    new Product("J01", "Telephone", 3000, 19.25F),
                    new Product("J02", "Pain", 150, 0)
                };
        }
        public void Add(Product user, Action<IEnumerable<Product>> callBack)
        {
            data.Add(user);
            dataBase.Insert(user.Serialize());
            if (callBack != null)
                callBack(data);
        }

        public void Delete(Product user, Action<IEnumerable<Product>> callBack)
        {
            data.Remove(user);
            if (callBack != null)
                callBack(data);
        }

        public void Delete(IEnumerable<Product> users, Action<IEnumerable<Product>> callBack)
        {
            foreach(Product u in users)
            {
                data.Remove(u);
            }
            if (callBack != null)
                callBack(data);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate, Action<IEnumerable<Product>> callBack)
        {
            var users = data.Where(predicate).ToArray();
            if (callBack != null)
                callBack(users);
            return users;
        }

        public IEnumerable<Product> GetAll()
        {
            return data;
            //throw new NotImplementedException();
        }

        public void Set(Product oldProduct, Product newProduct, Action<IEnumerable<Product>> callBack)
        {
            data[data.IndexOf(oldProduct)] = newProduct;
            if (callBack != null)
                callBack(data);
        }
    }
}
