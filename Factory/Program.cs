using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //nesneleri factory dizayn pattern ile üreterek kodumuzu değişime açık hale getirdik. 
            CustomerManager cm = new CustomerManager(new FileLoggerFactory());
            cm.Save();
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Birkaç farklı yere(database, dosyalar, mail), birkaç farklı şekilde(xml,json) loglama yapılabilir.
    /// We can record the log with diffirent file format(xml,json) to different places(to databases, to file, to mailbox)
    /// </summary>
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
    public class DbLoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Loglama ile ilgili işlemler burada 
            return new DbLogger();
        }
    }
    public class FileLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Loglama ile ilgili işlemler burada
            return new FileLogger();
        }
    }

    public interface ILogger
    {
        void Log();
    }
    public class DbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with DatabaseLogger");
        }
    }
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with FileLogger");
        }
    }

    //iş katmanı
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
