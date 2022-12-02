using System;
namespace AdapterExample
{
    // Система яку будемо адаптовувати
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "old system";
        }
    }
    // Широковикористовуваний інтерфейс нової системи (специфікація до квартири)
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    // Ну і власне сама розетка у новій квартирі
    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "new interface";
        }
    }
    // Адаптер назовні виглядає як нові євророзетки, шляхом наслідування прийнятного у 
    // системі інтерфейсу
    class Adapter : INewElectricitySystem
    {
        // Але всередині він старий
        private readonly OldElectricitySystem _adaptee;
        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        // А тут відбувається вся магія: наш адаптер «перекладає»
        // функціональність із нового стандарту на старий
        public string MatchWideSocket()
        {
            // Якщо б була різниця 
            // то тут ми б помістили трансформатор
            return _adaptee.MatchThinSocket();
        }
    }

     class  ElectricityConsumer
    {
        // Зарядний пристрій, який розуміє тільки нову систему
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    //-------------My Variant


    class OldLightbulb
    {
        public string MatchThinSocket()
        {
            return "old system light";
        }
    }
    interface INewLightbulb
    {
        string MatchWideSocketLightbulb();
    }

    class NewLightbulb : INewLightbulb
    {
        public string MatchWideSocketLightbulb()
        {
            return "new interface light";
        }
    }
    class AdapterLightbulb : INewLightbulb
    {
        private readonly OldLightbulb _adaptee;
        public AdapterLightbulb(OldLightbulb adaptee)
        {
            _adaptee = adaptee;
        }
        public string MatchWideSocketLightbulb()
        {
            return _adaptee.MatchThinSocket();
        }
    }

    class LightbulbConsumer
    {
        public static void ChargeNotebook(INewLightbulb Lightbulb)
        {
            Console.WriteLine(Lightbulb.MatchWideSocketLightbulb());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            // 1) Ми можемо користуватися новою системою без проблем
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);
            // 2) Ми повинні адаптуватися до старої системи, використовуючи адаптер
            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new Adapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);

            var newLightbulb = new NewLightbulb();
            LightbulbConsumer.ChargeNotebook(newLightbulb);
            var OldLightBulb = new OldLightbulb();
            var adapterLigntBulb = new AdapterLightbulb(OldLightBulb);
            LightbulbConsumer.ChargeNotebook(adapterLigntBulb);
            Console.ReadKey();
        }
    }
}
