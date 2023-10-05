using System;
using static mydelegate.Logs;

namespace mydelegate
{
    public class Logs
    {
        // Khai báo một delegate
        public delegate void ShowLog(string message);

        static public void Normal(string s)
        {
            Console.ResetColor();
            Console.WriteLine(string.Format("{0}", s));
            Console.ResetColor();
        }

        // Phương thức tương đồng với ShowLog (tham số, kiểu trả về)
        static public void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Info: {0}", s));
            Console.ResetColor();
        }

        // Phương thức tương đồng với ShowLog (tham số, kiểu trả về)
        static public void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("Waring: {0}", s));
            Console.ResetColor();
        }

        public static void TestShowLog()
        {
            ShowLog showLog;

            showLog = Info;         // showLog gán bằng phương thức Info
            showLog("Thông báo");   // Thi hành delegate chính là thi hành Info

            showLog = Warning;      // showLog gán bằng phương thức Warning
            showLog("Thông báo");   // Thi hành delegate chính là thi hành Info
        }
        public static void TestShowLogMulti()
        {
            ShowLog showLog;

            showLog = null;
            showLog += Warning;         // Nối thêm Warning vào delegate
            showLog += Info;            // Nối thêm Info vào delegate
            showLog += Warning;         // Nối thêm Warning vào delegate

            //Một lần gọi thi hành tất cả các phương thức trong chuỗi delegate
            showLog("TestLog");         //Hoặc an toàn: showLog?.Invoke("TestLog");
        }

        public static void TestAction(string s)
        {
            Action<string> showLog = null;

            showLog += Logs.Warning;         // Nối thêm Warning vào delegate
            showLog += Logs.Info;            // Nối thêm Info vào delegate
            showLog += Logs.Warning;         // Nối thêm Warning vào delegate

            // Một lần gọi thi hành tất cả các phương thức trong chuỗi delegate
            showLog(s);
        }

        static void TinhTong(int a, int b, Action<string> callback)
        {
            int c = a + b;
            // Gọi callback
            callback(c.ToString());
        }

        public static void TestTinhTong()
        {
            TinhTong(5, 6, (x) => Console.WriteLine($"Tổng hai số là: {x}"));
            TinhTong(1, 3, Logs.Info);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logs.TestTinhTong();
        }
    }
}
