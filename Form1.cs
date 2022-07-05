using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = "Жена";
            textBox4.Text = Convert.ToString(seva.time);
            textBox3.Text = Convert.ToString(seva.hp);
            textBox8.Text = Convert.ToString(skillPoints);
            textBox5.Text = Convert.ToString(seva.luck);
            textBox6.Text = Convert.ToString(seva.strong);
            textBox7.Text = Convert.ToString(seva.charisma);
            textBox9.Text = seva.Location;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
        }
        List<string> locations = new List<string>() {"Квартира","Подъезд","Вход в дом","Площадка","Улица","Магазин"};
        List<Item> items = new List<Item>() {new Item("Молоко"), new Item("Пиво"), new Item("Деньги")};
        Seva seva = new Seva();
        Opponent opponent;
        int skillPoints = 5;
        string oldlocation;

        private void button1_Click(object sender, EventArgs e)
        {
            switch (seva.Location)
            {
                case "Квартира":
                    {
                        button2.Visible = false;
                        oldlocation = seva.Location; 
                        seva.Location = locations[1];
                        textBox9.Text = seva.Location;
                        break;
                    }
                case "Подъезд":
                    {
                        if (oldlocation == "Вход в дом")
                        {
                            
                        }
                        oldlocation = seva.Location;
                        seva.Location = locations[2];
                        textBox9.Text = seva.Location;
                        button5.Visible=true;
                        button10.Visible=true;
                        button1.Visible = false;
                        textBox1.Text = "Ты встретил бабок которые ругались на тебя алкаша";
                        break;
                    }
                case "Вход в дом":
                    {
                        if (oldlocation == "Площадка")
                        {
                            oldlocation = seva.Location;
                            seva.Location = locations[1];
                            textBox9.Text = seva.Location;
                            button1.Visible = false;
                            seva.final(textBox1);
                            if (textBox1.Text == "Печалька")
                            {
                                textBox1.Text = "Слушай, муженек мой, я тебе сейчас эту сковородку...";
                                opponent = new Opponent("Жена", 3, 2, "Подъезд");
                                textBox10.Text = Convert.ToString(opponent.hp);
                                textBox2.Text = Convert.ToString(opponent.name);
                                button3.Visible = true;

                            }
                           
                        }
                        else
                        {
                            oldlocation = seva.Location;
                            seva.Location = locations[3];
                            textBox9.Text = seva.Location;
                        }
                        break;
                    }
                case "Площадка":
                    {
                        if (oldlocation == "Улица")
                        {
                            oldlocation = seva.Location;
                            seva.Location = locations[2];
                            textBox9.Text = seva.Location;
                        }
                        else
                        {
                            oldlocation = seva.Location;
                            seva.Location = locations[4];
                            textBox9.Text = seva.Location;
                            textBox1.Text = "Ты стоишь у перехода, как ты пойдешь?";
                            button1.Visible=false;
                            button11.Visible=true;
                            button12.Visible = true;
                        }
                        break;
                    }
                case "Улица":
                    {
                        if(oldlocation == "Магазин")
                        {
                            textBox1.Text = "Ты встретил собутыльников, что ты будешь делать?";
                            button1.Visible=false;
                            button13.Visible = true;
                            button14.Visible = true;
                            button15.Visible = true;
                            oldlocation = seva.Location;
                            seva.Location = locations[3];
                            textBox9.Text = seva.Location;
                        }
                        else
                        {
                            textBox1.Text = "Наконец то этот гребанный магазин!";
                            oldlocation = seva.Location;
                            seva.Location = locations[5];
                            textBox9.Text = seva.Location;
                            button4.Visible=true;
                            button9.Visible = true;
                        }
                        break;
                    }
                case "Магазин":
                    {
                        textBox1.Text = "Ты стоишь у перехода, как ты пойдешь?";
                        button1.Visible = false;
                        button11.Visible = true;
                        button12.Visible = true;
                        button4.Visible = false;
                        button9.Visible = false;
                        oldlocation = seva.Location;
                        seva.Location = locations[4];
                        textBox9.Text = seva.Location;
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            seva.seek(textBox1);
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (opponent.name)
            {
                case "Гопники":
                    {
                        button5.Visible = false;
                        seva.beat(opponent);
                        textBox10.Text = Convert.ToString(opponent.hp);
                        textBox1.Text = "Неплохой удар!";
                        if (opponent.hp<1)
                        {
                            textBox1.Text = "Ты победил, неплохо";
                            button1.Visible = true;
                            button3.Visible = false;
                            textBox3.Text = Convert.ToString(seva.hp);
                            break;
                        }
                        opponent.beat(seva);
                        textBox3.Text = Convert.ToString(seva.hp);
                        if (seva.hp==0)
                        {
                            textBox1.Text = "ТЫ проиграл,в итоге ты не принес молоко жене и в итоге она ушла от тебя, ты стал одиноким алкашом под забором";
                            button1.Visible = false;
                            button2.Visible = false;
                            button3.Visible = false;
                            button4.Visible = false;
                            button5.Visible = false;
                            button9.Visible = false;
                            button10.Visible = false;
                            button11.Visible = false;
                            button12.Visible = false;
                            button13.Visible = false;
                            button14.Visible = false;
                            button15.Visible = false;
                        }
                        break;
                    }
                case "Жена":
                    {
                        button5.Visible = false;
                        seva.beat(opponent);
                        if (opponent.hp < 1)
                        {
                            textBox1.Text = "Ты победил, неплохо, правда ты почти убил жену и на тебя накатали заявление, ты сел на долгих 5 лет в тюрьму!";
                            button1.Visible = false;
                            button2.Visible = false;
                            button3.Visible = false;
                            button4.Visible = false;
                            button5.Visible = false;
                            button9.Visible = false;
                            button10.Visible = false;
                            button11.Visible = false;
                            button12.Visible = false;
                            button13.Visible = false;
                            button14.Visible = false;
                            button15.Visible = false;
                            break;
                        }
                        opponent.beat(seva);
                        if (seva.hp < 1)
                        {
                            textBox1.Text = "ТЫ проиграл,в итоге жена ушла от тебя, и ее последние слова были такие: КАК ЖЕ ТЫ ЖАЛОК!";
                            button1.Visible = false;
                            button2.Visible = false;
                            button3.Visible = false;
                            button4.Visible = false;
                            button5.Visible = false;
                            button9.Visible = false;
                            button10.Visible = false;
                            button11.Visible = false;
                            button12.Visible = false;
                            button13.Visible = false;
                            button14.Visible = false;
                            button15.Visible = false;
                        }
                        break;
                    }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            seva.buy(items[0]);
            for(int i = 0;i < seva.items.Count;i++)
            {
                if (seva.items[i].name == "Молоко")
                {
                    textBox1.Text = "Ты купил молоко";
                }
                else
                {
                    textBox1.Text = "Ты не купил молоко, не хватило денег";
                }
            }
            button4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            seva.Say(textBox1);
            if (textBox2.Text == "Гопники")
            {
                button5.Visible = false;
            }
            if (textBox1.Text == "Успешно")
            {
                button1.Visible = true;
                button3.Visible=false;
                button5.Visible=false;
                button10.Visible=false;

            }
            else
            {
                textBox1.Text = "Мда ну и мужики пошли, ни стыда ни совести, эй ребятки проучите его! Эй мужик! Ты ахерел?!";
                opponent = new Opponent("Гопники", 2, 1, "Вход в дом");
                button10.Visible = false;
                button3.Visible = true;
                textBox10.Visible = true;
                textBox10.Text = Convert.ToString(opponent.hp);
                label7.Visible = true;
                textBox2.Text = "Гопники";
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            seva.buy(items[1]);
            for (int i = 0; i < seva.items.Count; i++)
            {
                if (seva.items[i].name == "Пиво")
                {
                    textBox1.Text = "Ты купил пиво";
                }
                else
                {
                    textBox1.Text = "Ты не купил пиво, не хватило денег";
                }
            }
            button9.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(skillPoints>0)
            {
                seva.luck++;
                skillPoints--;
                textBox8.Text = Convert.ToString(skillPoints);
                textBox5.Text = Convert.ToString(seva.luck);
                if (skillPoints == 0)
                {
                    button6.Visible = false;
                    button7.Visible = false;
                    button8.Visible = false;
                }
                if(seva.luck == 5)
                {
                    button6.Visible=false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (skillPoints > 0)
            {
                seva.strong++;
                skillPoints--;
                textBox8.Text = Convert.ToString(skillPoints);
                textBox6.Text = Convert.ToString(seva.strong);
                if (skillPoints == 0)
                {
                    button6.Visible = false;
                    button7.Visible = false;
                    button8.Visible = false;
                }
                if (seva.strong == 5)
                {
                    button7.Visible = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (skillPoints > 0)
            {
                seva.charisma++;
                skillPoints--;
                textBox8.Text = Convert.ToString(skillPoints);
                textBox7.Text = Convert.ToString(seva.charisma);
                if (skillPoints == 0)
                {
                    button6.Visible = false;
                    button7.Visible = false;
                    button8.Visible = false;
                }
                if (seva.charisma == 5)
                {
                    button8.Visible = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Мда ну и мужики пошли, ни стыда ни совести, эй ребятки проучите его! Эй мужик! Ты ахерел?!";
            opponent = new Opponent("Гопники", 2, 1, "Вход в дом");
            button10.Visible = false;
            button5.Visible = true;
            button3.Visible = true;
            textBox10.Visible = true;
            textBox10.Text = Convert.ToString(opponent.hp);
            label7.Visible = true;
            textBox2.Text = "Гопники";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Visible = false;
            button12.Visible = false;
            button1.Visible = true;
            textBox1.Text = "Ты просто аккуратно перешел дорогу.";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(seva.luck >=3)
            {
                button11.Visible = false;
                button12.Visible = false;
                button1.Visible = true;
                textBox1.Text = "Отлично ты смог!";
            }
            else
            {
                textBox1.Text = "Не повезло, тебе ногу переехала машина";
                seva.hp--;
                button1.Visible = true;
                seva.status(textBox1);
                if(textBox1.Text == "Мужик, да ты помер")
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    button12.Visible = false;
                    button13.Visible = false;
                    button14.Visible = false;
                    button15.Visible = false;
                }
                textBox3.Text = Convert.ToString(seva.hp);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < seva.items.Count; i++)
            {
                if (seva.items[i].name == "Пиво")
                {
                    seva.items.RemoveAt(i);
                    textBox1.Text = "Ты отдал пиво";
                    button13.Visible = false;
                    button14.Visible = false;
                    button15.Visible = false;
                    button1.Visible=true;
                }
                else
                {
                    textBox1.Text = "У тебя нет пива, гребаный алкаш, а еще другом завешся!";
                    button14.Visible = false;
                    button13.Visible = false;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (seva.luck >=4)
            {
                textBox1.Text = "Тебе удалось, ты невероятно везуч";
                button13.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button1.Visible = true;
            }
            else
            {
                textBox1.Text = "Куда это мы уходим, А!?";
                button13.Visible = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Ну вот! Уважил!";
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button1.Visible = true;
        }
    }
}
