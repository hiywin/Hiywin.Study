using IoC.AspNetCore.IDAL;
using System;

namespace IoC.AspNetCore.DAL
{
    public class Redmi : AbstractPhone
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public void Call()
        {
            Console.WriteLine("Call: " + Name);
        }

        public void Text()
        {
            Console.WriteLine("Text: " + Name);
        }
    }
}
