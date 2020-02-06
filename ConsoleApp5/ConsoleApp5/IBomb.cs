using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public delegate void Count();
    interface IBomb
    {
        event Count OnCount;
        void CountOff();
        void Ent();
        void Show();
        void Animate();
        void Time();
        void TimeFly();
        void Time(string s);
        void Country();
    }
}
