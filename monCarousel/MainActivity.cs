using Android.App;
using Android.Widget;
using Android.OS;

using Android.Support.V4.View;
using Android.Support.V4.App;
using FlashCardPager;

namespace monCarousel
{
    [Activity(Label = "monCarousel", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        public static int nbImages = 5;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.myViewpager);
            imagesAction listeImages = new imagesAction();
            
            MyViewPager adapter = new MyViewPager(SupportFragmentManager, listeImages);
            viewPager.Adapter = adapter;
            viewPager.PageMargin = -300;
            viewPager.SetOnPageChangeListener(adapter);
        }
    }
}

