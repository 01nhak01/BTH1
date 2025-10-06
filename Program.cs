using System;
namespace BTH1_Bai2
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
        static void Main()
        {
            //Nhap so nguyen duong n
            Console.Write("Nhap so nguyen duong n: ");
            int n = int.Parse(Console.ReadLine());
            //Tính tổng số nguyên tố < n
            int sum = 0;
            for (int i = 2; i < n; i++)
                if (SNT(i) == true) sum += i;
            //In kết quả
            Console.WriteLine("Tong cac so nguyen to < n la: " + sum);
        }
    }
}