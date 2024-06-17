using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amanda_Eks.Simulator
{
    internal class SimulateRented
    {
        private Thread _thread;

        private bool _running;

        public SimulateRented(Thread thread, bool running)
        {
            _thread = thread;
            _running = running;
        }

        public void Run()
        {
            Random random = new Random();
            while (_running)
            {
                Console.WriteLine("Thread is running...");
                Thread.Sleep((int)random.NextInt64(long.Parse("5000"), long.Parse("25000")));  // Simulate some work
            }
        }

        public void Stop() 
        {
            if (_running)
            {
                _running = false;
                _thread.Join();  // Wait for the thread to finish
            }
        }

        public void Start()
        {
            if (!_running)
            {
                _running = true;
                _thread.Start();
                Console.WriteLine("Thread started.");
            }
        }
    }
}
