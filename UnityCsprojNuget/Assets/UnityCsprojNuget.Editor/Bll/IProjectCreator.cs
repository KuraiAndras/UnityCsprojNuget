namespace UnityCsprojNuget.Editor.Bll
{
    public interface IProjectCreator
    {
        void InitializeProject(string asmdefPath, bool overwrite);
    }
}