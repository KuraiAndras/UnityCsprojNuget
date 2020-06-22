namespace UnityCsprojNuget.Editor.Bll
{
    internal interface IProjectCreator
    {
        void InitializeProject(string asmFileName, bool overwrite);
    }
}