using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Ask user for firstname
            System.Console.WriteLine("FirstName: ");
            string FirstName = System.Console.ReadLine();
            //Ask user for lastname
            System.Console.WriteLine("LastName: ");
            string LastName = System.Console.ReadLine();
            //Aks user for social skills
            System.Console.WriteLine("Social Skills (seperated by comma): ");
            string SocialSkills = System.Console.ReadLine();
            //Ask user for social accounts
            System.Console.WriteLine("Social Accounts (properties seperated by comma, accounts by semicolon): ");
            string SocialAccounts = System.Console.ReadLine();
            writeOutput(FirstName, LastName, SocialSkills, SocialAccounts);
        }

        //write output to the console
        static void writeOutput(string firstname, string lastname, string socialSkills, string socialAccounts)
        {
            string firstAndLastName = firstname + " " + lastname;
            string[] SocialSkillsArray = socialSkills.Split(",");
            Person person = new Person();
            person.FirstName = firstname;
            person.LastName = lastname;
            person.SocialSkills = SocialSkillsArray;
            person.SocialAccounts = getSocialAccounts(socialAccounts);

            System.Console.WriteLine("The number of VOWELS: " + (countVowels(firstname) + countVowels(lastname)));
            System.Console.WriteLine("The number of CONSONANTS: " + (countConsonants(firstname) + countConsonants(lastname)));
            System.Console.WriteLine("The firstname + last name entered: " + firstAndLastName);
            System.Console.WriteLine("The reverse version of the firstname and lastname: " + reverseName(firstAndLastName));
            System.Console.WriteLine("The JSON format of the entire object: " + JsonSerializer.Serialize(person));
        }

        //get the socialaccounts from the user
        static SocialAccount[] getSocialAccounts(string accounts)
        {
            //add accounts to list
            string[] SocialAccountsArray = accounts.Split(";");
            List<SocialAccount> socialAccounts = new List<SocialAccount>();
            foreach (var account in SocialAccountsArray)
            {
                var sAccount = account.Split(",");
                SocialAccount socialAccount = new SocialAccount(sAccount[0], sAccount[1]);
                socialAccounts.Add(socialAccount);
            }
            return socialAccounts.ToArray();
        }

        //TRUE if character is a vowel, FALSE otherwise
        static bool isVowel(string letter)
        {
            if (letter == "a" || letter == "e" || letter == "i" || letter == "o" || letter == "u")
            {
                return true;
            }
            return false;
        }

        //TRUE if character is a consonant, FALSE otherwise
        static bool isConsonant(string letter)
        {
            if (letter == "b" || letter == "c" || letter == "d" || letter == "f" || letter == "g" || letter == "h" || letter == "j" || letter == "k" || letter == "l" || letter == "m" || letter == "n" || letter == "p" || letter == "q" || letter == "r" || letter == "s" || letter == "t" || letter == "v" || letter == "w" || letter == "x" || letter == "y" || letter == "z")
            {
                return true;
            }
            return false;
        }

        //get number of vowels in string
        static int countVowels(string word)
        {
            int number = 0;
            foreach (var element in word.ToCharArray())
            {
                if (isVowel(element.ToString()))
                {
                    number++;
                }
            }
            return number;
        }

        //get number of consonants in string
        static int countConsonants(string word)
        {
            int number = 0;
            foreach (var element in word.ToCharArray())
            {
                if (isConsonant(element.ToString()))
                {
                    number++;
                }
            }
            return number;
        }

        //reverse the characters of a string
        static string reverseName(string name)
        {
            char[] charArray = name.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
