using Matrix.Net.Domain;

namespace Matrix.Net.CoreService
{
	public interface IMatrixMessageService
	{
		Message GetIncomingMessage(int number);

		Message GetOutgoingMessage(int number);
		//object GetInternalMessage(int number);
	}
}
