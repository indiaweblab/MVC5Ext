using System;
using System.Linq;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IBaseBLL<T>
    {
        void Insert(T model);
        void Delete(T model, bool IsSoftDel, string Pro = "IsDel", bool DelTag = true);
        void Delete(Expression<Func<T, bool>> delWhere, bool IsSoftDel, string Pro = "IsDel", bool DelTag = true);
        void Updata(T model, params string[] strparams);
        void Updata(Expression<Func<T, bool>> upWhere, bool IsUpDelData, T model, params string[] strparame);
        IQueryable<T> GetList(Expression<Func<T, bool>> strWhere, bool SelectDelData = false, bool isAsNoTracking = true, string tableName = null);
        IQueryable<T> GetList<TTb>(Expression<Func<T, bool>> strWhere, bool SelectDelData = false, bool isAsNoTracking = true, Expression<Func<T, TTb>> tableName = null);
        IQueryable<T> GetList<Tkey>(int indexPage, int sizePage, out int total, Expression<Func<T, bool>> strWhere, bool SelectDelData = false, Expression<Func<T, Tkey>> strOrederBy = null, bool order = true, bool isAsNoTracking = true, string tableName = null);
        IQueryable<T> GetList<Tkey, TTb>(int indexPage, int sizePage, out int total, Expression<Func<T, bool>> strWhere, bool SelectDelData = false, Expression<Func<T, Tkey>> strOrederBy = null, bool order = true, bool isAsNoTracking = true, Expression<Func<T, TTb>> tableName = null);

    }
}
