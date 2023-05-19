using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace test_time
{

    internal class Program
    {
        static List<DegreeProgram> degreeProgramList = new List<DegreeProgram>();
        static List<Student> studentList = new List<Student>();
        static void Main(string[] args)
        {
            string option = "";
            while (option != "4")
            {
                option = mainMenu();
                if (option == "1")
                {
                    manageDegreeProgramController();
                }
                else if (option == "2")
                {
                    manageDegreeSubjectsController();
                }
                else if (option == "3")
                {
                    manageStudentController();
                }
                else if (option == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option ! try again");
                }
            }
        }
        static string mainMenu()
        {
            Console.Clear();
            Console.WriteLine("Type the number to select the desired Menu !");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                                               ");
            Console.WriteLine("1 >> Manage Degree Programs");
            Console.WriteLine("2 >> Manage Subjects");
            Console.WriteLine("3 >> Manage Students");
            Console.WriteLine("4 >> Exit ");
            string option = Console.ReadLine();
            return option;
        }
        // MANAGE DEGREE PROGRAMS
        static string manageDegreeProgramMenu()
        {
            Console.Clear();
            Console.WriteLine("Manage Degree Program Menu !");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                                               ");
            Console.WriteLine("1 :> Add Degree Programs");
            Console.WriteLine("2 :> View Degree Programs");
            Console.WriteLine("3 :> Remove Degree programs");
            Console.WriteLine("4 :> Exit ");
            string option = Console.ReadLine();
            return option;
        }
        static void manageDegreeProgramController()
        {
            string DegreeProgramMenuOption = "";
            while (DegreeProgramMenuOption != "4")
            {
                DegreeProgramMenuOption = manageDegreeProgramMenu();
                if (DegreeProgramMenuOption == "1")
                {
                    degreeProgramList.Add(addDegreeProgram());
                    Console.ReadKey();
                }
                else if (DegreeProgramMenuOption == "2")
                {
                    viewDegreeProgram();
                    Console.ReadKey();
                }
                else if (DegreeProgramMenuOption == "3")
                {
                    bool result = removeDegreeProgram();
                    if (result)
                    {
                        Console.WriteLine("Program removed Successfully ! ");
                    }
                    if (!result)
                    {
                        Console.WriteLine("Degree Program Does not Exist ! ");
                    }
                    Console.ReadKey();

                }
                else if (DegreeProgramMenuOption == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You entered wrong option !");
                }
            }
        }
        static DegreeProgram addDegreeProgram()
        {
            Console.WriteLine("Enter Title of Degree : ");
            string degreeTitle = Console.ReadLine();
            Console.WriteLine("Enter Duration of Degree : ");
            string degreeDuration = Console.ReadLine();
            Console.WriteLine("Enter number of subject (Degree contains) : ");
            int numberOfSubjects = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the minimum merit to join the degree : ");
            float degreeMerit = float.Parse(Console.ReadLine());
            var degreeProgram = new DegreeProgram(degreeTitle, degreeDuration, numberOfSubjects,degreeMerit);
            return degreeProgram;
        }
        static void viewDegreeProgram()
        {
            foreach (var degreeProgram in degreeProgramList)
            {
                degreeProgram.Display();
            }
        }
        static bool removeDegreeProgram()
        {
            Console.WriteLine("Enter Title of Degree Program");
            string title = Console.ReadLine();
            foreach (var degreeProgram in degreeProgramList)
            {
                if (degreeProgram.degreeTitle == title)
                {
                    degreeProgramList.Remove(degreeProgram);
                    return true;
                }

            }
            return false;

        }

        // MANAGE DEGREE SUBJECTS
        static string manageDegreeSubjectsMenu()
        {
            Console.Clear();
            Console.WriteLine("Type the number to select the desired Menu !");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                                               ");
            Console.WriteLine("1 :> Add Subject");
            Console.WriteLine("2 :> View Subjects");
            Console.WriteLine("3 :> Remove Subject");
            Console.WriteLine("4 :> Exit ");
            string option = Console.ReadLine();
            return option;
        }
        static void manageDegreeSubjectsController()
        {
            string DegreeSubjectMenuOption = "";
            while (DegreeSubjectMenuOption != "4")
            {
                DegreeSubjectMenuOption = manageDegreeSubjectsMenu();
                if (DegreeSubjectMenuOption == "1")
                {
                    DegreeProgram degreeProgram = checkForProgram();

                    if (degreeProgram != null)
                    {
                        if (degreeProgram.NumberOfSubjects > degreeProgram.SubjectsCount)
                        {
                            int result = degreeProgram.CalculateCreditsHours();
                            if (result <= 20)
                            {
                                Subjects subjectsOBJ = addSubjects(degreeProgram);
                                degreeProgram.addSubject(subjectsOBJ);
                                degreeProgram.SubjectsCount += 1;
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Credit Hour limit exceed !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Degree Subjects limit exceed !");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You entered invalid Degree Program !");
                        Console.ReadKey();
                    }
                }
                else if (DegreeSubjectMenuOption == "2")
                {
                    DegreeProgram degreeProgram = checkForProgram();
                    if (degreeProgram != null)
                    {
                        degreeProgram.DisplaySubjects();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You entered invalid Degree Program !");
                    }

                }
                else if (DegreeSubjectMenuOption == "3")
                {
                    DegreeProgram degreeProgram = checkForProgram();
                    if (degreeProgram != null)
                    {
                        Console.WriteLine("Enter Subject Code : ");
                        string code = Console.ReadLine();
                        bool result = degreeProgram.removeSubject(code);
                        if (result)
                        {
                            Console.WriteLine("Subject Remove Successfully !");
                        }
                        else
                        {
                            Console.WriteLine("Subject does not found!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You entered invalid Degree Program !");
                    }
                }
                else if (DegreeSubjectMenuOption == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option ! Try Again");
                }

            }
        }
        static DegreeProgram checkForProgram()
        {
            Console.WriteLine("Enter name of Degree Program : ");
            string title = Console.ReadLine();
            foreach (var degreeProgram in degreeProgramList)
            {
                if (degreeProgram.degreeTitle == title)
                {
                    return degreeProgram;
                }

            }
            return null;
        }
        static Subjects addSubjects(DegreeProgram degreeProgram)
        {
            Console.WriteLine("Enter Subject Code : ");
            string subjectCode = Console.ReadLine();
            Console.WriteLine("Enter Subject Type : ");
            string subjectType = Console.ReadLine();
            Console.WriteLine("Enter fee of Subject : ");
            float feeOfSubject = float.Parse(Console.ReadLine());
            int creditHours;
            while (true)
            {
                Console.WriteLine("Enter Credit Hours : ");
                creditHours = int.Parse(Console.ReadLine());
                //if(degreeProgram.CalculateCreditsHours() <= 20)
                if (creditHours <= 20)
                {
                    Console.WriteLine("Enter credit hour less then 20 !");
                }
                else
                {
                    break;
                }
            }
            var subjects = new Subjects(subjectCode, subjectType, creditHours,feeOfSubject);
            return subjects;
        }

        // MANAGE STUDENT
        static string manageStudentMenu()
        {
            Console.Clear();
            Console.WriteLine("Manage Student Menu !");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                                               ");
            Console.WriteLine("1 :> Add Student");
            Console.WriteLine("2 :> View Students");
            Console.WriteLine("3 :> Remove Students");
            Console.WriteLine("4 :> Exit ");
            string option = Console.ReadLine();
            return option;
        }

        static void manageStudentController()
        {
            string studentMenuOption = "";
            while (studentMenuOption != "4")
            {
                studentMenuOption=manageStudentMenu();
                if (studentMenuOption == "1")
                {
                    studentList.Add(addStudent());
                        Console.WriteLine("Student Added Successfully !");
                    Console.ReadKey();
                }
                else if (studentMenuOption == "2")
                {
                    viewStudents();
                    Console.ReadKey();
                }
                else if (studentMenuOption == "3")
                {
                    Console.WriteLine("Enter Student name : ");
                    string name = Console.ReadLine();
                    bool result = checkForStudent(name);
                    if (result)
                    {
                        removeStudent(name);
                        Console.WriteLine("Student Removed Successfully !");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You Entered Wrong Credentials !");
                        Console.ReadKey();
                    }
                }
                else if (studentMenuOption == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option ! Try Again");
                        Console.ReadKey();
                }
            }
        }
        static Student addStudent()
        {
            Console.WriteLine("Enter Student name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student age : ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student FSC. Marks : ");
            float fscMarks = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat Marks : ");
            float ecatMarks = float.Parse(Console.ReadLine());
            int preferencesCount = 1;
            Console.WriteLine("Enter number " + preferencesCount + " preferences : ");
            string degreeName = Console.ReadLine();
            bool result = addPreferences(degreeName);
            if (result)
            {
                Console.WriteLine("Preference Added Successfully ! ");
            }
            else
            {
                preferencesCount-- ;
                Console.WriteLine("You Entered Invalid Degree Name !");
            }
            while (true)
            {
                Console.WriteLine("You want to add more preferences ! (press 'y' or press 'n')");
                string optionEntered = Console.ReadLine();
                if (optionEntered == "y")
                {
                    ++preferencesCount;
                    Console.WriteLine("Enter number " + preferencesCount + " preferences : ");
                    string degreeName1 = Console.ReadLine();
                    bool result1 = addPreferences(degreeName1);
                    if (result1)
                    {
                        Console.WriteLine("Preference Added Successfully ! ");
                    }
                    else
                    {
                        preferencesCount--;
                        Console.WriteLine("You Entered Invalid Degree Name !");
                    }
                }
                if (optionEntered == "n")
                {
                    if (preferencesCount >= 2)
                    {
                    break;
                    }
                }

            }
            Student student = new Student(name, age, fscMarks, ecatMarks, preferencesCount);
            return student;
        }
        static void viewStudents()
        {
            foreach (Student student in studentList)
            {
                Console.WriteLine(student.Name + " " + student.age + " " + student.fscMarks + " " + student.ecatMarks);
            }
        }
        static bool checkForStudent(string name)
        {

            foreach (Student student in studentList)
            {
                if (student.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        static void removeStudent(string name)
        {
            foreach (Student student in studentList)
            {
                if (student.Name == name)
                {
                    studentList.Remove(student);
                }
                 
            }
        }
        static bool addPreferences(string degree)
        {
            foreach(DegreeProgram OBJ in degreeProgramList)
            {
                if(OBJ.degreeTitle == degree)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
