using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using MultiOsLibrary;

namespace MultiOsAppAndroid
{
    public class ArtworkFragment : Fragment
    {
        private TextView textTitle;
        private TextView textDesc;
        private ImageView image;
        public Artwork Artwork { get; set; }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View rootView = inflater.Inflate(Resource.Layout.ArtworkFragment, container, false);

            textTitle = rootView.FindViewById<TextView>(Resource.Id.textTitle);
            textDesc = rootView.FindViewById<TextView>(Resource.Id.textDesc);
            image = rootView.FindViewById<ImageView>(Resource.Id.imageView);
            
            textTitle.Text = Artwork.Title;
            textDesc.Text = Artwork.Description;
            image.SetImageResource(ResourceHelper.TranslateDrawableWithReflection(Artwork.Image));

            return rootView;
        }
    }
}