using IoC.AspNetCore.IBLL;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace IoC.AspNetCore.Factory
{
    public class SimpleFactory
    {
        private static string IStudentServiceAssembly =
            CustomConfigManager.GetConfig("IStudentServiceAssembly");

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
    }

    public class CustomConfigManager
    {
        public static string GetConfig(string key)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            string configValue = configuration.GetSection(key).Value;
            return configValue;
        }
    }
}
