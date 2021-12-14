using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ColorContraster.ViewModels
{
    /// <summary>
    /// ViewModel to the analyser, for the main view
    /// </summary>
    class AnalyzerVM : INotifyPropertyChanged
    {
        #region events management
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void RatioMustChange()
        {
            OnChanged("Ratio");
            OnChanged("SmallTextAA");
            OnChanged("SmallTextAAA");
            OnChanged("LargeTextAA");
            OnChanged("LargeTextAAA");
        }
        private void ForegroundChange()
        {
            OnChanged("ForeColor");
            OnChanged("ForeRed");
            OnChanged("ForeGreen");
            OnChanged("ForeBlue");
            OnChanged("ForeHTML");
            RatioMustChange();
        }
        private void BackgroundChange()
        {
            OnChanged("BackColor");
            OnChanged("BackRed");
            OnChanged("BackGreen");
            OnChanged("BackBlue");
            OnChanged("BackHTML");
            RatioMustChange();
        }

        #endregion
        
        private Logic.Analyzer model;

        /// <summary>
        /// Init the viewmodel
        /// </summary>
        /// <param name="model">the model</param>
        public AnalyzerVM(Logic.Analyzer model)
        {
            this.model = model;
        }

        #region foreground properties

        public System.Windows.Media.Color ForeColor
        {
            get
            {
                return System.Windows.Media.Color.FromRgb(model.Foreground.Red, model.Foreground.Green, model.Foreground.Blue);
            }
            set
            {
                model.Foreground = new Logic.Color(value.R, value.G, value.B);
                ForegroundChange();
            }
        }        
        

        public byte ForeRed
        {
            get => model.Foreground.Red;
            set
            {
                model.Foreground.Red = value;
                ForegroundChange();
            }
        }

        public byte ForeBlue
        {
            get => model.Foreground.Blue;
            set
            {
                model.Foreground.Blue = value;
                ForegroundChange();
            }
        }

        public byte ForeGreen
        {
            get => model.Foreground.Green;
            set
            {
                model.Foreground.Green=value;
                ForegroundChange();
            }
        }

        public string ForeHTML
        {
            get => model.Foreground.HTMLCode;
            set
            {
                model.Foreground.HTMLCode = value;
                ForegroundChange();
            }
        }
        #endregion

        #region background properties
        public System.Windows.Media.Color BackColor
        {
            get
            {
                return System.Windows.Media.Color.FromRgb(model.Background.Red, model.Background.Green, model.Background.Blue);
            }
            set
            {
                model.Background = new Logic.Color(value.R, value.G, value.B);
                BackgroundChange();
            }
        }

        public byte BackRed
        {
            get => model.Background.Red;
            set
            {
                model.Background.Red = value;
                BackgroundChange();
            }
        }

        public byte BackGreen
        {
            get => model.Background.Green;
            set
            {
                model.Background.Green = value;
                BackgroundChange();
            }
        }

        public byte BackBlue
        {
            get => model.Background.Blue;
            set
            {
                model.Background.Blue = value;
                BackgroundChange();
            }
        }

        public string BackHTML
        {
            get => model.Background.HTMLCode;
            set
            {
                model.Background.HTMLCode = value;
                BackgroundChange();
            }
        }
        #endregion

        #region WCAG properties
        public string Ratio
        {
            get
            {
                return string.Format("{0:F}:1", model.Ratio);
            }
        }

        private const string baseuri = "pack://application:,,,/ColorContraster;component/Img/";
        public BitmapImage SmallTextAA
        {
            get
            {
                
                string uri = baseuri + ((model.SmallTextAA) ? "ok.png" : "nok.png");
                BitmapImage bmp = new BitmapImage(new Uri(uri));
                return bmp;
            }
        }
        public BitmapImage SmallTextAAA
        {
            get
            {

                string uri = baseuri  + ((model.SmallTextAAA) ? "ok.png" : "nok.png");
                BitmapImage bmp = new BitmapImage(new Uri(uri));
                return bmp;
            }
        }
        public BitmapImage LargeTextAA
        {
            get
            {

                string uri = baseuri + ((model.LargeTextAA) ? "ok.png" : "nok.png");
                BitmapImage bmp = new BitmapImage(new Uri(uri));
                return bmp;
            }
        }
        public BitmapImage LargeTextAAA
        {
            get
            {

                string uri = baseuri + ((model.LargeTextAAA) ? "ok.png" : "nok.png");
                BitmapImage bmp = new BitmapImage(new Uri(uri));
                return bmp;
            }
        }
        #endregion
    }
}
