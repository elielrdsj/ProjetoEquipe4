using LetsMarket.Db;
using LetsMarket.View;

namespace LetsMarket.Logic
{
    public class Login
    {
        public static void VerifyLogin()
        {
            var loggedIn = false;
            var attempts = 0;

            do
            {
                attempts++;
                Console.Clear();

                if (attempts > 1)
                {
                    Console.WriteLine(Environment.NewLine);
                    ConsoleInput.WriteError("DADOS INCORRETOS");
                    Console.WriteLine(Environment.NewLine);
                }

                Console.WriteLine("SYSTEM LOGIN");

                var username = ConsoleInput.GetString("login");
                var password = ConsoleInput.GetPassword("senha");

                //if (LoginIsValid(username, password))
                    loggedIn = true;

            } while (!loggedIn);

        }

        //private static bool LoginIsValid(string? username, string password)
        //{
        //    foreach (var usuario in Database.Employees)
        //    {
        //        if (usuario.Login == username && usuario.Password == password)
        //            return true;
        //    }

        //    return false;
        //}
    }
}
