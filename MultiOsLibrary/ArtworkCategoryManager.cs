using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOsLibrary
{
    public class ArtworkCategoryManager
    {
        private readonly ArtworkCategory[] categories;
        private int currentIndex = 0;
        private readonly int lastIndex;

        public ArtworkCategoryManager()
        {
            categories = InitCategories();
            lastIndex = categories.Length - 1;
        }

        private ArtworkCategory[] InitCategories()
        {
            var initCategories = new ArtworkCategory[] {
                new ArtworkCategory()
                {
                    Title = "Landscape",
                    Description = "Amazing landscape pictures"
                },
                new ArtworkCategory()
                {
                    Title = "Water",
                    Description = "Amazing water pictures"
                },
                new ArtworkCategory()
                {
                    Title = "Sky",
                    Description = "Amazing sky pictures"
                }
            };

            return initCategories;
        }

        public int Length
        {
            get { return categories.Length; }
        }

        public void MoveFirst()
        {
            currentIndex = 0;
        }

        public void MoveNext()
        {
            if (currentIndex < lastIndex)
                ++currentIndex;
        }

        public void MoveTo(int position)
        {
            if (position >= 0 && position <= lastIndex)
                currentIndex = position;
            else
                throw new IndexOutOfRangeException(
                    String.Format("{0} is an invalid position. Position must be between 0 and {1}",
                    position, lastIndex));

        }

        public ArtworkCategory Current
        {
            get { return categories[currentIndex]; }
        }

        public Boolean CanMoveNext
        {
            get { return currentIndex < lastIndex; }
        }


    }
}
