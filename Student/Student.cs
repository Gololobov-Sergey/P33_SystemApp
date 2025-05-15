namespace Student
{
    /// <summary>
    /// Клас Студент
    /// </summary>
    /// 
    public class Student
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDay { get; set; }


        public Student()
        {
            
        }

        public Student(string firstName, string lastName, DateTime birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
        }

        /// <summary>
        /// Виводить інформацію про студента
        /// </summary>
        public void Info()
        {
            Console.WriteLine($"{LastName.PadRight(15)} {FirstName.PadRight(10)} {BirthDay.ToShortDateString()}");

        }



        public override int GetHashCode()
        {
            return $"{LastName}{FirstName}".GetHashCode();
        }

    }
}
