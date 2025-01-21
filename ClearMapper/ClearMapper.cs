using System;
using System.Collections.Generic;
using System.Linq;

namespace ClearMapperLibrary
{
    public sealed partial class ClearMapper : IClearMapper, IMapper
    {

        private readonly ClearMapperOption _option = new ClearMapperOption();
        private List<Delegate> configurations;

        public ClearMapper(Action<ClearMapperOption> op)
        {
            op.Invoke(_option);
            configurations = _option.getConfigurations();
        }

        /// <summary>
        /// scan from assembly
        /// </summary>
        public ClearMapper()
        {

            var profiles = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => t.IsSubclassOf(typeof(ClearMapperProfile)));

            foreach (Type t in profiles)
            {
                var instance = (ClearMapperProfile)Activator.CreateInstance(t, _option);
            }

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
                    throw new Exception($"Happened uncontrol exception in {nameof(ClearMapper)} library, call 911 :)");

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

            throw new Exception($"Happened uncontrol exception in {nameof(ClearMapper)} library, call 911 :)");
        }

    }
}


