using System;

namespace DelegateEvent
{
    delegate void PressKeyDel(object source, KeyEventArgs arg);
    class Program
    {
        private static KeyEvent ke = new();
        static Action doTask = () => ke.MakeTask();
        public static void Main()
        {
            doTask.Invoke();
        }
    }
}