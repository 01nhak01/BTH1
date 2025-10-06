using System;
namespace BTH1_Bai1
{
    class Program
    {
        //Kiểm tra số nguyên tố
        static bool SNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }
        //Kiểm tra số chính phương
        static bool SCP(int n)
        {
            if (n < 0) return false;
            int a = (int)Math.Sqrt(n);
            return a * a == n;
        }
        // a. Tinh tong cac so le 
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
        // b. Dem so nguyen to
        static int DemSNT(int[] arr)
        {
            int dem = 0;
            for (int i = 0; i < arr.Length; i++)
                if (SNT(arr[i]) == true) dem++;
            return dem;
        }
        // c.Tim so chinh phuong nho nhat
        static int TimSoChinhPhuong(int[] arr)
        {
            int minn = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (SCP(arr[i]) == true && arr[i] < minn)
                    minn = arr[i];
            }
            if (minn == int.MaxValue)
                return -1;
            else return minn;
        }
        static void Main()
        {
            //Nhập n và tạo mảng
            Console.Write("Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(-1001, 1001);
            }
            //Xuất mảng ngẫu nhiên
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
            //Tổng các số lẻ
            Console.WriteLine("Tong cac so le: " + SumSoLe(arr));
            //Số lượng số nguyên tố
            Console.WriteLine("So luong so nguyen to: " + DemSNT(arr));
            //Số chính phương
            Console.WriteLine("So chinh phuong nho nhat: " + TimSoChinhPhuong(arr));
        }
    }
}
