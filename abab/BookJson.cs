
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EllensBookList
{
	public class AuthorData
	{
		public string name { get; set; }
		public string id { get; set; }
	}

	public class BookData
	{
		public string dewey_decimal { get; set; }
		public string isbn13 { get; set; }
		public string notes { get; set; }
		public string title_latin { get; set; }
		public string publisher_id { get; set; }
		public string publisher_text { get; set; }
		public string language { get; set; }
		public string isbn10 { get; set; }
		public string publisher_name { get; set; }
		public string lcc_number { get; set; }
		public string book_id { get; set; }
		public string physical_description_text { get; set; }
		public string summary { get; set; }
		public List<AuthorData> author_data { get; set; }
		public List<string> subject_ids { get; set; }
		public string title { get; set; }
		public string marc_enc_level { get; set; }
		public string awards_text { get; set; }
		public string edition_info { get; set; }
		public string urls_text { get; set; }
		public string title_long { get; set; }
		public string dewey_normal { get; set; }
	}

	public class JsonBookData
	{
		public string index_searched { get; set; }
		public List<BookData> data { get; set; }
	}
}

