using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic
{
    /// <summary>
    /// The main logic class
    /// </summary>
    [DataContract] public class Analyzer
    {
        [DataMember] private Color foreground;
        [DataMember] private Color background;

        public Analyzer()
        {
            foreground = new Color(255, 255, 255);
            background = new Color(0,0,0);
        }

        /// <summary>
        /// Gets or sets the fore color
        /// </summary>
        public Color Foreground { get => foreground; set => foreground = value; }
        /// <summary>
        /// Gets or sets the back color
        /// </summary>
        public Color Background { get => background; set => background = value; }

        /// <summary>
        /// Gets the constrast ratio between foreground & background color
        /// If both colors not set, the ratio is equal to NaN
        /// </summary>        
        public double Ratio
        {
            get
            {
                double val = double.NaN;
                if ( (background!=null) && (foreground!=null))
                {
                    val = (foreground.Luminance + 0.05) / (background.Luminance + 0.05);
                    if (val < 1.0)
                        val = 1.0 / val;
                }
                    
                return val;
            }
        }

        /*
 *  LE WCAG recommande comme ratio correct
 *  Petit texte : 4.5 (AA) 7 (AAA)
 *  Grand texte : 3 (AA)  4.5 (AAA)
 */

        /// <summary>
        /// Tells if the contrast of small text is ok (AA)
        /// </summary>
        public bool SmallTextAA
        {
            get => Ratio>=4.5;
        }

        /// <summary>
        /// Tells if the contrast of small text is ok (AAA)
        /// </summary>
        public bool SmallTextAAA
        {
            get => Ratio>=7;
        }

        /// <summary>
        /// Tells if the contrast of large text is ok (AA)
        /// </summary>
        public bool LargeTextAA
        {
            get => Ratio>=3;
        }

        /// <summary>
        /// Tells if the contrast of large text is ok (AAA)
        /// </summary>
        public bool LargeTextAAA
        {
            get => Ratio>=4.5;
        }
    }
}
