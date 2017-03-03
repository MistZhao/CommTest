using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tools
{
    /// <summary>
    /// 单例模式的泛型实现，通过反射绕过new，避免泛型约束中的new()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Singleton<T> where T : class
    {
        private static T _Instance = null;
        private static readonly object locker = new object();
        // 用于接收泛型实现类的类型，以便通过反射获取类
        // Type[i]中i的值表示构造函数中的参数个数，无参则为0
        public static readonly Type[] types = new Type[1];
        public static readonly Type[] paramTypes = new Type[0];

        private Singleton()
        {

        }

        public static T GetInstance()
        {
            if (_Instance == null)
            {
                lock (locker)
                {
                    if (_Instance == null)
                    {
                        //_Instance = new T(); //不用new是因为不要添加new()泛型约束，否则实现类必须有公有无参的构造函数，不符合单例的目的
                        ConstructorInfo ci = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                            null, paramTypes, null);
                        if (ci == null) { throw new InvalidOperationException("class must contain a private constructor without any parameters"); }
                        _Instance = (T)ci.Invoke(null);
                    }
                }
            }
            return _Instance;
        }

        public static T GetInstance(object[] objs)
        {
            if (_Instance == null)
            {
                lock (locker)
                {
                    if (_Instance == null)
                    {
                        //_Instance = new T(); //不用new是因为不要添加new()泛型约束，否则实现类必须有公有无参的构造函数，不符合单例的目的
                        ConstructorInfo ci = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                            null, types, null);
                        if (ci == null) { throw new InvalidOperationException("class must contain a private constructor with one parameter"); }
                        _Instance = (T)ci.Invoke(objs);
                    }
                }
            }
            return _Instance;
        }
    }
}
