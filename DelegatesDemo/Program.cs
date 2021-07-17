using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    //delegate declaration -- compiler automatically convert it into class form, we can use MyDelegate as class.
    delegate void MyDelegate(string str);   // signature of delegate class and method (whose address we want to pass inside delgate) must match
    delegate void MyOtherDelegate(string str, int a);

    class Program
    {
        static void Main(string[] args)
        {
            Greeting("hello");

            //delegate instatiation and subscription
            MyDelegate del = new MyDelegate(Greeting);  

            //Invoke delegate
            //del.Invoke("called from its address");
            //del("the other way");

            del = Hello;  //single cast delegate
            del("hi");

            del += Hello;  //multicast delegate  , here subscribe Hello method

            del -= Greeting;  // unsubscribe 

            // del = HelloAgain   // error because the signature of delegate and method does not match
            MyOtherDelegate del2 = new MyOtherDelegate(HelloAgain);

            del2("romi", 3);
        }

        public static void Greeting(string msg)
        {
            Console.WriteLine($"Greeting : {msg}");
        }

        public static void Hello(string msg)
        {
            Console.WriteLine($"Hello : {msg}");
        }

        public static void HelloAgain(string msg, int times)
        {
            Console.WriteLine($"Hello : {msg}");
        }
    }
}
