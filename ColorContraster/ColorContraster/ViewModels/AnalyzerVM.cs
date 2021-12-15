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


        /// <summary>
        /// Couleur de 1er plan
        /// </summary>
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
        
        /// <summary>
        /// Composante rouge de la couleur de 1er plan
        /// </summary>

        public byte ForeRed
        {
            get => model.Foreground.Red;
            set
            {
                model.Foreground.Red = value;
                ForegroundChange();
            }
        }

        /// <summary>
        /// Composante bleue de la couleur de 1er plan
        /// </summary>
        public byte ForeBlue
        {
            get => model.Foreground.Blue;
            set
            {
                model.Foreground.Blue = value;
                ForegroundChange();
            }
        }

        /// <summary>
        /// Composante verte de la couleur de 1er plan
        /// </summary>
        public byte ForeGreen
        {
            get => model.Foreground.Green;
            set
            {
                model.Foreground.Green=value;
                ForegroundChange();
            }
        }

        /// <summary>
        /// Code HTML de la couleur de 1er plan
        /// </summary>
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
        /// <summary>
        /// Couleur d'arrière-plan
        /// </summary>
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


        /// <summary>
        /// Composante rouge de la couleur d'arrière-plan
        /// </summary>
        public byte BackRed
        {
            get => model.Background.Red;
            set
            {
                model.Background.Red = value;
                BackgroundChange();
            }
        }

        /// <summary>
        /// Composante verte de la couleur d'arrière-plan
        /// </summary>
        public byte BackGreen
        {
            get => model.Background.Green;
            set
            {
                model.Background.Green = value;
                BackgroundChange();
            }
        }

        /// <summary>
        /// Composante bleue de la couleur d'arrière-plan
        /// </summary>
        public byte BackBlue
        {
            get => model.Background.Blue;
            set
            {
                model.Background.Blue = value;
                BackgroundChange();
            }
        }

        /// <summary>
        /// Code HTML de la couleur d'arrière-plan
        /// </summary>
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
        /// <summary>
        /// Ratio de contraste
        /// </summary>
        public string Ratio
        {
            get
            {
                return string.Format("{0:F}:1", model.Ratio);
            }
        }

        private const string baseuri = "pack://application:,,,/ColorContraster;component/Img/";

        /// <summary>
        /// Image indiquant si le critère AA est validé ou non pour du texte normal
        /// </summary>
        public BitmapImage SmallTextAA
        {
            get
            {
                
                string uri = baseuri + ((model.SmallTextAA) ? "ok.png" : "nok.png");
                BitmapImage bmp = new BitmapImage(new Uri(uri));
                return bmp;
            }
        }
        /// <summary>
        /// Image indiquant si le critère AAA est validé ou non pour du texte normal
        /// </summary>
        public BitmapImage SmallTextAAA
        {
            get
            {

                string uri = baseuri  + ((model.SmallTextAAA) ? "ok.png" : "nok.png");
                BitmapImage bmp = new BitmapImage(new Uri(uri));
                return bmp;
            }
        }
        /// <summary>
        /// Image indiquant si le critère AA est validé ou non pour du texte agrandi
        /// </summary>
        public BitmapImage LargeTextAA
        {
            get
            {

                string uri = baseuri + ((model.LargeTextAA) ? "ok.png" : "nok.png");
                BitmapImage bmp = new BitmapImage(new Uri(uri));
                return bmp;
            }
        }
        /// <summary>
        /// Image indiquant si le critère AAA est validé ou non pour du texte agrandi
        /// </summary>
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
