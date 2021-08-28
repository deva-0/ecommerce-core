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

        /// <inheritdoc />
        public Expression<Func<T, object>> OrderBy { get; private set; }

        /// <inheritdoc />
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        /// <summary>
        /// Adds expression to be included in a query. 
        /// </summary>
        /// <param name="includeExpression">Valid include expression</param>
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        /// <summary>
        /// Adds expression which describes item order. 
        /// </summary>
        /// <param name="orderByExpression">Valid OrderBy expression</param>
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        /// <summary>
        /// Adds expression which describes item order in descending sequence.
        /// </summary>
        /// <param name="orderByDescendingExpression">Valid OrderBy expression</param>
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }
    }
}