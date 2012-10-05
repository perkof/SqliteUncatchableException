using System;
using SQLite;

namespace Problems
{
	public class TestObject
	{
		[Indexed]
		[PrimaryKey]
		public string Id { get; set; }

		public string Property1 { get; set; }
		public string Property2  { get; set; }
		public string Property3 { get; set; }
	}
}

