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
using Android.Views;
using Android.Widget;
using MultiOsLibrary;

namespace MultiOsAppAndroid
{
    [Activity(Label = "Gallery", MainLauncher = true, Icon = "@drawable/icon")]
    public class ArtworkActivity : FragmentActivity
    {
        private ArtworkManager artworkManager;
        private ArtworkPagerAdapter artworkPagerAdapter;
        private ViewPager viewPager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GalleryActivity);

            artworkManager = new ArtworkManager();
            artworkManager.MoveFirst();
            artworkPagerAdapter = new ArtworkPagerAdapter(SupportFragmentManager, artworkManager);

            viewPager = FindViewById<ViewPager>(Resource.Id.artworkPager);
            viewPager.Adapter = artworkPagerAdapter;
        }
    }
}