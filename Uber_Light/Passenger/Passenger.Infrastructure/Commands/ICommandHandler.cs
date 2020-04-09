using System.Threading.Tasks;


/*// Odpowiedzialny za poprawne przechwycenie naszych komend. 
 * Interfejs Generyczny gdzie T będzie jakąś komendą z pojedyńczą metodą asynchro. 
 * na wejście dostanie naszą komendę.
 * */

namespace Passenger.Infrastructure.Commands    //Tak jak IComand to jest MArker Interfejs, niczego nie definiuje.
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}