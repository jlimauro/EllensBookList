using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using EllensBookList.Shared;
using System.Collections.Generic;
using SQLite;
using ZXing.Mobile;
using System.Linq;

namespace EllensBookList.Android
{
    [Activity(Label = "Ellen's Book List", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button button;
        ListView mListView;
        List<BookInfo> mItems;
        private MyTableRowAdapter adapter;
        string dbPath;
        SQLiteConnection dbConn;
        private readonly IBookRepository repository = new BookRespository();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            MobileBarcodeScanner.Initialize(Application);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.btAddBook);
            mListView = FindViewById<ListView>(Resource.Id.myListView);

            dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            dbConn = new SQLiteConnection(System.IO.Path.Combine(dbPath, "ellenBookData.db"));
            dbConn.CreateTable<BookInfo>();

            LoadBookData();

            button.Click += Button_Click;
        }

        private void LoadBookData()
        {
            var bookData = from books in dbConn.Table<BookInfo>()
                           select books;

            mItems = new List<BookInfo>();

            foreach (var bData in bookData)
            {
                mItems.Add(new BookInfo() { BookTitle = bData.BookTitle, AuthorName = bData.AuthorName });
            }

            adapter = new MyTableRowAdapter(this, mItems);
            mListView.Adapter = adapter;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            //Handle result
            //
            //			if (result != null) {
            //				Console.WriteLine ("Scanned Barcode: " + result.Text);
            //
            //				LookUpBook (result.Text);
            //
            //
            //				LoadBookData ();
            //
            //			}

            LookUpBook("9780984782802");
            //LoadBookData ();
        }

        private async void LookUpBook(string barcodeString)
        {
            //string searchUrl = "http://isbndb.com//api/books.xml?access_key=2692SYFX&index1=isbn&value1=" + barcodeString;
            string searchUrl = @"http://isbndb.com/api/v2/json/2692SYFX/book/" + barcodeString;
            string bookTitle = string.Empty;
            string author = string.Empty;
            try
            {
                var data = await repository.GetBookInfoAsync(searchUrl);

                List<BookData> bData = data.ToList();

                if (bData.Count > 0)
                {
                    bookTitle = bData[0].title;
                    author = bData[0].author_data[0].name;

                    dbConn.Insert(new BookInfo()
                    {
                        BookTitle = string.Format("Book Title: {0}", bookTitle),
                        AuthorName = string.Format("Author Name: {0}", author)
                    });
                }

            }
            catch (Exception ex)
            {

                System.Console.WriteLine(ex.Message.ToString());
            }

            LoadBookData();
        }
    }
}
