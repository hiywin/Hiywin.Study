using IoC.AspNetCore.IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.AspNetCore.DAL
{
    public class Vivo : AbstractPhone
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
