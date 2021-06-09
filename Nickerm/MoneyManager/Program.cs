using System;
using System.Data.Entity;
using System.Threading;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new Context())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        Console.WriteLine("Объекты успешно сохранены");

                        var entity = new EFUnitOfWork();
                        //var u = entity.Users.Get(1);
                        //Console.WriteLine($"{u.Id}, {u.Name}, {u.Email}, {u.Hash}, {u.Salt}");

                      
                        //var k = entity.Users.GetUserByEmail("AlexanderEmail@gmail.com"); ; 
                        //Console.WriteLine($"{k.Id}, {k.Name}, {k.Email}, {k.Hash}, {k.Salt}");

                        var u = entity.Users.GetAllUsers();
                        foreach (var i in u)
                        {
                            Console.WriteLine($"{i.Id}, {i.Name}, {i.Email}");
                        }

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
