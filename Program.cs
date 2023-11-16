﻿// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration.Assemblies;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

List<Plant> plants = new List<Plant>()
{
new Plant()
{
Species = "Ficus lyrata",
LightNeeds = 3,
AskingPrice = 35.99M,
City = "Austin",
ZIP = 78701,
Sold = false
},
new Plant()
{
Species = "Monstera deliciosa",
LightNeeds = 2,
AskingPrice = 25.00M,
City = "New York",
ZIP = 10001,
Sold = false
},
new Plant()
{
Species = "Succulent Assortment",
LightNeeds = 3,
AskingPrice = 15.50M,
City = "Los Angeles",
ZIP = 90001,
Sold = true
},
new Plant()
{
Species = "Orchid Phalaenopsis",
LightNeeds = 2,
AskingPrice = 20.75M,
City = "Miami",
ZIP = 33101,
Sold = false
},
new Plant()
{
Species = "Snake Plant",
LightNeeds = 1,
AskingPrice = 18.00M,
City = "Chicago",
ZIP = 60601,
Sold = false
}
};

Console.Clear();

string greeting = @"Welcome to ExtraVert
The best place in the galaxy to buy all of your plants!";

string choice = null;

Console.WriteLine(greeting);
while (choice != "0")
{
    MainMenu();
}

void MainMenu()
{
    Console.WriteLine(@"
Please Select An Option To Navigate To:
0. Exit
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. Delist a plant
");

    choice = Console.ReadLine().Trim();

    switch (choice)
    {
        case "0":
            Console.Clear();
            Console.WriteLine(@"Thank you for visiting ExtraVert! We hope to see you again.
Goodbye :)

Please press any key to close the application");
            Console.ReadKey();
            Console.Clear();
            break;
        case "1":
            Console.Clear();
            ListPlants();
            break;
        case "2":
            Console.Clear();
            PostPlant();
            break;
        case "3":
            Console.Clear();
            AdoptPlant();
            break;
        case "4":
            Console.Clear();
            RemovePlant();
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}

void ListPlants()
{
    int counter = 0;
    Console.WriteLine("All Plants:");
    foreach (Plant plant in plants)
    {
        counter++;
        Console.WriteLine($"{counter}. {plant.Species} in {plant.City} and {(plant.Sold ? "was sold" : "is availble")} for ${plant.AskingPrice}.");
    }
    Console.WriteLine(@"
Please press any button to return back to the main menu");
    Console.ReadKey();
    Console.Clear();
};

void PostPlant()
{
    string PlantSpecies = null;
    int PlantLightNeeds = 0;
    decimal PlantPrice = 0.00M;
    string PlantCity = null;
    int PlantZIP = 0;
    bool PlantSold = false;

    string exitReminder = "At any time you may type 'exit' to return back to the main menu to stop posting a plant for sale.";
    string userinput = null;
    int exitOption = 0;

    while (exitOption == 0)
    {
        // Step 1
        Console.WriteLine(@$"Thank you for choosing to post a plant for sale!
{exitReminder}

Press Any Key To Continue");

        Console.ReadKey();
        Console.Clear();

        // Step 2 - PlantSpecies
        Console.WriteLine(@$"Please provide the Species of your plant:");
        while (true)
        {
            userinput = Console.ReadLine().Trim();
            if (userinput == "exit")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userinput == "")
            {
                Console.WriteLine("Please provide a valid response...");
            }
            else if (int.TryParse(userinput, out _))
            {
                Console.WriteLine("The species name should not be a number...");
            }
            else
            {
                PlantSpecies = userinput;
                break;
            }
        }

        Console.Clear();

        // Step 3 - PlantLightNeeds
        Console.WriteLine(@$"Please give the amount of light needed for you plant on a scale of 1-5.");
        while (true)
        {
            userinput = Console.ReadLine().Trim();
            if (userinput == "exit")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userinput == "")
            {
                Console.WriteLine("Please provide a valid response...");
            }
            else if (!int.TryParse(userinput, out _))
            {
                Console.WriteLine("The light needed should be a number 1-5...");
            }
            else if (int.Parse(userinput) > 5 || int.Parse(userinput) < 0)
            {
                Console.WriteLine("The light needed should be a number 1-5...");
            }
            else
            {
                PlantLightNeeds = int.Parse(userinput);
                break;
            }
        }

        Console.Clear();

        // Step 4 - PlantPrice
        Console.WriteLine(@$"Please provide the price you wish to sell your plant for.");
        while (true)
        {
            userinput = Console.ReadLine().Trim();
            if (userinput == "exit")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userinput == "" || !decimal.TryParse(userinput, out _))
            {
                Console.WriteLine("Please provide a valid response...");
            }
            else if (decimal.Parse(userinput) < 0)
            {
                Console.WriteLine("The price of a plant can not be less than 0...");
            }
            else
            {
                PlantPrice = decimal.Parse(userinput);
                break;
            }
        }
        Console.Clear();

        // Step 5 - PlantCity
        Console.WriteLine(@$"Please provide the city your plant is being sold in.");
        while (true)
        {
            userinput = Console.ReadLine().Trim();
            if (userinput == "exit")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userinput == "")
            {
                Console.WriteLine("Please provide a valid response...");
            }
            else if (int.TryParse(userinput, out _))
            {
                Console.WriteLine("The City should not be a number...");
            }
            else
            {
                PlantCity = userinput;
                break;
            }
        }

        Console.Clear();

        // Step 6 - PlantZIP
        Console.WriteLine(@$"Please provide the ZIP Code your plant is being sold in.");
        while (true)
        {
            userinput = Console.ReadLine().Trim();
            if (userinput == "exit")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userinput == "")
            {
                Console.WriteLine("Please provide a valid response...");
            }
            else if (!int.TryParse(userinput, out _))
            {
                Console.WriteLine("A ZIP Code can only be a 5 digit number...");
            }
            else if (userinput.Length > 5 || userinput.Length < 5)
            {
                Console.WriteLine("A ZIP Code can only be a 5 digit number...");
            }
            else
            {
                PlantZIP = int.Parse(userinput);
                break;
            }
        }

        Console.Clear();

        // Verify Info Is Correct
        Console.WriteLine(@$"Please verify that all of your plant's information looks correct.

Species: {PlantSpecies}
Light Requirement: {PlantLightNeeds}
Price: ${PlantPrice}
City: {PlantCity}
ZIP: {PlantZIP}

Please Select An Option to Continue:
1. Post Plant for Sale
2. Make Changes
3. Cancel Post");

        exitOption = int.Parse(Console.ReadLine().Trim());
        Console.Clear();

        switch (exitOption)
        {
            // post plant for sale
            case 1:
                Console.Clear();
                Console.WriteLine(@"Your plant has been posted for sale!

Press Any Key To Continue");

                Plant newPlant = new Plant()
                {
                    Species = PlantSpecies,
                    LightNeeds = PlantLightNeeds,
                    AskingPrice = PlantPrice,
                    City = PlantCity,
                    ZIP = PlantZIP,
                    Sold = false
                };

                plants.Add(newPlant);

                Console.ReadKey();
                Console.Clear();
                break;

            // make changes to plant
            case 2:
                Console.Clear();
                Console.WriteLine(@"You've selected to make changes.

Press Any Key To Continue");
                exitOption = 0;
                Console.ReadKey();
                Console.Clear();
                break;

            // cancel post
            case 3:
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine(@"This is not a valid choice...");
                break;
        }
    }
};

void AdoptPlant()
{
    string exitReminder = "At any time you may type 'exit' to return back to the main menu to stop adopting a plant.";
    string userinput = null;
    int AdoptedPlantIndex = 0;
    Plant AdoptedPlant = plants[AdoptedPlantIndex];
    int exitOption = 0;

    List<int> plantIDs = new List<int>();

    while (exitOption == 0)
    {
        // Step 1 - Welcome
        Console.WriteLine(@$"Thank you for choosing to adopt a plant!
{exitReminder}

Press Any Key To Continue");

        Console.ReadKey();
        Console.Clear();

        // Step 2 - Display Plants
        Console.WriteLine("Adoptable Plants:");
        foreach (Plant plant in plants)
        {
            if (!plant.Sold)
            {
                plantIDs.Add(plants.IndexOf(plant) + 1);
                Console.WriteLine($"PlantID #{plants.IndexOf(plant) + 1} - {plant.Species} is available in {plant.City} for ${plant.AskingPrice}.");
            }
        }

        // Step 3 - Ask user to choose a plant
        Console.WriteLine(@"
Please provide the PlantID you wish to adopt (you may also type 'exit' to go back to the main menu).");

        // Step 4 - Validate the user input
        while (true)
        {
            userinput = Console.ReadLine().Trim();
            if (userinput.ToLower() == "exit")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userinput == "")
            {
                Console.WriteLine("Please provide a valid response...");
            }
            else if (!int.TryParse(userinput, out _))
            {
                Console.WriteLine("Please only provide the PlantID #...");
            }
            else if (int.Parse(userinput) < 0)
            {
                Console.WriteLine("This is not a valid number...");
            }
            else if (plantIDs.Contains(int.Parse(userinput)))
            {
                AdoptedPlantIndex = int.Parse(userinput) - 1;
                AdoptedPlant = plants[AdoptedPlantIndex];
                break;
            }
            else
            {
                Console.WriteLine("Please provide a valid response...");
            }
        }

        Console.Clear();
        
        // Step 5 - Verify plant adoption
        Console.WriteLine(@$"You have chosen to adopt the following plant:
        
Species: {AdoptedPlant.Species}
Light Requirement: {AdoptedPlant.LightNeeds}
Price: ${AdoptedPlant.AskingPrice}
City: {AdoptedPlant.City}
ZIP: {AdoptedPlant.ZIP}

Please Select An Option to Continue:
1. Adopt This Plant
2. Adopt A Different Plant
3. Cancel Adoption");

        exitOption = int.Parse(Console.ReadLine().Trim()); 
        switch (exitOption)
        {
            // Adopt Plant
            case 1:
                Console.Clear();
                Console.WriteLine(@"Your plant has been adopted!

Press Any Key To Continue");

                plants[AdoptedPlantIndex].Sold = true;

                Console.ReadKey();
                Console.Clear();
                break;

            // Adopt a different plant
            case 2:
                Console.Clear();
                Console.WriteLine(@"You've selected to adopt a different plant.

Press Any Key To Continue");
                exitOption = 0;
                Console.ReadKey();
                Console.Clear();
                break;

            // cancel adoption
            case 3:
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine(@"This is not a valid choice...");
                break;
        }
    }
}

void RemovePlant()
{
    string exitReminder = "At any time you may type 'exit' to return back to the main menu to stop adopting a plant.";
    string userinput = null;
    int RemovePlantIndex = 0;
    Plant RemovePlant = plants[RemovePlantIndex];
    int exitOption = 0;

    List<int> plantIDs = new List<int>();

    while (exitOption == 0)
    {
        // Step 1 - Welcome
        Console.WriteLine(@$"Thank you for choosing to adopt a plant!
{exitReminder}

Press Any Key To Continue");

        Console.ReadKey();
        Console.Clear();

        // Step 2 - Display Plants
        Console.WriteLine("Adoptable Plants:");
        foreach (Plant plant in plants)
        {
            plantIDs.Add(plants.IndexOf(plant) + 1);
            Console.WriteLine($"PlantID #{plants.IndexOf(plant) + 1} - {plant.Species} is available in {plant.City} for ${plant.AskingPrice}.");
        }

        // Step 3 - Ask user to choose a plant
        Console.WriteLine(@"
Please provide the PlantID you wish to remove (you may also type 'exit' to go back to the main menu).");

        // Step 4 - Validate the user input
        while (true)
        {
            userinput = Console.ReadLine().Trim();
            if (userinput.ToLower() == "exit")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userinput == "")
            {
                Console.WriteLine("Please provide a valid response...");
            }
            else if (!int.TryParse(userinput, out _))
            {
                Console.WriteLine("Please only provide the PlantID #...");
            }
            else if (int.Parse(userinput) < 0)
            {
                Console.WriteLine("This is not a valid PlantID #...");
            }
            else if (plantIDs.Contains(int.Parse(userinput)))
            {
                RemovePlantIndex = int.Parse(userinput) - 1;
                break;
            }
            else
            {
                Console.WriteLine("Please provide a valid response...");
            }
        }

        Console.Clear();

        // Step 5 - Verify plant deletion
        Console.WriteLine(@$"You have chosen to remove the following plant:
        
Species: {RemovePlant.Species}
Light Requirement: {RemovePlant.LightNeeds}
Price: ${RemovePlant.AskingPrice}
City: {RemovePlant.City}
ZIP: {RemovePlant.ZIP}

Please Select An Option to Continue:
1. Remove This Plant
2. Remove A Different Plant
3. Cancel");

        exitOption = int.Parse(Console.ReadLine().Trim());
        switch (exitOption)
        {
            // Remove Plant
            case 1:
                Console.Clear();
                Console.WriteLine(@"Your plant has been removed!

Press Any Key To Continue");

                plants.RemoveAt(RemovePlantIndex);

                Console.ReadKey();
                Console.Clear();
                break;

            // Remove a different plant
            case 2:
                Console.Clear();
                Console.WriteLine(@"You've selected to remove a different plant.

Press Any Key To Continue");
                exitOption = 0;
                Console.ReadKey();
                Console.Clear();
                break;

            // cancel
            case 3:
                Console.Clear();
                Console.WriteLine(@"You've selected to cancel...

Press Any Key To Be Returned To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine(@"This is not a valid choice...");
                break;
        }
    }
}