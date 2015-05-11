using System;

namespace DDDScrum
{
    public class Product
    {
        public string Name { get; private set; }

        public Product(string name)
        {
            Name = name;
        }

        public void Rename(String newName)
        {
            Name = newName;
        }
    }
}