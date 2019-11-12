using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AddStudentsUsingList
{
    class Program
    {
        static void Main(string[] args)
        {
            //To create an object, you need to instantiate a class, or create a class instance.
            //To assign values to properties during the class instantiation process, use object initializers:
            List<StudentInfo> student = new List<StudentInfo>()
            {
            new StudentInfo("Leonardo", "Tacos", "Los Angeles", "Blue"),
            new StudentInfo("Brad", "Ribs", "Shawnee", "Green"),
            new StudentInfo("Jessica", "Lobster Roll", "Pancakes", "Purple")
        };

            //Loop through all data to choose a different student by entering a number
            bool playAgain = true;
            while (playAgain)

            {
                Console.WriteLine("Welcome to our C# class.");
                //Loop through list to display names, for example: 1. Ilona
                //student.Name -> Sort();
                for (int i = 0; i < student.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {student[i].Name}");
                }

                Console.WriteLine("Which student would you like to learn more about? (enter in numerical format):");
                int Number = TestValidity(student);

                //Loops through the data if the user wants to know more about the same student

                bool moreAboutStudent = true;
                while (moreAboutStudent)
                {
                    Console.WriteLine($"Student {Number + 1} is {student[Number].Name}. Would you like to know about {student[Number].Name} (enter yes or no)?");
                    try
                    {
                        string knowMoreAboutStudent = Console.ReadLine().ToLower();

                        if (knowMoreAboutStudent == "yes")
                        {
                            GetInfo(student, Number);
                        }

                        else if (knowMoreAboutStudent == "no")
                        {
                            UserPrompts(student, Number);
                            moreAboutStudent = false;
                            playAgain = false;
                        }
                    }
                    catch (FormatException) //Used when the user typed in in a wrong format
                    {
                        Console.WriteLine("Please use the correct format. Enter numbers Please try again.");
                        moreAboutStudent = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error has occurred. Please try again.");
                        moreAboutStudent = true;
                    }
                }
            }
        }

        //Validator method is used to validate if user entered a number and to accomondate for any other errors
        public static int TestValidity(List<StudentInfo> userInput)
        {
            bool repeatIntValidation = true;
            bool playAgain = true;
            int intUserInput = 0;

            while (repeatIntValidation)
            {
                try
                {
                    string stringUserInput = Console.ReadLine();

                    //Converted to integer and added -1 to count user input starting from 1 instead of 2. Example: typed in 1, Michael appears as 1.
                    intUserInput = int.Parse(stringUserInput) - 1;

                    repeatIntValidation = false;
                    playAgain = true;
                }
                catch (FormatException) //Used when the user typed in in a wrong format
                {
                    Console.WriteLine("Please use the correct format. Enter numbers Please try again.");
                    repeatIntValidation = true;
                }
                catch (IndexOutOfRangeException) //Used when the number exceedes 1-10 range
                {
                    Console.WriteLine("That student does not exist. Please try again.");
                    repeatIntValidation = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Value is invalid. Please try again.");
                    repeatIntValidation = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("An error has occurred. Please try again.");
                    repeatIntValidation = true;
                }
            }
            return intUserInput;
        }

        //Validator method overload used not to allow blanks when entering students to add
        public static string TestValidity()
        {
            string stringUserInput = "";
            do
            {
                try
                {
                    stringUserInput = Console.ReadLine().ToLower();

                    if (string.IsNullOrEmpty(stringUserInput))
                    {
                        Console.WriteLine("Empty input, please try again.");
                    }
                }
                catch (FormatException) //Used when the user typed in in a wrong format
                {
                    Console.WriteLine("Please use the correct format. Enter numbers Please try again.");
                }
                catch (Exception)
                {
                    Console.WriteLine("An error has occurred. Please try again.");
                }

            } while (string.IsNullOrEmpty(stringUserInput));

            return stringUserInput;
        }

        public static void GetInfo(List<StudentInfo> student, int intUserInput)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Enter input from the following options below: \nhometown \nfavorite food \nfavorite color");

                try
                {
                    string userInputOptions = Console.ReadLine().ToLower();

                    //Nested if else statements only applies if answered yes to get to know about a user
                    if (userInputOptions == "hometown")
                    {
                        Console.WriteLine($"{student[intUserInput].Name} is from {student[intUserInput].HomeTown}.");
                    }
                    else if (userInputOptions == "favorite food")
                    {
                        Console.WriteLine($"{student[intUserInput].Name} likes {student[intUserInput].Food}.");
                    }
                    else if (userInputOptions == "favorite color")
                    {
                        Console.WriteLine($"{student[intUserInput].Name} likes {student[intUserInput].FavoriteColor}.");
                    }
                    else
                    {
                        Console.WriteLine("That data does not exist. Please try again. (enter “hometown” or “favorite food or favorite color or number”)");
                    }
                }
                catch (FormatException) //Used when the user typed in in a wrong format
                {
                    Console.WriteLine("Please use the correct format. Enter numbers Please try again.");
                    repeat = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Value is invalid. Please try again.");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Value is invalid. Please try again.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Im sorry thats not a valid input try again.\n");
                }
            }
        }

        public static void UserPrompts(List<StudentInfo> student, int intUserInput)
        {
            bool moreAboutStudent = true;
            bool playAgain = true;
            //If answered no and the user dont want to get to know the same user,
            //they can choose another student or add a new student to the end of the list
            Console.WriteLine("Would you like to know more about other students? (yes or no)");
            string userContinue = Console.ReadLine().ToLower();

            if (userContinue == "yes" || userContinue == "y")
            {
                moreAboutStudent = false;
                playAgain = true;
            }
            else if (userContinue == "no" || userContinue == "n")
            {
                Console.WriteLine("would you like to add a new student? (yes or no)");
                string userToAdd = Console.ReadLine().ToLower();

                if (userToAdd == "yes" || userToAdd == "y")
                {
                    AddStudent(student, intUserInput);
                    moreAboutStudent = false;
                    playAgain = false;
                }
                else if (userToAdd == "no" || userToAdd == "n")
                {
                    Console.WriteLine("Goodbye");
                    moreAboutStudent = false;
                }
            }
        }
        public static void AddStudent(List<StudentInfo> student, int intUserInput)
        {
            bool addInputAgain = true;

            while (addInputAgain)
            {
                try
                {
                    Console.WriteLine("Enter first name:");
                    string Name = TestValidity();

                    Console.WriteLine("Enter favorite food:");
                    string Food = TestValidity();

                    Console.WriteLine("Enter hometown:");
                    string HomeTown = TestValidity();

                    Console.WriteLine("Enter favorite color:");
                    string FavoriteColor = TestValidity();

                    //but you can also create and add the object in one step
                    //built object list dymatically with user input
                    student.Add(new StudentInfo(Name, Food, HomeTown, FavoriteColor));

                    Console.WriteLine($"User {Name} was added successfully.");

                    //Used with Linq system
                    student.Sort((x, y) => x.Name.CompareTo(y.Name));
                    //student.ForEach(m => Console.WriteLine($"{student[intUserInput].Count} {m.Name}"));

                    for (int i = 0; i < student.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {student[i].Name}");
                    }
                    addInputAgain = false;
                }
                catch (FormatException) //Used when the user typed in in a wrong format
                {
                    Console.WriteLine("Please use the correct format. Enter numbers Please try again.");
                    addInputAgain = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Value is invalid. Please try again.");
                    addInputAgain = true;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Value is invalid. Please try again.");
                    addInputAgain = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("An error has occurred. Please try again.");
                    addInputAgain = true;
                }
            }
        }
    }
}



