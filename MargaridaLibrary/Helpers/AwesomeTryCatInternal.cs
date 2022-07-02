using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.Util.Helpers.Internal
{
    public abstract class AwesomeTryCatInternalAbstract
    {
        public TryCatchOptions Option { get; set; }
        public abstract bool MustIgnore { get;}

        public abstract void ApplyAction(Exception? ex);
    }

    public class AwesomeTryCatInternal : AwesomeTryCatInternalAbstract
    {
        public AwesomeTryCatInternal(Action? action)
        {
            Option = new();
            Action = action;
        }

        public override bool MustIgnore => Action is null;

        Action? Action { get; set; }

        public override void ApplyAction(Exception? ex)
        {
            if (Action == null) return;

            Action();
        }
    }

    public class AwesomeTryCatInternal<T> : AwesomeTryCatInternalAbstract
        where T : Exception
    {
        public AwesomeTryCatInternal(Action<T> action)
        {
            Option = new();
            Action = action;
        }

        public override bool MustIgnore => Action is null;

        Action<T>? Action { get; set; }

        public override void ApplyAction(Exception? ex)
        {
            var casted = ex as T;

            if (casted == null || Action == null) return;

            Action(casted);
        }
    }
}
