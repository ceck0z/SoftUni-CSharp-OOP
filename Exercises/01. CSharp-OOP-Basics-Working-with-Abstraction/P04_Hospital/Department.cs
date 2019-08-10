namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        public Department(string name)
        {
            this.Name = name;

            this.rooms = new List<Room>();

            this.CreateRooms();
        }
        
        public string Name { get; set; }

        public List<Room> rooms { get; set; }

        private void CreateRooms()
        {
            for (int i = 0; i < 20; i ++)
            {
                this.rooms.Add(new Room());
            }
        }

        public void AddPatientToRoom(Patient patient)
        {
            var currentRoom = this.rooms.Where(x => !x.IsFull).FirstOrDefault();

            if (currentRoom != null)
            {
               currentRoom.AddPatient(patient);
            }           
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in this.rooms)
            {
                foreach (var patient in room.Patients)
                {
                    sb.AppendLine(patient.Name);
                }

            }

            return sb.ToString().TrimEnd();
        }
    }
}
