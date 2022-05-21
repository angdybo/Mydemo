using MvcEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public  class logicGoods
    {
        public List<Goods> GetGoodsList(string Key)
        {
            DemoEntity demoEntity = new DemoEntity();
             var data = demoEntity.Goods.ToList();
            if (!string.IsNullOrEmpty(Key))
            {
                data = data.Where(p => p.GoodName.Contains(Key)).ToList();
            }
            return data;
        }
        public bool DelGood(int ID)
        {
            DemoEntity demoEntity = new DemoEntity();
            var data = demoEntity.Goods.Where(p => p.ID == ID).FirstOrDefault();
            if (data != null)
            {
                demoEntity.Goods.Remove(data);
                demoEntity.SaveChanges();
                return true;
            }
            return false;
        }
        public Goods GetSingleGoods(int ID)
        {
            DemoEntity demoEntity = new DemoEntity();
            var data = demoEntity.Goods.Where(p => p.ID == ID).FirstOrDefault();
            return data;
        }

        public bool UodateSingleGoods(Goods good)
        {
            DemoEntity demoEntity = new DemoEntity();
            var data = demoEntity.Goods.Where(p => p.ID == good.ID).FirstOrDefault();
            if (data != null)
            {
                data.GoodName = good.GoodName;
                data.Price = good.Price;
                data.UnitPrice = good.UnitPrice;
                demoEntity.SaveChanges();
                return true;
            }
            return false;
        }
        public void InsterGood(Goods good)
        {
            DemoEntity demoEntity = new DemoEntity();
            demoEntity.Goods.Add(good);
            demoEntity.SaveChanges();
        }
    }
}
