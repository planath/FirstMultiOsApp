using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MultiOsLibrary;

namespace MultiOsAppAndroid
{
    [Activity(Label = "Gallery", MainLauncher = true, Icon = "@drawable/icon")]
    public class ArtworkActivity : FragmentActivity
    {
        public const string CATEGORY_TITLE_EXTRA = "DisplayCategoryTitleExtra";
        private const string DEFAULT_CATEGORY_TITLE = "Sky";
        private ArtworkCategoryManager _artworkCategoryManager;
        private ArtworkManager _artworkManager;
        private ArtworkPagerAdapter artworkPagerAdapter;
        private ViewPager viewPager;
        private DrawerLayout drawerLayout;
        private ListView categoryDrawerListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ArtworkActivity);

            _artworkCategoryManager = new ArtworkCategoryManager();
            _artworkCategoryManager.MoveFirst();

            var categoryTitle = _artworkCategoryManager.Current.Title;
            _artworkManager = new ArtworkManager(categoryTitle);
            _artworkManager.MoveFirst();
            artworkPagerAdapter = new ArtworkPagerAdapter(SupportFragmentManager, _artworkManager);
            viewPager = FindViewById<ViewPager>(Resource.Id.artworkPager);
            viewPager.Adapter = artworkPagerAdapter;

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            categoryDrawerListView = FindViewById<ListView>(Resource.Id.categoryDrawerListView);

            categoryDrawerListView.Adapter = new ArtworkCategoryManagerAdapter(this, Resource.Layout.CategoryItem, _artworkCategoryManager);
            categoryDrawerListView.SetItemChecked(0, true);

            categoryDrawerListView.ItemClick += categoryDrawerListView_ItemClicked;
        }

        private void categoryDrawerListView_ItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            drawerLayout.CloseDrawer(categoryDrawerListView);
            _artworkCategoryManager.MoveTo(e.Position);
            _artworkManager = new ArtworkManager(_artworkCategoryManager.Current.Title);
            artworkPagerAdapter.ArtworkManager = _artworkManager;

            viewPager.CurrentItem = 0;
        }
    }
}