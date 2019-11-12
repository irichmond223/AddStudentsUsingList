using System;
using System.Collections.Generic;
using System.Text;

namespace AddStudentsUsingList
{
    class StudentInfo
    {
        public string Name;
        public string Food;
        public string HomeTown;
        public string FavoriteColor;

        //default constructor
        public StudentInfo() { }


        //Constructors are class methods that are executed automatically when an object of a given type is created.
        //Constructors usually initialize the data members of the new object. 
        //Overload constructor
        public StudentInfo(string name, string food, string hometown, string favoritecolor)
        {
            Name = name; //Assigned to property
            Food = food;
            HomeTown = hometown;
            FavoriteColor = favoritecolor;

        }
    }
}
