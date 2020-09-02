using IoC.AspNetCore.Interface;
using System;

namespace IoC.AspNetCore.Services
{
    public class AndroidPhone:IPhone
    {
        public IMicrophone Microphone { get; set; }
        public IHeadphone Headphone { get; set; }
        public IPower Power { get; set; }

        public AndroidPhone()
        {
            Console.WriteLine("{0} 构造函数",this.GetType().Name);
        }

        public void Call()
        {
            Console.WriteLine("{0} 打电话",this.GetType().Name);
        }

        public void Init(IPower power)
        {
            Power = power;
        }
    }
}
