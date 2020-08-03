using Matrix.Net.Domain;
using MatrixWebObjAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
	public class MatrixService : IMatrixService
	{
		private readonly MsgInfoClass _matrix;

		public MatrixService()
		{
			_matrix = new MsgInfoClass();
		}
		public Message GetAllMessage(int number)
		{
			return GetMessage(number, MessageDirection.AllMessages);
		}

		public Message GetInternalMessage(int number)
		{
			return GetMessage(number, MessageDirection.Internal);
		}

		private Message GetMessage(int number, MessageDirection direction)
		{
			var msg = _matrix.FetchMsgInfo(number, direction == MessageDirection.Incoming ? "INC" : "OUT");

			if (msg == null)
				return null;

			return new Message
			{
				Number = number,
				Subject = msg,
				Direction = direction
			};
		}
	}
}
