
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
using Android;

namespace EllensBookList.Android
{			
	public class MyTableRowAdapter : BaseAdapter<BookInfo>
	{
		private List<BookInfo> mItems;
		private Context mContext;

		public MyTableRowAdapter(Context context, List<BookInfo> items)
		{
			mItems = items;
			mContext = context;
		}

		public override int Count
		{
			get { return mItems.Count; }
		}

		public override long  GetItemId (int position)
		{
			return position;
		}

		public override BookInfo this[int position]
		{
			get { return mItems [position]; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View row = convertView;

			if (row == null) {
				row = LayoutInflater.From (mContext).Inflate (Resource.Layout.cellLayout, null, false);
			}

//			ImageView bookImage = row.FindViewById<ImageView> (Resource.Id.bookImage);
//			bookImage.SetImageURI = mItems [position].BookImage;

			TextView txtBookTitle = row.FindViewById<TextView> (Resource.Id.txtBookTitle);
			txtBookTitle.Text = mItems [position].BookTitle;

			TextView txtAuthor = row.FindViewById<TextView> (Resource.Id.txtAuthorTitle);
			txtAuthor.Text = mItems [position].AuthorName;

			return row;
		}		

	}
}

