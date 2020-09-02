using IoC.AspNetCore.IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.AspNetCore.DAL
{
    public class Vivo : AbstractPhone
    {
        public override void Call()
        {
            Console.WriteLine("使用 {0} Call", this.GetType().Name);
        }

        public override void Text()
        {
            Console.WriteLine("使用 {0} Text", this.GetType().Name);
        }
    }
}
