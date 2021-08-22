using SeeWebMail.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeeWebMail.Contracts.Common
{
	public class OperationResult
	{
		public List<ErrorCodes> ErrorCodes { get; set; }

		public bool HasErrors => ErrorCodes.Any();

		public static OperationResult Success => Create();

		protected OperationResult()
		{
			ErrorCodes = new List<ErrorCodes>();
		}

		public static OperationResult Create() => new OperationResult();

		public OperationResult WithError(ErrorCodes error)
		{
			ErrorCodes.Add(error);
			return this;
		}

		public OperationResult WithErrors(IEnumerable<ErrorCodes> errors)
		{
			ErrorCodes.AddRange(errors);
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
			ErrorCodes.Add(error);
			return this;
		}

		public new OperationResult<T> WithErrors(IEnumerable<ErrorCodes> errors)
		{
			ErrorCodes.AddRange(errors);
			return this;
		}

	}
}
