using System;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Meta
{
    public class EnvironmentSetupFacts
    {
        [Fact]
        public void MustHaveEnvironmentVariableSet()
        {
            string exampleDataPath = Environment.GetEnvironmentVariable("BUILD_ARGDATA_EXAMPLEDATA");

            exampleDataPath.Should()
                .NotBeNullOrEmpty("the environment variable BUILD_ARGDATA_EXAMPLEDATA must be set for the integration tests to work");
        }
    }
}
