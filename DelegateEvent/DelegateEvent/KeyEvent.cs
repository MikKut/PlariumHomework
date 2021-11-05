using System;

namespace DelegateEvent
{ 
    class KeyEvent
    {
        internal int Counter { get; private set; }
        internal event PressKeyDel KeyPress;
        internal void OnKeyPress(char key)
        {
            var eventArgs = new KeyEventArgs();
            if (KeyPress != null)
            {
                eventArgs.ch = key;
                KeyPress(this, eventArgs);
            }
        }
        public KeyEvent()
        {
            this.Counter = 0;
        }
        internal void MakeTask()
        {
            this.Counter = 0;
            var keyEvent = new KeyEvent();
            keyEvent.KeyPress += (source, arg) => this.Counter++;
            keyEvent.KeyPress += (source, arg) => Console.WriteLine($"Получено сообщение о нажатии клавиши: {arg.ch}");
            Console.WriteLine("Введите несколько символов. Для останова введите точку.");
            EnterAKeys(keyEvent);
            Console.WriteLine($"Было нажато {Counter} клавиш.");
        }
        private static void EnterAKeys(KeyEvent keyEvent)
        {
            char key;
            while (true)
            {
                key = Console.ReadKey().KeyChar;
                if (key == '.')
                {
                    break;
                }
                keyEvent.OnKeyPress(key);
            }
        }
    }
}
