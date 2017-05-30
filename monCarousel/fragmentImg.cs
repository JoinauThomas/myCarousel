using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
namespace monCarousel
{
    public class fragmentImg : Android.Support.V4.App.Fragment
    {
        public static int currentPosition;

        public fragmentImg()
        {

        }
        
        public static fragmentImg newInstance(string img, string titImg, int position )
        {
            currentPosition = position;
            Console.WriteLine(position);
            Bundle arg = new Bundle();
            arg.PutString("frag_image", img);
            arg.PutString("frag_TitreImg", titImg);

            fragmentImg monFragment = new fragmentImg();
            monFragment.Arguments = arg;
            return monFragment;
        }

        public override View OnCreateView(
           LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            string image = Arguments.GetString("frag_image", "");
            string titreImg = Arguments.GetString("frag_TitreImg", "");

            View view = inflater.Inflate(Resource.Layout.myFragment, container, false);
            ImageView Image = (ImageView)view.FindViewById(Resource.Id.myImage);

            int resourceId = (int)typeof(Resource.Drawable).GetField(image).GetVa‌​lue(null);
            Image.SetImageResource(resourceId);
            Image.SetAdjustViewBounds(true);
            

            return view;
        }

    }
}