using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopToolBar
{
    public  class BeanRealmService
    {
       
        private  Realm realm = null;
        public BeanRealmService ()
        {
            if (realm == null)
            {
                //数据库配置  
                var config = new RealmConfiguration("new.realm")  //设置路径
                {
                    //删除new.realm文件下的现有数据库，请勿使用此标志发布应用程序（虚拟机测试可用）  
                   // ShouldDeleteIfMigrationNeeded = true,
                    //版本号 默认为0
                    SchemaVersion = 1
                };
                //删除历史数据文件  数据库类型发生变化时 可以进行此操作
                Realm.DeleteRealm(config);

                //得到实例
                realm = Realm.GetInstance(config);

            }

        }

       
        public void AddBean(Bean bean)
        {
            
            realm.Write(() =>
            {
                
                realm.Add(bean);
            });
       
        }

        public Bean FindOneById(int id)
        {
            var bean = realm.Find<Bean>(1);
            if (bean != null)
                return bean;

            return null;
        }

        public IQueryable<Bean> FindAll()
        {
            var beans = realm.All<Bean>() ;
            if (beans == null)
                return null;
            return beans as IQueryable<Bean>;
        }

        public Boolean DeleteOneById(int id)
        {
            Bean bean= FindOneById(id);
            if (bean == null)
                return false;

            using (var trans = realm.BeginWrite())
            {
                realm.Remove(bean);
                trans.Commit();
            }
            return true;
        }

        public Boolean UpdateBean(Bean newbean)
        {
            Bean oldbean = FindOneById(newbean.Id);
            if (oldbean == null)
                return false;
            using (var trans = realm.BeginWrite())
            {
                oldbean.Name = newbean.Name;
                oldbean.Age = newbean.Age;
                oldbean.Counter = newbean.Counter;
                trans.Commit();
            }
            return true;
        }

        public Boolean ComputeCount(int id, int number)
        {
            Bean bean = FindOneById(id);
            if (bean == null)
                return false;
            realm.Write(() =>
            {
                //修改id为1的count值  增加2
                bean.Counter.Increment(number); // 1
            });
            return true;
        }
    }
}
