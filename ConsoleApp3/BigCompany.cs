using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp3
{
	class BigCompany:Entity
	{
		private string _name { get; }
		private string _industry { get; }
		private List<Vacancy> _vacancies { get; }
		private int _countOfPartners { get; set; }
		private Vacancy _vacancy;

		public BigCompany(string Name, Status status, DateTime CreateDate, string Industry,int CountOfPartners)
			: base(Name, status, CreateDate)
		{
			_name = Name;
			_industry = Industry;
			_vacancies = new List<Vacancy>();
			_countOfPartners = CountOfPartners;
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
			_countOfPartners = 0;
		base.ChangeStatus(status);
	}

	public void AddVacancy(string Name,Status Status,DateTime CreatedDate, int Salary,string Requirements)
		{
			_vacancy = new Vacancy(Name,Status,CreatedDate, Salary, Requirements);
			_vacancies.Add(_vacancy);
		}

		public void CloseVacancy(int identifier) {
			Vacancy vacancy = _vacancies.Where(t=>t.Identifier == identifier)
				.First();
			vacancy._status = Status.Closed;
		}

		public Vacancy GetVacancy(int identifier)
		{
			return _vacancies.Where(t => t.Identifier == identifier)
				.FirstOrDefault();
		}

		public void VacancyListToString()
		{
			foreach (var vacancy in _vacancies)
			{
				Console.WriteLine(vacancy._title+ " - "+vacancy._status+", "+vacancy._salary);
			}
		}

		public override string ToString()
		{
			return GetInstanceName() + " ," + base.ToString() + " , " + _industry + " , "+ _countOfPartners;  
		}

		public double GetSalaryBudget() {
			var salaryBudget = 0.0;
			foreach(var vacancy in _vacancies)
			{
				if (vacancy._status == Status.Active)
				{
					salaryBudget += vacancy._salary;
				}
			}
			return salaryBudget;
		}

		public override string GetInstanceName()
		{
			return _name;
		}
	}
}
