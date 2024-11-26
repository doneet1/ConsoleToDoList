namespace ConsoleToDoList
{
    internal class Program
    {
        static void Main()
        {
            //Creates task list
            List<string> tasks = new();
            string currentFile = "";
            Console.WriteLine("What do you want to do?\n" +
                "1. Show all tasks.\n" +
                "2. Add a task.\n" +
                "3. Remove a task.\n" +
                "4. Load tasks from a file\n" +
                "5. Save tasks to a file\n" +
                "0. Exit the Application\n\n" +
                "(type a number)");
            int option;
            bool success = int.TryParse(Console.ReadLine(), out option);
            if (!success)
            {
                Console.WriteLine("Type a correct number!");
                Menu();
            }
            while (true)
            {
                switch (option)
                {
                    case 0:
                        //Exits the application
                        Environment.Exit(0);
                        break;
                    case 1:
                        //Shows all tasks
                        Console.WriteLine("---\nTasks:\n");
                        if (tasks.Count != 0)
                        {
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.Write("\t" + i + ". ");
                                Console.WriteLine(tasks[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No tasks found!");
                        }
                        Console.WriteLine();
                        Menu();
                        break;
                    case 2:
                        //Adds a task
                        Console.WriteLine("---\nType the task:");
                        string newTask = Console.ReadLine();
                        tasks.Add(newTask);
                        Console.WriteLine("Task Added Successfuly!\n\n");
                        Menu();
                        break;
                    case 3:
                        //Removes a task
                        Console.WriteLine("---\nTasks:");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.Write(i + ". ");
                            Console.WriteLine(tasks[i]);
                        }
                        Console.WriteLine("\nWhich task to remove? (write task's index):");
                        int removedTask = Convert.ToInt32(Console.ReadLine());
                        tasks.RemoveAt(removedTask);
                        Console.WriteLine("Task Removed Successfuly!\n\n");
                        Menu();
                        break;
                    case 4:
                        //Loads tasks from a file
                        int loadOption;
                        Console.WriteLine($"---\n" +
                            $"What do you want to do? (type a number)\n" +
                            $"1. Load from default path (C:\\Users\\{Environment.UserName}\\Documents\\tasks.txt)\n" +
                            $"2. Load from custom file\n" +
                            $"3. Go back.");
                        loadOption = Convert.ToInt32(Console.ReadLine());
                        string[] fileContent;
                        switch (loadOption)
                        {
                            case 1:
                                //Loads tasks from C:\Users\current_user\Documents\tasks.txt
                                if (!File.Exists($"C:\\Users\\{Environment.UserName}\\Documents\\tasks.txt"))
                                {
                                    Console.WriteLine($"File C:\\Users\\{Environment.UserName}\\Documents\\tasks.txt Doesn't exist");
                                    Menu();
                                    break;
                                }
                                fileContent = File.ReadAllLines($"C:\\Users\\{Environment.UserName}\\Documents\\tasks.txt");
                                foreach(string line in fileContent)
                                {
                                    tasks.Add(line);
                                }
                                Console.WriteLine("File successfuly read!\n\n");
                                currentFile = ($"C:\\Users\\{Environment.UserName}\\Documents\\tasks.txt");
                                Menu();
                                break;
                            case 2:
                                //Loads tasks from C:\Users\current_user\Documents\user_file.txt
                                Console.WriteLine("Type the file's name (file must be located in \"Documents\" folder!");
                                string customFileName = Console.ReadLine();
                                if (!File.Exists($"C:\\Users\\{Environment.UserName}\\Documents\\{customFileName}.txt"))
                                {
                                    Console.WriteLine($"File C:\\Users\\{Environment.UserName}\\Documents\\{customFileName}.txt Doesn't exist");
                                }
                                fileContent = File.ReadAllLines($"C:\\Users\\{Environment.UserName}\\Documents\\{customFileName}.txt");
                                foreach (string line in fileContent)
                                {
                                    tasks.Add(line);
                                }
                                Console.WriteLine("File successfuly read!\n\n");
                                currentFile = ($"C:\\Users\\{Environment.UserName}\\Documents\\{customFileName}.txt");
                                Menu();
                                break;
                            case 3:
                                Menu();
                                break;
                        }
                        break;
                    case 5:
                        //Saves tasks to a file
                        int saveOption = 0;
                        Console.WriteLine($"---\n" +
                            $"What do you want to do? (type a number)\n" +
                            $"1. Override current file\n" +
                            $"2. Save to new file\n" +
                            $"3. Go back.");
                        saveOption = Convert.ToInt32(Console.ReadLine());
                        switch (saveOption)
                        {
                            case 1:
                                //Overrides current file
                                if(string.IsNullOrEmpty(currentFile))
                                {
                                    Console.WriteLine("There is no file to override!\n\n");
                                    Menu();
                                    break;
                                }
                                File.WriteAllLines(currentFile, tasks);
                                Console.WriteLine("File overridden successfuly!");
                                break;
                            case 2:
                                //Saves to a new file
                                Console.WriteLine("---\n" +
                                    "Type your desired file name:");
                                string newFileName = Console.ReadLine();
                                File.WriteAllLines($"C:\\Users\\{Environment.UserName}\\Documents\\{newFileName}.txt", tasks);
                                Console.WriteLine($"File successfuly saved in C:\\Users\\{Environment.UserName}\\Documents\\{newFileName}.txt\n\n");
                                Menu();
                                break;
                            case 3:
                                Menu();
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            void Menu()
            {
                Console.WriteLine("What do you want to do?\n" +
                        "1. Show all tasks.\n" +
                        "2. Add a task.\n" +
                        "3. Remove a task.\n" +
                        "4. Load tasks from a file\n" +
                        "5. Save tasks to a file\n" +
                        "0. Exit the Application\n\n" +
                        "(type a number)");
                success = int.TryParse(Console.ReadLine(), out option);
                if (!success)
                {
                    Console.WriteLine("Type a correct number!");
                    Menu();
                }
            }
        }
    }
}
