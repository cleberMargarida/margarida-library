using Margarida.Util.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.Util.Helpers.Internal
{
    public abstract class AwesomeTryCatAbstract
    {
        protected Queue<AwesomeTryCatInternalAbstract> queue;
        protected Action finalizator;

        public AwesomeTryCatAbstract()
        {
            queue = new Queue<AwesomeTryCatInternalAbstract>();
            finalizator = () => { };
        }
    }

    public class AwesomeTryCat : AwesomeTryCatAbstract
    {
        private int attempts;
        private TimeSpan delay;
        private Action action;

        public AwesomeTryCat(Action action) : base()
        {
            this.action = action;
        }

        public AwesomeTryCat Attempts(int attempts = 1, TimeSpan delay = default)
        {
            this.attempts = attempts;
            this.delay = delay;
            return this;
        }

        public void Execute()
        {
            Exception? localEx = default;

            try 
            {
                action();
            }
            catch (Exception ex) 
            {
                localEx = ex; 
            }

            attempts.Repeat(() => queue.ForEach(item =>
            {
                if (item.MustIgnore) return;

                if (localEx != null && item.Option.Attend(localEx))
                    item.ApplyAction(localEx);

                Thread.Sleep(delay);
            }));

            finalizator();
        }

        public AwesomeTryCat IgnoreFails()
        {
            queue.Enqueue(new AwesomeTryCatInternal(() => { }));
            return this;
        }

        public AwesomeTryCat Catch(Action catchCall)
        {
            queue.Enqueue(new AwesomeTryCatInternal(catchCall));
            return this;
        }

        public AwesomeTryCat CatchType<T>(Action<T> catchCall)
            where T : Exception
        {
            queue.Enqueue(new AwesomeTryCatInternal<T>(catchCall));
            return this;
        }

        public AwesomeTryCat On(Expression<Func<TryCatchOptions, bool>> options)
        {
            var local = new TryCatchOptions();
            options.To(local).Assign(true);
            queue.Last().Option = local;
            return this;
        }

        public AwesomeTryCat On(Expression<Action<TryCatchOptions>> options)
        {
            var local = new TryCatchOptions();
            options.Compile().Invoke(local);
            queue.Last().Option = local;
            return this;
        }

        public AwesomeTryCat Finally(Action action)
        {
            this.finalizator = action;
            return this;
        }
    }

    public class TryCatchOptions
    {
        protected System.Type? specificType;
        protected Func<Exception, bool>? followingPredicate;

        public bool AnyFailure { get; set; }
        public bool ExistInnerException { get; set; }
        protected bool TypeSpecified { get; set; }
        protected bool FollowingSpecified { get; set; }

        public void OfType<T>()
        {
            TypeSpecified = true;
            specificType = typeof(T);
        }

        public void Following(Func<Exception, bool> predicate)
        {
            FollowingSpecified = true;
            followingPredicate = predicate;
        }

        internal bool Attend(Exception ex)
        {
            if (AnyFailure) return true;
            if (ExistInnerException) return ex?.InnerException != null;
            if (TypeSpecified) return specificType == ex.GetType();
            if (FollowingSpecified) return followingPredicate != null && followingPredicate(ex);
            return false;
        }
    }
}
