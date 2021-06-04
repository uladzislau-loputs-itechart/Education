using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MoneyManager
{
    class DataToDBInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            GetUsers().ForEach(u => context.Users.Add(u));
            context.SaveChanges();
            GetCategories().ForEach(c => context.Categories.Add(c));
            context.SaveChanges();
            GetAssets().ForEach(a => context.Assets.Add(a));
            context.SaveChanges();
            GetTransactions().ForEach(t => context.Transactions.Add(t));
            context.SaveChanges();
        }

        private static List<User> GetUsers()
        {
            var users = new List<User>
            {
            new User{Name="Alexander",Email="AlexanderEmail@gmail.com",Hash="234o234uiiuuihev",Salt="234sdfsvsv"},
            new User{Name="Victor",Email="VictorEmail@gmail.com",Hash="gfnf545gdfvdfv",Salt="746hgfbdfdf"},
            new User{Name="Kiril",Email="KirilEmail@gmail.com",Hash="77575rfgdgdg",Salt="dfbdfbdfb4545dfd"},
            new User{Name="Petr",Email="PetrEmail@gmail.com",Hash="44678fgtbfh",Salt="sdcsvdrfhty45646"},
            new User{Name="Sergey",Email="SergeyEmail@gmail.com",Hash="446457dfbffteh",Salt="dfdffgnyfgrt546"},
            new User{Name="Igor",Email="IgorEmail@gmail.com",Hash="fgnfjk78u54dfbfgn",Salt="3453fshytgjyyf"}
            };

            return users;
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
            new Category{Name="Food", ParentId = null, Type = 1},
            new Category{Name="Transportation", ParentId = null, Type = 1},
            new Category{Name="Culture", ParentId = null, Type = 1},
            new Category{Name=" Self-development", ParentId = null, Type = 1},
            new Category{Name="Taxi", ParentId = 2, Type = 1},
            new Category{Name=" Public transport", ParentId = 2, Type = 1},
            new Category{Name="Cafe", ParentId = 1, Type = 1},
            new Category{Name="Salary", ParentId = null, Type = 0},
            new Category{Name="Bonus", ParentId = null, Type = 0},
            new Category{Name="Petty cash", ParentId = null, Type = 0},
            new Category{Name="Office supplies", ParentId = 10, Type = 0},
            new Category{Name="cards for customers", ParentId = 10, Type = 0},
            new Category{Name="Holiday bonus", ParentId = 9, Type = 0},
            new Category{Name="Retention bonus", ParentId = 9, Type = 0}
            };

            return categories;
        }

        private static List<Asset> GetAssets()
        {
            var assets = new List<Asset>
            {
            new Asset{Name="cash", UserId = 1 },
            new Asset{Name="debit", UserId = 1 },
            new Asset{Name="cards", UserId = 1 },
            new Asset{Name="bank account", UserId = 1 },
            new Asset{Name="cash", UserId = 2 },
            new Asset{Name="debit", UserId = 2 },
            new Asset{Name="cards", UserId = 2 },
            new Asset{Name="loan", UserId = 2 },
            new Asset{Name="cash", UserId = 3 },
            new Asset{Name="debit", UserId = 3 },
            new Asset{Name="cash", UserId = 3 },
            new Asset{Name="loan", UserId = 3 },
            new Asset{Name="cash", UserId = 4 },
            new Asset{Name="debit", UserId = 4 },
            new Asset{Name="cards", UserId = 4 },
            new Asset{Name="bank account", UserId = 4 },
            new Asset{Name="cash", UserId = 5 },
            new Asset{Name="debit", UserId = 5 },
            new Asset{Name="loan", UserId = 5 },
            new Asset{Name="bank account", UserId = 5 },
            new Asset{Name="cards", UserId = 6 },
            new Asset{Name="debit", UserId = 6 },
            new Asset{Name="cash", UserId = 6 },
            new Asset{Name="loan", UserId = 6 }
            };

            return assets;
        }

        private static List<Transaction> GetTransactions()
        {
            var transactions = new List<Transaction>
            {
            new Transaction{CategoryId = 7, Amount = 100, AssetId = 1, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 120, AssetId = 2, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 130, AssetId = 3, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 200, AssetId = 4, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 150, AssetId = 5, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 170, AssetId = 6, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 120, AssetId = 7, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 200, AssetId = 8, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 120, AssetId = 9, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 200, AssetId = 10, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 300, AssetId = 11, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 170, AssetId = 12, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 130, AssetId = 13, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 200, AssetId = 14, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 400, AssetId = 15, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 190, AssetId = 16, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 140, AssetId = 17, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 110, AssetId = 18, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 110, AssetId = 19, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 110, AssetId = 20, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 300, AssetId = 21, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 170, AssetId = 22, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 130, AssetId = 23, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 200, AssetId = 24, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 400, AssetId = 1, Comment = null, Date = System.DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 190, AssetId = 2, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 140, AssetId = 3, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 110, AssetId = 4, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 110, AssetId = 5, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 6, Amount = 110, AssetId = 6, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 300, AssetId = 7, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 170, AssetId = 8, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 130, AssetId = 9, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 200, AssetId = 10, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 400, AssetId = 11, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 190, AssetId = 12, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 140, AssetId = 13, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 110, AssetId = 14, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 110, AssetId = 15, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 110, AssetId = 16, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 300, AssetId = 17, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 170, AssetId = 18, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 130, AssetId = 19, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 200, AssetId = 20, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 400, AssetId = 21, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 190, AssetId = 22, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 140, AssetId = 23, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 110, AssetId = 24, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 110, AssetId = 1, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 110, AssetId = 2, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 110, AssetId = 3, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 300, AssetId = 4, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 170, AssetId = 5, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 130, AssetId = 6, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 200, AssetId = 7, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 400, AssetId = 8, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 190, AssetId = 9, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 140, AssetId = 10, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 110, AssetId = 11, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 110, AssetId = 12, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 110, AssetId = 13, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 300, AssetId = 14, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 170, AssetId = 15, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 130, AssetId = 16, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 200, AssetId = 17, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 400, AssetId = 18, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 190, AssetId = 19, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 140, AssetId = 20, Comment = null, Date = System.DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 110, AssetId = 21, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 110, AssetId = 22, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 110, AssetId = 23, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 300, AssetId = 24, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 170, AssetId = 1, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 130, AssetId = 2, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 200, AssetId = 3, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 400, AssetId = 4, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 190, AssetId = 5, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 140, AssetId = 6, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 110, AssetId = 7, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 110, AssetId = 8, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 14, Amount = 110, AssetId = 9, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 300, AssetId = 10, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 170, AssetId = 11, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 130, AssetId = 12, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 200, AssetId = 13, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 400, AssetId = 14, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 190, AssetId = 15, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 140, AssetId = 16, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 110, AssetId = 17, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 110, AssetId = 18, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 110, AssetId = 19, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 300, AssetId = 20, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 170, AssetId = 21, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 130, AssetId = 22, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 200, AssetId = 23, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 400, AssetId = 24, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 190, AssetId = 1, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 140, AssetId = 2, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 110, AssetId = 3, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 110, AssetId = 4, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 110, AssetId = 5, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 11, Amount = 130, AssetId = 6, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 12, Amount = 200, AssetId = 7, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 4, Amount = 400, AssetId = 8, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 8, Amount = 190, AssetId = 9, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 13, Amount = 140, AssetId = 10, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 3, Amount = 110, AssetId = 11, Comment = "Some comment", Date = DateTime.Now},
            new Transaction{CategoryId = 5, Amount = 110, AssetId = 12, Comment = null, Date = DateTime.Now},
            new Transaction{CategoryId = 7, Amount = 110, AssetId = 13, Comment = "Some comment", Date = DateTime.Now}

            };

            return transactions;
        }
    }
}
