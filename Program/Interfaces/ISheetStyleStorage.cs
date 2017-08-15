namespace Program.Logic

{
    interface ISheetStyleStorage
    {
         string PrintStyle { get; set; }

         string PaperSize { get; set; }

        int Orientation { get; set; }

        int Appearence { get; set; }

        int PaperHeight { get; set; }

         int PaperLength { get; set; }

    }
}
