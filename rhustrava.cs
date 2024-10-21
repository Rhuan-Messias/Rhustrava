using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Rhustrava
{
    internal class Program
    {
        [System.Serializable]
        struct User
        {
            public int Id;
            public string NickName;
            public string Name;
            public string PassWord;
        }

        static List<User> users = new List<User>();


        enum LoginScreen { LogIn = 1, SignIn };




        //Main
        static void Main(string[] args)
        {
            //Login
            EnterScreen();

            //Menu
        }




        //First Screen
        static void EnterScreen()
        {
            bool loginmatch = false;
            while (!loginmatch)
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("***** Bem Vindo ao Rhustrava *****");
                Console.WriteLine("**********************************");
                Console.WriteLine("\n1 - Log In\n2 - Sign In");
                LoginScreen choice = (LoginScreen)int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case LoginScreen.LogIn:
                        if (LogIn() == 1)
                        {
                            loginmatch = true;
                            Console.WriteLine("Success Login");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("**************************************");
                            Console.WriteLine("***** WRONG USERNAME OR PASSWORD *****");
                            Console.WriteLine("*****   PRESS ENTER TO RETURN    *****");
                            Console.WriteLine("**************************************");
                        }
                        break;
                    case LoginScreen.SignIn:

                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        //LoginFunction
        static int LogIn()
        {
            int validation = 0;
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                validation = 0;
            } else if(username == "admin" && password == "admin")
            {
                validation = 1;
            } else if(users == null || users.Count == 0)
            {
                foreach(var user in users)
                {
                    if(username == user.Name && password == user.PassWord)
                    {
                        validation = 1;
                    }
                    else
                    {
                        validation = 0;
                    }
                }
            } else
            {
                validation = 0;
            }
            return validation;
        }
    }



}
