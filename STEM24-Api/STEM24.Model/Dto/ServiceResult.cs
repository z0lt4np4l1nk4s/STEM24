namespace STEM24.Model.Dto;

/// <summary>
/// Service result
/// </summary>
public class ServiceResult
{
    /// <summary>
    /// Is success
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Error messages
    /// </summary>
    public List<string> ErrorMessages { get; set; } = default!;

    /// <summary>
    /// Success
    /// </summary>
    /// <returns>Service result</returns>
    public static ServiceResult Success()
    {
        return new ServiceResult { IsSuccess = true };
    }

    /// <summary>
    /// Failure
    /// </summary>
    /// <returns>Service result</returns>
    public static ServiceResult Failure()
    {
        return new ServiceResult { IsSuccess = false };
    }

    /// <summary>
    /// Failure width error message
    /// </summary>
    /// <param name="errorMessage">Error message</param>
    /// <returns>Service result</returns>
    public static ServiceResult Failure(string errorMessage)
    {
        return new ServiceResult { IsSuccess = false, ErrorMessages = new List<string> { errorMessage } };
    }

    /// <summary>
    /// Failure with error messages
    /// </summary>
    /// <param name="errorMessages">Error messages</param>
    /// <returns>Service result</returns>
    public static ServiceResult Failure(List<string> errorMessages)
    {
        return new ServiceResult { IsSuccess = false, ErrorMessages = errorMessages };
    }
}

/// <summary>
/// Service result
/// </summary>
/// <typeparam name="T">Type</typeparam>
public class ServiceResult<T>
{
    /// <summary>
    /// Is success
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Result
    /// </summary>
    public T? Result { get; set; }

    /// <summary>
    /// Error messages
    /// </summary>
    public List<string> ErrorMessages { get; set; } = default!;

    /// <summary>
    /// Success
    /// </summary>
    /// <returns>Service result</returns>
    public static ServiceResult<T> Success()
    {
        return new ServiceResult<T> { IsSuccess = true };
    }

    /// <summary>
    /// Success with result
    /// </summary>
    /// <param name="result">Result</param>
    /// <returns>Service result</returns>
    public static ServiceResult<T> Success(T result)
    {
        return new ServiceResult<T> { IsSuccess = true, Result = result };
    }

    /// <summary>
    /// Failure
    /// </summary>
    /// <returns>Service result</returns>
    public static ServiceResult<T> Failure()
    {
        return new ServiceResult<T> { IsSuccess = false };
    }

    /// <summary>
    /// Failure width error message
    /// </summary>
    /// <param name="errorMessage">Error message</param>
    /// <returns>Service result</returns>
    public static ServiceResult<T> Failure(string errorMessage)
    {
        return new ServiceResult<T> { IsSuccess = false, ErrorMessages = new List<string> { errorMessage } };
    }

    /// <summary>
    /// Failure with error messages
    /// </summary>
    /// <param name="errorMessages">Error messages</param>
    /// <returns>Service result</returns>
    public static ServiceResult<T> Failure(List<string> errorMessages)
    {
        return new ServiceResult<T> { IsSuccess = false, ErrorMessages = errorMessages };
    }
}
