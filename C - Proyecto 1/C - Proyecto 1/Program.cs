using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace C___Proyecto_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuLoop = true;
            int cnt = 0;
            int menuValue;
            ConsoleKeyInfo keyValue;
            Console.CursorVisible = true;
            Console.WriteLine("select an option:" + System.Environment.NewLine);
           var x = Console.CursorLeft;
           var y = Console.CursorTop;

            //string pathRoot = Directory.GetCurrentDirectory();
            //string path = pathRoot + @"it_company_data.txt";
            //var fileExist =!File.Exists(path);
            Project_Team.initialize();

            Menu.MenuOpt(Menu.MenuString, cnt);
            Console.CursorTop = y;

            
            cnt = Menu.MenuMove(cnt);
            Menu.MenuSelect(cnt);
            //var jsondata = Project_Team.GetJson();


            //Menu_Funtions.ItCompanyText(jsondata);
         





            Project_Team.GetJson();
        }
    }
}





//while ((keyValue = Console.ReadKey(true)).Key != ConsoleKey.Enter)
//{
//    switch (keyValue.Key)
//    {
//        case ConsoleKey.DownArrow:
//            if (cnt < Menu.MenuString.Length-1)
//                cnt++;

//            break;
//        case ConsoleKey.UpArrow:
//            if (cnt == 0) continue;
//            cnt--;
//            break;
//    }
//    Console.CursorTop = y;

//    menuValue = Menu.MenuOpt(Menu.MenuString , cnt);
//    Console.WriteLine(menuValue);
//}