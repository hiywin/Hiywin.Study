using IoC.AspNetCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.AspNetCore.Services
{
    public class Microphone:IMicrophone
    {
        public Microphone()
        {
            Console.WriteLine($"{this.GetType().Name} 被构造。。。");
        }
    }
}
