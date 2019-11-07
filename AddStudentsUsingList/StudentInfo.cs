using System;
using System.Collections.Generic;
using System.Text;

namespace AddStudentsUsingList
{
    class StudentInfo
    {
        public string Name;
        public string HomeTown;
        public string FavoriteFood;
        public string FavoriteColor;

        //default constructor

        public StudentInfo(){}

        //Overload

        public StudentInfo(string name)
        {
            Name = name; //Assigned to property
        }

        public StudentInfo(string name, string favoritefood)
        {
            Name = name;
            FavoriteFood = favoritefood;
        }

        public StudentInfo(string name, string favoritefood, string hometown)
        {
            Name = name;
            FavoriteFood = favoritefood;
            HomeTown = hometown;
            
        }
        public StudentInfo(string name, string favoritefood, string hometown, string favoritecolor)
        {
            Name = name;
            FavoriteFood = favoritefood;
            HomeTown = hometown;
            FavoriteColor = favoritecolor;
        }

    }
}

//Program.cs
//StudentInfo student = new StudentInfo("Drew", "Detroit", "Chicken");

//List<StudentInfo> studentList = new List<StudentInfo>();

//////Hard coding objects into list
//////{ 
//////    new StudentInfo("name", "hometown", "food"),
//////    new StudentInfo("newName", "newTown", "newFood")
//////};

// studentList.Add(student);

//Console.WriteLine("Add new student");
//bool repeat = true;
//while (repeat)
//{

//    Console.WriteLine("Give me a new students name");
//    string name = Console.ReadLine();

//    Console.WriteLine("Give me a new students hometown");
//    string homeTown = Console.ReadLine();

//    Console.WriteLine("Give me a new students food");
//    string favoriteFood = Console.ReadLine();

//    //StudentInfo newStudent = new StudentInfo(name,homeTown,favoriteFood);

//    studentList.Add(new StudentInfo(name, homeTown, favoriteFood));

//    Console.WriteLine("Continue");
//    string input = Console.ReadLine();

//    if(input.ToLower() != "y")
//    {
//        repeat = false;
//    }
//}

//foreach(StudentInfo Student in studentList)
//{
//    Console.WriteLine($"{Student.Name} {Student.HomeTown} {Student.FavoriteFood}");
//}

//Console.WriteLine(); //Used for debugging