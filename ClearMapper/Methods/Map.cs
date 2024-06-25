using System.Collections.Generic;
using System.Linq;

namespace ClearMapperLibrary
{
    public partial class ClearMapper
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


