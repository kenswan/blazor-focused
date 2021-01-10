﻿using BlazoRx.Core.Store;
using BlazoRx.Core.Test.Model;
using BlazoRx.Core.Test.Utility;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazoRx.Core.Test.Store
{
    public partial class StoreTests
    {
        [Fact(DisplayName = "Should reduce state value")]
        public void ShouldReduceStateValue()
        {
            var originalClass = SimpleClassUtilities.GetRandomSimpleClass();
            var originalReducedClass = new TestReducer().Execute(originalClass);
            var updatedClass = SimpleClassUtilities.GetRandomSimpleClass();
            var updatedReducedClass = new TestReducer().Execute(updatedClass);
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddStore(originalClass, builder =>
            {
                builder.RegisterReducer(new TestReducer());
                return builder;
            });

            var provider = serviceCollection.BuildServiceProvider();
            var store = provider.GetRequiredService<IStore<SimpleClass>>();
            SimpleClassSubset actualReducedState = default;

            store.Reduce<SimpleClassSubset>(reducedState =>
            {
                actualReducedState = reducedState;
            });

            actualReducedState.Should().BeEquivalentTo(originalReducedClass);

            store.SetState(updatedClass);

            actualReducedState.Should().BeEquivalentTo(updatedReducedClass);
        }
    }
}