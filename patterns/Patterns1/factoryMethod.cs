using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    public interface INotification
    {
        void send(string message);
    }

    public class mailNotification : INotification
    {
        public void send(string message)
        {
            Console.WriteLine($"Отправка email: {message}");
        }
    }

    public class smsNotification : INotification
    {
        public void send(string message)
        {
            Console.WriteLine($"Отправка sms: {message}");
        }
    }

    public class pushNotification : INotification
    {
        public void send(string message)
        {
            Console.WriteLine($"Отправка push: {message}");
        }
    }

    public abstract class NotificationFactory
    {
        public abstract INotification CreateNotification();

        public void sendNotification(string message)
        {
            var notification = CreateNotification();
            notification.send(message);
        }
    }

    public class mailFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            return new mailNotification();
        }
    }
    public class smsFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            return new smsNotification();
        }
    }
    public class pushFactory : NotificationFactory
    {
        public override INotification CreateNotification()
        {
            return new pushNotification();
        }
    }
}
