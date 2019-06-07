using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager();
            cm.Save();
            Console.ReadKey();
        }
    }
    public class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

    public interface ILogging
    {
        void Log();
    }
    public class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached!");
        }
    }

    public interface ICaching
    {
        void Cache();
    }
    public class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("UserChecked!");
        }
    }

    public interface IAuthorize
    {
        void CheckUser();
    }
    public class Validate : IValidate
    {
        public void Validation()
        {
            Console.WriteLine("Validated!");
        }
    }

    public interface IValidate
    {
        void Validation();
    }

    public class CrossCuttingConcernsFacade
    {
        public ICaching Caching;
        public IAuthorize Authorize;
        public ILogging Logging;
        public IValidate Validate;
        public CrossCuttingConcernsFacade()
        {
            Caching = new Caching();
            Logging = new Logging();
            Authorize = new Authorize();
            Validate = new Validate();
        }
    }
    public class CustomerManager
    {
        private CrossCuttingConcernsFacade _concern;
        public CustomerManager()
        {
            _concern = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concern.Validate.Validation();
            _concern.Authorize.CheckUser();
            _concern.Caching.Cache();
            _concern.Logging.Log();
            Console.WriteLine("Saved!");
        }
    }
}
