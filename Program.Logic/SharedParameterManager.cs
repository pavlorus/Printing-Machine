using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Program.Logic
{
    class SharedParameterManager
    {

        public string SharedFileName { get; set; }
        public string FilePathToSharedFile { get; set; }

        private string _exsistingSharedParameter = string.Empty;

        public Application AplicationRvt { get; set; }

        public SharedParameterManager()
        {

        }

        public SharedParameterManager(Application app, string sharedFileName, string filePathToSharedFile)
        {
            AplicationRvt = app;
            SharedFileName = sharedFileName;
            FilePathToSharedFile = filePathToSharedFile;
            GetExistingSharedParameterFile();
        }

        public void AddExistingSharedParameter(string groupOfSharedParam, string name, CategorySet cats, BuiltInParameterGroup group, bool inst)

        {
            try
            {
                AplicationRvt.SharedParametersFilename = GetNewSharedParameterFilePath();
                DefinitionFile defFile = AplicationRvt.OpenSharedParameterFile();
                if (defFile == null) throw new Exception("No SharedParameter File!");

                DefinitionGroups myGroups = defFile.Groups;
                DefinitionGroup myGroup = myGroups.get_Item(groupOfSharedParam);
                ExternalDefinition def = null;
                if (myGroup == null) throw new Exception("The group doesn't exist. Inspect name of group");
                def = myGroup.Definitions.get_Item(name) as ExternalDefinition;
                if (def == null) throw new Exception("The parameter doesnt exist");

                Binding binding = AplicationRvt.Create.NewTypeBinding(cats);
                if (inst) binding = AplicationRvt.Create.NewInstanceBinding(cats);

                BindingMap map = (new UIApplication(AplicationRvt)).ActiveUIDocument.Document.ParameterBindings;
                map.Insert(def, binding, group);
                SetExistingSharedParameterFile();
            }
            finally
            {
                SetExistingSharedParameterFile();
            }
        }

        private void GetExistingSharedParameterFile()
        {
            _exsistingSharedParameter = AplicationRvt.SharedParametersFilename;
        }
        private void SetExistingSharedParameterFile()
        {
            AplicationRvt.SharedParametersFilename = _exsistingSharedParameter;
        }

        private string GetNewSharedParameterFilePath()
        {
            return FilePathToSharedFile + SharedFileName;
        }
    }
}