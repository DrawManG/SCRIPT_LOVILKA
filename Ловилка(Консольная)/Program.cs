using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ловилка_Консольная_
{
    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public Int32 X;
            public Int32 Y;
            public Int32 Width;
            public Int32 Height;
        }



        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr WindowFromPoint(Point point);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, Point point);
        /// <summary>
        /// По дискриптору возвращает название окна
        /// </summary>
        /// <param name="hWnd">Дискриптор окна</param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern Int32 GetWindowText(IntPtr hWnd, StringBuilder lpString, Int32 nMaxCount);
        /// <summary>
        /// Получить информацию об окне со следующим заголовком
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll", SetLastError = true)]
       

        static extern Int32 GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        static string GetWindowText(IntPtr hWnd)
        {
            int len = GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(len);
            len = GetWindowText(hWnd, sb, len);
            return sb.ToString(0, len);
        }

        /// <summary>
        /// API для ролучения позиции курсора
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>

        [DllImport("user32.dll")]
        static extern Boolean GetCursorPos(out Point lpPoint);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

      
           

            static void Main()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            Thread.Sleep(2000);
            do
            {
                Thread.Sleep(3000);
                Point lpPoint;
                SetCursorPos(962, 542);
                GetCursorPos(out lpPoint);
                SetCursorPos(962, 542);
                IntPtr hWnd = WindowFromPoint(lpPoint);
                var hWnd1 = ChildWindowFromPoint(hWnd, lpPoint);
                Console.WriteLine("{1}", hWnd, GetWindowText(hWnd));
                string cc = GetWindowText(hWnd);
                SetCursorPos(962, 542);
                if (cc == "РК статика")
                {

                    System.Diagnostics.Process.Start("https://api.telegram.org/bot1093127317:AAHpR6rK4yNphDZriruKdbIQUCtcyVDZccc/sendMessage?chat_id=-1001220049143&text=Вылезло%20сообщение%20на%20резонансной%20колонке");
                    Environment.Exit(0);
                }
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.F6)
                {
                    Environment.Exit(0);
                }
            } while (true);
            Console.ReadLine();
            
        }

    }
}