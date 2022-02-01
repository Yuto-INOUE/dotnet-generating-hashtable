using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			for (var i = 0; i < 10; i++)
			{
				Measure(
					() =>
					{
						for (var j = 0; j < 1000000; j++)
						{
							var s = new ManyProperties();
							var ht = s.AsHashtable1();
						}
					});

				Measure(
					() =>
					{
						for (var j = 0; j < 1000000; j++)
						{
							var s = new ManyProperties();
							var ht = s.AsHashtable2();
						}
					});
			}

			Console.ReadLine();
		}

		static void Measure(Action action)
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			action.Invoke();

			stopWatch.Stop();
			Console.WriteLine($"Elapsed -> {stopWatch.ElapsedMilliseconds} [ms]");
		}
	}

	static class StringExtensions
	{
		public static string ToLowerSnakeCase(this string src)
		{
			if (src == null) throw new ArgumentNullException(nameof(src));

			var sb = new StringBuilder();
			foreach (var c in src)
			{
				if ('A' <= c && c <= 'Z')
				{
					if (sb.Length > 0)
					{
						sb.Append("_");
					}

					sb.Append(c.ToString().ToLowerInvariant());
				}
				else
				{
					sb.Append(c.ToString());
				}
			}

			return sb.ToString();
		}
	}

	class ManyProperties
	{
		public Hashtable AsHashtable1()
		{
			return new Hashtable
			{
				{ nameof(this.Prop1).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop2).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop3).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop4).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop5).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop6).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop7).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop8).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop9).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop10).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop11).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop12).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop13).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop14).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop15).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop16).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop17).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop18).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop19).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop20).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop21).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop22).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop23).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop24).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop25).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop26).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop27).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop28).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop29).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop30).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop31).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop32).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop33).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop34).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop35).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop36).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop37).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop38).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop39).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop40).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop41).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop42).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop43).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop44).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop45).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop46).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop47).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop48).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop49).ToLowerSnakeCase(), this.Prop1 },
				{ nameof(this.Prop50).ToLowerSnakeCase(), this.Prop1 },
			};
		}

		public Hashtable AsHashtable2()
		{
			var dic = GetType()
				.GetProperties(BindingFlags.DeclaredOnly)
				.ToDictionary(
					p => p.Name.ToLowerSnakeCase(),
					p => (string)p.GetValue(this));
			return new Hashtable(dic);
		}

		public string Prop1 { get; } = "";
		public string Prop2 { get; } = "";
		public string Prop3 { get; } = "";
		public string Prop4 { get; } = "";
		public string Prop5 { get; } = "";
		public string Prop6 { get; } = "";
		public string Prop7 { get; } = "";
		public string Prop8 { get; } = "";
		public string Prop9 { get; } = "";
		public string Prop10 { get; } = "";
		public string Prop11 { get; } = "";
		public string Prop12 { get; } = "";
		public string Prop13 { get; } = "";
		public string Prop14 { get; } = "";
		public string Prop15 { get; } = "";
		public string Prop16 { get; } = "";
		public string Prop17 { get; } = "";
		public string Prop18 { get; } = "";
		public string Prop19 { get; } = "";
		public string Prop20 { get; } = "";
		public string Prop21 { get; } = "";
		public string Prop22 { get; } = "";
		public string Prop23 { get; } = "";
		public string Prop24 { get; } = "";
		public string Prop25 { get; } = "";
		public string Prop26 { get; } = "";
		public string Prop27 { get; } = "";
		public string Prop28 { get; } = "";
		public string Prop29 { get; } = "";
		public string Prop30 { get; } = "";
		public string Prop31 { get; } = "";
		public string Prop32 { get; } = "";
		public string Prop33 { get; } = "";
		public string Prop34 { get; } = "";
		public string Prop35 { get; } = "";
		public string Prop36 { get; } = "";
		public string Prop37 { get; } = "";
		public string Prop38 { get; } = "";
		public string Prop39 { get; } = "";
		public string Prop40 { get; } = "";
		public string Prop41 { get; } = "";
		public string Prop42 { get; } = "";
		public string Prop43 { get; } = "";
		public string Prop44 { get; } = "";
		public string Prop45 { get; } = "";
		public string Prop46 { get; } = "";
		public string Prop47 { get; } = "";
		public string Prop48 { get; } = "";
		public string Prop49 { get; } = "";
		public string Prop50 { get; } = "";
	}
}
