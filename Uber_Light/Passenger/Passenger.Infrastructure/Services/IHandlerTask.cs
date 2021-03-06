﻿using System;
using System.Threading.Tasks;
using NLog;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.Services
{
    public interface IHandlerTask
    {
        IHandlerTask Always(Func<Task> always);
        IHandlerTask OnCustomError(Func<PassengerException, Task> onCustomError,                //Zadziała na zdefiniowane wyjątki 
            bool propagateException = false, bool executeOnError = false);
        IHandlerTask OnCustomError(Func<PassengerException, Logger, Task> onCustomError,
            bool propagateException = false, bool executeOnError = false);
        IHandlerTask OnError(Func<Exception, Task> onError, bool propagateException = false);   //Zadziała na wszystkie pozostałe wyjątki
        IHandlerTask OnError(Func<Exception, Logger, Task> onError, bool propagateException = false);
        IHandlerTask OnSuccess(Func<Task> onSuccess);                                           //Zadziała tylko gdy operacja się powiedzie
        IHandlerTask PropagateException();
        IHandlerTask DoNotPropagateException();
        IHandler Next();
        Task ExecuteAsync();
    }
}