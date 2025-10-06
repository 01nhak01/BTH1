using System;
namespace BTH1_Bai05
{
    class Program
    {
        //Kiểm tra năm nhuận
        public static bool CheckNamNhuan(int year)
        {
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }
        //Kiểm tra ngày tháng năm có hợp lệ hay không.
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
        //Tìm thứ trong tuần
        static string CheckThu(int year, int month, int day)
        {
            //Điểu chỉnh lại tháng 1 và tháng 2 theo công thức Zeller
            if (month == 1)
            {
                month = 13;
                year--;
            }
            else if (month == 2)
            {
                month = 14;
                year--;
            }
            int q = day;
            int m = month;
            int k = year % 100;//Số năm trong thế kỷ (lấy phần dư của năm)
            int j = year / 100;//Số thế kỷ (lấy phần nguyên của năm)
            //Công thức Zeller
            int h = (q + (13 * (m + 1)) / 5 + k + k / 4 + j / 4 + 5 * j) % 7;
            string thu;
            //Dùng switch để xác định thứ trong tuần.
            switch (h)
            {
                case 0:
                    thu = "thu bay";
                    break;
                case 1:
                    thu = "chu nhat";
                    break;
                case 2:
                    thu = "thu hai";
                    break;
                case 3:
                    thu = "thu ba";
                    break;
                case 4:
                    thu = "thu tu";
                    break;
                case 5:
                    thu = "thu nam";
                    break;
                case 6:
                    thu = "thu sau";
                    break;
                default:
                    thu = "khong xac dinh";
                    break;
            }
            return thu;
        }
        static void Main()
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
            //Output: in thứ trong tuần
            if (Check(year, month, day) == true)
                Console.WriteLine($"Ngay {day}/{month}/{year} la {CheckThu(year, month, day)}");
            else Console.WriteLine("Khong hop le!!");
        }
    }
}
