namespace Passenger.Infrastructure.Services
{

    public interface IEncrypter                 //Interfejs ma dwie metody. 1 pobiera Salta ( do solenia hasła  oraz 2 Hasha do poprawnego szyfrowania hasła
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }
}