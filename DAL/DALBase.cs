using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALBase<T> where T : class,new()
    {
        /// <summary>
        /// 数据库访问上下文对象
        /// </summary>
        protected HotelDBEntities Context = new HotelDBEntities();

        /// <summary>
        /// 添加实体到数据库
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// 
        public T Create(T t)
        {
            T domain = Context.Set<T>().Add(t);
            Context.SaveChanges();
            return domain;
        }
        /// <summary>
        /// 删除实体,先查询出实体然后删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Delete(T t)
        {
            T domain = Context.Set<T>().Remove(t);
            Context.SaveChanges();
            return domain;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Delete(List<T> t)
        {
            Context.Set<T>().RemoveRange(t);
            return Context.SaveChanges();
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLamdba"></param>
        /// <returns></returns>
        public List<T> ToList(Expression<Func<T, bool>> whereLamdba)
        {
            return Context.Set<T>().Where(whereLamdba).ToList();
        }

        /// <summary>
        /// 修改实体,先查询出实体后修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(T t)
        {
            T domain = Context.Set<T>().Attach(t);
            Context.Entry<T>(t).State = EntityState.Modified;
            return Context.SaveChanges();
        }
        /// <summary>
        /// 获取单个实体对象
        /// </summary>
        /// <param name="exprssion"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> exprssion)
        {
            return Context.Set<T>().SingleOrDefault(exprssion);
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        /// <summary>
        /// 数据总数量
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> exprssion)
        {
            return Context.Set<T>().Count(exprssion);
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int Create(List<T> list)
        {
            Context.Set<T>().AddRange(list);
            return Context.SaveChanges();
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="pageIndex">页索引从1开始</param>
        /// <param name="pageSize">页数据数量</param>
        /// <returns></returns>
        public IList<T> GetPageData(int pageIndex, int pageSize)
        {
            return Context.Set<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页数据数量</param>
        /// <param name="whereLamdba">查询条件</param>
        /// <param name="orderLambda">排序列</param>
        /// <returns></returns>
        public IList<T> GetPageData(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLamdba, Expression<Func<T, object>> orderLambda)
        {
            return Context.Set<T>().Where(whereLamdba)
                .OrderBy(orderLambda)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parametes"></param>
        /// <returns></returns>
        public IList<T> ExecuteSql(string sql, params object[] parametes)
        {
            return Context.Set<T>().SqlQuery(sql, parametes).ToList();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
