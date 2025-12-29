using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    internal class Adapter
    {
        public interface IPayment
        {
            void Payment();
        }


        public class Cash : IPayment
        {
            public void Payment()
            {
                Console.WriteLine("Оплата наличными");
            }
        }



        public class Customer
        {
            public void purchase(IPayment payment)
            {
                payment.Payment();
            }
        }

        public interface IcashlessPayment
        {
            void cashlessPayment();
        }


        public class Card : IcashlessPayment
        {
            public void cashlessPayment()
            {
                Console.WriteLine("Оплата картой");
            }
        }

        public class cardToPaymentAdaptet : IPayment
        {
            Card card;

            public cardToPaymentAdaptet(Card c)
            {
                card = c;
            }

            public void Payment()
            {
                card.cashlessPayment();
            }
        }


    }
}
