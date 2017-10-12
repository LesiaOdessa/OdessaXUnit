using System;
using Starcounter;

namespace OdessaXUnit
{
    [Database]
    public class Person
    {
        public string Name { get; set; }
    }

    public class Program
    {
        static void Main()
        {
            Db.Transact(() =>
            {
                new Person { Name = "John" };
            });
        }
    }
}