using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.Util.Linq
{
    public class AwesomeExpression<T1,T2>
    {
        private Expression<Func<T1, T2>> expression;
        private T1 input;
        private T2 value;

        public static implicit operator Action<T1>(AwesomeExpression<T1, T2> awesome)
        {
            return Expression.Lambda<Action<T1>>(Expression
                        .MakeBinary(ExpressionType.Assign,
                                    awesome.expression.Body,
                                    Expression.Constant(awesome.value)),
                                    awesome.expression.Parameters).Compile();
        }

        public static implicit operator T1(AwesomeExpression<T1, T2> awesome)
        {
            return awesome.input;
        }

        public AwesomeExpression(Expression<Func<T1, T2>> expression)
        {
            this.expression = expression;
        }

        public AwesomeExpression(Expression<Func<T1, T2>> expression, T2 value) : this(expression)
        {
            this.value = value;
        }

        public AwesomeExpression(Expression<Func<T1, T2>> expression, T1 input) : this(expression)
        {
            this.input = input;
        }

        public AwesomeExpression<T1, T2> To(T1 input)
        {
            ((Action<T1>)this)(input);
            this.input = input;
            return this;
        }

        public AwesomeExpression<T1, T2> Assign(T2 value)
        {
            this.value = value;
            ((Action<T1>)this)(input);
            return this;
        }

        public AwesomeExpression<T1, T2> Execute(Expression<Action<T1>> expression)
        {
            var action = expression.Compile();
            action(input);
            return this;
        }
    }

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
    }
}
