using NUnit.Framework;
using UnityCsprojNuget.Editor.Application;
using UnityCsprojNuget.Editor.Domain;

namespace UnityCsprojNuget.Tests
{
    public class SlnTests
    {
        [TestCase(SlnStrings.Empty, false, SlnStrings.Empty)]
        [TestCase(SlnStrings.Empty, true, SlnStrings.Filled)]
        public void TestSlnModification(string inputSln, bool addToSolution, string expectedSln)
        {
            // Arrange
            var options = new NugetOptions { AddProjectsToSolution = addToSolution };
            var processor = SolutionProcessor.CreateDefault(options);

            // Act
            var updatedSln = processor.ProcessSolutionFile(inputSln);

            // Assert
            Assert.AreEqual(SlnStrings.CreateNormalized(expectedSln), SlnStrings.CreateNormalized(updatedSln));
        }
    }
}
