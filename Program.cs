﻿using NLog;
using System.Reflection;
using System.Text.Json;
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();

logger.Info("Program started");

// deserialize mario json from file into List<Mario>
string marioFileName = "mario.json";
List<Mario> marios = [];
// check if file exists
if (File.Exists(marioFileName))
{
  marios = JsonSerializer.Deserialize<List<Mario>>(File.ReadAllText(marioFileName))!;
  logger.Info($"File deserialized {marioFileName}");
}

// deserialize dk json from file into List<DonkeyKong>
string donkeyKongFileName = "dk.json";
List<DonkeyKong> donkeyKongs = [];
// check if file exists
if (File.Exists(donkeyKongFileName))
{
  donkeyKongs = JsonSerializer.Deserialize<List<DonkeyKong>>(File.ReadAllText(donkeyKongFileName))!;
  logger.Info($"File deserialized {donkeyKongFileName}");
}

// deserialize sf2 json from file into List<DonkeyKong>
string streetFighterFileName = "sf2.json";
List<StreetFighter> streetFighters = [];
// check if file exists
if (File.Exists(streetFighterFileName))
{
  streetFighters = JsonSerializer.Deserialize<List<StreetFighter>>(File.ReadAllText(streetFighterFileName))!;
  logger.Info($"File deserialized {streetFighterFileName}");
}

do
{
  // display choices to user
  Console.WriteLine("1) Interact With Mario Characters");
  Console.WriteLine("2) Interact With Donkey Kong Characters");
  Console.WriteLine("3) Interact With Street Fighter II Characters");
  Console.WriteLine("Enter to quit");

  // input selection
  string? choice = Console.ReadLine();
  logger.Info("User choice: {Choice}", choice);

  if (choice == "1")
  {
    // display choices to user
    Console.WriteLine("1) Display Mario Characters");
    Console.WriteLine("2) Add Mario Character");
    Console.WriteLine("3) Remove Mario Character");
    Console.WriteLine("Enter to quit");

    // input selection
    string? choiceM = Console.ReadLine();
    logger.Info("User choice: {Choice}", choiceM);

    if (choiceM == "1")
    {
      // Display Mario Characters
      foreach (var c in marios)
      {
        Console.WriteLine(c.Display());
      }
    }
    else if (choiceM == "2")
    {
      // Add Mario Character
      // Generate unique Id
      Mario mario = new()
      {
        Id = marios.Count == 0 ? 1 : marios.Max(c => c.Id) + 1
      };
      InputCharacter(mario);
      // Add Character
      marios.Add(mario);
      File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
      logger.Info($"Character added: {mario.Name}");
    }
    else if (choiceM == "3")
    {
      // Remove Mario Character
      Console.WriteLine("Enter the Id of the character to remove:");
      if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
      {
        Mario? character = marios.FirstOrDefault(c => c.Id == Id);
        if (character == null)
        {
          logger.Error($"Character Id {Id} not found");
        }
        else
        {
          marios.Remove(character);
          // serialize list<marioCharacter> into json file
          File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
          logger.Info($"Character Id {Id} removed");
        }
      }
      else
      {
        logger.Error("Invalid Id");
      }
    }
    else if (string.IsNullOrEmpty(choiceM))
    {
      break;
    }
    else
    {
      logger.Info("Invalid choice");
    }
  }
  else if (choice == "2")
  {
    // display choices to user
    Console.WriteLine("1) Display Donkey Kong Characters");
    Console.WriteLine("2) Add Donkey Kong Character");
    Console.WriteLine("3) Remove Donkey Kong Character");
    Console.WriteLine("Enter to quit");

    // input selection
    string? choiceD = Console.ReadLine();
    logger.Info("User choice: {Choice}", choiceD);

    if (choiceD == "1")
    {
      // Display Donkey Kong Characters
      foreach (var c in donkeyKongs)
      {
        Console.WriteLine(c.Display());
      }
    }
    else if (choiceD == "2")
    {
      // Add Donkey Kong Character
      // Generate unique Id
      DonkeyKong donkeyKong = new()
      {
        Id = donkeyKongs.Count == 0 ? 1 : donkeyKongs.Max(c => c.Id) + 1
      };
      InputCharacter(donkeyKong);
      // Add Character
      donkeyKongs.Add(donkeyKong);
      File.WriteAllText(donkeyKongFileName, JsonSerializer.Serialize(donkeyKongs));
      logger.Info($"Character added: {donkeyKong.Name}");
    }
    else if (choiceD == "3")
    {
      // Remove Donkey Kong Character
      Console.WriteLine("Enter the Id of the character to remove:");
      if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
      {
        DonkeyKong? character = donkeyKongs.FirstOrDefault(c => c.Id == Id);
        if (character == null)
        {
          logger.Error($"Character Id {Id} not found");
        }
        else
        {
          donkeyKongs.Remove(character);
          // serialize list<DonketKongCharacter> into json file
          File.WriteAllText(donkeyKongFileName, JsonSerializer.Serialize(donkeyKongs));
          logger.Info($"Character Id {Id} removed");
        }
      }
      else
      {
        logger.Error("Invalid Id");
      }
    }
    else if (string.IsNullOrEmpty(choiceD))
    {
      break;
    }
    else
    {
      logger.Info("Invalid choice");
    }
  } else if (choice == "3")
    {
    // display choices to user
    Console.WriteLine("1) Display Street Fighter II Characters");
    Console.WriteLine("2) Add Street Fighter II  Character");
    Console.WriteLine("3) Remove Street Fighter II Character");
    Console.WriteLine("Enter to quit");

    // input selection
    string? choiceS = Console.ReadLine();
    logger.Info("User choice: {Choice}", choiceS);

    if (choiceS == "1")
    {
      // Display Street Fighter II Characters
      foreach (var c in streetFighters)
      {
        Console.WriteLine(c.Display());
      }
    }
    else if (choiceS == "2")
    {
      // Add Street Fighter II Character
      // Generate unique Id
      StreetFighter streetFighter = new()
      {
        Id = streetFighters.Count == 0 ? 1 : streetFighters.Max(c => c.Id) + 1
      };
      InputCharacter(streetFighter);
      // Add Character
      streetFighters.Add(streetFighter);
      File.WriteAllText(streetFighterFileName, JsonSerializer.Serialize(streetFighters));
      logger.Info($"Character added: {streetFighter.Name}");
    }
    else if (choiceS == "3")
    {
      // Remove Street Fighter II Character
      Console.WriteLine("Enter the Id of the character to remove:");
      if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
      {
        StreetFighter? character = streetFighters.FirstOrDefault(c => c.Id == Id);
        if (character == null)
        {
          logger.Error($"Character Id {Id} not found");
        }
        else
        {
          streetFighters.Remove(character);
          // serialize list<StreetFighter2Character> into json file
          File.WriteAllText(streetFighterFileName, JsonSerializer.Serialize(streetFighters));
          logger.Info($"Character Id {Id} removed");
        }
      }
      else
      {
        logger.Error("Invalid Id");
      }
    }
    else if (string.IsNullOrEmpty(choiceS))
    {
      break;
    }
    else
    {
      logger.Info("Invalid choice");
    }
  } else if (string.IsNullOrEmpty(choice))
      {
        break;
      }
      else
      {
        logger.Info("Invalid choice");
      }
} while (true);

logger.Info("Program ended");

static void InputCharacter(Character character)
{
  Type type = character.GetType();
  PropertyInfo[] properties = type.GetProperties();
  var props = properties.Where(p => p.Name != "Id");
  foreach (PropertyInfo prop in props)
  {
    if (prop.PropertyType == typeof(string))
    {
      Console.WriteLine($"Enter {prop.Name}:");
      prop.SetValue(character, Console.ReadLine());
    } else if (prop.PropertyType == typeof(List<string>)) {
      List<string> list = [];
      do {
        Console.WriteLine($"Enter {prop.Name} or (enter) to quit:");
        string response = Console.ReadLine()!;
        if (string.IsNullOrEmpty(response)){
          break;
        }
        list.Add(response);
      } while (true);
      prop.SetValue(character, list);
    }
  }
}