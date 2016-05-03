using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace EllensBookList.Shared
{
	public class BookRespository : IBookRepository
	{
		public async Task<IEnumerable<BookData>> GetBookInfoAsync(string url)
		{
			var client = new HttpClient ();

			var result = await client.GetStringAsync(url);

			return JsonConvert.DeserializeObject<JsonBookData> (result).data;
		}
	}

	public interface IBookRepository
	{
		Task<IEnumerable<BookData>> GetBookInfoAsync(string url);
	}
}

