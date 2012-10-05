using System;
using SQLite;
using System.IO;
using System.Timers;

namespace Problems
{
	public static class SqlLiteHelper
	{

		private static SQLiteConnection _connection;
		private static Timer _timer;

		private static readonly string _databaseFile = String.Format("{0}/TestDatabase.db", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
		public static SQLiteConnection GetConnection ()
		{
			if(_connection != null)
				return _connection;

			var exists = File.Exists(_databaseFile);

			var connection = new SQLiteConnection(_databaseFile, true)
			{
				BusyTimeout = TimeSpan.FromSeconds(10),
				Trace = false
			};


			if(!exists)
			{
				connection.CreateTable<TestObject>();
			}

			_connection = connection;

			return _connection;
		}

		public static TableQuery<TestObject> GetQuery ()
		{
			return _connection.Table<TestObject>();
		}
	
		public static void StartCreatingRecords ()
		{
			_timer = new Timer
			{
				AutoReset = true,
				Interval = 0.6 * 1000,
			};

			_timer.Elapsed += CreateRecords;

			_timer.Start();
		}

		public static void StopCreatingRecords ()
		{
			_timer.Stop();
		}

		static void CreateRecords (object sender, ElapsedEventArgs e)
		{
			try{
			// create 200 records
				for (int i = 0; i<200; i++) {
					var myRecord = new TestObject {
						Id = Guid.NewGuid().ToString(),
						Property1 = Guid.NewGuid().ToString(),
						Property2 = Guid.NewGuid().ToString(),
						Property3 = Guid.NewGuid().ToString(),
					};

					_connection.Insert(myRecord, typeof(TestObject));
				}
			} catch (Exception ex)
			{
				Console.WriteLine(string.Format("This should catch the exception: {0}", ex));
			}
		}
	}
}

