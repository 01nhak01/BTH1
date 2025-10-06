using System;
namespace BTH1_Bai06
{
    class Program
    {
        static Random random = new Random();
        // a.Xuat ma tran
        static void XuatMaTran(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }
        // b.Tim phan tu lon nhat, phan tu nho nhat
        static int TimPhanTuMax(int[,] a)
        {
            int maxn = int.MinValue; //Gán maxn bằng giá trị nhỏ nhất để so sánh.
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] > maxn)
                        maxn = a[i, j];
                }
            }
            return maxn;
        }
        static int TimPhanTuMin(int[,] a)
        {
            int minn = int.MaxValue; //Gán minn bằng giá trị lớn nhất để so sánh.
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] < minn)
                        minn = a[i, j];
                }
            }
            return minn;
        }
        // c.Tim dong co tong lon nhat
        static int TimDongCoTongMax(int[,] a)
        {
            int maxsum = int.MinValue;//Gán maxsum = giá trị nhỏ nhất
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
                    maxsum = sum;//So sánh các tổng rồi gán lại vào maxsum.
                    row = i;
                }
            }
            return row + 1;
        }
        // d.Tong cac so khong phai la snt
        //Kiểm tra số nguyên tố
        static bool SNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i < n; i++)
                if (n % i == 0) return false;
            return true;
        }
        static int TongKoNguyenTo(int[,] a)
        {
            int sum = 0;
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (SNT(a[i, j]) == false)
                        sum += a[i, j];
                }
            }
            return sum;
        }
        // e.Xoa dong thu k
        static int[,] Xoa(int[,] a, int k)
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
        // f.Xoa cot chua phan tu lon nhat
        static int[,] XoaCot(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int cot = -1;
            int phatumax = TimPhanTuMax(a);//Đã có hàm tìm phẩn tử lớn nhất ở câu b.
            //Xác định cột có phần tử lớn nhất
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] == phatumax)
                    {
                        cot = j;
                        break;
                    }
                }
                if (cot != -1) break;
            }
            if (cot == -1) return a; //Nếu không tìm thấy trả về ma trận cũ
            //Tạo ma trận mới có ít hơn 1 cột
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
            //Nhập xuất n dòng.
            Console.Write("Nhap so dong n: ");
            int n = int.Parse(Console.ReadLine());
            //Nhập xuất m cột
            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine());
            //Tạo mảng random
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = random.Next(-100, 100);
            //In ra ma trận vừa tạo
            Console.WriteLine("Ma tran:");
            XuatMaTran(a);
            //In ra phần tử lớn nhất
            Console.WriteLine("Phan tu lon nhat trong mang: " + TimPhanTuMax(a));
            //In ra phần tử nhỏ nhất
            Console.WriteLine("Phan tu nho nhat trong mang: " + TimPhanTuMin(a));
            //In ra dòng có tổng lớn nhất
            Console.WriteLine("Dong co tong lon nhat: " + TimDongCoTongMax(a));
            //In ra tổng không nguyên tố
            Console.WriteLine("Tong cac so khong phai nguyen to: " + TongKoNguyenTo(a));
            //Nhập xuất dòng cần xóa
            Console.Write("Nhap dong muon xoa: ");
            int k = int.Parse(Console.ReadLine());
            a = Xoa(a, k - 1);
            //In ra ma trận sau khi xóa dòng thứ k
            Console.WriteLine("Ma tran sau khi xoa: ");
            XuatMaTran(a);
            //In ra ma trận sau khi xóa cột chứa phần tử lớn nhất
            a = XoaCot(a);
            Console.WriteLine("Ma tran sau khi xoa cot chua phan tu lon nhat: ");
            XuatMaTran(a);
        }
    }
}
