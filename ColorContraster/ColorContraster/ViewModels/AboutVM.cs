using System;
using System.Collections.Generic;
using System.Text;

namespace ColorContraster.ViewModels
{
    class AboutVM
    {
        public string Version
        {
            get
            {                
                return string.Format(Res.Strings.VersionNumber, GetType().Assembly.GetName().Version.ToString(2), 2023);
            }
        }
    }
}
