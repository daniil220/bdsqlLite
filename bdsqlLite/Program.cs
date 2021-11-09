using Microsoft.EntityFrameworkCore;
using System;

namespace SQLlitleForIS_19_03.DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы в программе ура ");
            while (true)
            {
                PrintMenu();
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Если вы хотите получить  список  всех пользователей введите \"allUser\"");
            Console.WriteLine("Если вы хотите добавить нового пользователя введите \"addUser\"");
            Console.WriteLine("Если вы хотите удалить  пользователя введите \"removeUser\"");
            Console.WriteLine("Если вы хотите показать список всех емайлов введите\"allEmail\"");
            Console.WriteLine("Если вы хотите добавить новый емайл введите\"addEmail\"");

            switch (Console.ReadLine().ToUpper())
            {
                case "ALLUSER": PrintAllUser(); break;
                case "ADDUSER": AddUser(); break;
                case "REMOVEUSER": RemoveUser(); break;
                case "ALLEMAIL": PrintAllEmail(); break;
                case "ADDEMAIL": AddEmail(); break;
                case "REMOVEEMAIL": RemoveEmail(); break;
                default: Console.WriteLine("Команда не  опознана, введите команду  еще  раз"); break;
            }

            Console.WriteLine();
        }

        private static void RemoveEmail()
        {
            using (DB.LitleContext context = new DB.LitleContext ())
            {
                try
                {
                    Console.WriteLine("Введите ид емайла");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var email = context.Emails.Find(id);
                    if (email != null)
                    {
                        context.Emails.Remove(email);
                        context.SaveChanges();
                        Console.WriteLine("Емайл удален из БД");
                        PrintAllEmail ();
                    }
                    else
                    {
                        Console.WriteLine("Емайл не найден");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AddEmail()
        {
            Console.WriteLine("Укажите название емайла ");
            var name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine($"не корректное имя");
                return;
            }
            try
            {
                
               
                PrintAllUser();
                Console.WriteLine("Укажите id пользователя");


                int idUser = Convert.ToInt32(Console.ReadLine());
                var user = IsUser(idUser);

                if (user != null)
                {
                    Console.WriteLine($"Вы выбрали пользователя {user.ToString()}");
                }
                else
                {
                   
                    Console.WriteLine("Пользователь не найден");
                    return;
                }


                using (DB.LitleContext context = new DB.LitleContext())
                {
                    context.Emails.Add(new DB.Email()
                    {
                        Title = name,
                        UserId = user.Id,
                       
                    });

                    context.SaveChanges();
                    Console.WriteLine("Сохранение  прошло успешно");
                    PrintAllEmail();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }





        }

        private static DB.User IsUser(int idUser)
        {
            using (DB.LitleContext context = new DB.LitleContext())
            {
                try
                {
                    var user = context.Users.Find(idUser);
                    if (user != null)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        private static void PrintAllEmail()
        {
            using (DB.LitleContext context = new DB.LitleContext())
            {
                try
                {
                    foreach (var item in context.Emails.Include(x => x.User))
                    {
                        Console.WriteLine(item.Id + " " + item.Title);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void RemoveUser()
        {
            using (DB.LitleContext context = new DB.LitleContext())
            {
                try
                {
                    Console.WriteLine("Введите ид пользователя которого хотите удалить");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var user = context.Users.Find(id);
                    if (user != null)
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                        Console.WriteLine("Пользователь удален из БД");
                        PrintAllUser();
                    }
                    else
                    {
                        Console.WriteLine("Пользователь не найден");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AddUser()
        {
            using (DB.LitleContext context = new DB.LitleContext())
            {
                try
                {
                    Console.WriteLine("Введите имя пользователя");
                    var name = Console.ReadLine().TrimStart().TrimEnd();

                    if (String.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Имя не  корректно");
                        return;
                    }

                    context.Users.Add(new DB.User() { Name = name });
                    context.SaveChanges();
                    Console.WriteLine("Пользователь добавлен в БД");

                    PrintAllUser();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        
        private static void PrintAllUser()
        {
            using (DB.LitleContext context = new DB.LitleContext())
            {
               
                
                try
                {
                    foreach (var item in context.Users)
                    {
                        Console.WriteLine(item.Id + " " + item.Name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                          
            
            
            }
        }
    }
}