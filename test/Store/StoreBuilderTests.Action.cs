﻿using System;
using BlazorFocused.Test.Utility;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorFocused.Store.Test
{
    public partial class StoreBuilderTests
    {
        [Fact]
        public void ShouldRegisterActionByType()
        {
            storeBuilder.RegisterAction<TestAction>();

            var services = storeBuilder.BuildServices();

            Assert.NotNull(services.GetRequiredService<TestAction>());
        }

        [Fact]
        public void ShouldRegisterActionWithInputByType()
        {
            storeBuilder.RegisterAction<TestActionWithInput>();

            var services = storeBuilder.BuildServices();

            Assert.NotNull(services.GetRequiredService<TestActionWithInput>());
        }

        [Fact]
        public void ShouldRegisterActionByInstance()
        {
            var testAction = new TestAction { CheckedPropertyId = Guid.NewGuid().ToString() };

            storeBuilder.RegisterAction(testAction);

            var services = storeBuilder.BuildServices();

            var providerTestAction = services.GetRequiredService<TestAction>();

            Assert.Equal(testAction.CheckedPropertyId, providerTestAction.CheckedPropertyId);
        }

        [Fact]
        public void ShouldRegisterActionWithInputByInstance()
        {
            var testAction = new TestActionWithInput { CheckedPropertyId = Guid.NewGuid().ToString() };

            storeBuilder.RegisterAction(testAction);

            var services = storeBuilder.BuildServices();

            var providerTestAction = services.GetRequiredService<TestActionWithInput>();

            Assert.Equal(testAction.CheckedPropertyId, providerTestAction.CheckedPropertyId);
        }
    }
}
