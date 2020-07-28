namespace UnityCsprojNuget.Editor.Application
{
    public interface ISolutionProcessor
    {
        string ProcessSolutionFile(string slnContent);
    }
}
