using IoC.AspNetCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.AspNetCore.Services
{
    public class Headphone:IHeadphone
    {
        public Headphone(IPower power)
        {
            Console.WriteLine($"{this.GetType().Name} 被构造。。。");
        }
    }
}
