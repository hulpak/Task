using System;

namespace ConsoleApp3
{
	class Vacancy:Entity
	{
		private static int _identifier = 0;
		public string _title { get; }
		public int _salary { get; }
		public Status _status { get; set; }
		public string _requirements { get; }
		public int Identifier { get; }

		public Vacancy(string Title, Status Status, DateTime CreatedDate, int Salary, string Requirements)
			: base(Title, Status, CreatedDate)
		{
			_title = Title;
			_status = Status;
			_salary = Salary;
			_requirements = Requirements;
			_identifier++;
			Identifier = _identifier;
		}

		public override string ToString()
		{
			return GetInstanceName()+" ,"+base.ToString() + " ,salary - " + _salary+ " ,requirements - "+_requirements;
		}

		public override string GetInstanceName()
		{
			return _title;
		}
	}
}
