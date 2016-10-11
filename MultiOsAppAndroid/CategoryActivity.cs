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
    [Activity(Label = "My Galleries")]
    public class CategoryActivity : ListActivity
    {
        private ArtworkCategoryManager _artworkCategoryManager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _artworkCategoryManager = new ArtworkCategoryManager();
            
            ListAdapter =
                new ArtworkCategoryManagerAdapter(this, Android.Resource.Layout.SimpleListItem1, _artworkCategoryManager);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Intent intent = new Intent(this, typeof(ArtworkActivity));
            _artworkCategoryManager.MoveTo(position);
            var title = _artworkCategoryManager.Current.Title;

            intent.PutExtra(ArtworkActivity.CATEGORY_TITLE_EXTRA, title);
            StartActivity(intent);
        }
    }
}