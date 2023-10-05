using System;
namespace MyLambda
{
    class Program
    {
        public delegate int TinhToan(int a, int b);
        static void Main(string[] args)
        {

            //Gán lambda cho Func
            Func<int, int, int> tinhtong1 = (int x, int y) => {
                return x + y;
            };
            // Gán lambda cho Action
            Action<int> thongbao = (int vl) => {
                Console.WriteLine(vl);
            };

            int kq1 = tinhtong1(5, 3); // kq1 = 8
            int kq2 = tinhtong1(5, 5); // kq2 = 10
            thongbao(kq1); // In ra: 8
            thongbao(kq2); // In ra: 10

        }
    }
}