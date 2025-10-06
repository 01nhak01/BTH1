using System;
namespace BTH1_Bai4
{
    class Program
    {
        //Kiểm tra năm nhuận
        static bool NamNhuan(int year)
        {
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }
        //Xử lý tháng đó có bao nhiêu ngày (dùng switch)
        static int SoNgayTrongThang(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return NamNhuan(year) ? 29 : 28;
                default:
                    return -1;
            }
        }
        static void Main()
        {
            //Nhập xuất tháng.
            Console.Write("Nhap thang: ");
            int month = int.Parse(Console.ReadLine());
            //Nhập xuất năm.
            Console.Write("Nhap nam: ");
            int year = int.Parse(Console.ReadLine());
            //Gán số ngày của tháng năm đó
            int days = SoNgayTrongThang(month, year);
            //Output số ngày của tháng năm đó
            if (days == -1)
                Console.WriteLine("Khong hop le!");
            else
                Console.WriteLine($"Thang {month}/{year} co {days} ngay.");
        }
    }
}
