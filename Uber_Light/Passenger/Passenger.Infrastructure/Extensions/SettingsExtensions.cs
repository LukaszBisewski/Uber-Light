using Microsoft.Extensions.Configuration;

namespace Passenger.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new() //na wejście metody obiekt IConfiguration który pochodzi z biblioteki Microsoft Extension. Where T jest zawsze klasą i posiada konstruktor.
        {
            /*W tej metodzie dostajemy na wejście naszą klasę GeneralSettings,
             * zrób replaca czyli usuń 'settings'z nazwy
             * i na końcu poierz sekcję (sekcaj to tekst w launch.json
             * na końcu metoda bind która przypisze eartości jsona do naszych property i zwróci wartoś jako konfig
             */
            var section = typeof(T).Name.Replace("Settings", string.Empty);             //Pobieramy nazwę naszego typu i robimy replace, zmieniamy nazwe typu, usuwamy z niego zakończenie settings
            var configurationValue = new T();                                           // stwórz nowy pusty obiekt klasy T 
            configuration.GetSection(section).Bind(configurationValue);                 // Konfiguracja pobiera  nazwe sekcji i wykorzystujemy biblioteke binder i przypisz ustawienia do obiektu tej klasy.
            return configurationValue;
           
        }
    }// ciekawe
}
