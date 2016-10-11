using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOsLibrary
{
    public class ArtworkManager
    {
        public const string OUT_OF_RANGE_INDEX = "{0} is invalid position. Must be between 0 and {1}";
        private const string DefaultCategory = "Sky";
        private readonly Artwork[] gallery;
        private int currentIndex;
        private readonly int lastIndex;
        
        public ArtworkManager() :this(DefaultCategory){}

        public ArtworkManager(string categoryTitle)
        {
            switch (categoryTitle)
            {
                case "Sky":
                    gallery = InitSkyGallery();
                    break;
                case "Landscape":
                    gallery = InitLandscapeGallery();
                    break;
                case "Water":
                    gallery = InitWaterGallery();
                    break;
            }

            if (gallery != null)
            {
                lastIndex = gallery.Length - 1;
            }
            
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
                //throw new IndexOutOfRangeException(
                //    String.Format(OUT_OF_RANGE_INDEX,
                //    position, lastIndex));
                throw new IndexOutOfRangeException(OUT_OF_RANGE_INDEX);
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

       
        private Artwork[] InitWaterGallery()
        {
            return new Artwork[]
            {
                new Artwork()
                {
                    Title = "Berg",
                    Description = "Berg aus der Water Gallery beschreibung",
                    Image = "back_0"
                },
                new Artwork()
                {
                    Title = "Stadt",
                    Description = "Stadt aus der Water Gallery beschreibung",
                    Image = "back_3"
                },
                new Artwork()
                {
                    Title = "Land",
                    Description = "Land aus der Water Gallery beschreibung",
                    Image = "back_2"
                },
                new Artwork()
                {
                    Title = "Fluss",
                    Description = "Fluss aus der Water Gallery beschreibung",
                    Image = "back_1"
                },
            };
        }

        private Artwork[] InitLandscapeGallery()
        {
            return new Artwork[]
            {
                new Artwork()
                {
                    Title = "Fluss",
                    Description = "Fluss aus der Landscape Gallery beschreibung",
                    Image = "back_1"
                },
                new Artwork()
                {
                    Title = "Berg",
                    Description = "Berg aus der Landscape Gallery beschreibung",
                    Image = "back_0"
                },
                new Artwork()
                {
                    Title = "Stadt",
                    Description = "Stadt aus der Landscape Gallery beschreibung",
                    Image = "back_3"
                },
                new Artwork()
                {
                    Title = "Land",
                    Description = "Land aus der Landscape Gallery beschreibung",
                    Image = "back_2"
                }
            };
        }

        private Artwork[] InitSkyGallery()
        {
            return new Artwork[]
            {
                new Artwork()
                {
                    Title = "Stadt",
                    Description = "Stadt aus der Sky Gallery beschreibung",
                    Image = "back_3"
                },
                new Artwork()
                {
                    Title = "Berg",
                    Description = "Berg aus der Sky Gallery beschreibung",
                    Image = "back_0"
                },
                new Artwork()
                {
                    Title = "Land",
                    Description = "Land aus der Sky Gallery beschreibung",
                    Image = "back_2"
                },
                new Artwork()
                {
                    Title = "Fluss",
                    Description = "Fluss aus der Sky Gallery beschreibung",
                    Image = "back_1"
                }
            };
        }
    }
}
