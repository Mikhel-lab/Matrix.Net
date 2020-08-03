using Matrix.Net.Domain;
using MatrixWebObjAccess;

namespace Matrix.Net.CoreService
{
	public class MatrixMessageService : IMatrixMessageService
	{
		private readonly MsgInfoClass _matrix;

		public MatrixMessageService()
		{
			_matrix = new MsgInfoClass();
		}


		public Message GetIncomingMessage(int number)
		{
			return GetMessage(number, MessageDirection.Incoming);
		}

		public Message GetOutgoingMessage(int number)
		{
			return GetMessage(number, MessageDirection.Outgoing);
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
