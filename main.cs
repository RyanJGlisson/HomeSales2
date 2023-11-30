using System;

class Program 
{
  public static void Main (string[] args) 
  {
// Arrays to store salesperson names, allowed initials, and accumulated sales values
        string[] salespersonNames = { "Danielle", "Edward", "Francis" };
        char[] allowedInitials = { 'D', 'E', 'F' };
        int[] salesTotals = new int[3];

        // Variables to keep track of grand total and highest sale
        int grandTotal = 0;
        char highestSalesperson = ' ';

        // Repeat until the user enters 'Z' or 'z':
        do
        {
            // Display allowed initials
            Console.WriteLine("Allowed Initials: " + string.Join(", ", allowedInitials));

            // Prompt the user for input
            Console.Write("Enter salesperson initial (Z to finish): ");
            char input = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            // Check if input is 'Z' to finish the loop
            if (input == 'Z')
                break;

            // Check if the input is a valid salesperson initial
            int index = Array.IndexOf(allowedInitials, input);
            if (index == -1)
            {
                Console.WriteLine("Error, invalid salesperson selected, please try again");
                continue;
            }

            // Prompt the user for the amount of sale
            Console.Write($"Enter the amount of sale for {salespersonNames[index]}: ");
            int sale;
            if (int.TryParse(Console.ReadLine(), out sale))
            {
                // Update the sales total for the corresponding salesperson
                salesTotals[index] += sale;

                // Update the grand total
                grandTotal += sale;

                // Update the highest salesperson if needed
                int highestIndex = Array.IndexOf(allowedInitials, highestSalesperson);
                if (highestIndex == -1 || salesTotals[index] > salesTotals[highestIndex])
                {
                    highestSalesperson = input;
                }
            }
            else
            {
                Console.WriteLine("Invalid sale amount. Please enter a valid number.");
            }

        } while (true);

        // Display the results
        Console.WriteLine($"Grand Total: ${grandTotal:N0}");
        Console.WriteLine($"Highest Sale: {highestSalesperson}");

        // Wait for user input to close the console window
        Console.ReadLine();
    }
}