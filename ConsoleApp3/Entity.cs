using System;

namespace ConsoleApp3
{
	enum Status
	{
		Active,
		Closed
	}
	abstract class Entity
	{
		private string EntityName;
		private Status Status { get; set; }
		public DateTime CreatedDate { get; }

		public Entity(string EntityName, Status Status, DateTime CreatedDate)
		{
			this.EntityName = EntityName;
			this.Status = Status;
			this.CreatedDate = CreatedDate;
		}
		public virtual void ChangeStatus(Status status) {
			if(status!=Status.Closed)
				this.Status = Status.Closed;
		}
		public abstract string GetInstanceName();

		public override string ToString()
		{
			return  Status + " , " + CreatedDate;
		}
	}
}