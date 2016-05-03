
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace EllensBookList
{
	public class BookInfo
	{
		//public imag BookImage { get; set; }
		[PrimaryKey]
		public string BookTitle { get; set; }
		public string AuthorName { get; set; }
		public string bookImageURL { get; set; }
	}
}

