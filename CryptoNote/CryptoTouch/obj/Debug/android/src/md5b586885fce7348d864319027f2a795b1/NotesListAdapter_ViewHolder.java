package md5b586885fce7348d864319027f2a795b1;


public class NotesListAdapter_ViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CryptoNote.Adapters.NotesListAdapter+ViewHolder, CryptoTouch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NotesListAdapter_ViewHolder.class, __md_methods);
	}


	public NotesListAdapter_ViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == NotesListAdapter_ViewHolder.class)
			mono.android.TypeManager.Activate ("CryptoNote.Adapters.NotesListAdapter+ViewHolder, CryptoTouch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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