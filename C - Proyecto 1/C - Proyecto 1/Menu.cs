using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C___Proyecto_1
{
    class Menu
    {

        public static string[] MenuString = new string[]
        {
            "IT Company(ALL DATA INFORMATION).",
            "Update developer working hour and activity(Programmer in charge).",
            "Update Project Team.",
            "Exit.",

        };

        public static void MenuOpt(string[] menuValue, int cnt)
        {
            int mTarget = 0;
            int mIndex = 0;
            Array.ForEach(menuValue, e =>
            {
                if (mIndex == cnt)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(e);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    mTarget = cnt + 1;
                }
                else
                {
                    Console.CursorLeft = 0;

                    Console.WriteLine(e);
                }
                mIndex++;

            });
            //return mTarget;
        }

        public static int MenuMove( int cont)
        {
            int  menuValue;
            var y = Console.CursorTop;
            int cnt = cont;
            ConsoleKeyInfo keyValue;


            while ((keyValue = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                switch (keyValue.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (cnt < Menu.MenuString.Length - 1)
                            cnt++;

                        break;
                    case ConsoleKey.UpArrow:
                        if (cnt == 0) continue;
                        cnt--;
                        break;
                }
                Console.CursorTop = y;

               Menu.MenuOpt(Menu.MenuString, cnt);
               
            }
            return cnt +1;
        }

        public static void MenuSelect(int cnt)
        {
            switch (cnt)
            {
                case 1:
                    Console.Clear();
                    Menu_Funtions.ItCompany();
                    break;
                case 2:
                    Console.Clear();
                    Menu_Funtions.Update_working_hour_activity();
                    break;
                case 3:
                    Console.Clear();
                    Menu_Funtions.ProjectTeam();
                    break;
                case 4:
                    Console.Clear();
                    Menu_Funtions.Exit();
                    break;
            }
        }
    }
}
