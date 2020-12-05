using UnityEngine;

namespace Delegates_Observer
{

    namespace Geekbrains
    {
        public sealed class DelegatesObserver
        {
            public delegate void MyDelegate(object o);
            public sealed class Source
            {
                private MyDelegate _functions;

                public void Add(MyDelegate f)
                {
                    _functions += f;
                }

                public void Remove(MyDelegate f)
                {
                    _functions -= f;
                }

                public void Run()
                {
                    Debug.Log("RUNS!");
                    if (_functions != null) _functions(this);
                }
            }

            public sealed class Observer1 // Наблюдатель 1
            {
                public void Do(object o)
                {
                    Debug.Log($"Первый. Принял, что объект {o} побежал");
                }
            }

            public sealed class Observer2 // Наблюдатель 2
            {
                public void Do(object o)
                {
                    Debug.Log($"Второй. Принял, что объект {o} побежал");
                }
            }
        }
    }

    namespace Geekbrains
    {
        public class Test : MonoBehaviour
        {
            private void Start()
            {
                DelegatesObserver.Source s = new DelegatesObserver.Source();
                DelegatesObserver.Observer1 o1 = new DelegatesObserver.Observer1();
                DelegatesObserver.Observer2 o2 = new DelegatesObserver.Observer2();
                DelegatesObserver.MyDelegate d1 = new DelegatesObserver.MyDelegate(o1.Do);
                s.Add(d1);
                s.Add(o2.Do);
                s.Run();
                s.Remove(o1.Do);
                s.Run();
            }
        }
    }
}