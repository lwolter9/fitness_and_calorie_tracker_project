using System;
using System.Collections.Generic;

namespace Fitness_Tracker_Phase_1
    {
    internal class Food //food object that allows for entry of food data 
        {
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carabohydrates { get; set; }
        public double Fat { get; set; }

        public Food()
            {
            Name = null;
            Calories = 0;
            Protein = 0;
            Carabohydrates = 0;
            Fat = 0;
            }
        public Food(string name, double cal, double prot, double carbs, double fat)
            {
            Name = name;
            Calories = cal;
            Protein = prot;
            Carabohydrates = carbs;
            Fat = fat;
            }
        }
    internal class Consumed
        {
        public double AmountConsumed { get; set; } // TODO: TEST THIS SHIT OUT
        public Food ConsumedFood { get; set; }
        public Consumed()
            {
            AmountConsumed = 0;
            ConsumedFood = new Food();
            }
        public Consumed(double amountConsumed, Food consumedFood)
            {
            AmountConsumed = amountConsumed;
            ConsumedFood = consumedFood;
            }
        }
    internal class Day // stores the food objects in 4 categories depending on user input as well as the amount of food consumed use a dictionary to acomplish this
        {
        public Dictionary<string, List<Food>> foodTime = new Dictionary<string, List<Food>> { { "breakfast", new List<Food>(1) }, { "lunch", new List<Food>(1) }, { "dinner", new List<Food>(1) }, { "snack", new List<Food>(1) } }; // TODO: figure out dictionaries

        public void createEntry() // creates a new food item and adds it to the food database
            {

            }

        public void updateEntry() // updates food in database
            {

            }

        public void deleteEntry() // updates food in database
            {

            }

        public void findEntry() // updates food in database
            {

            }
        }
    internal class Tracker //this holds all the information. the day object will act as a container for the Consumed objects. the food objects will hold individual food data. needs to check if today exists if not generate a new day object
        {

        }

    internal class Program
        {
        static void Main(string[] args)
            {
            Dictionary<string, Food> foodDatabase = new Dictionary<string, Food> { };
            Dictionary<string, List<Food>> foodTime = new Dictionary<string, List<Food>> { { "breakfast", new List<Food>(1) }, { "lunch", new List<Food>(1) }, { "dinner", new List<Food>(1) }, { "snack", new List<Food>(1) } }; // change Food to consumed. think about whether list should be changed to dict 

            double gramsConsumed;
            addFoodToDay(ref foodTime, ref foodDatabase);

            Console.Write("Enter the amount of food consume in grams: ");
            gramsConsumed = Convert.ToDouble(Console.ReadLine());


            //foodDatabase.Add(new Food(foodName, carbsPerHundred, proteinPerHundred, carbsPerHundred, fatPerHundred)); // this is similar to how a value is added to an array. since the initial capacity of the list is 0 Add has to be used
            //foodTime["breakfast"].Add(new Food(foodName, carbsPerHundred, proteinPerHundred, carbsPerHundred, fatPerHundred));
            Console.WriteLine("The amount of {0} that has been consumed is {1}. This amounts to {2} calories which consist of {3}g of protein, {4}g of carbohydrates and {5}g of fat.", foodDatabase["chicken"].Name, gramsConsumed, gramsConsumed * foodDatabase["chicken"].Calories, gramsConsumed * foodDatabase["chicken"].Protein, gramsConsumed * foodDatabase["chicken"].Carabohydrates, gramsConsumed * foodDatabase["chicken"].Fat);
            
            Console.WriteLine(foodIsInDatabase("chicken", foodDatabase));
            }

        static void addFoodToDay(ref Dictionary<string, List<Food>> day, ref Dictionary<string, Food> foodDatabase) // not done
            {
            string foodName, timeOfDay;
            Console.Write("Which meal is it [breakfast, lunch, dinner, snack]: ");
            timeOfDay = Console.ReadLine();
            Console.Write("What food did you eat: ");
            foodName = Console.ReadLine();
            if (!foodIsInDatabase(foodName, foodDatabase)) //add more exception handling in here.
                {
                createNewFood(foodDatabase);
                day[timeOfDay].Add(foodDatabase[foodName]);
                }
            else
                day[timeOfDay].Add(foodDatabase[foodName]);
            }
        static void createNewFood(Dictionary<string, Food> foodDatabase) // TODO: Write error handling function & add it to the tracker class
            {
            string foodName;
            double caloriesPerHundred;
            double proteinPerHundred;
            double carbsPerHundred;
            double fatPerHundred;

            Console.Write("Enter the name of the food: ");
            foodName = Console.ReadLine();
            Console.Write("Enter the amount of calories per 100g: ");
            caloriesPerHundred = Convert.ToDouble(Console.ReadLine()) / 100; // quantity has been divided so that everything recorded will be in 1g units
            Console.Write("Enter the amount of protein per 100g: ");
            proteinPerHundred = Convert.ToDouble(Console.ReadLine()) / 100;
            Console.Write("Enter the amount of carbs per 100g: ");
            carbsPerHundred = Convert.ToDouble(Console.ReadLine()) / 100;
            Console.Write("Enter the amount of fat per 100g: ");
            fatPerHundred = Convert.ToDouble(Console.ReadLine()) / 100;

            foodDatabase.Add(foodName, new Food(foodName, caloriesPerHundred, proteinPerHundred, carbsPerHundred, fatPerHundred));
            }

        static bool foodIsInDatabase(string foodName, Dictionary<string, Food> foodDatabase)
            {
            return foodDatabase.ContainsKey(foodName);
            }

        void deleteFoodFromDatabase(string foodName, Dictionary<string, Food> database)
            {
            database.Remove(foodName);
            }
        void deleteFoodFromDay(string foodName, string dayTime, Dictionary<string, List<Food>> database) // may need to change if consumed is used instead
            {
            database[dayTime].Remove(database[dayTime].Find(Food => Food.Name == foodName));
            }
        void displaySpecificDay()
            {

            }
        }
    }


// TODO: figure out the data needed for the day objects. current requirements: methods(sumIntakeQuantity, removeItem, addItem, existingItem, displayTodaysIntake)
// TODO: add functionality to enable multiple inputs for the same time of day
