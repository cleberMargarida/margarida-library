using System.Linq.Expressions;
using System.Reflection;

namespace Margarida.Util.Expressions
{
    public static class AwesomeExpressionExt
    {
        class FinderProperty : ExpressionVisitor
        {
            private readonly string toFind;

            internal FinderProperty(string toFind)
            {
                this.toFind = toFind;
            }

            public bool IsFound { get; private set; }

            protected override Expression VisitMember(MemberExpression node)
            {
                IsFound |= node.Member.MemberType == MemberTypes.Property && node.Member.Name == toFind;
                return base.VisitMember(node);
            }
        }

        public static bool RefersToProperty<T1, T2>(this Expression<Func<T1, T2>> expression, string property)
        {
            return new FinderProperty(property).Inner(x => x.Visit(expression)).IsFound;
        }

        public static AwesomeExpression<TIn, TOut> Assign<TIn, TOut>(this Expression<Func<TIn, TOut>> expression, TOut value)
        {
            return new AwesomeExpression<TIn, TOut>(expression, value);
        }

        public static AwesomeExpression<TIn, TOut> To<TIn, TOut>(this Expression<Func<TIn, TOut>> expression, TIn value)
        {
            return new AwesomeExpression<TIn, TOut>(expression, value);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expressao)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(expressao.Body), expressao.Parameters.First());
        }

        public static TProp? GetValueFrom<T, TProp>(this T instancia, Expression<Func<T, TProp>> expression)
            where TProp : class
        {
            object? propriedade = instancia;
            MemberExpression? memberExpression = GetMemberExpression(expression);
            while (GetByComposing(memberExpression).GetValueOrDefault())
            {
                memberExpression = GetMemberExpression(memberExpression) ?? throw new ArgumentNullException(nameof(memberExpression)); ;
                propriedade = ((PropertyInfo)memberExpression.Member).GetValue(propriedade, null);
            }

            return GetProperty(expression).GetValue(propriedade, null) as TProp;
        }

        private static MemberExpression GetMemberExpression<T, TProp>(Expression<Func<T, TProp>> expression)
        {
            return (MemberExpression)expression.Body;
        }

        private static MemberExpression? GetMemberExpression(MemberExpression expression)
        {
            return expression?.Expression as MemberExpression;
        }

        private static PropertyInfo GetProperty<T, TProp>(Expression<Func<T, TProp>> expression)
        {
            return (PropertyInfo)GetMemberExpression(expression).Member;
        }

        private static bool? GetByComposing(MemberExpression expression)
        {
            return expression?.Expression?.NodeType.Equals(ExpressionType.MemberAccess);
        }
    }
}
