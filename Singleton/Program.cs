﻿using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                var getInstance = CustomerManager.GetInstance();
                getInstance.Save();
            }
            Console.ReadKey();
        }
    }
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {
            Console.WriteLine("Instance created.");
        }
        public static CustomerManager GetInstance()
        {
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            Console.WriteLine("GetInstance running.");
            return _customerManager;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}
