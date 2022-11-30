using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            //дає змогу динамічно додавати об’єктам нову функціональність, загортаючи їх у корисні «обгортки».
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation() - ялинка");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class ConcreteDecoratorA : Decorator
    {
        private string addedState;
       
        public override void Operation()
        {
            string[] color = { "зелений", "червоний", "блакитний", "жовтий", "білий", };
            Random random = new Random();
            int index = random.Next(color.Length);
            base.Operation();
            addedState = "New State";
            Console.WriteLine("ConcreteDecoratorA.Operation() - герлянда кольору: {0}", color[index]);
        }
    }

    // "ConcreteDecoratorB" 
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            string[] type = { "Шар", "сосулька", "паперова прикраса", };
            Random random = new Random();
            int index = random.Next(type.Length);
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation() - iграшка типу: {0}", type[index]);
        }
        void AddedBehavior()
        { }
    }
}
