namespace MyLinq
{
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // các màu sắc
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }



    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }

    public class Products
    {
        // In ra các sản phẩm có giá 400
        public static void ProductPrice400(List<Product> products, List<Brand> brands)
        {
            var ketqua = from product in products
                         join brand in brands on product.Brand equals brand.ID
                         select new
                         {
                             name = product.Name,
                             brand = brand.Name,
                             price = product.Price
                         };

            foreach (var item in ketqua)
            {
                Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
            }

        }
    }

    class Program
    {
        static List<Brand> brands = new List<Brand>() {
            new Brand{ID = 1, Name = "Cong ty AAA"},
            new Brand{ID = 2, Name = "Cong ty BBB"},
            new Brand{ID = 4, Name = "Cong ty CCC"},
        };

        static List<Product> products = new List<Product>()
        {
            new Product(1, "Ban tra",    400, new string[] {"Xam", "Xanh"},         2),
            new Product(2, "Tranh treo", 400, new string[] {"Vang", "Xanh"},        1),
            new Product(3, "Den trum",   500, new string[] {"Trang"},               3),
            new Product(4, "Ban hoc",    200, new string[] {"Trang", "Xanh"},       1),
            new Product(5, "Tui da",     300, new string[] {"Đo", "Den", "Vang"},   2),
            new Product(6, "Giuong ngu", 500, new string[] {"Trang"},               2),
            new Product(7, "Tu ao",      600, new string[] {"Trang" },               3),
        };

        static void Main(string[] args)
        {
            Products.ProductPrice400(products,brands);
        }

    }
}