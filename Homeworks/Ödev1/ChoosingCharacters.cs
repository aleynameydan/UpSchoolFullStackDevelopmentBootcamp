using System.Text;
using PasswordGenerator;
using PasswordGenerator;
namespace PasswordGenerator.Domain
{

    public class ChoosingCharacters
    {
        public static string LCase = "abcdefghijklmnopqursuvwxyz";
        public static string UCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Numbers = "1234567890";
        public static string SpeacialCharacters = "@£$%^&*()#€";
        private readonly Random _random;
        public static string SelectedCharacters { get; set; } = null!;
        
        public ChoosingCharacters()
        {
           
            _random = new Random();
        }

        public static void AddLower()
        {
            SelectedCharacters += (LCase);
        }

        public static void AddUpper()
        {
            SelectedCharacters += (UCase);
        }
        public static void AddNumbers()
        {
            SelectedCharacters += (Numbers);
        }
        public static void AddSpecialCharacters()
        {
            SelectedCharacters += (SpeacialCharacters);
        }

        public string GetRandomPassword( int x)
        {
            string charset = "";

            for (int i = 0; i < x; i++)
            {
                var randomIndex = _random.Next(x);
                var character = SelectedCharacters[randomIndex];
                charset += character;
            }
            return charset;
            


        }






    }



    
    
    
    
}

