using System;
using System.Collections.Generic;
using System.Text;

namespace Solucion_Lab_21_abril
{
    public class User
    {
        private string userName;
        private string email;
        private string password;
        private string phone;

        public string Email { get => email; set => email = value; }

        public User(string username, string email, string password, string phone)
        {
            this.userName = username;
            this.email = email;
            this.password = password;
            this.phone = phone;
        }
        public delegate void EmailVerifiedHandler(object source);
        public event EmailVerifiedHandler EmailVerified;
        public virtual void OnEmailVerifiedHandler()
        {
            if (EmailVerified != null)
            {
                EmailVerified(this);
            }
        }

        public void OnEmailSent(object source)
        {
            Console.WriteLine("Desea verificar el correo? Y/N");
            bool closer = true;
            do
            {
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case ("Y"):
                        EmailVerified(this);
                        closer = false;
                        break;
                    case ("N"):
                        closer = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida");
                        break;

                }
            } while (closer);
        }
    }
}
