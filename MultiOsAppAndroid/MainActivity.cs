        using System;
using Android.App;
using Android.Widget;
using Android.OS;
using MultiOsLibrary;

namespace MultiOsAppAndroid
{
    //[Activity(Label = "Multi OS App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button backButton;
        private Button nextButton;
        private TextView textTitle;
        private TextView textDesc;
        private ImageView image;
        private ArtworkManager manager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            backButton = FindViewById<Button>(Resource.Id.buttonBack);
            nextButton = FindViewById<Button>(Resource.Id.buttonNext);
            textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            textDesc = FindViewById<TextView>(Resource.Id.textDesc);
            image = FindViewById<ImageView>(Resource.Id.imageView);

            backButton.Click += backButton_Click;
            nextButton.Click += nextButton_Click;

            manager = new ArtworkManager();
            manager.MoveFirst();
            DisplayCurrentArtwork();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (manager.CanMoveNext)
            {
                manager.MoveNext();
                DisplayCurrentArtwork();
            }

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (manager.CanMoveBack)
            {
                manager.MoveBack();
                DisplayCurrentArtwork();
            }

        }

        private void DisplayCurrentArtwork()
        {
            var art = manager.CurrentArtwork;
            var imageId = ResourceHelper.TranslateDrawableWithReflection(art.Image);

            textTitle.Text = art.Title;
            textDesc.Text = art.Description;
            image.SetImageResource(imageId);

            backButton.Enabled = manager.CanMoveBack;
            nextButton.Enabled = manager.CanMoveNext;
        }
    }
}

