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
                        //DataToDB.Load(db);
                        //db.SaveChanges();
                        //Console.WriteLine("Объекты успешно сохранены");

                        var entity = new EFUnitOfWork();
                        //var u = entity.Users.GetUser("AlexanderEmail@gmail.com");
                        //Console.WriteLine($"{u.Id}, {u.Name}, {u.Email}, {u.Hash}, {u.Salt}");
                       
                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }
            Console.Read();
        }
    }
}
