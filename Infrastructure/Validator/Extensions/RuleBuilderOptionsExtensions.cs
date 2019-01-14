using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Resources;
using FluentValidation.Validators;
using Infrastructure.Events;
using System;

namespace Infrastructure.Validator.Extensions
{
    public static class RuleBuilderOptionsExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithEvent<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Event @event)
        {
            return rule
                .WithErrorCode(@event.Code.ToString())
                .WithMessage(@event.Message);
        }

        public static IRuleBuilderOptions<T, TProperty> WithGlobalEvent<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Event @event)
        {
            foreach (var item in (rule as RuleBuilder<T, TProperty>).Rule.Validators)
            {
                item.Options.ErrorMessageSource = new StaticStringSource(@event.Message);
                item.Options.ErrorCodeSource = new StaticStringSource(@event.Code.ToString());
            }

            return rule;
        }
        public static IRuleBuilderOptions<T, TProperty> WithGlobalEvent<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Event @event, Func<T, TProperty, string> messageProvider)
        {
            foreach (var item in (rule as RuleBuilder<T, TProperty>).Rule.Validators)
            {
                item.Options.ErrorMessageSource = 
                    new LazyStringSource(context => messageProvider((T)context.InstanceToValidate, (TProperty)context.PropertyValue));

                item.Options.ErrorCodeSource = new StaticStringSource(@event.Code.ToString());
            }

            return rule;
        }

        public static IRuleBuilderOptions<T, TProperty> WithGlobalEvent<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Event @event, Func<TProperty, string> messageProvider)
        {
            foreach (var item in (rule as RuleBuilder<T, TProperty>).Rule.Validators)
            {
                item.Options.ErrorMessageSource =
                    new LazyStringSource(context => messageProvider((TProperty)context.PropertyValue));

                item.Options.ErrorCodeSource = new StaticStringSource(@event.Code.ToString());
            }

            return rule;
        }
    }
}
