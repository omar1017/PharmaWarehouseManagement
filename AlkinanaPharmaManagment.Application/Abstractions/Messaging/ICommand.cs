using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand;

    public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand;

    public interface IBaseCommand;

}
