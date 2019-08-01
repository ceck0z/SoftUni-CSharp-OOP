
namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;


        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();
        }

        public void run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();
                var departament = inputArgs[0];
                var firstName = inputArgs[1];
                var lastName = inputArgs[2];
                var patient = inputArgs[3];
                var fullName = firstName + lastName;

                addDoctor(fullName);

                addDepartment(departament);

                // isFree = imaMqsto
                bool isFree = departments[departament]
                    .SelectMany(x => x) // - достъпва дъщерните листове в лист 
                    .Count() < 60;

                if (isFree)
                {

                    doctors[fullName].Add(patient);

                    addPatientToRoom(departament, patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    var allPatientsInDepartment = departments[departmentName]
                        .Where(x => x.Count > 0)
                        .SelectMany(x => x)
                        .ToArray();

                    Console.WriteLine(string.Join(Environment.NewLine, allPatientsInDepartment ));
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int room);

                    if (isRoom)
                    {

                        string departmentName = args[0];

                        var allPatientInRoom = departments[args[0]][room - 1]
                           .OrderBy(x => x)
                           .ToArray();

                        Console.WriteLine(string.Join(Environment.NewLine, allPatientInRoom));

                    }
                    else
                    {

                        string fullName = args[0] + args[1];
                        string departmentName = args[0];

                        var allPatientOfDoctor = doctors[fullName]
                            .OrderBy(x => x)
                            .ToArray();

                        Console.WriteLine(string.Join(Environment.NewLine, allPatientOfDoctor));
                    }

                    
                }
                command = Console.ReadLine();
            }
        }

        private void addPatientToRoom(string departament, string patient)
        {
            int room = 0;

            for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
            {
                if (departments[departament][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            //int targetRoom = departments[departament]
            //    .SelectMany(x => x)
            //    .Where(x => x.Count() < 3 )
            //    .FirstOrDefault();

            departments[departament][room].Add(patient);
        }

        private void addDepartment(string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private void addDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
