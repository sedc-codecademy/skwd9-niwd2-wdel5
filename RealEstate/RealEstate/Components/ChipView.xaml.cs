using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RealEstate.Components
{
    public partial class ChipView : ContentView
    {
        public event EventHandler ChipDeleted;

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                label.Text = value;
            }
        }

        public ChipView()
        {
            InitializeComponent();
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ChipDeleted?.Invoke(this, e);
        }
    }
}
