using System;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using monCarousel;
using Android.Support.V4.View;

namespace FlashCardPager
{
    public class MyViewPager : FragmentPagerAdapter, ViewPager.IOnPageChangeListener
    {
        public static int CurrentPage;
        public imagesAction monImg;
        private Android.Support.V4.App.FragmentManager fm;
        private MainActivity context;
        private static float tailleMin = MainActivity.TAILLE_MIN;
        private static float tailleMax = MainActivity.TAILLE_MAX;
        private static float tailleDiff = tailleMax - tailleMin;

        public MyViewPager(Android.Support.V4.App.FragmentManager fm, imagesAction monImage, MainActivity context) : base(fm)
        {
            this.monImg = monImage;
            this.fm = fm;
            this.context = context;
        }

        public override int Count
        {
            get { return monImg.nbImages; }
        }

        void ViewPager.IOnPageChangeListener.OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            LinearLayout prevprev = getRootView(position - 1);
            LinearLayout prev = getRootView(position);
            LinearLayout cur = getRootView(position + 1);
            LinearLayout next = getRootView(position + 2);


            if (prevprev != null)
            {
                prevprev.ScaleX = tailleMin;
                prevprev.ScaleY = tailleMin;

            }
            if (prev != null)
            {
                prev.ScaleX = tailleMax - (tailleDiff * positionOffset);
                prev.ScaleY = tailleMax - (tailleDiff * positionOffset);
                prev.TranslationZ = 10 - 10 * positionOffset;


            }

            if (cur != null)
            {
                cur.ScaleX = tailleMin + (tailleDiff * positionOffset);
                cur.ScaleY = tailleMin + (tailleDiff * positionOffset);
                cur.TranslationZ = 0 + 10 * positionOffset;
            }

            if (next != null)
            {
                next.ScaleX = tailleMin;
                next.ScaleY = tailleMin;

            }
        }

        void ViewPager.IOnPageChangeListener.OnPageScrollStateChanged(int state)
        {
            Console.WriteLine(state);
        }

        void ViewPager.IOnPageChangeListener.OnPageSelected(int position)
        {
            fragmentImg.SetPosition(position);
        }



        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            var frag = (Android.Support.V4.App.Fragment)fragmentImg.newInstance(monImg[position].image, monImg[position].titreImage, position);
            return frag;
        }

        public View GetView(int position)
        {
            View c;
            try
            {
                Fragment x = GetItem(position);
                c = x.View;
            }
            catch (Exception ex)
            {
                return null;
            }

            return c;
        }

        private LinearLayout getRootView(int position)
        {
            LinearLayout ly;
            try
            {
                ly = (LinearLayout)fm.FindFragmentByTag(this.getFragmentTag(position)).View.FindViewById(Resource.Id.myLinµLayout);
            }
            catch (Exception ex)
            {
                return null;
            }
            return ly;
        }
        private String getFragmentTag(int position)
        {
            return "android:switcher:" + context.viewPager.Id + ":" + position;
        }





    }
}