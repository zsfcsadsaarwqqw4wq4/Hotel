using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLBase<T,M> where T:class,new() 
        where M:DALBase<T>,new()
    {
        private static M manager = new M();
        /// <summary>
        /// 获取单个实体对象
        /// </summary>
        /// <param name="exprssion"></param>
        /// <returns></returns>
        public static T Get(Expression<Func<T, bool>> exprssion)
        {
            return manager.Get(exprssion);
        }
        /// <summary>
        /// 添加实体到数据库
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T Create(T t)
        {
            return manager.Create(t);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public static IList<T> GetAll()
        {
            return manager.GetAll();
        }

        /// <summary>
        /// 删除实体,先查询出实体然后删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T Delete(T t)
        {
            return manager.Delete(t);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int Delete(List<T> t)
        {
            return manager.Delete(t);
        }


        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int Create(List<T> list)
        {
            return manager.Create(list);
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLamdba"></param>
        /// <returns></returns>
        public static List<T> ToList(Expression<Func<T, bool>> whereLamdba)
        {
            return manager.ToList(whereLamdba);
        }

        /// <summary>
        /// 修改实体,先查询出实体后修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int Update(T t)
        {
            return manager.Update(t);
        }

        /// <summary>
        /// 数据总数量
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            return manager.Count();
        }

        public static int Count(Expression<Func<T, bool>> exprssion)
        {
            return manager.Count(exprssion);
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页数据数量</param>
        /// <returns></returns>
        public static IList<T> GetPageData(int pageIndex, int pageSize)
        {
            return manager.GetPageData(pageIndex, pageSize);
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页数据数量</param>
        /// <param name="whereLamdba">查询条件</param>
        /// <param name="orderLambda">排序列</param>
        /// <returns></returns>
        public static IList<T> GetPageData(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLamdba,
            Expression<Func<T, object>> orderLambda)
        {

            return manager.GetPageData(pageIndex, pageSize, whereLamdba, orderLambda);
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parametes"></param>
        /// <returns></returns>
        public static IList<T> ExecuteSql(string sql, params object[] parametes)
        {
            return manager.ExecuteSql(sql, parametes);
        }   
    }
}
