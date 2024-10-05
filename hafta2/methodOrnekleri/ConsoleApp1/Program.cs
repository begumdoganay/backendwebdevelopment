using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("----- Application Started -----\n");

        // Step 1: Print favorite song lyrics. My favorite band:Panic! At the disco. ofc i said that this song 
        #region Step 1: Print Song Lyrics
        PrintFavoriteSongLyrics();
        #endregion

        // Step 2: Generate a random number and print its remainder when divided by 2 let's gooooo
        #region Step 2: Random Number Remainder
        int remainder = GetRandomNumberMod2();
        Console.WriteLine($"\n Random number remainder when divided by 2: {remainder}");
        #endregion

        // Step 3: Multiply two numbers and print the result
        #region Step 3: Multiply Numbers
        int product = MultiplyNumbers(5, 7);
        Console.WriteLine($"\nThe product of 5 and 7: {product}");
        #endregion

        // Step 4: Print welcome message with first and last name
        #region Step 4: Welcome Message
        PrintWelcomeMessage("John", "Doe");
        #endregion

        Console.WriteLine("\n----- Application Ended -----");
    }

    #region Method: Print Song Lyrics
    /// <summary>
    /// Prints a favorite song lyric to the console.
    /// </summary>
    static void PrintFavoriteSongLyrics()
    {
        Console.WriteLine("My favorite song lyrics: \"Saying, 'If you go on, you might pass out in a drain pipe.'\n Oh yeah, don't threaten me with a good time.\"");
    }
    #endregion

    #region Method: Get Remainder When Divided by 2
    /// <summary>
    /// Generates a random number between 1 and 100, then returns the remainder when divided by 2.
    /// </summary>
    /// <returns>Remainder when divided by 2</returns>
    static int GetRandomNumberMod2()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 100);
        return randomNumber % 2;
    }
    #endregion

    #region Method: Multiply Two Numbers
    /// <summary>
    /// Multiplies two given numbers and returns the result.
    /// </summary>
    /// <param name="number1">First number</param>
    /// <param name="number2">Second number</param>
    /// <returns>Product of the two numbers</returns>
    static int MultiplyNumbers(int number1, int number2)
    {
        return number1 * number2;
    }
    #endregion

    #region Method: Print Welcome Message
    /// <summary>
    /// Prints a welcome message using the given first and last names.
    /// </summary>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    static void PrintWelcomeMessage(string firstName, string lastName)
    {
        Console.WriteLine($"\nWelcome, {firstName} {lastName}!");
    }
    #endregion
}
