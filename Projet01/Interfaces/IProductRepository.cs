using Projet01.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Projet01.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product, Action<IEnumerable<Product>> callBack);
        IEnumerable<Product> GetAll();
        void Delete(Product product, Action<IEnumerable<Product>> callBack);
        void Delete(IEnumerable<Product> product, Action<IEnumerable<Product>> callBack);
        void Set(Product oldProduct, Product newProduct, Action<IEnumerable<Product>> callBack);
        IEnumerable<Product> Find(Func<Product, bool> predicate, Action<IEnumerable<Product>> callBack);
    }
}