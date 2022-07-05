using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
	internal class Seva : Person
	{
		
		public List<Item> items;
		public int luck;
		public int strong;
		public int charisma;
		public int time;
		Random random = new Random();
		public Seva()
		{
			Item item = new Item("Деньги");
			items = new List<Item>();
			this.name = "Сева";
			this.hp = 3;
			this.Location = "Квартира";
			luck = 1;
			strong = 1;
			charisma = 1;
			time = 120;
			this.items.Add(item);
		}
		public void beat(Person person)
		{
			person.hp -= strong;
		}
		public void Say(TextBox textBox) // договориться с кем нибудь
		{
			double chance = 0.2 * charisma;
			double risk = random.NextDouble();
			if (chance > risk)
			{
				textBox.Text = "Успешно";
			}
			else
			{
				textBox.Text = "Провал";
			}
		}
		public void buy(Item item)
		{
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].name == "Деньги")
				{
					items.Remove(items[i]);
					this.items.Add(item);
					break;
				}
				else
				{
					Console.Write("У тебя нет деняг, вали отсюда");
				}
			}
		}
		public void seek(TextBox textBox)  //поиск заначки
		{
			if (this.luck >= 4)
			{
				textBox.Text = "Успешно, ты нашел еще деняг";
				Item item = new Item("Деньги");
				this.items.Add(item);
			}
			else
			{
				textBox.Text = "Провал";
			}
		}
		public void final(TextBox textBox)
		{
			if (time >= 0)
			{
				for (int i = 0; i < items.Count; i++)
				{
					if (items[i].name == "Молоко")
					{
						items.Remove(items[i]);
						textBox.Text = "Спасибо, дорогой"; // Победа, конец
					break;
					}
					else
					{
						textBox.Text = "Печалька"; // после этого будет файт
					}
				}
			}
			else
			{

			}
		}
		public void status(TextBox textBox)
		{
			if (hp <= 0)
			{
				textBox.Text = "Мужик, да ты помер";
			}
	
		}
		public void timekiller(int time)
        {
			this.time -= time;
        }
	}
}
