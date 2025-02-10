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
    internal class Consumed // container for a food object and the amount consumed
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
        public Dictionary<string, List<Consumed>> foodTime = new Dictionary<string, List<Consumed>> { { "breakfast", new List<Consumed>(1) }, { "lunch", new List<Consumed>(1) }, { "dinner", new List<Consumed>(1) }, { "snack", new List<Consumed>(1) } }; // TODO: figure out dictionaries

        /*
         foodTime -> foodTime
         asks for meal time and food name. if food exists in list asks if user would like to modify otherwise does not add food
         
         
         */
        public void CreateEntry(Dictionary<string, List<Consumed>> foodTime, Dictionary<string, Food> database) // creates a new consumed item and adds it to the food database
            {
            string foodName, timeOfDay;
            Console.Write("Which meal is it [breakfast, lunch, dinner, snack]: ");
            timeOfDay = Console.ReadLine();
            Console.Write("What food did you eat: ");
            foodName = Console.ReadLine(); // ok so here is the thought. this method can end here. call it through a method in the tracker class and have that method handle the checks since that method is responsible for most actions. that way i can keep everything nicely separated into their own functions.
            if (!FoodIsInDatabase(foodName, foodDatabase)) //this has gotten a bit complicated. i need to access the database of food from tracker in this method to retreive food items and add them to the day.
                {
                CreateNewFood(foodDatabase);
                day[timeOfDay].Add(foodDatabase[foodName]);
                }
            else
                day[timeOfDay].Add(foodDatabase[foodName]);
            }
        /*
         
         
         */
        public void UpdateEntry() // updates food in database
            {

            }
        /*
         
         
         
         */
        public void DeleteEntry() // deletes food in database
            {

            }
        /*
         
         
         
         
         */
        public bool FindEntry(string foodName, Dictionary<string, List<Consumed>> foodList) // checks if food is in database
            {
            return true;
            }

        }
    internal class Tracker //this holds all the information. the day object will act as a container for the Consumed objects. the food objects will hold individual food data. needs to check if today exists if not generate a new day object
        {
        static public Dictionary<string, Day> Calendar = new Dictionary<string, Day> { };
        static public List<Food> Foods = new List<Food>(1);

        static void DisplaySpecificDay(Dictionary<string, Day> calendar, string date)
            {

            }
        static void DeleteFoodFromDatabase(string foodName, Dictionary<string, Food> database) //adjust to take Calendar
            {
            database[dayTime].Remove(database[dayTime].Find(Food => Food.Name == foodName));
            }
        /*
        HtDF
        foodName, Dictionary -> Boolean
        checks if a foodName is in a Dictionary and returns true if it is in
        static bool FoodIsInDatabase(string foodName, Dictionary<string, Food> foodDatabase)

        */
        static bool FoodIsInDatabase(string foodName, Dictionary<string, Food> foodDatabase)
            {
            return foodDatabase.ContainsKey(foodName);
            }

        /*
        Implementation of HtDP course
        HtDF:
       foodDatabase -> void
       creates a new food and adds it to the database
       static void CreateNewFood(foodDatabase){return;}



        */
        static void CreateNewFood(Dictionary<string, Food> foodDatabase) // TODO: Write error handling function & add it to the tracker class
            {
            /*
             Implementation of HtDP course
            HtDD:
            foodName is String
            interp. name of a food item
            const string FOOD_CUT = "chicken";

            static void FunctionForFoodName(fn)
            {
            return fn;
            }
             */
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
        static void AddDayToCalendar()
            {

            }

        }

    internal class Program
        {
        static void Main(string[] args)
            {
            Dictionary<string, Food> foodDatabase = new Dictionary<string, Food> { { "chicken", new Food("chicken", 1, 1, 1, 1) } };
            Dictionary<string, List<Food>> foodTime = new Dictionary<string, List<Food>> { { "breakfast", new List<Food>(1) }, { "lunch", new List<Food>(1) }, { "dinner", new List<Food>(1) }, { "snack", new List<Food>(1) } }; // change Food to consumed. think about whether list should be changed to dict 

            double gramsConsumed;
            AddFoodToDay(ref foodTime, ref foodDatabase);

            Console.Write("Enter the amount of food consume in grams: ");
            gramsConsumed = Convert.ToDouble(Console.ReadLine());


            //foodDatabase.Add(new Food(foodName, carbsPerHundred, proteinPerHundred, carbsPerHundred, fatPerHundred)); // this is similar to how a value is added to an array. since the initial capacity of the list is 0 Add has to be used
            //foodTime["breakfast"].Add(new Food(foodName, carbsPerHundred, proteinPerHundred, carbsPerHundred, fatPerHundred));
            Console.WriteLine("The amount of {0} that has been consumed is {1}. This amounts to {2} calories which consist of {3}g of protein, {4}g of carbohydrates and {5}g of fat.", foodTime["breakfast"][0].Name, gramsConsumed, gramsConsumed * foodTime["breakfast"][0].Calories, gramsConsumed * foodTime["breakfast"][0].Protein, gramsConsumed * foodTime["breakfast"][0].Carabohydrates, gramsConsumed * foodTime["breakfast"][0].Fat);
            DeleteFoodFromDatabase("chicken", foodDatabase);
            Console.WriteLine(FoodIsInDatabase("chicken", foodDatabase));
            }

        static void AddFoodToDay(ref Dictionary<string, List<Food>> day, ref Dictionary<string, Food> foodDatabase) // not done
            {
            string foodName, timeOfDay;
            Console.Write("Which meal is it [breakfast, lunch, dinner, snack]: ");
            timeOfDay = Console.ReadLine();
            Console.Write("What food did you eat: ");
            foodName = Console.ReadLine();
            if (!FoodIsInDatabase(foodName, foodDatabase)) //add more exception handling in here.
                {
                CreateNewFood(foodDatabase);
                day[timeOfDay].Add(foodDatabase[foodName]);
                }
            else
                day[timeOfDay].Add(foodDatabase[foodName]);
            }
        }
    }


// TODO: figure out the data needed for the day objects. current requirements: methods(sumIntakeQuantity, removeItem, addItem, existingItem, displayTodaysIntake)
// TODO: add functionality to enable multiple inputs for the same time of day
