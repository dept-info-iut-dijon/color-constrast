using System;

namespace Logic
{
    class ColorException : Exception { }
    class BadHTMLCode : ColorException { }

    /// <summary>
    /// Simple color
    /// </summary>
    public class Color
    {
        private byte red, green, blue;

        private void FromInt(int rvb)
        {
            red = (byte)((rvb & 0xFF0000) >> 16);
            green = (byte)((rvb & 0x00FF00) >> 8);
            blue = (byte)((rvb & 0x0000FF));
        }

        /// <summary>
        /// Init a color
        /// </summary>
        /// <param name="r">red value</param>
        /// <param name="g">green value</param>
        /// <param name="b">blue value</param>
        public Color(byte r=0, byte g=0, byte b=0)
        {
            red = r; green = g; blue = b;
        }

        /// <summary>
        /// Init a color
        /// </summary>
        /// <param name="c">another color</param>
        public Color(Color c)
        {
            red = c.red; green = c.green; blue = c.blue;
        }

        /// <summary>
        /// Init a color
        /// </summary>
        /// <param name="rvb">32-bits RVB</param>
        public Color(int rvb)
        {
            FromInt(rvb);
        }
        

        /// <summary>
        /// Gets or sets red value
        /// </summary>
        public byte Red {get => red; set => red = value; }
        /// <summary>
        /// Gets or sets green value
        /// </summary>
        public byte Green { get => green; set => green = value; }        
        /// <summary>
        /// Gets or sets blue value
        /// </summary>
        public byte Blue { get => blue; set => blue = value; }

        private static double CalculComp(byte c)
        {
            double cc = c / 255.0;
            if (cc <= 0.03928)
                cc = cc / 12.92;
            else
                cc = Math.Pow(((cc + 0.055) / 1.055), 2.4);
            return cc;
        }
        /// <summary>
        /// Gets the relative luminance
        /// </summary>
        public double Luminance
        {
            get
            {
                double r = CalculComp(red);
                double v = CalculComp(green);
                double b = CalculComp(blue);                
                return 0.2126*r + 0.7152*v + 0.0722*b;
            }
        }
        

        /// <summary>
        /// Gets or sets the HTML code of color
        /// </summary>
        public string HTMLCode
        {
            get => string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
            set
            {
                if (value == null || value.Length != 7 || value[0] != '#')
                    throw new BadHTMLCode();
                string temp = value.Replace("#", "0x");
                int val = Convert.ToInt32(temp, 16);
                FromInt(val);                
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Color color &&
                   red == color.red &&
                   green == color.green &&
                   blue == color.blue;
        }
    }
}
