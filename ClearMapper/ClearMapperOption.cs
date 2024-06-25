using System;
using System.Collections.Generic;

namespace ClearMapperLibrary
{
    public sealed class ClearMapperOption
    {
        protected List<Delegate> configurations = new List<Delegate>();

        public void AddConfiguration<TSource, TDestination>(Func<TSource, TDestination> i)
            where TSource : class
            where TDestination : class
        {
            configurations.Add(i);
        }

        internal List<Delegate> getConfigurations()
        {
            return configurations;
        }
    }

}


