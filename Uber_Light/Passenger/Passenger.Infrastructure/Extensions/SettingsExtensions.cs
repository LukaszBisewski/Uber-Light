using Microsoft.Extensions.Configuration;

namespace Passenger.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            /*W tej metodzie dostajemy na wejście klasę GeneralSettings,
             * replaca czyli usuń 'settings'z nazwy
             * i na końcu poierz sekcję (sekcja to tekst w launch.json
             * na końcu metoda bind która przypisze wartość jsona do naszych property i zwróci wartoś jako config
             */
            var section = typeof(T).Name.Replace("Settings", string.Empty);             //Pobieramy nazwę naszego typu i robimy replace, zmieniamy nazwe typu, usuwamy z niego zakończenie settings
            var configurationValue = new T();                                           // Stwórz nowy pusty obiekt klasy T 
            configuration.GetSection(section).Bind(configurationValue);                 // Konfiguracja pobiera  nazwe sekcji i wykorzystujemy biblioteke binder i przupisuje ustawienia do obiektu tej klasy.
            return configurationValue;
           
        }
    }
}
