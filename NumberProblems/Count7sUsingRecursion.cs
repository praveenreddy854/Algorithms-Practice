namespace ConsoleApp1.NumberProblems
{
    public class Count7sUsingRecursion
    {
        public static int Count7(int n)
        {
              if(n < 7){
                    return 0;
                }
  
            if(n % 10 == 7)
            {
                return Count7(n / 10) + 1;
            }
                return Count7(n / 10);
       } 
       public static void Test()
       {
           System.Console.WriteLine(Count7(717) == 2);
           System.Console.WriteLine(Count7(7) == 1);
           System.Console.WriteLine(Count7(171) == 1);
           System.Console.WriteLine(Count7(121) == 0);
       }
}
}