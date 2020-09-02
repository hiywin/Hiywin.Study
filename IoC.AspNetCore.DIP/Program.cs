
using IoC.AspNetCore.Factory;
using IoC.AspNetCore.IBLL;
using IoC.AspNetCore.IDAL;
using IoC.AspNetCore.Interface;
using System;

namespace IoC.AspNetCore.DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Test();

            Console.Read();
        }

        static void Test()
        {
            Console.WriteLine("请输入：");
            var r = Console.ReadLine();
            if (r == "1")
            {
                DIP();

                Test();
            }
        }

        // 依赖倒置写法
        static void DIP()
        {
            {   //依赖于BLL，DAL引用
                //IStudentService service = new StudentService();
                //service.Study();

                //AbstractPhone redmi = new Redmi();
                //service.PlayAbstractPhone(redmi);

                //AbstractPhone vivo = new Vivo();
                //service.PlayAbstractPhone(vivo);
            }
            {   //使用反射
                IStudentService service = SimpleFactory.CreateStudenService();
                service.Study();
                AbstractPhone phone = SimpleFactory.CreateAbstractPhone();
                service.PlayAbstractPhone(phone);

            }
            {    //使用反射
                IPhone phone = SimpleFactory.CreatePhone();
                phone.Call();
            }

        } 
    }
}
