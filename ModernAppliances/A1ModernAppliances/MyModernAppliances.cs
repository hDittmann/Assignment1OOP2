using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.Write("Enter the item number of an appliance: ");

            // Create long variable to hold item number

            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            if (!long.TryParse(Console.ReadLine(), out long itemNumber))
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance? foundAppliance = null;

            // Loop through Appliances
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable
            // Break out of loop (since we found what need to)
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }

            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number."); return;
            }

            // Otherwise (appliance was found)
            // Test found appliance is available
            // Checkout found appliance
            // Write "Appliance has been checked out."
            else if (foundAppliance.IsAvailable)
            {
                foundAppliance.Checkout();
                Console.WriteLine("Appliance has been checked out.");
            }

            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options:");
            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            Console.WriteLine("0 - Any\n2 - Double Doors\n3 - Three Doors\n4 - Four Doors");

            // Write "Enter number of doors: "
            Console.Write("Enter number of doors: ");

            // Create variable to hold entered number of doors
            // Get user input as string and assign to variable
            string? doors = Console.ReadLine();

            // Convert user input from string to int and store as number of doors variable.
            if (!int.TryParse(doors, out int numberOfDoors))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Down cast Appliance to Refrigerator
            // Refrigerator refrigerator = (Refrigerator) appliance;
            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"
            Console.WriteLine("0 - Any\n1 - Residential\n2 - Commercial");

            // Write "Enter grade:"
            Console.Write("Enter grade: ");

            // Get user input as string and assign to variable
            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string? grade = Console.ReadLine();

            // Test input is "0"
            // Assign "Any" to grade
            // Test input is "1"
            // Assign "Residential" to grade
            // Test input is "2"
            // Assign "Commercial" to grade
            // Otherwise (input is something else)
            // Write "Invalid option"
            if(grade == "0")
            {
                grade = "Any";
            }
            else if (grade == "1")
            {
                grade = "Residential";
            }
            else if (grade == "2")
            {
                grade = "Commercial";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"
            Console.WriteLine("0 - Any\n1 - 18 Volt\n2 - 24 Volt");

            // Write "Enter voltage:"
            Console.Write("Enter voltage: ");

            // Get user input as string
            // Create variable to hold voltage
            short voltage = short.Parse(Console.ReadLine());

            // Test input is "0"
            // Assign 0 to voltage
            // Test input is "1"
            // Assign 18 to voltage
            // Test input is "2"
            // Assign 24 to voltage
            // Otherwise
            // Write "Invalid option."
            if (voltage == 0)
            {
                voltage = 0;
            }
            else if (voltage == 1)
            {
                voltage = 18;
            }
            else if (voltage == 2)
            {
                voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            // Check if current appliance is vacuum
            // Down cast current Appliance to Vacuum object
            // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum vacuum)
                {
                    if ((grade == "Any" || vacuum.Grade == grade) && (voltage == 0 || vacuum.BatteryVoltage == voltage))
                    {
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"
            Console.WriteLine("0 - Any\n1 - Kitchen\n2 - Work site");

            // Write "Enter room type:"
            Console.Write("Enter room type: ");

            // Get user input as string and assign to variable

            // Create character variable that holds room type
            string? room = Console.ReadLine();

            // Test input is "0"
            // Assign 'A' to room type variable
            // Test input is "1"
            // Assign 'K' to room type variable
            // Test input is "2"
            // Assign 'W' to room type variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            // return;
            char roomType;
            if (room == "0")
            {
                roomType = 'A';
            }
            else if (room == "1")
            {
                roomType = 'K';
            }
            else if (room == "2")
            {
                roomType = 'W';
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave
            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Microwave)
                {
                    Microwave microwave = (Microwave)appliance;
                    if (room == "A" || microwave.RoomType == roomType)
                    {
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
             DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            
        }
    }
}
