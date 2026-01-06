
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;



class Program
{
    static void Main(string[] args)
    {
        AvlTree<string> tree = new AvlTree<string>();

        #region Test Balancing
        //RR
        // int[] values = { 10, 20, 30 };

        //LL
        //  int[] values = { 30, 20, 10 };

        //LR
        // int[] values = { 30, 10, 20 };

        //RL
        //int[] values = { 10, 30, 20 };

        // Inserting values
        //int[] values = { 10, 20, 30, 40, 50, 25 };

        #endregion

        #region Test Delete
        //Console.WriteLine("Removing value 30 ...");
        //Thread.Sleep(1000);

        //tree.Delete(30);
        //Console.WriteLine("the tree after remove the value 30 ...");
        //tree.Print();
        //Console.WriteLine("waitong to Remove value 10 ...");
        //Thread.Sleep(1000);
        //tree.Delete(10);
        //Console.WriteLine("the tree after remove the value 10 ...");
        //tree.Print();

        //var k = 'y';

        //while (k == 'y' || k == 'Y')
        //{
        //    Console.Clear();
        //    tree.Print();
        //    Thread.Sleep(500);
        //    Console.Write("Search: ");
        //    string value = Console.ReadLine().Trim().ToString();

        //    Console.WriteLine($"Searching {value}...");
        //    Thread.Sleep(1000);

        //    var result = tree.Search(value);

        //    if (result == null)
        //    {
        //        Console.WriteLine($"the value {value} not found!.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Value found with heigt : {result.Hight}");
        //    }


        //    Console.WriteLine("Do you want to perform Search again? (Y/N)");

        //    k = Console.ReadKey().KeyChar;
        //}


        #endregion

        #region Test AutoComplete 

        string[] values =
                        {
                            "Adam","Alex","Ali","Amir","Anis","Ayoub","Bilal","Brahim","Chafik","Djalil",
                            "Djamel","Elias","Fadi","Fares","Farouk","Hakim","Hamza","Hani","Hassan","Ilyes",
                            "Imad","Ismail","Jalil","Karim","Khaled","Khalil","Lotfi","Mahdi","Malik","Marwan",
                            "Mehdi","Mokhtar","Mohamed","Mounir","Nabil","Nadir","Nassim","Noureddine","Omar","Othman",
                            "Rachid","Reda","Riad","Said","Sami","Samir","Sofiane","Taha","Tarek","Wahid",
                            "Yacine","Yahia","Yanis","Yasser","Yazid","Younes","Youssef","Zakaria","Zinedine","Ziyad",
                            "Adel","Aimen","Akram","Amine","Anwar","Aref","Aziz","Badis","Belkacem","Bilel",
                            "Fouad","Hichem","Kamel","Laid","Meriem","Noura","Salim","Selim","Siham","Souad",
                            "Walid","Yamina","Zahra","Aicha","Imene","Lamia","Rania","Sabrina","Sara","Nesrine"
                        };
        foreach (var value in values)
        {
           tree.Insert(value);
        }


        var k = 'y';

        while (k == 'y' || k == 'Y')
        {
            Console.Clear();
            tree.Print();
            Thread.Sleep(500);
            Console.Write("Search: ");
            string value = Console.ReadLine().Trim().ToString();

            Console.WriteLine($"Searching items start with {value}...");
            Thread.Sleep(1500);

            var result = tree.AutoComplete(value);

            if (result == null)
            {
                Console.WriteLine($"there is no  value start with {value}!.");
            }
            else
            {
                Console.WriteLine(" + ----------------------- +");
                foreach (var item in result)
                {
                    Console.WriteLine($"| - {item}");
                }
                Console.WriteLine(" + ----------------------- +");
            }


            Console.WriteLine("Do you want to perform Search again? (Y/N)");

            k = Console.ReadKey().KeyChar;
        }

        #endregion



    }
}