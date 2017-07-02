using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{

			Vacancy juniorNet = new Vacancy("Junior.Net developer", Status.Active, DateTime.Now, 200, "--");
			Vacancy juniorJava = new Vacancy("Junior java developer", Status.Active, DateTime.Now, 300, "spring webflow, spring MVC");
			Vacancy SeniorNet = new Vacancy("Senior.Net developer", Status.Closed, DateTime.Now, 1600, " ");

			BigCompany sharpMinds = new BigCompany("SharpMinds", Status.Active, DateTime.Now, " -- ", 100);
			sharpMinds.AddVacancy("Junior.Net developer", Status.Active, DateTime.Now, 300, "EF, ASP.MVC, WPF");
			sharpMinds.AddVacancy(juniorJava._title, juniorJava._status, juniorJava.CreatedDate, juniorJava._salary, juniorJava._requirements);
			sharpMinds.AddVacancy("Middle.Net Developer", Status.Active, DateTime.Now, 800, "...");
			sharpMinds.AddVacancy("Senior front-end", Status.Active, DateTime.Now, 1400, " ");
			sharpMinds.AddVacancy(SeniorNet._title, SeniorNet._status, SeniorNet.CreatedDate, SeniorNet._salary, SeniorNet._requirements);
			Console.WriteLine(sharpMinds.ToString());
			sharpMinds.VacancyListToString();
			Console.WriteLine(sharpMinds.GetSalaryBudget());
			Console.WriteLine(" ----------------------------------------- ");


			SmallCompany softimus = new SmallCompany("Softimus", Status.Active, DateTime.Now, "Small company");
			softimus.AddVacancy(juniorNet._title, juniorNet._status, juniorNet.CreatedDate, juniorNet._salary, juniorNet._requirements);
			softimus.AddVacancy("Junior front-end", Status.Active, DateTime.Now, 250, "--");
			softimus.AddVacancy("Midle.Net", Status.Active, DateTime.Now, 500, "--");
			Console.WriteLine(softimus.ToString());
			softimus.VacancyListToString();
			Console.WriteLine(" ----------------------------------------- ");

			sharpMinds.CloseVacancy(6);
			Console.WriteLine(sharpMinds.ToString());
			sharpMinds.VacancyListToString();
			Console.WriteLine(" ----------------------------------------- ");

			softimus.CloseVacancy(9);
			Console.WriteLine(softimus.ToString());
			softimus.VacancyListToString();
			Console.WriteLine(" ------------------------------------------ ");

			sharpMinds.ChangeStatus(Status.Active);
			Console.WriteLine(sharpMinds.ToString());
			sharpMinds.VacancyListToString();
			Console.WriteLine(" ------------------------------------------ ");

			sharpMinds.ChangeStatus(Status.Closed);
			Console.WriteLine(sharpMinds.ToString());
			sharpMinds.VacancyListToString();
			Console.WriteLine(" ------------------------------------------ ");

			softimus.ChangeStatus(Status.Closed);
			Console.WriteLine(softimus.ToString());
			softimus.VacancyListToString();
			Console.WriteLine(" ------------------------------------------ ");

			var entities = new List<Entity>()
			{
				new BigCompany("SharpMinds", Status.Active, DateTime.Now, " -- ", 100),
				new BigCompany("SoftServe", Status.Active, DateTime.Now, " -- ", 140),
				new SmallCompany("GlobalIT", Status.Active, DateTime.Now, "Software"),
				new BigCompany("EPAM", Status.Closed, DateTime.Now, " -- ", 340),
				new SmallCompany("Yuron", Status.Active, DateTime.Now, "Software")
			};

			foreach (var entity in entities)
			{
				Console.WriteLine(entity.ToString());
			}

			Console.ReadKey();
		}
	}
}
