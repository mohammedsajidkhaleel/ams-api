using ams.domain.Abstractions;
using MediatR;

namespace ams.application.Abstractions.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand
{
}
public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}
public interface IBaseCommand
{
}
