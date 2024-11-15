﻿using HW_12.Contracts;
using HW_12.Entities;
using HW_12.Enums;
using HW_12.Services;

IPlanService service = new PlanService();
IAuthentication auth = new Authentication();
bool end = false;
bool stop = false;

while (end == false)
{
    try
    { 
    int options = 0;
    Console.Clear();
    Console.WriteLine("1- Login");
    Console.WriteLine("2- Register");
    Console.WriteLine("3- Exit");
    options = Convert.ToInt32(Console.ReadLine());
    switch (options)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("please enter your username");
            string username=Console.ReadLine();
            Console.WriteLine("please enter your password");
            string password = Console.ReadLine();
            UserMenu(auth.Login(username,password));
            Console.ReadKey();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("please enter your username");
            string Username = Console.ReadLine();
            Console.WriteLine("please enter your password");
            string Password = Console.ReadLine();
            Console.WriteLine(auth.Register(Username,Password));
            Console.ReadKey();
            break;
        case 3:
            Console.Clear();
            end= true;
            Console.ReadKey();
            break;

    }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }

}






void UserMenu(User U)
{



    while (stop == false)
    {
        try
        {
            int option = 0;
            Console.Clear();
            Console.WriteLine("1- show all plans");
            Console.WriteLine("2- Add a new plan");
            Console.WriteLine("3- remove plan");
            Console.WriteLine("4- search");
            Console.WriteLine("5- change status");
            Console.WriteLine("6- Update plan");
            Console.WriteLine("7- Exit");
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Clear();
                    foreach (Plans p in service.GetAll(U.Id))
                    {
                        Console.WriteLine($"{p.Id}) {p.Title} {p.Date}  | {(PriorityEnum)p.PriorityId}   -   {(StatusEnum)p.StatusId}");
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("please enter the title of the plan");
                    string title = Console.ReadLine();
                    Console.Write("please enter the description of the plan");
                    string description = Console.ReadLine();
                    Console.Write("Please enter the date of the plan (yyyy-MM-dd): ");
                    DateOnly dateInput = DateOnly.Parse(Console.ReadLine());

                    Console.Write("please enter the priority of the course( 1) LowPriority,2) ModeratePriority,3) Important,4) HighPriority,5) Critical ) : ");
                    int iD = Convert.ToInt32(Console.ReadLine());
                    service.NewPlan(title, description, dateInput, iD, 1, U.Id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    foreach (Plans p in service.GetAll(U.Id)) { Console.WriteLine($"{p.Id}) {p.Title}   -{ p.Description}-   {p.Date}  | {(PriorityEnum)p.PriorityId}   -   {(StatusEnum)p.StatusId}"); }
                    Console.WriteLine("please enter the id of the plan : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(service.Delete(id,U.Id));
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();

                    Console.WriteLine("please enter the title you wnat to search : ");
                    string search = Console.ReadLine();
                    foreach (Plans prod in service.Search(search, U.Id))
                    { Console.WriteLine($"{prod.Id}) {prod.Title}   -{prod.Description}-   {prod.Date}  | {(PriorityEnum)prod.PriorityId}   -   {(StatusEnum)prod.StatusId}"); }

                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("please enter the id of the plan : ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("please enter the status of your plan (1) NotStarted=1,2) InProgress,3) Finnished,3) abandoned) : ");
                    int statusid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(service.ChangeStatus(Id, statusid,U.Id));

                    Console.ReadKey();
                    break;
                case 6:
                    Console.Clear();
                    bool x = false;
                    foreach (Plans p in service.GetAll(U.Id)) { Console.WriteLine($"{p.Id}) {p.Title}    -{p.Description}-    {p.Date}  | {(PriorityEnum)p.PriorityId}   -   {(StatusEnum)p.StatusId}"); }
                    Console.WriteLine("please enter the id of the product : ");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    while (x == false)
                    {
                        Console.Clear();
                        Console.WriteLine("1)change title");
                        Console.WriteLine("2)change description");
                        Console.WriteLine("3)change date");
                        Console.WriteLine("4)change priority");
                        Console.WriteLine("5)Exit");

                        int op = Convert.ToInt32(Console.ReadLine());
                        if (op == 5) { break; }
                        Console.WriteLine("what do you want to change it to : ");
                        string New = Console.ReadLine();
                        Console.WriteLine(service.Update(ID, op, New,U.Id));
                        Console.ReadKey();
                    }
                    Console.ReadKey();
                    break;
                case 7:
                    Console.Clear();
                    stop=true;
                    break;
                default:

                    Console.WriteLine("idont know what you are saying");
                    break;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}


