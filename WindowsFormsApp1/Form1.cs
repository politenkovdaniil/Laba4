using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Movie> MovieList = new List<Movie>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)//Кнопка перезаполнить
        {
            this.MovieList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) //генерирует остаток отделения на 3 (от 0 до 2)
                {
                    case 0:
                        this.MovieList.Add(Film.Generate());//если 0  фильм
                        listBox1.Items.Add(i + 1 + ") Фильм");//в листбук добавить строчку "Фильм"
                        break;
                    case 1:
                        this.MovieList.Add(Serial.Generate());//если 1 сериал
                        listBox1.Items.Add(i + 1 + ") Сериал");//в листбук добавить строчку "Сериал"
                        break;
                    case 2:
                        this.MovieList.Add(TV.Generate());//если 2 телепередача
                        listBox1.Items.Add(i + 1 + ") Телепередача");//в листбук добавить строчку "Телепередача"
                        break;
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            int FilmCount = 0;
            int SerialCount = 0;
            int TVCount = 0;

            foreach (var fruit in this.MovieList)
            {
                if (fruit is Film)// если фильм то +1 к фильмам
                {
                    FilmCount += 1;
                }
                else if (fruit is Serial)// если фильм то +1 к сериалам 
                {
                    SerialCount += 1;
                }
                else if (fruit is TV)// если фильм то +1 к телепередачам
                {
                    TVCount += 1;
                }
            }

            txtInfo.Text = "Фильм\tСериал\tТелепередача";// вывод на ричбокс 
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", FilmCount, SerialCount, TVCount);
        }

        private void btnGet_Click(object sender, EventArgs e)//Кнопка взять
        {
            if (this.MovieList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";
                pictureBox1.Image = null;
                return;
            }
            //минус один и удаление строчки из листбука
            var Movie = this.MovieList[0];
            this.MovieList.RemoveAt(0);
            listBox1.Items.Remove(listBox1.Items[0]);
            txtOut.Text = Movie.GetInfo();
            pictureBox1.Image = Movie.GetImage();
            ShowInfo();
        }
    }
}
