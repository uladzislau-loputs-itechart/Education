using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace MoneyManager
{
    public class AssetRepository : IRepository<Asset>
    {
        private Context db;

        public AssetRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Asset> GetAll()
        {
            return db.Assets;
        }

        public Asset Get(int id)
        {
            return db.Assets.Find(id);
        }

        public void Create(Asset asset)
        {
            db.Assets.Add(asset);
        }

        public void Update(Asset asset)
        {
            db.Entry(asset).State = EntityState.Modified;
        }

        public IEnumerable<Asset> Find(Func<Asset, Boolean> predicate)
        {
            return db.Assets.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Asset asset = db.Assets.Find(id);
            if (asset != null)
                db.Assets.Remove(asset);
        }
    }
}
