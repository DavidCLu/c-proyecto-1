using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C___Proyecto_1
{
    class Menu_Funtions
    {



        public static void ItCompany()
        {
            Console.WriteLine("IT Company ,\n");
            var jsondata = Project_Team.GetJson();
            Menu_Funtions.ItCompanyText(jsondata);
            TurnBack();
        }
       
       
        public static void Update_working_hour_activity()
        {
            Console.WriteLine("Update working days and activity.");

            /*Write developer name*/

            string updateDevepHour=""; 
            bool devepInput = false;
            int newTime=0;
            var activity = "None";
            Console.WriteLine("\n Choose which developer you want to upgrade to:\n " +
                                  "David, Mariam, Nerea, Marta, Jose, Maite, All or None\n");
            while (devepInput == false)
            {
                updateDevepHour = Console.ReadLine().ToString();

                if(updateDevepHour == "David" || updateDevepHour == "Mariam" || updateDevepHour == "Nerea" ||
                   updateDevepHour == "Marta" || updateDevepHour == "Jose" || updateDevepHour == "Maite" || 
                   updateDevepHour == "All"   || updateDevepHour == "None") 
                {
                    devepInput = true;
                }
                else
                {
                    Console.WriteLine("\n Wrong name!! \n Choose which developer you want to upgrade to:\n " +
                                      "David, Mariam, Nerea, Marta, Jose, Maite, All or None\n");
                }
            }

            if (updateDevepHour != "None")
            {
                /*Write developer new hour*/
                Console.WriteLine($"\n Add how many days {updateDevepHour} will work !! \n " +
                                  "Write a number for add days, Add '-'(Number)  for subtract days, write '0' for don't change days. \n");

                
                while (!int.TryParse(Console.ReadLine(), out newTime))
                {
                    Console.Write("Error. Enter number!! \n");
                }

                /*Developer Activity*/

                Console.WriteLine("\n Assign new activity, or writte 'None' for dont change. \n");
                activity = Console.ReadLine().ToString();
                Console.WriteLine("\n");
            }


            /*Update json*/
            var jsondata = Project_Team.GetJson();
            Project_Team.UpdateDataJson(updateDevepHour, newTime, jsondata, activity, 0, "None");


            TurnBack();
        }
        
        
        public static void ProjectTeam()
        {
            Console.WriteLine("Project Team");

            Console.WriteLine("Choose the proyect: 1 or 2, 0 for dont change");
            int project = 0;
            var projectLoop = false;
            string project_type="";
            while (projectLoop == false)
            {
                while (!int.TryParse(Console.ReadLine() , out project))
                {
                    Console.WriteLine("Choose the proyect: 1 or 2, 0 for dont change");
                }
                if (project == 1 || project == 2 || project == 0) projectLoop = true;
            }
            if(project != 0)
            {
                Console.WriteLine("Choose a new proyect name");
                project_type = Console.ReadLine();
            }


            var jsondata = Project_Team.GetJson();
            Project_Team.UpdateDataJson("None", 0, jsondata, "None" , project, project_type);

            TurnBack();
        }
       
        public static void Exit()
        {

        }
        


        public static void ItCompanyText(List<Project_Team>  jsondata)
        {

            var data = jsondata;
            var inCharge = data[0].programmer_in_charge;
            var employees1 = data[0].programmer_in_charge[0].EmployeesList[0];
            var employees2 = data[0].programmer_in_charge[1].EmployeesList[0];

            var inCharge50 = data[1].programmer_in_charge;
            var employees50 = data[1].programmer_in_charge[0].EmployeesList[0];
            var totalHourThisMooth = 
                            (inCharge[0].time- Int32.Parse(inCharge[0].nextMoothDays))+ (inCharge[1].time- Int32.Parse(inCharge[1].nextMoothDays)) + 
                            (employees1.time - Int32.Parse(employees1.nextMoothDays)) +   (employees2.time - Int32.Parse(employees2.nextMoothDays))+ 
                            (inCharge50[0].time - Int32.Parse(inCharge50[0].nextMoothDays)) + (employees50.time - Int32.Parse(employees50.nextMoothDays));
            var totalHourRest = (inCharge[0].time + inCharge[1].time + employees1.time + employees2.time + inCharge50[0].time + employees50.time) - totalHourThisMooth;

            var a = 
            $"IT COMPANY  - Report \n\n" +

                //$"nx = variable(like Integer) \n\n" +
                $"IT Company is actually composed of {data.Count} project teams, and {data[0].NumProgrammers + data[1].NumProgrammers } programmers. \n\n" +
                $"this month, {totalHourThisMooth} days have been consummed by {data[0].NumProgrammers + data[1].NumProgrammers } programmers, and {totalHourRest} days still in charge. \n\n" +
                $"Project teams details: \n\n" +

                $"Project team - {data[0].Project_type}: \n\n" +
                $" -{inCharge[0].lastName}, {inCharge[0].name},in  charge of {inCharge[0].activity} from {inCharge[0].periodInit} to {inCharge[0].periodEnd}(duration {inCharge[0].time}), this month: {inCharge[0].time - Int32.Parse(inCharge[0].nextMoothDays)} days(total cost = {inCharge[0].cost} $)\n" +
                $" -{inCharge[1].lastName}, {inCharge[1].name},in  charge of {inCharge[1].activity} from {inCharge[1].periodInit} to {inCharge[1].periodEnd}(duration {inCharge[1].time}), this month: {inCharge[1].time - Int32.Parse(inCharge[1].nextMoothDays)} days(total cost = {inCharge[1].cost} $)\n" +
                $" -{employees1.lastName}, {employees1.name}, in  charge of {employees1.activity} from {employees1.periodInit} to {employees2.periodEnd}(duration {employees1.time}), this month: {employees1.time - Int32.Parse(employees1.nextMoothDays)} days(total cost = {employees1.cost} $)\n" +
                $" -{employees2.lastName}, {employees2.name}, in  charge of {employees2.activity} from {employees2.periodInit} to {employees2.periodEnd}(duration {employees2.time}), this month: {employees2.time - Int32.Parse(employees2.nextMoothDays)} days(total cost = {employees2.cost} $)\n\n" +

                $"Project team - {data[1].Project_type}: \n\n" +

                $" -{inCharge50[0].lastName}, {inCharge50[0].name}, in  charge of {inCharge50[0].activity} from {inCharge50[0].periodInit} to {inCharge50[0].periodEnd}(duration {inCharge50[0].time}), this month: {inCharge50[0].time - Int32.Parse(inCharge50[0].nextMoothDays)} days(total cost = {inCharge50[0].cost} $)\n" +
                $" -{employees50.lastName}, {employees50.name}, in  charge of {employees50.activity} from {employees50.periodInit} to {employees50.periodEnd}(duration {employees50.time}), this month: {employees50.time - Int32.Parse(employees50.nextMoothDays)} days(total cost = {employees50.cost} $)\n";


            Console.WriteLine(a+"\n \n");
        }


        public static void TurnBack()
        {
            var y = Console.CursorTop;
            ConsoleKeyInfo keyValue;
            int cnt;

            Console.WriteLine("<-------Enter for turn back to Menu------->");


            while ((keyValue = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                Console.WriteLine("<-------Enter for turn back to Menu------->");
            }

            Console.Clear();
            y = 0;
            Menu.MenuOpt(Menu.MenuString, 0);
            Console.CursorTop = y;
            cnt = Menu.MenuMove(0);
            Menu.MenuSelect(cnt);    
        }

    }
}




