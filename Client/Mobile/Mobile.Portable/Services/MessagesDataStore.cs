using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Matrix.Net.Clients.HttpClient;

namespace Matrix.Net.Client.Services
{
	public class MessagesDataStore : IDataStore<Message>
	{
		private MessageClient _client;

		public MessagesDataStore()
		{
			var httpClient = new HttpClient();
			_client = new MessageClient(httpClient);
		}
		public Task<bool> AddItemAsync(Message item)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateItemAsync(Message item)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteItemAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<Message> GetItemAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Message>> GetItemsAsync(bool forceRefresh = false)
		{
			throw new NotImplementedException();
		}
	}
}
