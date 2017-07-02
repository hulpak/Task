using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
	class SmallCompany:Entity
	{
		private string _name { get; }
		private string _industry { get; }
		private List<Vacancy> _vacancies { get; }
		private Vacancy _vacancy;
		private const int Max_Active_Vacancy = 5;
		private static int activeVacancy = 0;
		private int currentActive;

		public SmallCompany(string Name, Status status, DateTime CreateDate,string Industry) 
			: base(Name, status, CreateDate)
		{
			_name = Name;
			_industry = Industry;
			_vacancies = new List<Vacancy>();
		}

		public void AddVacancy(string Name, Status Status, DateTime CreatedDate, int Salary, string Requirements)
		{
			if (Status == Status.Active)
			{
				activeVacancy++;
				currentActive = activeVacancy;
				if (currentActive <= Max_Active_Vacancy)
				{
					_vacancy = new Vacancy(Name, Status, CreatedDate, Salary, Requirements);
					_vacancies.Add(_vacancy);
				}

			}
			else
			{
				_vacancy = new Vacancy(Name, Status, CreatedDate, Salary, Requirements);
				_vacancies.Add(_vacancy);
			}
		}

		public void CloseVacancy(int identifier)
		{
			Vacancy vacancy = _vacancies.Where(t => t.Identifier == identifier)
				.First();
			vacancy._status = Status.Closed;
		}

		public override string ToString()
		{
			return GetInstanceName() + " ," + base.ToString() + " , " + _industry ;
		}

		public override void ChangeStatus(Status status)
		{
			if (status == Status.Closed)
			{
				foreach (var vacancy in _vacancies)
				{
					vacancy._status = Status.Closed;
				}
			}
			base.ChangeStatus(status);
		}

		public void VacancyListToString()
		{
			foreach (var vacancy in _vacancies)
			{
				Console.WriteLine(vacancy._title + " - " + vacancy._status + ", " + vacancy._salary);
			}
		}

		public Vacancy GetVacancy(int identifier)
		{
			return _vacancies.Where(t => t.Identifier == identifier)
				.FirstOrDefault();
		}

		public override string GetInstanceName()
		{
			return _name;
		}
	}
}
