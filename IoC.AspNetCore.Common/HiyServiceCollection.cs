using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC.AspNetCore.Common
{
    public class HiyServiceCollection : IHiyServiceCollection
    {
        private Dictionary<string, Type> hiyDictionary = new Dictionary<string, Type>();

        /// <summary>
        /// 注册服务    注册抽象和实现
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        public void AddScope(Type serviceType, Type implementationType)
        {
            this.hiyDictionary.Add(serviceType.FullName, implementationType);
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            Type type = this.hiyDictionary[typeof(T).FullName];

            #region 封装实现递归
            //#region 选择构造函数
            //var ctorArray = type.GetConstructors();// 获取所有的构造函数
            //var ctor = ctorArray.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();// 构造函数最多的
            //#endregion
            //#region 准备构造函数的参数
            //List<object> paramList = new List<object>();
            //foreach (var param in ctor.GetParameters())
            //{
            //    var paramType = param.ParameterType;
            //    var paramTargetType = this.hiyDictionary[paramType.FullName];
            //    var target = Activator.CreateInstance(paramTargetType);
            //    paramList.Add(target);
            //}
            //#endregion
            #endregion

            return (T)this.GetService(type);            
        }

        private object GetService(Type type)
        {
            #region 选择构造函数
            var ctorArray = type.GetConstructors();// 获取所有的构造函数
            var ctor = ctorArray.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();// 构造函数最多的
            #endregion
            #region 准备构造函数的参数
            List<object> paramList = new List<object>();
            foreach (var param in ctor.GetParameters())
            {
                var paramType = param.ParameterType;
                var paramTargetType = this.hiyDictionary[paramType.FullName];
                var target = this.GetService(paramTargetType);
                paramList.Add(target);
            }
            #endregion
            var obj = Activator.CreateInstance(type, paramList.ToArray());
            // 如果需要属性注入
            foreach (var prop in type.GetProperties())
            {
                Type proptype = prop.PropertyType;
                Type propTargetType = this.hiyDictionary[proptype.FullName];
                var propObject = this.GetService(propTargetType);
                prop.SetValue(obj, propObject);
            }
            // 如果需要方法注入

            return obj;
        }
    }
}
