using Autofac;
using IoC.AspNetCore.Interface;
using IoC.AspNetCore.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoC.AspNetCore.Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Autofac();

            Console.Read();
        }

        /// <summary>
        /// 依赖注入三种方式
        /// 1.构造函数注入
        /// 2.属性注入
        /// 3.方法注入
        /// </summary>
        static void Autofac()
        {
            {   // 模拟netcore内置依赖注入方式

                //// 声明容器
                //IServiceCollection serviceDescriptors = new ServiceCollection();
                //serviceDescriptors.AddTransient(typeof(IPhone), typeof(ApplePhone));
                //serviceDescriptors.AddTransient(typeof(IHeadphone), typeof(Headphone));
                //serviceDescriptors.AddTransient(typeof(IMicrophone), typeof(Microphone));
                //serviceDescriptors.AddTransient(typeof(IPower), typeof(Power));

                //// 注册容器
                //ServiceProvider serviceProvider = serviceDescriptors.BuildServiceProvider();

                //// 根据抽象获取实例
                //IPhone phone = serviceProvider.GetService<IPhone>();
                //IHeadphone headphone = serviceProvider.GetService<IHeadphone>();
                //IMicrophone microphone = serviceProvider.GetService<IMicrophone>();
                //IPower power = serviceProvider.GetService<IPower>();
            }

            {   // Autofac - 构造函数注入

                // 实现步骤：
                // 1.通过nuget引入Autofac
                // 2.创建容器
                // 3.接口与实现注入
                // 4.接口调用

                ContainerBuilder containerBuilder = new ContainerBuilder();
                containerBuilder.RegisterType<ApplePhone>().As<IPhone>();
                containerBuilder.RegisterType<Headphone>().As<IHeadphone>();
                containerBuilder.RegisterType<Microphone>().As<IMicrophone>();
                containerBuilder.RegisterType<Power>().As<IPower>();
                IContainer container = containerBuilder.Build();
                IPhone phone = container.Resolve<IPhone>();
                phone.Call();
            }
            {   // Autofac - 属性注入(PropertiesAutowired支持)

                // 属性注入之后，AndroidPhone中的IMicrophone也被构造了
                ContainerBuilder containerBuilder = new ContainerBuilder();
                containerBuilder.RegisterType<AndroidPhone>().As<IPhone>().PropertiesAutowired();   //支持属性注入
                containerBuilder.RegisterType<Headphone>().As<IHeadphone>();
                containerBuilder.RegisterType<Microphone>().As<IMicrophone>();
                containerBuilder.RegisterType<Power>().As<IPower>();
                IContainer container = containerBuilder.Build();
                IPhone phone = container.Resolve<IPhone>();
                phone.Call();
            }
            {   // Autofac - 方法注入

                // 在类中创建方法，构造函数注入之后直接调用该方法
                ContainerBuilder containerBuilder = new ContainerBuilder();
                containerBuilder.RegisterType<AndroidPhone>().As<IPhone>();
                containerBuilder.RegisterType<Headphone>().As<IHeadphone>();
                containerBuilder.RegisterType<Microphone>().As<IMicrophone>();
                containerBuilder.RegisterType<Power>().As<IPower>();

                IContainer container = containerBuilder.Build();
                IPhone phone = container.Resolve<IPhone>();
                phone.Init(container.Resolve<IPower>());    //方法注入
                phone.Call();
            }
            {   // Autofac - 一个接口有多个实现时，选择指定名称的实现

                // 注入时：As会以最后一个实现为准；Named可指定使用哪个实现
                ContainerBuilder containerBuilder = new ContainerBuilder();
                containerBuilder.RegisterType<AndroidPhone>().Named<IPhone>("AndroidPhone");
                containerBuilder.RegisterType<ApplePhone>().Named<IPhone>("ApplePhone");
                containerBuilder.RegisterType<Headphone>().As<IHeadphone>();
                containerBuilder.RegisterType<Microphone>().As<IMicrophone>();
                containerBuilder.RegisterType<Power>().As<IPower>();

                IContainer container = containerBuilder.Build();
                IPhone phone = container.ResolveNamed<IPhone>("AndroidPhone");  //指定某个实现
                phone.Call();
            }
        }
    }
}
