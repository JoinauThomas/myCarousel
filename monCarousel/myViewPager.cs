using System;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using monCarousel;
using Android.Support.V4.View;

namespace FlashCardPager
{
    class MyViewPager : FragmentPagerAdapter, ViewPager.IOnPageChangeListener
    {
        void ViewPager.IOnPageChangeListener.OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            Console.WriteLine(positionOffset);
        }

        void ViewPager.IOnPageChangeListener.OnPageScrollStateChanged(int state)
        {
            Console.WriteLine(state);
        }

        void ViewPager.IOnPageChangeListener.OnPageSelected(int position)
        {
            Console.WriteLine(position);
        }
        public imagesAction monImg;
        public MyViewPager(Android.Support.V4.App.FragmentManager fm, imagesAction monImage)
            : base(fm)
        {
            this.monImg = monImage;
        }

        public override int Count
        {
            get { return monImg.nbImages; }
        }


        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return (Android.Support.V4.App.Fragment) fragmentImg.newInstance( monImg[position].image, monImg[position].titreImage, position );
            
        }

       
    }
}