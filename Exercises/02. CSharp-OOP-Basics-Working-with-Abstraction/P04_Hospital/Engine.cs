namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Hospital hospital;

        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();

            hospital = new Hospital();
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
                var fullName = firstName + " " + lastName;

                this.hospital.AddDoctor(firstName, lastName);
                this.hospital.AddDepartment(departament);
                this.hospital.AddPatient(fullName, departament, patient);
                
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    Department department = this.hospital.departments.FirstOrDefault(x => x.Name == departmentName);

                    Console.WriteLine(department);                   
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int targetRoom);

                    if (isRoom)
                    {
                        string departmentName = args[0];

                        Room room = this.hospital.departments.FirstOrDefault(x => x.Name == departmentName).rooms[targetRoom - 1];

                        Console.WriteLine(room);
                    }
                    else
                    {

                        string fullName = args[0] + " " + args[1];

                        Doctor doctor = this.hospital.Doctors.FirstOrDefault(x => x.FullName == fullName);
                        Console.WriteLine(doctor);
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
