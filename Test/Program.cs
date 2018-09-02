using CompositeDesignPattern.Domain;
using CompositeDesignPattern.Domain.WorkForces;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkForce w = new WorkForce();
            
            Console.WriteLine(w.Name);

            WorkForce ww = new A();

            Console.WriteLine(ww.Name);

            A www = new A();

            Console.WriteLine(www.Name);
        }
    }
}
