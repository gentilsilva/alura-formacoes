using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Exceptions
{

	[Serializable]
	public class ByteBankException : Exception
	{
		public ByteBankException() { }
		public ByteBankException(string mensagem) : base("Aconteceum uma Exceção -> " + mensagem) { }
		public ByteBankException(string mensagem, Exception interna) : base(mensagem, interna) { }
		protected ByteBankException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
