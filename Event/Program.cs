using System;
namespace MyEvent
{
    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(string data)
        {
            this.data = data;
        }
        // Lưu dữ liệu gửi đi từ publisher
        private string data;

        public string Data
        {
            get { return data; }
        }
    }

    // Xây dựng lớp, phát đi sự kiện (data)
    public class ClassA
    {
        // Tạo Event với EventHandler
        public event EventHandler<MyEventArgs> event_news;

        public void Send(string s)
        {
            event_news?.Invoke(this, new MyEventArgs(s));
        }
    }

    public class ClassB
    {
        public void Sub(ClassA p)
        {
            p.event_news += ReceiverFromPublisher;
        }

        private void ReceiverFromPublisher(object? sender, MyEventArgs e)
        {
            Console.WriteLine("ClassB: " + e.Data);
        }

    }


    public class ClassC
    {
        public void Sub(ClassA p)
        {
            p.event_news += ReceiverFromPublisher;
        }

        private void ReceiverFromPublisher(object? sender, MyEventArgs e)
        {
            Console.WriteLine("ClassC: " + e.Data);
        }
    }

    class Program
    {
        static void TestEventHandler()
        {
            ClassA p = new ClassA();
            ClassB sa = new ClassB();
            ClassC sb = new ClassC();

            sa.Sub(p); // sa đăng ký nhận sự kiện từ p
            sb.Sub(p); // sb đăng ký nhận sự kiện từ p
            Console.WriteLine("Da dang ky");
            p.Send("Test");
        }
        static void Main(string[] args)
        {
            TestEventHandler();
        }
    }
}