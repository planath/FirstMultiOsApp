package md570f9d30918ceb69f5db34009dfaad4e3;


public class ArtworkActivity
	extends android.support.v4.app.FragmentActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MultiOsAppAndroid.ArtworkActivity, MultiOsAppAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ArtworkActivity.class, __md_methods);
	}


	public ArtworkActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ArtworkActivity.class)
			mono.android.TypeManager.Activate ("MultiOsAppAndroid.ArtworkActivity, MultiOsAppAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
