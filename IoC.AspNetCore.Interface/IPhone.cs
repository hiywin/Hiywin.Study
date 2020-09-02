using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.AspNetCore.Interface
{
    public interface IPhone
    {
        void Call();
        void Init(IPower power);

        IMicrophone Microphone { get; set; }
        IHeadphone Headphone { get; set; }
        IPower Power { get; set; }
    }
}
