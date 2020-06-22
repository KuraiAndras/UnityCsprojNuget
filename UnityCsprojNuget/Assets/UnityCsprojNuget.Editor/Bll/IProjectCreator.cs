namespace UnityCsprojNuget.Editor.Bll
{
    public interface IProjectCreator
    {
        void InitializeProject(string asmFileName, bool overwrite);
    }
}