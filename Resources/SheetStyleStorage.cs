using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Resources

{
    public enum PaperOrientation { Portrait, Landscape }

    public enum PaperAppearence { Color, Black, Grayscale }

    [Serializable]
    class SheetStyleStorage
    {
        public string PrintStyle { get; set; }

        public string PaperSize { get; set; }

        public int Orientation { get; set; }

        public int Appearence { get; set; }

        public int PaperHeight { get; set; }

        public int PaperLength { get; set; }

    }
}
