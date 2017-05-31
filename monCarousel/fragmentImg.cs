using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
namespace monCarousel
{
    public class fragmentImg : Android.Support.V4.App.Fragment
    {
        

        public fragmentImg()
        {

        }
        
        public static fragmentImg newInstance(string img, string titImg, int position )
        {
            Bundle arg = new Bundle();
            arg.PutString("frag_image", img);
            arg.PutString("frag_TitreImg", titImg);
            arg.PutInt("frag_Position", position);

            fragmentImg monFragment = new fragmentImg();
            monFragment.Arguments = arg;
            return monFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            int firstPos = MainActivity.PREMIERE_IMG;
            float tailleMax = MainActivity.TAILLE_MAX;
            float tailleMin = MainActivity.TAILLE_MIN;

            string image = Arguments.GetString("frag_image", "");
            string titreImg = Arguments.GetString("frag_TitreImg", "");
            int position = Arguments.GetInt("frag_Position");

            View view = inflater.Inflate(Resource.Layout.myFragment, container, false);
            ImageView Image = (ImageView)view.FindViewById(Resource.Id.myImage);

            int resourceId = (int)typeof(Resource.Drawable).GetField(image).GetVa‌​lue(null);
            Image.SetImageResource(resourceId);
            Image.SetAdjustViewBounds(true);

            if (position == firstPos)
            {
                view.TranslationZ = 10;
                view.ScaleX = tailleMax;
                view.ScaleY = tailleMax;
            }
            else if (position == firstPos + 1 || position == firstPos - 1)
            {
                view.TranslationZ = 9;
                view.ScaleX = tailleMin;
                view.ScaleY = tailleMin;
            }
            else
            {
                view.TranslationZ = 8;
                view.ScaleX = tailleMin;
                view.ScaleY = tailleMin;
            }
            return view;
        }

    }
}