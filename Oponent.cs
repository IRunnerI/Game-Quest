using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
	internal class Opponent : Person
	{
		int strong;
		public Opponent(string name, int hp, int strong, string Location)
		{
			this.name = name;
			this.hp = hp;
			this.strong = strong;
			this.Location = Location;
		}
		public void beat(Person person)
		{
			person.hp -= strong;
		}
	}
}
