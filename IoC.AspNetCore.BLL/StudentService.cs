using IoC.AspNetCore.IBLL;
using IoC.AspNetCore.IDAL;
using System;

namespace IoC.AspNetCore.BLL
{
    public class StudentService : IStudentService
    {
        public void PlayAbstractPhone(AbstractPhone phone)
        {
            Console.WriteLine("用 {0}", phone.GetType().Name);
            phone.Call();
            phone.Text();
        }

        public void Study()
        {
            Console.WriteLine("Study");
        }
    }
}
