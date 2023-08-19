using Domain.SeedWork;
using Microsoft.Extensions.Logging;

namespace Application.SeedWork;

//  TODO: Make as an abstract class with try...catch template and call action or func inside try block. Sample:
// 
//public abstract class CommandHandler<TRequest, TResponse, T>
//    where T : class
//    where TResponse : CommandResponse<T>
//{
//    private readonly ILogger logger;
//
//    public CommandHandler(ILogger logger)
//    {
//        this.logger = logger;
//    }
//
//    public abstract Task<T> Action(TRequest request, CancellationToken cancellationToken);
//
//    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
//    {
//        DomainErrorDetails? errorDetails = null;
//        bool result = true;
//        T? objectResult = null;
//
//        try
//        {
//            objectResult = await Action(request, cancellationToken);
//        }
//        catch (DomainException ex)
//        {
//            errorDetails = new(ex, ex.Message);
//            result = false;
//            logger.LogError(ex, message: ex.Message);
//        }
//        catch (Exception ex)
//        {
//            result = false;
//            logger.LogCritical(ex, message: ex.Message);
//        }
//
//        TResponse response = 
//            (TResponse)new CommandResponse<T>(
//                objectResult,
//                result,
//                errorDetails);
//
//        return response;
//    }
//}
//
//public class CommandResponse<T>
//    : CommandResponse
//{
//    public CommandResponse(T? objectResult, bool result, DomainErrorDetails? errorDetails)
//        : base(result, errorDetails)
//    {
//        ObjectResult = objectResult;
//    }
//
//    public T? ObjectResult { get; init; }
//}
//
//public class CommandResponse
//{
//    public CommandResponse(bool result, DomainErrorDetails? errorDetails)
//    {
//        Result = result;
//        ErrorDetails = errorDetails;
//    }
//
//    DomainErrorDetails? ErrorDetails { get; init; }
//    public bool Result { get; init; }
//}

public interface ICommandHandler<in TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TRequest>
{
    Task Handle(TRequest request, CancellationToken cancellationToken);
}
