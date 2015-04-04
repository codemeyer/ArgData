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
            string exampleDataEnvironment = Environment.GetEnvironmentVariable("BUILD_ARGDATA_EXAMPLEDATA");

            exampleDataEnvironment.Should()
                .NotBeNullOrEmpty("the environment variable BUILD_ARGDATA_EXAMPLEDATA must be set for the integration tests to work");
        }
    }
}
