using SeeWebMail.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeeWebMail.Contracts.Common
{
	public class OperationResult
	{
		public IEnumerable<ErrorCodes> ErrorCodes { get; set; }

		public bool HasErrors => ErrorCodes.Any();

		public static OperationResult Success => Create();

		protected OperationResult()
		{
			ErrorCodes = Enumerable.Empty<ErrorCodes>();
		}

		public static OperationResult Create() => new OperationResult();

		public OperationResult WithError(ErrorCodes error)
		{
			ErrorCodes.Append(error);
			return this;
		}
	}

	public class OperationResult<T> : OperationResult
	{
		public T Value { get; set; }

		public OperationResult(T value)
		{
			Value = value;
		}

		public static OperationResult<T> Create(T value)
		{
			return new OperationResult<T>(value);
		}

		public new OperationResult<T> WithError(ErrorCodes error)
		{
			return this.WithError(error);
		}

	}
}
