using Utilities;

namespace Program.Logic
{
    class NamingStyle
    {   // I think I need to delete this class, becouse I don't know where use this solution.
        public string SheetId { get; set; }

        public string SheetName { get; set; }

        private string ReplacingCharacter="_";

        public NamingStyle(string sheetId,  string sheetName)
        {
            SheetId = sheetId;
            SheetName = TextCorrection.DeleteSpecificCharacters(sheetName, ReplacingCharacter);
        }
        
    }
}