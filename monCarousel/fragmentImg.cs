using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.App;
using Android.Graphics;
using static Android.Graphics.Bitmap;
using Android.Graphics.Drawables;
using static Android.Database.MatrixCursor;
using System.Threading.Tasks;
using Android.Content.Res;



namespace monCarousel
{
    public class fragmentImg : Android.Support.V4.App.Fragment
    {
        public static int positionImg;
        public static int qualiteImg = MainActivity.QUALITE_IMAGES;

        public fragmentImg()
        {

        }

        public static void SetPosition(int position)
        {
            positionImg = position;

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

            //////////////////////////////////////////////

            BitmapFactory.Options options = GetBitmapOptionsOfImage(image);

            Bitmap bitmapToDisplay = LoadScaledDownBitmapForDisplay(Resources, options, qualiteImg, qualiteImg, image);


            ///////////////////////////////////////////


            View view = inflater.Inflate(Resource.Layout.myFragment, container, false);
            ImageView Image = (ImageView)view.FindViewById(Resource.Id.myImage);

            Image.SetImageBitmap(bitmapToDisplay);
            //int resourceId = (int)typeof(Resource.Drawable).GetField(image).GetVa‌​lue(null);
            //Image.SetImageResource(resourceId);
            //Image.SetAdjustViewBounds(true);
            



            Image.Click += img_Click;



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
        public void img_Click(object sender, EventArgs e)
        {
            
            // creation du dialog
            AlertDialog.Builder myDialog = new AlertDialog.Builder(Context);
            
            myDialog.SetTitle("Title");
            //recupération de l'image
            
            myDialog.SetView(GetImage());
            // création du bouton dans le dialog
            myDialog.SetPositiveButton("Select", (senderAlert, args) =>
            {
                ////////////////////////////////////////
                /////  mettre l'action voulue ici  /////
                ////////////////////////////////////////

                Toast.MakeText(Context, "image selected!", ToastLength.Short).Show();
            });

            // affichage du dialogue
            myDialog.Show();



        }
        public View GetImage()
        {
            string image = Arguments.GetString("frag_image", "");

            ImageView img = new ImageView(Context);
            int resourceId = (int)typeof(Resource.Drawable).GetField("photo" + positionImg).GetVa‌​lue(null);

            BitmapFactory.Options options = GetBitmapOptionsOfImage(image);

            Bitmap bitmapToDisplay = LoadScaledDownBitmapForDisplay(Resources, options, 500, 500, image);

            img.SetImageBitmap(bitmapToDisplay);
            img.SetAdjustViewBounds(true);

            return img;
        }

       



        ////////////////////////////////////////////////////////////////////////////////////////////

        public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            // Raw height and width of image
            float height = options.OutHeight;
            float width = options.OutWidth;
            double inSampleSize = 1D;

            if (height > reqHeight || width > reqWidth)
            {
                int halfHeight = (int)(height / 2);
                int halfWidth = (int)(width / 2);

                // Calculate a inSampleSize that is a power of 2 - the decoder will use a value that is a power of two anyway.
                while ((halfHeight / inSampleSize) > reqHeight && (halfWidth / inSampleSize) > reqWidth)
                {
                    inSampleSize *= 2;
                }

            }

            return (int)inSampleSize;
        }

        public Bitmap LoadScaledDownBitmapForDisplay(Resources res, BitmapFactory.Options options, int reqWidth, int reqHeight, string image)
        {
            // Calculate inSampleSize
            options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);

            // Decode bitmap with inSampleSize set
            options.InJustDecodeBounds = false;

            int idImage = (int)typeof(Resource.Drawable).GetField(image).GetVa‌​lue(null);
            return BitmapFactory.DecodeResource(res, idImage, options);
        }

        BitmapFactory.Options GetBitmapOptionsOfImage(string image)
        {
            BitmapFactory.Options options = new BitmapFactory.Options
            {
                InJustDecodeBounds = true
            };

            // The result will be null because InJustDecodeBounds == true.
            int idImage = (int)typeof(Resource.Drawable).GetField(image).GetVa‌​lue(null);

            Bitmap result = BitmapFactory.DecodeResource(Resources, idImage, options);


            int imageHeight = options.OutHeight;
            int imageWidth = options.OutWidth;
            
            return options;
        }
    }
}