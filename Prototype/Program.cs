using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { FirstName = "burak" };
            Person p2 = p.Clone();
            p2.FirstName = "parlak";
            Console.WriteLine(p.FirstName);
            Console.WriteLine(p2.FirstName);
            Console.ReadKey();
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
