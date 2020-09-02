using IoC.AspNetCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.AspNetCore.Services
{
    public class Power:IPower
    {
        public Power(IMicrophone microphone)
        {
            Console.WriteLine($"{this.GetType().Name} 被构造。。。");
        }
    }
}
