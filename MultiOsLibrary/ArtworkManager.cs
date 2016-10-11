using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOsLibrary
{
    public class ArtworkManager
    {
        private readonly Artwork[] gallery;
        private int currentIndex;
        private readonly int lastIndex;

        public ArtworkManager()
        {
            gallery = InitGallery();
            lastIndex = gallery.Length - 1;
        }

        public Artwork CurrentArtwork
        {
            get { return gallery[currentIndex]; }
        }

        public int Length {
            get { return gallery.Length; }
        } 
        public void MoveFirst()
        {
            currentIndex = 0;
        }
        public void MoveLast()
        {
            currentIndex = lastIndex;
        }
        public void MoveNext()
        {
            if (CanMoveNext)
            {
                ++currentIndex;
            }
        }
        public void MoveBack()
        {
            if (CanMoveBack)
            {
                --currentIndex;
            }
        }

        public void MoveTo(int position)
        {
            if (position >= 0 && position <= lastIndex)
            {
                currentIndex = position;
            }
            else
            {
                throw new IndexOutOfRangeException(
                    String.Format("{0} is invalid position. Must be between 0 and {1}",
                    position, lastIndex));
            }
        }

        public bool CanMoveBack
        {
            get { return currentIndex > 0; }
        }
        public bool CanMoveNext
        {
            get { return currentIndex < lastIndex; }
        }

        private Artwork[] InitGallery()
        {
            return new Artwork[]
            {
                new Artwork()
                {
                    Title = "Berg",
                    Description = "Berg beschreibung",
                    Image = "back_0"
                },
                new Artwork()
                {
                    Title = "Stadt",
                    Description = "Stadt beschreibung",
                    Image = "back_3"
                },
                new Artwork()
                {
                    Title = "Land",
                    Description = "Land beschreibung",
                    Image = "back_2"
                },
                new Artwork()
                {
                    Title = "Fluss",
                    Description = "Fluss beschreibung",
                    Image = "back_1"
                },
            };
        }
    }
}
