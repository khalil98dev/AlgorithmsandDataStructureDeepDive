using Algo;

int[] koko =
{
    1,5,3,2,7,98,15,17,19,33
};


//Console.WriteLine("before sort: ");

//koko.Print();

//var Sorted = koko.SortDesc();

//Console.WriteLine("After sort Desc: ");

//Sorted.Print();


//var Sorted2 = koko.SortAsc();

//Console.WriteLine("After sort Asc: ");

//Sorted2.Print();


Console.WriteLine("before sort: ");



koko.Print();


Console.WriteLine("After sort asc: ");

koko.InsertionSortAsc();

koko.Print();


Console.WriteLine("After sort Desc: ");

koko.InsertionSortDesc();

koko.Print();





