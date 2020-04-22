namespace Passenger.Infrastructure.Exceptions
{
    public static class ErrorCodesServices
    {
        public static string EmailinUse => "email_in_use";
        public static string InvalidEmail => "invalid_password";
        public static string InvalidCredentials => "invalid_credentials";
        public static string DriverNotFound => "driver_not_found";
        public static string DriverAllreadyExists=> "driver_allready_exists";
        public static string UserNotFound => "user_not_found";
    }
}