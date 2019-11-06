﻿using System;
using System.Collections.Generic;

namespace AddStudentsUsingList
{
    class Program
    {
        static void Main(string[] args)
        {

            Arrays();

        }
        public static void Arrays()
        {
            List<string> names = new List<string>() { "Ilona", "Michael", "Viktoriya", "Sarah", "Angela", "Maria", "Scott", "David", "Victor", "Ivan" };
            List<string> food = new List<string>() { "Tacos", "Potato Salad", "Borsch", "Ice Cream", "Meat Loaf", "Soup", "Steak", "Beef Stew", "Pizza", "Donuts" };
            List<string> hometown = new List<string>() { "Kiev", "Dnipro", "Lugansk", "Detroit", "Ann Arbor", "Grand Rapids", "Las Vegas", "New York", "Chicago", "Los Angeles" };
            List<int> favoritenumber = new List<int>() { 5, 1, 20, 10, 3, 20, 6, 10, 7, 8 };

            Console.WriteLine("Welcome to our C# class.  ");

            //Loop through list to display names, for example: 1. Ilona
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
            }

            //Loop through all data to choose a different student by entering a number
            bool playAgain = true;
            while (playAgain)
            {
                Console.WriteLine("Which student would you like to learn more about? (enter in numerical format):");
                string stringUserInput = Console.ReadLine();
                //Validates all the data to ensure the format is correct, within a range of a list, and no blanks allowed
                try
                {
                    //Converted to integer and added -1 to count user input starting from 1 instead of 2. Example: typed in 1, Michael appears as 1.
                    int intUserInput = int.Parse(stringUserInput) - 1;

                    //Loops through the data if the user wants to know more about the same student
                    bool moreAboutStudent = true;
                    while (moreAboutStudent)
                    {
                        Console.WriteLine($"Student {stringUserInput} is {names[intUserInput]}. Would you like to know about {names[intUserInput]} (enter yes or no)?");
                        string knowMoreAboutStudent = Console.ReadLine();

                        if (knowMoreAboutStudent == "yes")
                        {
                            Console.WriteLine("Enter input from the following options below: \n hometown \n favorite food \n \n favorite number");
                            string userInputOptions = Console.ReadLine();

                            //Nested if else statements only applies if answered yes to get to know about a user
                            if (userInputOptions == "hometown")
                            {
                                Console.WriteLine($"{names[intUserInput]} is from {hometown[intUserInput]}.  ");
                            }
                            else if (userInputOptions == "favorite food")
                            {
                                Console.WriteLine($"{names[intUserInput]} likes {food[intUserInput]}.  ");
                            }
                            else if (userInputOptions == "favorite number")
                            {
                                Console.WriteLine($"{names[intUserInput]} likes {favoritenumber[intUserInput]}.  ");
                            }
                            else
                            {
                                Console.WriteLine("That data does not exist. Please try again. (enter “hometown” or “favorite food or favorite color or number”)");
                            }
                        }
                        else if (knowMoreAboutStudent == "no")
                        {
                            //If answered no and the user dont want to get to know the same user,
                            //they can choose another student or add a new student to the end of the list
                            Console.WriteLine("Would you like to know more about other students? (yes or no) \n Or would you like to add a new student? enter (add)");
                            string userContinue = Console.ReadLine();

                            if (userContinue == "yes")
                            {
                                moreAboutStudent = false;
                                playAgain = true;
                            }
                            bool addNameAgain = true;

                            if (userContinue == "add")
                            {
                                while (addNameAgain)
                                {
                                    Console.WriteLine("Enter first name: ");
                                    string userName = Console.ReadLine();
                                    names.Add(userName);

                                    Console.WriteLine("Enter favorite food: ");
                                    string userFood = Console.ReadLine();
                                    food.Add(userFood);

                                    Console.WriteLine("Enter hometown: ");
                                    string userhometown = Console.ReadLine();
                                    hometown.Add(userhometown);

                                    Console.WriteLine("Enter favorite number: ");
                                    string userNum = Console.ReadLine();
                                    int userNumber = int.Parse(userNum);
                                    favoritenumber.Add(userNumber);


                                    if (userName == "" || userFood == "" || userhometown == "" || userName == "")
                                    {
                                        Console.WriteLine("Cannot be empty. Try again.");
                                        
                                        playAgain = false;
                                        moreAboutStudent = false;
                                        addNameAgain = true;
                                    }
                                }
                            }


                            //To display the loop of newly updated list for verification
                            for (int i = 0; i < names.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {names[i]}");
                            }
                        }

                        else
                        {
                            //If dont want to know about any other students or to add
                            Console.WriteLine("Goodbye");
                            playAgain = false;
                            moreAboutStudent = false;
                        }
                    }

                }
                catch (FormatException) //Used when the user typed in in a wrong format, in this case in words instead of numbers.
                {
                    Console.WriteLine("Enter numbers only. Please try again.");
                }
                catch (IndexOutOfRangeException) //Used when the number exceedes 1-10 range.
                {
                    Console.WriteLine("That student does not exist. Please try again.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Value cannot be empty. Try again.");
                }
            }
            return;
        }
    }
 }
