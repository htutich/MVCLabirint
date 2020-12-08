using System;
using System.Collections.Generic;


namespace MVCLabirint
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _dictionary = new Dictionary<Type, object>();

        public static void Set(object obj)
        {
            var type = obj.GetType();
            if (_dictionary.ContainsKey(type))
            {
                throw new ArgumentException("В ServiceLocator уже есть компонент с таким типом.");
            }
            _dictionary.Add(type, obj);
        }

        public static T Get<T>()
        {
            var type = typeof(T);
            if (!_dictionary.ContainsKey(type))
            {
                throw new ArgumentException("В ServiceLocator нет компонента с таким типом");
            }
            return (T)_dictionary[type];
        }

        public static void Destroy()
        {
            _dictionary.Clear();
        }

    }
}