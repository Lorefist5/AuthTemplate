using DefaultCoreLibrary.Core;
using FluentValidation.Results;


namespace AuthTemplate.Application.Common.Helpers;

public static class ErrorParserHelper
{
    /// <summary>
    /// Only for parsing FluentValidation results
    /// </summary>
    /// <typeparam name="T">Type here is only for initializing the Result type</typeparam>
    /// <param name="validationResult">the validation results</param>
    /// <returns>Only returns a Result object with errors or no error</returns>
    public static IEnumerable<Error> Parse(ValidationResult validationResult)
    {   
        var errors = validationResult.Errors.Select(e => new Error(e.ErrorCode, e.ErrorMessage));

        return errors;
    }
}
