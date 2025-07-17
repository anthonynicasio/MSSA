namespace Password_Lockout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tempUserID = "";
            string tempPassword = "";
            string userID = "Anthony";
            string password = "password";
            int loginAttempts = 0;
            int maxLoginAttempts = 3;

            while (loginAttempts < maxLoginAttempts)
            {
                Console.Write("Enter your username:");
                tempUserID = Console.ReadLine();
                Console.Write("Enter your password:");
                tempPassword = Console.ReadLine();

                if (tempUserID == userID && tempPassword == password)
                {
                    Console.WriteLine("You're in!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Please try again. Attemps left: {maxLoginAttempts - loginAttempts}");
                    loginAttempts++;
                }

                Console.WriteLine("Too many failed attempts. User account locked");
            }

        }
    }
}
