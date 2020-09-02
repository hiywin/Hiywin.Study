using IoC.AspNetCore.IBLL;
using IoC.AspNetCore.IDAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace IoC.AspNetCore.Factory
{
    public class SimpleFactory
    {
        private static string IStudentServiceAssembly =
            CustomConfigManager.GetConfig("IStudentServiceAssembly");

        private static string AbstractPhoneAssembly =
            CustomConfigManager.GetConfig("AbstractPhoneAssembly");

        public static IStudentService CreateStudenService()
        {
            #region 关键步骤
            //Assembly assembly = Assembly.LoadFrom("");  //动态加载dll
            //Type type = assembly.GetType("");           //获取类型
            //return (IStudentService)Activator.CreateInstance(type); //返回
            #endregion

            Assembly assembly = Assembly.LoadFrom(IStudentServiceAssembly.Split(',')[1]);  //动态加载dll
            Type type = assembly.GetType(IStudentServiceAssembly.Split(',')[0]);           //获取类型
            return (IStudentService)Activator.CreateInstance(type); //返回
        }

        public static AbstractPhone CreateAbstractPhone()
        {
            Assembly assembly = Assembly.LoadFrom(AbstractPhoneAssembly.Split(',')[1]);
            Type type = assembly.GetType(AbstractPhoneAssembly.Split(',')[0]);
            return (AbstractPhone)Activator.CreateInstance(type);
        }
    }

    public class CustomConfigManager
    {
        /// <summary>
        /// 读取appsettings.json配置文件
        /// </summary>
        public static string GetConfig(string key)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            string configValue = configuration.GetSection(key).Value;
            return configValue;
        }
    }
}
