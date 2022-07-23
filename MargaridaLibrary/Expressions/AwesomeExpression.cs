using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.Util.Expressions
{
    public class AwesomeExpression<T1,T2>
    {
        private Expression<Func<T1, T2>> expression;
        private T1? input;
        private T2? value;

        public static implicit operator Action<T1>(AwesomeExpression<T1, T2> awesome)
        {
            return Expression.Lambda<Action<T1>>(Expression
                        .MakeBinary(ExpressionType.Assign,
                                    awesome.expression.Body,
                                    Expression.Constant(awesome.value)),
                                    awesome.expression.Parameters).Compile();
        }

        public static implicit operator T1?(AwesomeExpression<T1, T2> awesome)
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
            ((Action<T1>)this)(input ?? throw new ArgumentNullException(nameof(input)));
            return this;
        }

        public AwesomeExpression<T1, T2> Action(Expression<Action<T1>> expression)
        {
            var action = expression.Compile();
            action(input ?? throw new ArgumentNullException(nameof(input)));
            return this;
        }
    }
}
