using MasterDevs.Core.System;

namespace System.Linq.Expressions
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<T>(this Expression<Func<T>> exp)
        {
            MemberExpression body = exp.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }

        public static string GetPropertyName<T, V>(this Expression<Func<T, V>> exp)
        {
            MemberExpression body = exp.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }

        public static void OnPropertyChanged<TViewModel, TPropertyType>(
            this TViewModel viewModel,
            Expression<Func<TViewModel, TPropertyType>> propReference,
            Action<TViewModel> onChanged) where TViewModel : System.ComponentModel.INotifyPropertyChanged
        {
            var propName = propReference.GetPropertyName();
            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == propName)
                    onChanged.SafeInvoke(viewModel);
            };
        }
    }
}