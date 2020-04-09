using System;
using System.Threading.Tasks;
using Autofac;

/*wysyła komendy do odpowiednich handlerów.
 * */
 

namespace Passenger.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context) //argument IComponentContext pochodzi z biblioteki Autofac i jest kontekstem dla kontenera IoC
        {
            _context = context;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand    //
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    $"Command: '{typeof(T).Name}' can not be null.");
            }
            var handler = _context.Resolve<ICommandHandler<T>>();   //Pobierz implementacje dla ICommendHandler od T a T jest komenda. 
            await handler.HandleAsync(command);
        }
    }
}