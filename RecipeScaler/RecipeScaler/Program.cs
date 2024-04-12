using System;

namespace RecipeScaler
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            while (true)
            {
                Console.WriteLine("Recipe Scaler");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear All Data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option:");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            recipe.EnterDetails();
                            break;
                        case 2:
                            recipe.DisplayRecipe();
                            break;
                        case 3:
                            recipe.ScaleRecipe();
                            break;
                        case 4:
                            recipe.ResetQuantities();
                            break;
                        case 5:
                            recipe.ClearData();
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }

    class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;

        public void EnterDetails()
        {
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount;
            if (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            ingredients = new string[ingredientCount];
            quantities = new double[ingredientCount];
            units = new string[ingredientCount];

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                ingredients[i] = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of {ingredients[i]}:");
                if (!double.TryParse(Console.ReadLine(), out quantities[i]) || quantities[i] <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                    return;
                }

                Console.WriteLine($"Enter the unit of measurement for {ingredients[i]}:");
                units[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount;
            if (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            steps = new string[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps[i] = Console.ReadLine();
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{ingredients[i]}: {quantities[i]} {units[i]}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe()
        {
            Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
            double factor;
            if (!double.TryParse(Console.ReadLine(), out factor) || (factor != 0.5 && factor != 2 && factor != 3))
            {
                Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3.");
                return;
            }

            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Assuming original quantities are saved somewhere and can be retrieved
            // For this example, resetting to default values (1)
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = 1;
            }
        }

        public void ClearData()
        {
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;
        }
    }
}
1
