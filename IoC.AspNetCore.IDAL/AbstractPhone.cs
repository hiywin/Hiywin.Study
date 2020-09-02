using System;

namespace IoC.AspNetCore.IDAL
{
    public abstract class AbstractPhone
    {
        public int Id { get; set; }
        public string Branch { get; set; }
        // 打电话
        public abstract void Call();
        // 发短信
        public abstract void Text();
    }
}
