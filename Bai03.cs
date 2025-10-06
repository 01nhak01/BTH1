using System;
namespace BTH1_Bai3
{
    class Program
    {
        //Kiểm tra năm nhuận
        public static bool CheckNamNhuan(int year)
        {
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }
        //Kiểm tra ngày tháng đó có hợp lệ hay không
        public static bool Check(int year, int month, int day)
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
                return false;
            int days;
            //Dùng switch để xử lý tháng đó có bao nhiêu ngày
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    days = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;
                case 2:
                    if (CheckNamNhuan(year))
                        days = 29;
                    else days = 28;
                    break;
                default:
                    return false;
            }
            return day <= days;
        }
        static void Main(string[] args)
        {
            //Nhập xuất ngày
            Console.Write("Nhap ngay: ");
            int day = int.Parse(Console.ReadLine());
            //Nhập xuất tháng
            Console.Write("Nhap thang: ");
            int month = int.Parse(Console.ReadLine());
            //Nhập xuất năm
            Console.Write("Nhap nam: ");
            int year = int.Parse(Console.ReadLine());
            //Xuất ngày tháng có hợp lệ hay không
            if (Check(year, month, day) == true)
                Console.WriteLine("Hop le!!");
            else Console.WriteLine("Khong hop le!!");
        }
    }
}
