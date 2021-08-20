export interface OperationResult {
  hasErrors: boolean,
  errorCodes: number[]
}

export interface OperationResult<T = void> {
  hasErrors: boolean,
  errorCodes: number[]
  value: T,
}

