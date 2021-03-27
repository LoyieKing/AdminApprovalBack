using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Common.Query
{
    public static class PaginationExtension
    {
        public static IQueryable<T> PaginationBy<T>(this IQueryable<T> queryable, Pagination pagination)
        {
            if (pagination == null) return queryable;
            bool isAsc = pagination.sord.ToLower() == "asc";
            string[] order = pagination.sidx.Split(',');
            MethodCallExpression? resultExp = null;
            foreach (string item in order)
            {
                string orderPart = item;
                orderPart = Regex.Replace(orderPart, @"\s+", " ");
                string[] orderArray = orderPart.Split(' ');
                string orderField = orderArray[0];
                if (orderArray.Length == 2)
                {
                    isAsc = orderArray[1].ToLower() == "asc";
                }

                var parameter = Expression.Parameter(typeof(T), "t");
                var property = typeof(T).GetProperty(orderField);
                if (property == null) continue;
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending",
                    new Type[] {typeof(T), property.PropertyType}, queryable.Expression,
                    Expression.Quote(orderByExp));
            }

            if (resultExp != null)
            {
                queryable = queryable.Provider.CreateQuery<T>(resultExp);
            }

            pagination.records = queryable.Count();
            return queryable.Skip(pagination.rows * (pagination.page - 1)).Take(pagination.rows);
        }   
    }
}