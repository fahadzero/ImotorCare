using IMotorCare.CustomControls;
using IMotorCare.Droid;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(GradientColorStack), typeof(GradientColorStackRenderer))]
namespace IMotorCare.Droid
{
    public class GradientColorStackRenderer : VisualElementRenderer<StackLayout>
    {
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }

        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {
            #region for Vertical Gradient    
            var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
            #endregion
            #region for Horizontal Gradient    
            //Android.Graphics.LinearGradient gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,
            #endregion
                StartColor.ToAndroid(),
             EndColor.ToAndroid(),
             Android.Graphics.Shader.TileMode.Mirror);

            Android.Graphics.Paint paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                GradientColorStack stack = e.NewElement as GradientColorStack;
                StartColor = stack.StartColor;
                EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }
    }
}