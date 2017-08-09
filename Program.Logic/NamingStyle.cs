using Utilities;

namespace Program.Logic
{
    class NamingStyle
    {
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