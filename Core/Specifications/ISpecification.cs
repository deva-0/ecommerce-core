using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    /// <summary>
    /// Represents required specification for query. 
    /// </summary>
    /// <typeparam name="T">Valid entity type</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Criteria expression passed to Where() 
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }
        /// <summary>
        /// Each expression in list passed to Include() 
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }
        /// <summary>
        /// Expression dictates how to order returned items. 
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }
        /// <summary>
        /// Expression dictates how to order returned items in descending sequence. 
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }
    }
}