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
        public ViewPager viewPager;

        public static int NB_IMAGES = 5;
        public static int PREMIERE_IMG = 2;
        public static int ECART_ENTRE_IMG = -350;
        public static int NB_PAGES_CHARGEES = 5;
        public static float TAILLE_MIN = 0.5f;
        public static float TAILLE_MAX = 1.0f;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);
            viewPager = FindViewById<ViewPager>(Resource.Id.myViewpager);
            imagesAction listeImages = new imagesAction();
            
            MyViewPager adapter = new MyViewPager(SupportFragmentManager, listeImages, this );
            viewPager.Adapter = adapter;
            viewPager.PageMargin = ECART_ENTRE_IMG;
            viewPager.SetOnPageChangeListener(adapter);
            viewPager.OffscreenPageLimit = NB_PAGES_CHARGEES;

            viewPager.SetCurrentItem(PREMIERE_IMG, true);
            
        }
    }
}

