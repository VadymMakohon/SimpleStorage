using System.Collections.Generic;
using System.Linq;

namespace SimpleStorage
{
    public class StorageManager
    {
        private readonly List<Product> _inventory = new List<Product>();

        public void AddProduct(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Product name cannot be empty.", nameof(name));

            var product = new Product(id, name);
            _inventory.Add(product);
        }

        public bool RemoveProduct(int id)
        {
            var product = _inventory.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                _inventory.Remove(product);
                return true;
            }
            return false;
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                throw new ArgumentException("Search term cannot be empty.", nameof(searchTerm));

            return _inventory
                .Where(p => p.ID.ToString() == searchTerm || p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _inventory.ToList();
        }
    }
}