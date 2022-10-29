using NetArchTest.Rules;

namespace wwimporters.UnitTests
{
    public class ArchitectureTests
    {
        private const string ApiNamespace = "wwimporters.api";
        private const string DomainNamespace = "wwimporters.domain";
        private const string EFMigrationsNamespace = "wwimporters.efmigrations";
        private const string InfrastructureNamespace = "wwimporters.infrastructure";


        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            var assembly = typeof(domain.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
                ApiNamespace,
                EFMigrationsNamespace,
                InfrastructureNamespace
            };

            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Infrastructure_Should_HaveDependencyOnDomain()
        {
            var assembly = typeof(infrastructure.AssemblyReference).Assembly;

            var testResult = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("EntityConfiguration")
                .Or()
                .HaveNameEndingWith("Context")
                .Should()
                .HaveDependencyOn(DomainNamespace)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Infrastructure_Should_Not_HaveDependencyOnAnyOtherProjects()
        {

            var assembly = typeof(infrastructure.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
                ApiNamespace,
                EFMigrationsNamespace
            };

            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void EFMigrations_Should_HaveDependencyOnInfrastructure()
        {

            var assembly = typeof(efmigrations.AssemblyReference).Assembly;

            var testResult = Types
                .InAssembly(assembly)
                .That()
                .ResideInNamespace("*Migrations*")
                .Should()
                .HaveDependencyOn(InfrastructureNamespace)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void EFMigrations_Should_Not_HaveDependencyOnAnyOtherProjects()
        {

            var assembly = typeof(efmigrations.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
                ApiNamespace,
                DomainNamespace
            };

            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}