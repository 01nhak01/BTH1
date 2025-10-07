using System;

namespace BTH1_Bai1
{
    class Program
    {
        // Kiểm tra số nguyên tố
        static bool SNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        // Kiểm tra số chính phương
        static bool SCP(int n)
        {
            if (n < 0) return false;
            int a = (int)Math.Sqrt(n);
            return a * a == n;
        }

        // a. Tính tổng các số lẻ
        static int SumSoLe(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                    sum += arr[i];
            }
            return sum;
        }

        // b. Đếm số nguyên tố
        static int DemSNT(int[] arr)
        {
            int dem = 0;
            for (int i = 0; i < arr.Length; i++)
                if (SNT(arr[i])) dem++;
            return dem;
        }

        // c. Tìm số chính phương nhỏ nhất
        static int TimSoChinhPhuong(int[] arr)
        {
            int minn = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (SCP(arr[i]) && arr[i] < minn)
                    minn = arr[i];
            }
            if (minn == int.MaxValue)
                return -1;
            else
                return minn;
        }

        static void Main()
        {
            // Nhập n và tạo mảng ngẫu nhiên
            Console.Write("Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(-1001, 1001);
            }

            // Xuất mảng ngẫu nhiên
            Console.WriteLine("Mang ngau nhien:");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();

            // Menu lựa chọn
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Tinh tong cac so le");
            Console.WriteLine("2. Dem so nguyen to");
            Console.WriteLine("3. Tim so chinh phuong nho nhat");
            Console.Write("Moi ban chon chuc nang (1-3): ");
            int choice = int.Parse(Console.ReadLine());

            // Thực hiện chức năng theo lựa chọn
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Tong cac so le: " + SumSoLe(arr));
                    break;
                case 2:
                    Console.WriteLine("So luong so nguyen to: " + DemSNT(arr));
                    break;
                case 3:
                    int kq = TimSoChinhPhuong(arr);
                    if (kq == -1)
                        Console.WriteLine(kq);
                    else
                        Console.WriteLine("So chinh phuong nho nhat: " + kq);
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }

            Console.WriteLine("\nChuong trinh ket thuc.");
        }
    }
}
