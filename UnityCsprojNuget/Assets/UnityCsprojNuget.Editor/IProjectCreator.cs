namespace UnityCsprojNuget.Editor
{
    internal interface IProjectCreator
    {
        void InitializeProject(string asmFileName, bool overwrite);
    }
}