using System;
using System.Collections.Generic;
using System.Linq;

namespace CleverMapperLibrary
{
    public sealed partial class CleverMapper
    {

        private readonly CleverMapperOption _option = new CleverMapperOption();
        private List<Delegate> configurations;

        public CleverMapper(Action<CleverMapperOption> op)
        {
            op.Invoke(_option);
            configurations = _option.getConfigurations();
        }

        private Func<TSource, TDestination> findConfig<TSource, TDestination>()
        {
            var funcs = configurations.Where(i =>
                i.Method.ReturnType == typeof(TDestination)
                && i.Method.GetParameters().First().ParameterType == typeof(TSource)
                && i.Method.GetParameters().Count() == 1
            );

            var countOfFuncs = funcs.Count();

            if (countOfFuncs == 1)
            {
                var finalFunc = funcs.First();
                var config = finalFunc as Func<TSource, TDestination>;
                if (config is null)
                    throw new Exception($"Happened uncontrol exception in {nameof(CleverMapper)} library, call 911 :)");

                return config;
            }

            if (countOfFuncs > 1)
                throw new Exception(
                    $"Conflicted in select of config. " +
                    $"because fount of ({countOfFuncs}) configurations for map from '{typeof(TSource).Name}' to '{typeof(TDestination).Name}'"
                    );

            if (countOfFuncs == 0)
                throw new Exception(
                    $"Not found configuration of map from '{typeof(TSource).Name}' to '{typeof(TDestination).Name}'"
                    );

            throw new Exception($"Happened uncontrol exception in {nameof(CleverMapper)} library, call 911 :)");
        }

    }


    public partial class CleverMapper
    {

        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
            where TSource : class
            where TDestination : class
        {

            var config = findConfig<TSource, TDestination>();
            var destination = source.Select(config);

            return destination;

        }

        public IQueryable<TDestination> Map<TSource, TDestination>(IQueryable<TSource> source)
             where TSource : class
             where TDestination : class
        {

            var config = findConfig<TSource, TDestination>();
            var destination = source.Select(x => config(x));

            return destination;

        }

        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {

            var config = findConfig<TSource, TDestination>();
            var destination = config(source);

            return destination;

        }

    }
}


