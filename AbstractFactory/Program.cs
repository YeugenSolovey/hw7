using System;

namespace AbstractFactory
{
    //дає змогу створювати сімейства пов’язаних об’єктів, не прив’язуючись до конкретних класів створюваних об’єктів.
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine, Color color)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
            Console.WriteLine("Set color: ");
            color.GetColor();
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    //ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }
    //ConcreteProductA3
    public class Mersedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mersedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine 4.4");
        }
    }

    //ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine 3.2");
        }
    }
    //ConcreteProductB3
    public class MersedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mesedes Engine 3.6");
        }
    }

    // AbstractProductC
    public abstract class Color
    {
        public virtual void GetColor()
        {
        }
    }
    public class FordColor : Color
    {
        public override void GetColor()
        {
            Console.WriteLine("Ford color: red");
        }
    }

    //ConcreteProductB2
    public class ToyotaColor : Color
    {
        public override void GetColor()
        {
            Console.WriteLine("Toyota color: green");
        }
    }
    //ConcreteProductB3
    public class MersedesColor : Color
    {
        public override void GetColor()
        {
            Console.WriteLine("Mesedes color: gray");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
        Color CreateColor();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }
        Color ICarFactory.CreateColor()
        {
            return new FordColor();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }
        Color ICarFactory.CreateColor()
        {
            return new ToyotaColor();
        }
    }

    // ConcreteFactory3
    public class MesedesFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Mersedes();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new MersedesEngine();
        }
        Color ICarFactory.CreateColor()
        {
            return new MersedesColor();
        }
    }

    public class ClientFactory
    {
        private Car car;
        private Engine engine;
        private Color color;

        public ClientFactory(ICarFactory factory)
        {
            //Абстрагування процесів інстанціювання
            car = factory.CreateCar();
            engine = factory.CreateEngine();
            color =  factory.CreateColor();
        }

        public void Run()
        {
            car.GetType();
            //Абстрагування варіантів використання
            car.Interact(engine, color);
        }
    }

    class AbstractFactoryApp
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client1 = new ClientFactory(carFactory);

            client1.Run();

            carFactory = new FordFactory();
            ClientFactory client2 = new ClientFactory(carFactory);
            client2.Run();

            carFactory = new MesedesFactory();
            ClientFactory client3 = new ClientFactory(carFactory);
            client3.Run();

            Console.ReadKey();
        }
    }
}
