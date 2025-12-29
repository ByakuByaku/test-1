using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    // Реальный объект - ваш банковский счет с деньгами
    class BankAccount : IBankAccount
    {
        public decimal Balance { get; private set; } = 10000m;

        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

    public interface IBankAccount
    {
        bool Withdraw(decimal amount);
    }
    // Прокси - банковская карта
    class BankCard : IBankAccount
    {
        private BankAccount _account;
        private string _pin;

        public BankCard(string pin)
        {
            _pin = pin;
            _account = new BankAccount();
        }

        public bool Withdraw(decimal amount)
        {

            //Проверка лимита
            if (amount > 50000)
            {
                Console.WriteLine("Превышен суточный лимит!");
                return false;
            }

            //Логирование
            Console.WriteLine($"Попытка снятия {amount} руб.");

            //Делегируем реальному объекту
            return _account.Withdraw(amount);
        }
    }

}
