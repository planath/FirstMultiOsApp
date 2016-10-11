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
using MultiOsLibrary;

namespace MultiOsAppAndroid
{
    class ArtworkCategoryManagerAdapter : BaseAdapter<ArtworkCategory>
    {
        private readonly Context _context;
        private readonly int _layoutResourceId;
        private ArtworkCategoryManager _artworkCategoryManager;

        public ArtworkCategoryManagerAdapter(Context context, int layoutResourceId,
            ArtworkCategoryManager artworkCategoryManager)
        {
            _context = context;
            _layoutResourceId = layoutResourceId;
            _artworkCategoryManager = artworkCategoryManager;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                LayoutInflater inflater = _context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(_layoutResourceId, null);
            }

            TextView textView = view.FindViewById<TextView>(Resource.Id.categoryTextView);
            textView.Text = this[position].Title;
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.categoryImageView);
            imageView.SetImageResource(ResourceHelper.TranslateDrawableWithReflection("back_3"));

            return view;
        }

        public override int Count {
            get { return _artworkCategoryManager.Length; }
        }

        public override ArtworkCategory this[int position]
        {
            get
            {
                _artworkCategoryManager.MoveTo(position);
                return _artworkCategoryManager.Current;
            }
        }
    }
}