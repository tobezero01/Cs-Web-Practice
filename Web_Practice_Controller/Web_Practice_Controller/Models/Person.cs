namespace Web_Practice_Controller.Models
{
	public class Person
	{
		public Guid Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public int Age { get; set; }

		public Person(Guid id, string firstName, string lastName, int age)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
		}

		public string getFullName()
		{ return FirstName + " " + LastName; }
	}
}