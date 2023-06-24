using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardHomeWork_22_06_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uzcard card = new Uzcard("1234567890123456", "John Doe", 100);
            card.AddWithBonus(50);
            card.Pay(30); // добавлен параметр cost

            Humo card2 = new Humo("9876543210987654", "Jane Doe", 50000);
            card2.AddWithBonus(100);
            card2.Pay(20000); // добавлен параметр cost
            card2.PayWireless(30000); // добавлен параметр cost
        }
    }
    public abstract class Card
    {
        public string Number { get; set; }
        public string HolderName { get; set; }
        public int Money { get; set; }

        public Card(string number, string holderName, int money)
        {
            Number = number;
            HolderName = holderName;
            Money = money;
        }

        public abstract bool Pay(int cost);

        public void Add(int amount)
        {
            Money += amount;
            Console.WriteLine(Money);
        }

        public virtual void AddWithBonus(int amount, int bonus = 2)
        {
            Add(amount + bonus);
        }
    }
    public class Uzcard : Card
    {
        public Uzcard(string number, string holderName, int money) : base(number, holderName, money)
        {
        }

        public override void AddWithBonus(int amount, int Bonus = 5)
        {
            base.AddWithBonus(amount, Bonus);
        }


        public override bool Pay(int cost)
        {
            if (Money - cost < 0)
            {
                Console.WriteLine("Not enough money on the card");
                return false;
            }

            Money -= cost;
            Console.WriteLine("Payment succeeded. Remaining balance: " + Money);
            return true;
        }

    }

    public class Humo : Card
    {
        public Humo(string number, string holderName, int money) : base(number, holderName, money)
        {
        }

        public override bool Pay(int cost)
        {
            if (Money - cost < 0)
            {
                Console.WriteLine("Not enough money on the card");
                return false;
            }

            Money -= cost;
            Console.WriteLine("Payment succeeded. Remaining balance: " + Money);
            return true;
        }

        public bool PayWireless(int cost)
        {
            if (cost < 0 || cost > 50000 || Money - cost < 0)
            {
                Console.WriteLine("Payment failed");
                return false;
            }

            Money -= cost;
            Console.WriteLine("Payment succeeded. Remaining balance: " + Money);
            return true;
        }
    }
}