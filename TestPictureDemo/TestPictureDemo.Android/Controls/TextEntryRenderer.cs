using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestPictureDemo.Droid.Controls;
using TestPictureDemo.UI.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextEntry), typeof(TextEntryRenderer))]
namespace TestPictureDemo.Droid.Controls
{
    public class TextEntryRenderer : EditorRenderer
    {

        public TextEntryRenderer(Context context) : base(context)
        {

        }

        [Obsolete]
        public TextEntryRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);


            if (Control != null)
            {
                Control.Background = null;
                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(50, 30, 50, 30);
                SetPadding(50, 30, 50, 30);



            }

            if (e.NewElement == null || e.OldElement != null)
                return;

        }
    }
}