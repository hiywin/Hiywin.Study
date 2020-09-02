using System;

namespace IoC.AspNetCore.IDAL
{
    public interface AbstractPhone
    {
        int ID { get; set; }
        string Name { get; set; }
        void Call();
        void Text();
    }
}
