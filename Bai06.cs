using System;

namespace BTH1_Bai06
{
    class Program
    {
        static Random random = new Random();

        // a. Xuất ma trận
        static void XuatMaTran(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }
        }

        // b. Tìm phần tử lớn nhất
        static int TimPhanTuMax(int[,] a)
        {
            int maxn = int.MinValue;
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] > maxn)
                        maxn = a[i, j];
            return maxn;
        }

        // b. Tìm phần tử nhỏ nhất
        static int TimPhanTuMin(int[,] a)
        {
            int minn = int.MaxValue;
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] < minn)
                        minn = a[i, j];
            return minn;
        }

        // c. Tìm dòng có tổng lớn nhất
        static int TimDongCoTongMax(int[,] a)
        {
            int maxsum = int.MinValue;
            int row = 0;
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                    sum += a[i, j];
                if (sum > maxsum)
                {
                    maxsum = sum;
                    row = i;
                }
            }
            return row + 1;
        }

        // d. Kiểm tra số nguyên tố
        static bool SNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        // d. Tổng các số không phải nguyên tố
        static int TongKoNguyenTo(int[,] a)
        {
            int sum = 0;
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (!SNT(a[i, j]))
                        sum += a[i, j];
            return sum;
        }

        // e. Xóa dòng thứ k
        static int[,] XoaDong(int[,] a, int k)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            if (k < 0 || k >= n) return a;
            int[,] b = new int[n - 1, m];
            int x = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                    b[x, j] = a[i, j];
                x++;
            }
            return b;
        }

        // f. Xóa cột chứa phần tử lớn nhất
        static int[,] XoaCotMax(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int cot = -1;
            int phatumax = TimPhanTuMax(a);
            for (int i = 0; i < n && cot == -1; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] == phatumax)
                    {
                        cot = j;
                        break;
                    }

            if (cot == -1) return a;

            int[,] b = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                int x = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == cot) continue;
                    b[i, x++] = a[i, j];
                }
            }
            return b;
        }

        static void Main()
        {
            Console.Write("Nhap so dong n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine());

            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = random.Next(-100, 100);

            Console.WriteLine("\n--- MA TRAN BAN DAU ---");
            XuatMaTran(a);

            Console.WriteLine("\n====== MENU ======");
            Console.WriteLine("1. Xuat ma tran");
            Console.WriteLine("2. Tim phan tu lon nhat, nho nhat");
            Console.WriteLine("3. Tim dong co tong lon nhat");
            Console.WriteLine("4. Tinh tong cac so khong phai la so nguyen to");
            Console.WriteLine("5. Xoa dong thu k");
            Console.WriteLine("6. Xoa cot chua phan tu lon nhat");
            Console.Write("Nhap lua chon: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nMa tran:");
                    XuatMaTran(a);
                    break;

                case 2:
                    Console.WriteLine($"Phan tu lon nhat: {TimPhanTuMax(a)}");
                    Console.WriteLine($"Phan tu nho nhat: {TimPhanTuMin(a)}");
                    break;

                case 3:
                    Console.WriteLine("Dong co tong lon nhat la: " + TimDongCoTongMax(a));
                    break;

                case 4:
                    Console.WriteLine("Tong cac so khong phai la so nguyen to: " + TongKoNguyenTo(a));
                    break;

                case 5:
                    Console.Write("Nhap dong muon xoa (1 -> " + a.GetLength(0) + "): ");
                    int k = int.Parse(Console.ReadLine());
                    a = XoaDong(a, k - 1);
                    Console.WriteLine("Ma tran sau khi xoa dong:");
                    XuatMaTran(a);
                    break;

                case 6:
                    a = XoaCotMax(a);
                    Console.WriteLine("Ma tran sau khi xoa cot chua phan tu lon nhat:");
                    XuatMaTran(a);
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }

            Console.WriteLine("\nChuong trinh ket thuc!");
        }
    }
}
