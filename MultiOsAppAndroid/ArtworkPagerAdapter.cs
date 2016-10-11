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
using Android.Support.V4.App;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Object = Java.Lang.Object;

namespace MultiOsAppAndroid
{
    class ArtworkPagerAdapter: FragmentStatePagerAdapter
    {
        ArtworkManager artworkManager;

        public ArtworkPagerAdapter(FragmentManager fm, ArtworkManager am) : base(fm)
        {
            this.artworkManager = am;

        }

        public override int Count { get { return artworkManager.Length; } }
        public override Fragment GetItem(int position)
        {
            artworkManager.MoveTo(position);
            var frag = new ArtworkFragment();
            frag.Artwork = artworkManager.CurrentArtwork;

            return frag;
        }

        public ArtworkManager ArtworkManager
        {
            set
            {
                artworkManager = value;
                NotifyDataSetChanged();
            }
        }

        public override int GetItemPosition(Object objectValue)
        {
            return PositionNone;
        }
    }
}