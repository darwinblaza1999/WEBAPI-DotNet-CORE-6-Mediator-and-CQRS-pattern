using MediatR;

namespace WebApplication1.Handler
{
    public interface ISender
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
        Task<object?> Send(object request, CancellationToken cancellationToken = default);
    }
    public interface IPublisher
    {
        Task Publish(object notification, CancellationToken cancellationToken = default);
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification;
    }
    public interface IMediator : ISender, IPublisher { }
}
