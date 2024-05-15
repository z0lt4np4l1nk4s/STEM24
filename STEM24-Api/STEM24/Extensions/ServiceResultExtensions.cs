namespace STEM24.Extensions;

/// <summary>
/// Service result extensions
/// </summary>
public static class ServiceResultExtensions
{
    /// <summary>
    /// Converts Service result to Action result
    /// </summary>
    /// <param name="result">Service result</param>
    /// <returns>Action result</returns>
    public static IActionResult ToActionResult(this ServiceResult result)
    {
        if (result == null || !result.IsSuccess || result.ErrorMessages != null && result.ErrorMessages.Any())
        {
            return new BadRequestObjectResult(result);
        }

        return new OkObjectResult(result);
    }

    /// <summary>
    /// Converts Service result to Action result
    /// </summary>
    /// <typeparam name="T">Result type</typeparam>
    /// <param name="result">Service result</param>
    /// <returns>Action result</returns>
    public static IActionResult ToActionResult<T>(this ServiceResult<T> result)
    {
        if (result != null && result.Result == null && !result.ErrorMessages.Any())
        {
            return new NotFoundObjectResult(result);
        }

        if (result == null || !result.IsSuccess || (result.ErrorMessages != null && result.ErrorMessages.Any()))
        {
            return new BadRequestObjectResult(result);
        }

        return new OkObjectResult(result);
    }
}

