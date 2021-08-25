using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    /// <summary>
    /// All specification classes must inherit this class. 
    /// </summary>
    /// <typeparam name="T">Entity type for specification</typeparam>
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        /// <inheritdoc />
        public Expression<Func<T, bool>> Criteria { get; }
        /// <inheritdoc />
        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        /// <summary>
        /// Adds expression to be included in a query. 
        /// </summary>
        /// <param name="includeExpression">Valid include expression</param>
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}