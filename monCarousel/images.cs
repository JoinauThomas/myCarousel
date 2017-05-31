using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace monCarousel
{
    public class images
    {
        public string image;
        public string titreImage;
        public int positionImg;

        public string Image
        {
            get { return image; }
        }
        public string TitreImage
        {
            get { return titreImage; }
        }
        public int PositionImg
        {
            get { return positionImg; }
        }
    }

    public class imagesAction
    {
        int nbPhotos = MainActivity.NB_IMAGES;
        
        private static images[] createTable()
        {
            int nbPhotos = MainActivity.NB_IMAGES;

            images[] table = new images[nbPhotos];
            int x = 0;
            while (x < nbPhotos)
            {
                table[x] = new images { image = "photo" + x, titreImage = "photo" + x, positionImg = x + 1 };
                x++;
            }
            return table;
        }

        static images[] CreateTableImage = createTable();

        private images[] mesImages;

        public imagesAction()
        {
            mesImages = CreateTableImage;
        }

        public images this[int i] { get { return mesImages[i]; } }

        public int nbImages { get { return mesImages.Length; } }
    }
}