using IoC.AspNetCore.IDAL;
using System;

namespace IoC.AspNetCore.DAL
{
    public class Redmi : AbstractPhone
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
