namespace ExamQualificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("       EXAM QUALIFICATION APP");
            Console.WriteLine("======================================");
            Console.WriteLine();

            double test1 = ReadMark("Enter Test 1 mark: ");
            double test2 = ReadMark("Enter Test 2 mark: ");
            double assignment1 = ReadMark("Enter Assignment 1 mark: ");
            double project = ReadMark("Enter Project mark: ");

            double weightedAverage =
                (test1 * 0.30) +
                (test2 * 0.50) +
                (assignment1 * 0.10) +
                (project * 0.10);

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine($"Weighted average: {weightedAverage:F2}%");

            if (weightedAverage >= 50)
            {
                Console.WriteLine("Result: The student qualifies to write the exam.");
            }
            else
            {
                Console.WriteLine("Result: The student does not qualify to write the exam.");
            }

            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }

        static double ReadMark(string message)
        {
            while (true)
            {
                Console.Write(message);

                string? input = Console.ReadLine();

                if (double.TryParse(input, out double mark) &&
                    mark >= 0 &&
                    mark <= 100)
                {
                    return mark;
                }

                Console.WriteLine("Invalid input. Please enter a number from 0 to 100.");
            }
        }
    }
}