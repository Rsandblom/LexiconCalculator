using System;

namespace LexiconCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueCalculating = true;
            double num1, num2;
            string selectedOption;

            while (continueCalculating)
            {
                selectedOption = DisplayAndCheckCalculationOptions();

                if (selectedOption != "q")
                {
                    num1 = EnterANumber(true);
                    num2 = EnterANumber(false);
                    double result = PerformSelectedCalculationOnNumbers(selectedOption, num1, num2);
                    Console.WriteLine($"The result is: {result}. {Environment.NewLine}Press enter to countinue.");
                    Console.ReadLine();
                }
                else
                {
                    continueCalculating = false;
                }
            }
            Console.WriteLine("Application has stopped.");
        }

        private static double PerformSelectedCalculationOnNumbers(string selectedOption, double num1, double num2)
        {
            double result = 0;

            switch (selectedOption)
            {
                case "+":
                    result = Addition(num1, num2);
                    break;
                case "-":
                    result = Substraction(num1, num2);
                    break;
                case "*":
                    result = Multiplication(num1, num2);
                    break;
                case "/":
                    result = Division(num1, num2);
                    break;
                default:
                    Console.WriteLine("Something went wrong.");
                    break;
            }
            return result;
        }


        private static double Addition(double num1, double num2) => num1 + num2;

        private static double Substraction(double num1, double num2) => num1 - num2;
        
        private static double Multiplication(double num1, double num2) => num1 * num2;

        private static double Division(double num1, double num2)
        {
            if (num1 == 0 || num2 == 0)
            {
                Console.WriteLine("Division by Zero is not allowed, result will be set to 0.");
                return 0;
            }
            return num1 / num2;
        }

        private static double EnterANumber(bool isFirstNumber)
        {
            string firstOrSecondNum = isFirstNumber ? "first" : "second";
            Console.Write($"Enter your {firstOrSecondNum} number: ");
            string enteredNum = Console.ReadLine();
            double enteredNumToDouble;

            if (!double.TryParse(enteredNum, out enteredNumToDouble))
            {
                Console.WriteLine("Input was not a valid number.");
                enteredNumToDouble = EnterANumber(isFirstNumber);
            }
            return enteredNumToDouble;

        }

        private static string DisplayAndCheckCalculationOptions()
        {
            Console.Clear();
            Console.Write("Welcome to the Calculator application, select type of mathematical operattion." + Environment.NewLine
                + "For addition enter: + " + Environment.NewLine
                + "For substracion enter: - " + Environment.NewLine
                + "For multiplication enter: * " + Environment.NewLine
                + "For division enter: / " + Environment.NewLine
                + "To quit application enter: q " + Environment.NewLine);

            string selOpt = Console.ReadLine();

            if (selOpt != "+" && selOpt != "-" && selOpt != "*" && selOpt != "/" && selOpt != "q")
            {
                Console.Write("Entered character is not a valid selection." + Environment.NewLine
                   + "Press enter to select again.");
                Console.ReadLine();
                selOpt = DisplayAndCheckCalculationOptions();
            }
            
            return selOpt;
            
        }
    }
}
