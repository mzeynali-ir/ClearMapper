using System.Collections.Generic;
using System.Linq;

namespace ClearMapperLibrary
{
    public interface IMapper
    {
        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
            where TSource : class
            where TDestination : class;

        IQueryable<TDestination> Map<TSource, TDestination>(IQueryable<TSource> source)
            where TSource : class
            where TDestination : class;

        TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class;

    }
}


