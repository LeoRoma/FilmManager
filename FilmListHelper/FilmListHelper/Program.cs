using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FilmListHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Insert credit card");
            //string creditCard = Console.ReadLine();
            //Console.WriteLine("Insert expiry date");
            //string expiryDate = Console.ReadLine();
            //Console.WriteLine("Insert cvv");
            //string cvv = Console.ReadLine();
            //Console.WriteLine(CreditCardCheck(creditCard, expiryDate, cvv));
            Console.WriteLine(LuhnAlgorythm("9795526789839145"));
        }

        //static bool CreditCardCheck(string creditCard, string expiryDate, string cvv)
        //{
        //    DateTime dt;
        //    var creditCardToSplit = creditCard.Split(" ");
        //    var firstFourNumbers = creditCardToSplit[0];
        //    var cardCheck = new Regex(@"^^4[0-9]{12}(?:[0-9]{3})?$");
        //    var dateWithDay = "01/" + expiryDate;
        //    var cvvCheck = new Regex(@"^\d{3}$");
        //    Console.WriteLine("Credit Card " + !cardCheck.IsMatch(creditCard));
        //    Console.WriteLine("Date " + DateTime.TryParseExact(dateWithDay, "dd/MM/yy", CultureInfo.InvariantCulture,
        //                  DateTimeStyles.None, out dt));
        //    Console.WriteLine("Cvv " + cvvCheck.IsMatch(cvv));
        //    DateTime dateConvert = DateTime.Parse(dateWithDay);
        //    Console.WriteLine(dateConvert);
        //    DateTime actualDate = DateTime.Now;
        //    return (dateConvert > actualDate);
        //}

        static string LuhnAlgorythm(string cardNo)
        {
            List<int> doubleDigits = new List<int>();
            List<int> sumOfDigits = new List<int>();
            int total = 0;

            for(int i = cardNo.Length - 1; i >= 0; i--)
            {
                if(i % 2 != 0)
                {
                    int doubleDigit = Int32.Parse(cardNo[i].ToString()) * 2;
                    doubleDigits.Add(doubleDigit);
                }
                
            }
            foreach (var n in doubleDigits)
            {
                if (n > 9)
                {
                    string numberToString = n.ToString();
                    char rightNum = numberToString[1];
                    char leftNum = numberToString[0];
                    int sum = Int32.Parse(leftNum.ToString()) + Int32.Parse(rightNum.ToString());
                    sumOfDigits.Add(sum);
                }
                else
                {
                    sumOfDigits.Add(Int32.Parse(n.ToString()));
                }
            }
            for(int i = cardNo.Length - 1; i >= 0; i--)
            {
                if(i % 2 == 0)
                {
                    sumOfDigits.Add(Int32.Parse(cardNo[i].ToString()));
                }
            }
            foreach(var n in sumOfDigits)
            {

                total += n;
            }
            Console.WriteLine(total);
            foreach (var n in sumOfDigits)
            {
                if(total % 10 == 0)
                {
                    return "Yes";
                }
            }
            return "No";
        }
    }
}
