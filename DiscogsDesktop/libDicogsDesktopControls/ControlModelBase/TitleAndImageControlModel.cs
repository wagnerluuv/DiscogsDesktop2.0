using System;
using System.Drawing;
using System.Windows;
using JetBrains.Annotations;

namespace libDicogsDesktopControls.ControlModelBase
{
    public abstract class TitleAndImageControlModel : DependencyObject
    {
        public string Title
        {
            get { return (string)this.GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title), typeof(string), typeof(TitleAndImageControlModel), new PropertyMetadata());

        public event Action ImageLoaded;

        private Image image;

        public Image Image
        {
            get => this.image;
            set
            {
                this.image = value;
                this.ImageLoaded?.Invoke();
            }
        }
        
        public abstract void StartImageLoading();
    }
}