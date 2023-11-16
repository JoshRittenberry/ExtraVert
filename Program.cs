// See https://aka.ms/new-console-template for more information

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Ficus lyrata",
        LightNeeds = 5,
        AskingPrice = 35.99M,
        City = "Austin",
        ZIP = 78701,
        Sold = false,
        AvailableUntil = new DateOnly(2023, 5, 22)
    },
    new Plant()
    {
        Species = "Monstera deliciosa",
        LightNeeds = 2,
        AskingPrice = 25.00M,
        City = "New York",
        ZIP = 10001,
        Sold = false,
        AvailableUntil = new DateOnly(2023, 6, 16)
    },
    new Plant()
    {
        Species = "Succulent Assortment",
        LightNeeds = 4,
        AskingPrice = 15.50M,
        City = "Los Angeles",
        ZIP = 90001,
        Sold = true,
        AvailableUntil = new DateOnly(2023, 6, 4)
    },
    new Plant()
    {
        Species = "Orchid Phalaenopsis",
        LightNeeds = 2,
        AskingPrice = 20.75M,
        City = "Miami",
        ZIP = 33101,
        Sold = false,
        AvailableUntil = new DateOnly(2023, 1, 11)
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 1,
        AskingPrice = 18.00M,
        City = "Chicago",
        ZIP = 60601,
        Sold = false,
        AvailableUntil = new DateOnly(2023, 6, 29)
    },
    new Plant()
    {
        Species = "Pothos",
        LightNeeds = 4,
        AskingPrice = 12.99M,
        City = "Seattle",
        ZIP = 98101,
        Sold = true,
        AvailableUntil = new DateOnly(2024, 1, 11)
    },
    new Plant()
    {
        Species = "ZZ Plant",
        LightNeeds = 1,
        AskingPrice = 22.00M,
        City = "Boston",
        ZIP = 02101,
        Sold = false,
        AvailableUntil = new DateOnly(2023, 12, 5)
    },
    new Plant()
    {
        Species = "Peace Lily",
        LightNeeds = 2,
        AskingPrice = 17.50M,
        City = "San Francisco",
        ZIP = 94101,
        Sold = true,
        AvailableUntil = new DateOnly(2024, 1, 20)
    },
    new Plant()
    {
        Species = "Aloe Vera",
        LightNeeds = 3,
        AskingPrice = 10.00M,
        City = "Dallas",
        ZIP = 75201,
        Sold = true,
        AvailableUntil = new DateOnly(2023, 11, 26)
    },
    new Plant()
    {
        Species = "Rubber Plant",
        LightNeeds = 5,
        AskingPrice = 24.00M,
        City = "Denver",
        ZIP = 80201,
        Sold = false,
        AvailableUntil = new DateOnly(2023, 12, 16)
    },
    new Plant()
    {
        Species = "Calathea",
        LightNeeds = 2,
        AskingPrice = 30.00M,
        City = "Atlanta",
        ZIP = 30301,
        Sold = true,
        AvailableUntil = new DateOnly(2024, 1, 25)
    },
    new Plant()
    {
        Species = "Spider Plant",
        LightNeeds = 1,
        AskingPrice = 14.99M,
        City = "Portland",
        ZIP = 97201,
        Sold = false,
        AvailableUntil = new DateOnly(2023, 12, 17)
    }
};

RemoveExpiredPosts();

Random random = new Random();
int randomInteger = random.Next(0, plants.Count);

Plant PlantOfTheDay = plants[randomInteger];

while (PlantOfTheDay.Sold)
{
    randomInteger = random.Next(0, plants.Count);
    PlantOfTheDay = plants[randomInteger];
}

Console.Clear();


string greeting = @"Welcome to ExtraVert
The best place in the galaxy to buy all of your plants!";

string choice = null;

string PlantOfTheDayText = ($"ExtraVert's Plant-Of-The-Day is the {PlantOfTheDay.Species}! This plant is located in {PlantOfTheDay.City}, and has a light requirement of {PlantOfTheDay.LightNeeds}, for only ${PlantOfTheDay.AskingPrice}!");
while (choice != "0")
{
    MainMenu();
}

void MainMenu()
{
    Console.WriteLine(@$"
{greeting}

{PlantOfTheDayText}

Please Select An Option To Navigate To:
0. Exit
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. Delist a plant
5. Search all plants by Light Needed
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
        case "5":
            Console.Clear();
            SearchPlants();
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}

void ListPlants()
{
    int counter = 0;
    Console.WriteLine(@"All Plants:
    ");
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
    DateOnly AvailableUntil = DateOnly.FromDateTime(DateTime.Now.AddDays(90));

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
        Console.WriteLine(@"Adoptable Plants:
        ");
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
    string exitReminder = "At any time you may type 'exit' to return back to the main menu to stop removing a plant.";
    string userinput = null;
    int RemovePlantIndex = 0;
    Plant RemovePlant = plants[RemovePlantIndex];
    int exitOption = 0;

    List<int> plantIDs = new List<int>();

    while (exitOption == 0)
    {
        // Step 1 - Welcome
        Console.WriteLine(@$"You have choosen to remove a plant!
{exitReminder}

Press Any Key To Continue");

        Console.ReadKey();
        Console.Clear();

        // Step 2 - Display Plants
        Console.WriteLine(@"Removable Plants:
        ");
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

void SearchPlants()
{
    string exitReminder = "At any time you may type 'exit' to return back to the main menu to stop adopting a plant.";
    string userinput = null;
    int LightValue = 0;
    int exitOption = 0;
    int count = 0;

    while (exitOption == 0)
    {
        // Step 1 - Welcome
        Console.WriteLine(@$"You may search all of the available plants based on the light needed. 
Please type in a value (1-5) to be show all the plants with that value or less!

{exitReminder}
");

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
                Console.WriteLine("Please only provide a number between 1 and 5...");
            }
            else if (int.Parse(userinput) > 0 && int.Parse(userinput) <= 5)
            {
                LightValue = int.Parse(userinput);
                break;
            }
            else
            {
                Console.WriteLine("Please provide a valid response...");
            }
        }

        Console.Clear();

        // Step 2 - Display Plants
        Console.WriteLine(@$"Plants with a Light Needed value of {LightValue} or less:
        ");
        foreach (Plant plant in plants)
        {
            if (plant.LightNeeds <= LightValue)
            {
                count++;
                Console.WriteLine($"{count}. {plant.Species} is available in {plant.City} for ${plant.AskingPrice}.");
            }
        }

        count = 0;

        // Step 3 - Ask user to choose a plant
        Console.WriteLine(@"
Press Any Key To Be Returned To The Main Menu.");
        
        Console.ReadKey();
        Console.Clear();
        return;
    }
}

void RemoveExpiredPosts()
{
    for (int i = plants.Count - 1; i >= 0; i--)
    {
        if (plants[i].AvailableUntil < DateOnly.FromDateTime(DateTime.Now))
        {
            plants.RemoveAt(i);
        }
    }
}