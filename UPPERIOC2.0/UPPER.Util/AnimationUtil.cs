using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UPPERIOC2.UPPER.Util
{
    public class AnimationUtil
    {
        
        private bool _isRunning = false;
        public static AnimationUtil Instance { get; private set; } = new AnimationUtil();
        public ConcurrentQueue<KeyValuePair<int,Action<int>>> Data = new  ConcurrentQueue<KeyValuePair<int, Action<int>>>();
        public AnimationUtil() { 
            _isRunning = true;
            Task.Factory.StartNew(() => {
                List<KeyValuePair<int, Action<int>>> Data = new List<KeyValuePair<int, Action<int>>>();
                List<KeyValuePair<int, Action<int>>> DelTemp= new List<KeyValuePair<int, Action<int>>>();
                while (_isRunning)
                {

                    if (this.Data.TryDequeue(out var x))
                    {
                        Data.Add(x);
                    }
                    using (var e = Data.GetEnumerator())
                    {
                        while (e.MoveNext())
                        {
                            e.Current.Key -= 5;
                            if (e.Current.Key < 0)
                            {
                                DelTemp.Add(e.Current);
                            }
                            e.Current.Value.Invoke(e.Current.Key);
                        }                        
                    }
                    Data.RemoveAll(item=> DelTemp.Contains(item));
                    DelTemp.Clear();
                    Thread.Sleep(5);
                }
            });
        }
        ~AnimationUtil() { 
            _isRunning &= false;
        }
        public void SetAnimation(int AllTime,Action<int> Invoke) 
        {
            Data.Enqueue(new KeyValuePair<int,Action<int>>(AllTime , Invoke));
        }
    }
    public class KeyValuePair <TKey,TValue>{
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
