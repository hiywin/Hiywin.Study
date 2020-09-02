using IoC.AspNetCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.AspNetCore.Services
{
    public class ApplePhone:IPhone
    {
        public IMicrophone Microphone { get; set; }
        public IHeadphone Headphone { get; set; }
        public IPower Power { get; set; }

        //public ApplePhone()
        //{
        //    Console.WriteLine("{0} 构造函数",this.GetType().Name);
        //}

        public ApplePhone(IHeadphone headphone)
        {
            this.Headphone = headphone;
            Console.WriteLine("{0} 带参数构造函数",this.GetType().Name);
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
