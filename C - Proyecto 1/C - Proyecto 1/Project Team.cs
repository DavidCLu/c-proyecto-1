using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C___Proyecto_1
{
    public  class  Project_Team
    {
        public string Project_type ;
        public int NumProgrammers;

        public List<Programmer_in_charge>  programmer_in_charge;



        public static void initialize()
        {
            string pathRoot = Directory.GetCurrentDirectory();

            string path = pathRoot + @"it_company_data.txt";

            var date1 = new DateTime(2023, 1, 10);
            var date2 = new DateTime(2023, 1, 10);
            var date3 = new DateTime(2023, 1, 5);
            var date4 = new DateTime(2023, 1, 5);
            var date5 = new DateTime(2023, 1, 20);
            var date6 = new DateTime(2023, 1, 20);

                int workTimeDavid  = 25;
                int workTimeMarian = 22;
                int workTimeNerea  = 30;
                int workTimeMarta  = 28;
                int workTimeJose   = 15;
                int workTimeMaite  = 15;
            
            /*add days*/


            if (!File.Exists(path))
            {

                List<Project_Team> project_Team = new List<Project_Team>
                {
                        new Project_Team
                        {
                            Project_type = " Project 100% Web Development",
                            NumProgrammers = 4,
                            programmer_in_charge = new List<Programmer_in_charge>
                            {
                                new Programmer_in_charge
                                {
                                    name = "David",
                                    lastName = "Consta",
                                    activity = "Scrum Master",
                                    category = "Programmer_in_charge",
                                    time = workTimeDavid,
                                    periodInit =  $"{date1.ToString("yyyy/MM/dd")}",
                                    periodEnd =  $"{date1.AddDays(workTimeDavid).ToString("yyyy/MM/dd")}" ,
                                    nextMoothDays =  date1.AddDays(workTimeDavid).ToString("dd"),
                                    cost= 800,
                                    EmployeesList = new List<Employees>
                                    {
                                        new Employees
                                        {
                                            name = "Marian",
                                            lastName="Lopez",
                                            activity = "full stack",
                                            category = "Employees",
                                            time = workTimeMarian,
                                            periodInit= $"{date2.ToString("yyyy/MM/dd")}",
                                            periodEnd = $"{ date2.AddDays(workTimeMarian).ToString("yyyy/MM/dd")}",
                                            nextMoothDays =  date2.AddDays(workTimeMarian).ToString("dd"),
                                            cost = 400,
                                        },
                                    },

                                },
                                new Programmer_in_charge
                                {
                                    name = "Nerea",
                                    lastName="Martin",
                                    activity = "Scrum Master",
                                    category = "Programmer_in_charge",
                                    time = workTimeNerea,
                                    periodInit = $"{date3.ToString("yyyy/MM/dd")} ",
                                    periodEnd =  $"{date3.AddDays(workTimeNerea).ToString("yyyy/MM/dd")}" ,
                                    nextMoothDays =  date3.AddDays(workTimeNerea).ToString("dd"),
                                    cost= 500,
                                    EmployeesList = new List<Employees>
                                    {
                                        new Employees
                                        {
                                            name = "Marta",
                                            lastName ="Gonzalez",
                                            activity = "full stack",
                                            category = "Employees",
                                            time = workTimeMarta,
                                            periodInit = $"{date4.ToString("yyyy/MM/dd")}",
                                            periodEnd =  $"{ date4.AddDays(workTimeMarta).ToString("yyyy/MM/dd")}",
                                            nextMoothDays =  date4.AddDays(workTimeMarta).ToString("dd"),
                                            cost =250,
                                        },
                                    }
                                }
                            },
                        }, 
                        new Project_Team
                        {
                            Project_type = " Project 50% WB Design",
                            NumProgrammers = 2,
                            programmer_in_charge = new List<Programmer_in_charge>
                            {
                                new Programmer_in_charge
                                {
                                    name = "Jose",
                                    lastName = "Consta",
                                    activity = "Scrum Master",
                                    category = "Programmer_in_charge",
                                    time = workTimeJose,
                                    periodInit = $"{date5.ToString("yyyy/MM/dd")}"  ,
                                    periodEnd =  $"{ date5.AddDays(workTimeJose).ToString("yyyy/MM/dd")}",
                                    nextMoothDays =  date5.AddDays(workTimeJose).ToString("dd"),
                                    cost= 800,
                                    EmployeesList = new List<Employees>
                                    {
                                        new Employees
                                        {
                                            name = "Maite",
                                            lastName="Lopez",
                                            activity = "full stack",
                                            category = "Employees",
                                            time = workTimeMaite,
                                            periodInit = $"{date6.ToString("yyyy/MM/dd")}", 
                                            periodEnd = $"{ date6.AddDays(workTimeMaite).ToString("yyyy/MM/dd")}" ,
                                            nextMoothDays =  date6.AddDays(workTimeMaite).ToString("dd"),
                                            cost = 400,
                                        },
                                    },

                                },
                            }
                        }
                 };

                string json = JsonConvert.SerializeObject(project_Team.ToArray(), Formatting.Indented);
                File.WriteAllText(path, json);

            }

        }


        public static void UpdateDataJson( string updateHourTo, int newTime, List<Project_Team> jsondata, string activity,int project, string project_type)
        {

            string pathRoot = Directory.GetCurrentDirectory();
            string path = pathRoot + @"it_company_data.txt";
            var fileExist = File.Exists(path);
            var data = jsondata;

            var project_type_100 = data[0].Project_type;
            var Project_type_50 = data[1].Project_type;

            var date1 = new DateTime(2023, 1, 10);
            var date2 = new DateTime(2023, 1, 10);
            var date3 = new DateTime(2023, 1, 5);
            var date4 = new DateTime(2023, 1, 5);
            var date5 = new DateTime(2023, 1, 20);
            var date6 = new DateTime(2023, 1, 20);

            
            int workTimeDavid =  data[0].programmer_in_charge[0].time;
            int workTimeMarian = data[0].programmer_in_charge[0].EmployeesList[0].time;
            int workTimeNerea =  data[0].programmer_in_charge[1].time;
            int workTimeMarta =  data[0].programmer_in_charge[1].EmployeesList[0].time;
            int workTimeJose =   data[1].programmer_in_charge[0].time;
            int workTimeMaite =  data[1].programmer_in_charge[0].EmployeesList[0].time;
            string activityDavid = data[0].programmer_in_charge[0].activity;
            string activityMarim = data[0].programmer_in_charge[0].EmployeesList[0].activity;
            string activityNerea = data[0].programmer_in_charge[1].activity;
            string activityMarta = data[0].programmer_in_charge[1].EmployeesList[0].activity;
            string activityJose =  data[1].programmer_in_charge[0].activity;
            string activityMaite = data[1].programmer_in_charge[0].EmployeesList[0].activity;

            if(project_type!= "None")
            {
                switch (project)
                {
                    case 0:
                        break;
                    case 1:
                        project_type_100 = project_type;
                        break;
                    case 2:
                        Project_type_50 = project_type;
                        break;
                }
            }
            /*add days and modify activity*/
            switch (updateHourTo)
            {
                case "None":
                    break;
                case "David":
                    workTimeDavid = workTimeDavid + newTime;
                    if (activity == "None") {}
                    else activityDavid = activity;
                    
                    break;
                case "Mariam":
                    workTimeMarian = workTimeMarian + newTime;
                    if (activity == "None") { }
                    else activityMarim = activity;
                    break;
                case "Nerea":
                    workTimeNerea = workTimeNerea + newTime;
                    if (activity == "None") { }
                   else activityNerea = activity;
                    break;
                case "Marta":
                    workTimeMarta = workTimeMarta + newTime;
                    if (activity == "None") { }
                    else activityMarta = activity;
                    break;
                case "Jose":
                    workTimeJose = workTimeJose + newTime;
                    if (activity == "None") { }
                    else activityJose = activity;
                    break;
                case "Maite":
                    workTimeMaite = workTimeMaite + newTime;
                    if (activity == "None") { }
                    else activityMaite = activity;
                    break;
                case "All":
                    workTimeDavid = workTimeDavid + newTime;
                    workTimeMarian = workTimeMarian + newTime;
                    workTimeNerea = workTimeNerea + newTime;
                    workTimeMarta = workTimeMarta + newTime;
                    workTimeJose = workTimeJose + newTime;
                    workTimeMaite = workTimeMaite + newTime;
                    break;
            }


            if (fileExist)
            {

                List<Project_Team> project_Team = new List<Project_Team>
                {
                        new Project_Team
                        {
                            Project_type = project_type_100,
                            NumProgrammers = 4,
                            programmer_in_charge = new List<Programmer_in_charge>
                            {
                                new Programmer_in_charge
                                {
                                    name = "David",
                                    lastName = "Consta",
                                    activity = activityDavid,
                                    category = "Programmer_in_charge",
                                    time = workTimeDavid,
                                    periodInit =  $"{date1.ToString("yyyy/MM/dd")}",
                                    periodEnd =  $"{date1.AddDays(workTimeDavid).ToString("yyyy/MM/dd")}" ,
                                    nextMoothDays =  date1.AddDays(workTimeDavid).ToString("dd"),
                                    cost= 800,
                                    EmployeesList = new List<Employees>
                                    {
                                        new Employees
                                        {
                                            name = "Marian",
                                            lastName="Lopez",
                                            activity = activityMarim,
                                            category = "Employees",
                                            time = workTimeMarian,
                                            periodInit= $"{date2.ToString("yyyy/MM/dd")}",
                                            periodEnd = $"{ date2.AddDays(workTimeMarian).ToString("yyyy/MM/dd")}",
                                            nextMoothDays =  date2.AddDays(workTimeMarian).ToString("dd"),
                                            cost = 400,
                                        },
                                    },

                                },
                                new Programmer_in_charge
                                {
                                    name = "Nerea",
                                    lastName="Martin",
                                    activity = activityNerea,
                                    category = "Programmer_in_charge",
                                    time = workTimeNerea,
                                    periodInit = $"{date3.ToString("yyyy/MM/dd")} ",
                                    periodEnd =  $"{date3.AddDays(workTimeNerea).ToString("yyyy/MM/dd")}" ,
                                    nextMoothDays =  date3.AddDays(workTimeNerea).ToString("dd"),
                                    cost= 500,
                                    EmployeesList = new List<Employees>
                                    {
                                        new Employees
                                        {
                                            name = "Marta",
                                            lastName ="Gonzalez",
                                            activity = activityMarta,
                                            category = "Employees",
                                            time = workTimeMarta,
                                            periodInit = $"{date4.ToString("yyyy/MM/dd")}",
                                            periodEnd =  $"{ date4.AddDays(workTimeMarta).ToString("yyyy/MM/dd")}",
                                            nextMoothDays =  date4.AddDays(workTimeMarta).ToString("dd"),
                                            cost =250,
                                        },
                                    }
                                }
                            },
                        },
                        new Project_Team
                        {
                            Project_type = Project_type_50,
                            NumProgrammers = 2,
                            programmer_in_charge = new List<Programmer_in_charge>
                            {
                                new Programmer_in_charge
                                {
                                    name = "Jose",
                                    lastName = "Consta",
                                    activity = activityJose,
                                    category = "Programmer_in_charge",
                                    time = workTimeJose,
                                    periodInit = $"{date5.ToString("yyyy/MM/dd")}"  ,
                                    periodEnd =  $"{ date5.AddDays(workTimeJose).ToString("yyyy/MM/dd")}",
                                    nextMoothDays =  date5.AddDays(workTimeJose).ToString("dd"),
                                    cost= 800,
                                    EmployeesList = new List<Employees>
                                    {
                                        new Employees
                                        {
                                            name = "Maite",
                                            lastName="Lopez",
                                            activity = activityMaite,
                                            category = "Employees",
                                            time = workTimeMaite,
                                            periodInit = $"{date6.ToString("yyyy/MM/dd")}",
                                            periodEnd = $"{ date6.AddDays(workTimeMaite).ToString("yyyy/MM/dd")}" ,
                                            nextMoothDays =  date6.AddDays(workTimeMaite).ToString("dd"),
                                            cost = 400,
                                        },
                                    },

                                },
                            }
                        }
                 };

                string json = JsonConvert.SerializeObject(project_Team.ToArray(), Formatting.Indented);
                File.WriteAllText(path, json);

            }

        }


        public static List<Project_Team>  GetJson()
        {
        string pathRoot = Directory.GetCurrentDirectory();
            string path = pathRoot + @"it_company_data.txt";

            string jsonFile;
            using (StreamReader reader = new StreamReader(path))
            {
                 jsonFile = reader.ReadToEnd();
            }
            var json = JsonConvert.DeserializeObject<List<Project_Team>>(jsonFile);

            return json;

        }

    }
}
