using Matrix.Net.Domain;
using System;
using System.Collections.Generic;
using System.Text;
//using Matrix.Net.Domain;

namespace DataService
{
	public interface IMatrixService
	{
		Message GetAllMessage(int number);
		Message GetInternalMessage(int number);
	}
}
