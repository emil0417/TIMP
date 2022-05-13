using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Отель
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            stop_1(); //убирает превый интерфейс
            nachal_desig(); // включаем экран загрузки
            clasSozd1();// создаём объекты класса гость
            clasSozd2();// создаём объекты класса номер


            stop_2();//убираем второй интерфейс
            stop_3();//убираем третий интерфейс
            stop_4();//убираем четвёртый интерфейс
            stop_5();//убираем пятый интерфейс
            stop_6();//убираем шестой интерфейс
            stop_7();//убираем седьмой интерфейс
            stop_8();//убираем восьмой интерфейс

        }


        const int kol_pers = 50;//задаём максимальное количество гостей
        const int kol_nom = 50;//задаём максимальное количество номеров
        int kol_strok = 0;//счётчик строк
        string path = "";//переменная для пути файла с ланными
        int schet = 0;//счётчик
        int zpnom = 1;//счётчик
        int nazad = 1;//счётчик
        int nazad2 = 1;//счётчик
        int knopka = 1;//счётчик
        int izmen = -1;//счётчик
        int ydalit = -1;//счётчик
        long nn = 0;//счётчик

        Guest[] pers = new Guest[kol_pers];//создаём экземпляры класса гость
        Nomer[] nom = new Nomer[kol_nom];//создаём экземпляры класса номер
        GuestZap perszap = new GuestZap();//создаём экземпляры вспомогательного класса гость2

        private void clasSozd1()
        {
            for (int i = 0; i < kol_pers; i++)
            {
                pers[i] = new Guest();
            }
        } // метод который создаёт объекты класса гость с помощью цикла
        private void clasSozd2()
        {
            for (int i = 0; i < kol_nom; i++)
            {
                nom[i] = new Nomer();
            }

            for (int i = 0; i < kol_nom; i++)  //заполняем свойства объекта
            {
                if (i < 10)//премиум 10
                {
                    nom[i].Lux = "Люкс";
                    nom[i].Prise = 10000;
                    nom[i].Storey = 5;
                    nom[i].KolvoMest = 4;
                    nom[i].Vid = "Красивый";
                    nom[i].KolBedroom = 5;
                    nom[i].Seif = "Есть";
                    nom[i].Internet = "Есть";
                    nom[i].DataOt = "";
                    nom[i].Namber = i + 1;
                }
                else
                {
                    nom[i].Lux = "Эконом";
                    nom[i].DataOt = "";
                    if (zpnom == 1)// 1 комнт
                    {
                        nom[i].Prise = 2000;
                        nom[i].KolvoMest = 1;
                        nom[i].KolBedroom = 1;
                        nom[i].Namber = i + 1;
                    }
                    else  // 2 комнаты
                    {
                        nom[i].Prise = 5000;
                        nom[i].KolvoMest = 2;
                        nom[i].KolBedroom = 2;
                        nom[i].Namber = i + 1;
                    }
                    zpnom *= -1;
                }
            }
            for (int i = 10; i < kol_nom; i++)
            {
                if (zpnom == 1)
                {
                    nom[i].Vid = "Красивый";
                    nom[i].Seif = "Нет";
                }
                else
                {
                    nom[i].Vid = "Обычный";
                    nom[i].Seif = "Есть";
                }
                zpnom *= -1;
                if (i < 20)
                {
                    nom[i].Storey = 1;
                    nom[i].Internet = "Нет";
                }
                if (i >= 20 && i < 30)
                {
                    nom[i].Storey = 2;
                    nom[i].Internet = "Нет";
                }
                if (i >= 30 && i < 40)
                {
                    nom[i].Storey = 3;
                    nom[i].Internet = "Нет";
                }
                if (i >= 40 && i < 50)
                {
                    nom[i].Storey = 4;
                    nom[i].Internet = "Есть";
                    nom[i].Prise += 500;
                }
            }
        }  //метод который создаёт объекты класса номер с помощью цикла

        private void zapolnenie()
        {
            try // конструкция обработки исключений
            {
                path = @textBox9.Text;

                StreamReader f = new StreamReader(path); //открываем файл
                while (!f.EndOfStream) //если файл открыт то заполняем свойства объетов
                {

                    string s = f.ReadLine();  //присваиваем переменной строку
                    string[] slovo = s.Split(new char[] { ' ' }); //разделяем строку по пробеллам



                    pers[schet].SeName = slovo[0];  //заполняем свойства объектов
                    pers[schet].Name = slovo[1];
                    pers[schet].FatherName = slovo[2];
                    pers[schet].Grazgdanstvo = slovo[3];
                    pers[schet].Pasport = slovo[4];
                    pers[schet].DayBirth = int.Parse(slovo[5]);
                    pers[schet].MonhBirth = int.Parse(slovo[6]);
                    pers[schet].YearBirth = int.Parse(slovo[7]);
                    pers[schet].NumberPhon = slovo[8];
                    pers[schet].InDay = int.Parse(slovo[9]);
                    pers[schet].InMonth = int.Parse(slovo[10]);
                    pers[schet].InYear = int.Parse(slovo[11]);
                    pers[schet].OutDay = int.Parse(slovo[12]);
                    pers[schet].OutMonth = int.Parse(slovo[13]);
                    pers[schet].OutYear = int.Parse(slovo[14]);
                    pers[schet].PersNomer = int.Parse(slovo[15]);
                    nom[pers[schet].PersNomer - 1].DataOt = pers[schet].OutDay + " " + pers[schet].OutMonth + " " + pers[schet].OutYear;

                    schet++;
                    kol_strok++;
                }
                f.Close(); //закрываем файл
                MessageBox.Show("данные успешно импортированы", "Уведомление");//выводим уведомление
                stop_3();//закрываем третий интерфейс
                zags_1();//запускаем первый интерфейс
            }
            catch //в случае возникновения исключения реализуется данный блок кода
            {
                MessageBox.Show("Введён не корректный путь к файлу повторите ввод", "Уведомление");
                textBox9.Text = "";
            }

        } //метод производит импорт данных

        private async void nachal_desig()
        {
            this.BackColor = Color.White;  //изменяем вид формы

            this.pictureBox1.Location = new System.Drawing.Point(125, 53);

            this.pictureBox1.Size = new System.Drawing.Size(677, 404);

            this.pictureBox2.Location = new System.Drawing.Point(760, 484);

            this.pictureBox2.Size = new System.Drawing.Size(153, 66);

            await Task.Delay(4000); // задержка на 4 секунды
            stop_nachal_desig(); //убираем экран загрузки
            zags_1();//загружаем первый интерфейс
        } //асинхронный метод который производит загрузку начального экрана

        private void stop_nachal_desig()
        {
            this.pictureBox1.Location = new Point(0, -1000); //убираем компоненты формы
            this.pictureBox2.Location = new Point(0, -1000);
        } // метод который убирает начальный экран

        private void stop_1()
        {
            this.button1.Location = new Point(0, -500);//убираем компоненты формы
            this.label1.Location = new Point(0, -500);
            this.button2.Location = new Point(0, -500);
            this.button3.Location = new Point(0, -500);
            this.button4.Location = new Point(0, -500);
            this.button22.Location = new Point(0, -500);
        } //метод который убирает первый интерфейс

        private void zags_1()
        {
            this.BackColor = Color.Black;  // устанавливаем компоненты формы
            // 
            // button1
            // 
            button1.Location = new Point(350, 139);
            button1.Size = new Size(273, 68);
            button1.Text = "Ввести нового гостя";
            // 
            // label1
            // 
            label1.Location = new Point(280, 55);
            label1.Size = new System.Drawing.Size(0, 39);
            label1.Text = "Выберите дальнейшие действия";
            // 
            // button2
            // 
            button2.Location = new Point(350, 226);
            button2.Size = new Size(273, 68);
            button2.Text = "Просмотр и поиск данных";
            // 
            // button3
            // 
            button3.Location = new Point(350, 322);
            button3.Size = new Size(273, 68);
            button3.Text = "Изменение и удаление данных";
            // 
            // button4
            // 
            button4.Location = new Point(350, 414);
            button4.Size = new Size(273, 68);
            button4.Text = "Импортировать данные";

            this.button22.BackColor = System.Drawing.Color.White;
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button22.Location = new System.Drawing.Point(740, 500);
            this.button22.Name = "button21";
            this.button22.Size = new System.Drawing.Size(166, 68);
            this.button22.TabIndex = 94;
            this.button22.Text = "Закрыть приложение";
            this.button22.UseVisualStyleBackColor = false;


        } //метод который загружает первый интерфейс

        private void stop_2()
        {
            this.label2.Location = new System.Drawing.Point(0, -500); //убираем компоненты формы
            this.label3.Location = new System.Drawing.Point(0, -500);
            this.label4.Location = new System.Drawing.Point(0, -500);
            this.label5.Location = new System.Drawing.Point(0, -500);
            this.label6.Location = new System.Drawing.Point(0, -500);
            this.label7.Location = new System.Drawing.Point(0, -500);
            this.label8.Location = new System.Drawing.Point(0, -500);
            this.label9.Location = new System.Drawing.Point(0, -500);
            this.label10.Location = new System.Drawing.Point(0, -500);
            this.label11.Location = new System.Drawing.Point(0, -500);
            this.label12.Location = new System.Drawing.Point(0, -500);
            this.textBox1.Location = new System.Drawing.Point(0, -500);
            this.textBox2.Location = new System.Drawing.Point(0, -500);
            this.textBox3.Location = new System.Drawing.Point(0, -500);
            this.textBox4.Location = new System.Drawing.Point(0, -500);
            this.textBox5.Location = new System.Drawing.Point(0, -500);
            this.textBox6.Location = new System.Drawing.Point(0, -500);
            this.textBox7.Location = new System.Drawing.Point(0, -500);
            this.textBox8.Location = new System.Drawing.Point(0, -500);
            this.radioButton1.Location = new System.Drawing.Point(0, -500);
            this.radioButton2.Location = new System.Drawing.Point(0, -500);
            this.groupBox1.Location = new System.Drawing.Point(0, -500);
            this.button5.Location = new System.Drawing.Point(0, -500);
        }  //метод который убирает второй интерфейс

        private void zags_2()
        {
            // устанавливаем компоненты формы
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(342, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите данные клиента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-31, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1365, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "_________________________________________________________________________________" +
    "_______________________________________________________________________________________";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(57, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 24);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(270, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 24);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(481, 93);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(192, 24);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(53, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Фамилия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(265, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Имя";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(475, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Отчество";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(76, 182);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 23);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "РФ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Checked = false;

            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(153, 182);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(125, 23);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Иностранное";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Checked = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(55, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Гражданство";
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(57, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 54);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(57, 283);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(317, 24);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(53, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(242, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Серия и номер паспорта";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(57, 379);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(154, 24);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox6.Location = new System.Drawing.Point(250, 379);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(154, 24);
            this.textBox6.TabIndex = 20;
            this.textBox6.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(53, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 23);
            this.label9.TabIndex = 21;
            this.label9.Text = "Дата приезда";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(246, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 23);
            this.label10.TabIndex = 22;
            this.label10.Text = "Дата отъезда";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(477, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 23);
            this.label11.TabIndex = 24;
            this.label11.Text = "Дата рождения";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox7.Location = new System.Drawing.Point(481, 283);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(154, 24);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(53, 436);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(169, 23);
            this.label12.TabIndex = 26;
            this.label12.Text = "Номер телефона";
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox8.Location = new System.Drawing.Point(57, 470);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(192, 24);
            this.textBox8.TabIndex = 25;
            this.textBox8.Text = "";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(710, 450);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 65);
            this.button5.TabIndex = 27;
            this.button5.Text = "Далее";
            this.button5.UseVisualStyleBackColor = false;
        } //метод который загружает второй интерфейс

        private void stop_3()
        {
            this.label13.Location = new System.Drawing.Point(0, -500); //убираем компоненты формы
            this.textBox9.Location = new System.Drawing.Point(0, -500);
            this.button6.Location = new System.Drawing.Point(0, -500);
            this.groupBox2.Location = new System.Drawing.Point(0, -500);
            this.button23.Location = new System.Drawing.Point(0, -500);
        } //метод который убирает третий интерфейс

        private void zags_3()
        {
            // устанавливаем компоненты формы
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(60, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(452, 25);
            this.label13.TabIndex = 28;
            this.label13.Text = "Для импорта файла вставьте путь к нему";
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox9.Location = new System.Drawing.Point(254, 210);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(447, 24);
            this.textBox9.TabIndex = 29;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(254, 267);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(447, 61);
            this.button6.TabIndex = 30;
            this.button6.Text = "Импортировать";
            this.button6.UseVisualStyleBackColor = false;


            this.button23.BackColor = System.Drawing.Color.White;
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button23.ForeColor = System.Drawing.Color.Black;
            this.button23.Location = new System.Drawing.Point(254, 500);
            this.button23.Name = "button22";
            this.button23.Size = new System.Drawing.Size(447, 77);
            this.button23.TabIndex = 94;
            this.button23.Text = "В главное меню";
            this.button23.UseVisualStyleBackColor = false;
            //// 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(197, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 269);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
        }   //метод который загружает третий интерфейс

        private void stop_4()
        {
            this.label14.Location = new System.Drawing.Point(0, -500); //убираем компоненты формы
            this.label15.Location = new System.Drawing.Point(0, -500);
            this.label18.Location = new System.Drawing.Point(0, -500);
            this.label19.Location = new System.Drawing.Point(0, -500);
            this.label20.Location = new System.Drawing.Point(0, -500);
            this.label21.Location = new System.Drawing.Point(0, -500);
            this.label22.Location = new System.Drawing.Point(0, -500);
            this.label23.Location = new System.Drawing.Point(0, -500);
            this.label24.Location = new System.Drawing.Point(0, -500);
            this.comboBox1.Location = new System.Drawing.Point(0, -500);
            this.comboBox2.Location = new System.Drawing.Point(0, -500);
            this.comboBox3.Location = new System.Drawing.Point(0, -500);
            this.comboBox4.Location = new System.Drawing.Point(0, -500);
            this.comboBox5.Location = new System.Drawing.Point(0, -500);
            this.comboBox6.Location = new System.Drawing.Point(0, -500);
            this.comboBox7.Location = new System.Drawing.Point(0, -500);

            this.button7.Location = new System.Drawing.Point(0, -500);
            this.textBox10.Location = new System.Drawing.Point(0, -500);
            this.button8.Location = new System.Drawing.Point(0, -500);
            this.label16.Location = new System.Drawing.Point(0, -500);
            this.label17.Location = new System.Drawing.Point(0, -500);
            this.button10.Location = new System.Drawing.Point(0, -500);
        } //метод который убирает четвёртый интерфейс

        private void zags_4()
        {
            // устанавливаем компоненты формы
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(259, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(398, 35);
            this.label14.TabIndex = 34;
            this.label14.Text = "Выберите тип размещения";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(-1, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(1056, 25);
            this.label15.TabIndex = 35;
            this.label15.Text = "_________________________________________________________________________________" +
    "______";

            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(321, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 24);
            this.comboBox1.TabIndex = 61;
            this.comboBox1.Text = "";
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(53, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 20);
            this.label18.TabIndex = 62;
            this.label18.Text = "Тип номера";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(53, 194);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(142, 20);
            this.label19.TabIndex = 64;
            this.label19.Text = "Количество мест";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(322, 193);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(132, 246);
            this.comboBox2.TabIndex = 63;
            this.comboBox2.Text = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(54, 242);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(97, 20);
            this.label20.TabIndex = 66;
            this.label20.Text = "Вид из окна";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(322, 241);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(165, 30);
            this.comboBox3.TabIndex = 65;
            this.comboBox3.Text = "";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(54, 294);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(234, 20);
            this.label21.TabIndex = 68;
            this.label21.Text = "Количество спальных комнат";
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(322, 293);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(132, 24);
            this.comboBox4.TabIndex = 67;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            this.comboBox4.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(542, 146);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(126, 20);
            this.label22.TabIndex = 70;
            this.label22.Text = "Наличие сейфа";
            // 
            // comboBox5
            // 
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(740, 146);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(126, 24);
            this.comboBox5.TabIndex = 69;
            this.comboBox5.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(542, 194);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(157, 20);
            this.label23.TabIndex = 72;
            this.label23.Text = "Наличие интернета";
            // 
            // comboBox6
            // 
            this.comboBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(740, 193);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(126, 24);
            this.comboBox6.TabIndex = 71;
            this.comboBox6.Text = "";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(542, 242);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 20925);
            this.label24.TabIndex = 74;
            this.label24.Text = "Этаж";
            // 
            // comboBox7
            // 
            this.comboBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(740, 241);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(126, 24);
            this.comboBox7.TabIndex = 73;
            this.comboBox7.Text = "";

            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(692, 306);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(223, 84);
            this.button7.TabIndex = 54;
            this.button7.Text = "Выполнить поиск свободных номеров";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox10.Location = new System.Drawing.Point(341, 457);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(96, 27);
            this.textBox10.TabIndex = 55;
            this.textBox10.Text = "";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(692, 437);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(223, 67);
            this.button8.TabIndex = 56;
            this.button8.Text = "Заселить";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.ForeColor = System.Drawing.Color.Black;
            this.button10.Location = new System.Drawing.Point(692, 510);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(223, 45);
            this.button10.TabIndex = 75;
            this.button10.Text = "В главное меню";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(-52, 393);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1056, 25);
            this.label16.TabIndex = 57;
            this.label16.Text = "_________________________________________________________________________________" +
    "______";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(53, 457);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(262, 25);
            this.label17.TabIndex = 58;
            this.label17.Text = "Заселить гостя в номер";


        } //метод который загружает четвёртый интерфейс

        private void stop_5()
        {
            this.dataGridView1.Location = new System.Drawing.Point(-1, -1000); //убираем компоненты формы
            this.button9.Location = new System.Drawing.Point(-1, -500);
        } //метод который убирает пятый интерфейс

        private void zags_5()
        {
            // устанавливаем компоненты формы
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(-1, -1);
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(952, 592);
            this.dataGridView1.TabIndex = 59;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(-1, 550);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(1013, 50);
            this.button9.TabIndex = 60;
            this.button9.Text = "Назад";
            this.button9.UseVisualStyleBackColor = true;
        } //метод который загружает пятый интерфейс

        private void stop_6()
        {
            this.label25.Location = new System.Drawing.Point(0, -500); //убираем компоненты формы
            this.button11.Location = new System.Drawing.Point(0, -500);
            this.button12.Location = new System.Drawing.Point(0, -500);
            this.label26.Location = new System.Drawing.Point(0, -500);
            this.textBox11.Location = new System.Drawing.Point(0, -500);
            this.button13.Location = new System.Drawing.Point(0, -500);
            this.button15.Location = new System.Drawing.Point(0, -500);
        } //метод который убирает шестой интерфейс

        private void zags_6()
        {
            // устанавливаем компоненты формы
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(373, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(285, 25);
            this.label25.TabIndex = 76;
            this.label25.Text = "Просмотр и поиск данных";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(150, 108);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(255, 90);
            this.button11.TabIndex = 77;
            this.button11.Text = "Вывод всех данных о номере";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(619, 108);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(255, 90);
            this.button12.TabIndex = 78;
            this.button12.Text = "Вывод всех данных о клиентах";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(385, 281);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(264, 23);
            this.label26.TabIndex = 79;
            this.label26.Text = "Введите фамилию клиента";
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox11.Location = new System.Drawing.Point(344, 320);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(338, 24);
            this.textBox11.TabIndex = 80;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.White;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(344, 361);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(333, 77);
            this.button13.TabIndex = 81;
            this.button13.Text = "Поиск клиента по фамилии";
            this.button13.UseVisualStyleBackColor = false;

            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.White;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button15.Location = new System.Drawing.Point(344, 450);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(333, 77);
            this.button15.TabIndex = 84;
            this.button15.Text = "В главное меню";
            this.button15.UseVisualStyleBackColor = false;
        } //метод который загружает шестой интерфейс

        private void stop_7()
        {
            this.button14.Location = new System.Drawing.Point(0, -500); //убираем компоненты формы
            this.dataGridView2.Location = new System.Drawing.Point(0, -1000);
        } //метод который убирает седьмой интерфейс

        private void zags_7()
        {
            // устанавливаем компоненты формы
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(-3, -4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(955, 523);
            this.dataGridView2.TabIndex = 82;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(-3, 516);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(1005, 80);
            this.button14.TabIndex = 83;
            this.button14.Text = "Назад";

        } //метод который загружает седьмой интерфейс

        private void stop_8()
        {
            this.label27.Location = new System.Drawing.Point(0, -500); //убираем компоненты формы
            this.button16.Location = new System.Drawing.Point(0, -500);
            this.textBox12.Location = new System.Drawing.Point(0, -500);
            this.button17.Location = new System.Drawing.Point(0, -500);
            this.textBox13.Location = new System.Drawing.Point(0, -500);
            this.label28.Location = new System.Drawing.Point(0, -500);
            this.button18.Location = new System.Drawing.Point(0, -500);
            this.button19.Location = new System.Drawing.Point(0, -500);
            this.button20.Location = new System.Drawing.Point(0, -500);
        } //метод который убирает восьмой интерфейс

        private void zags_8()
        {
            // устанавливаем компоненты формы
            nazad2 = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Black;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(238, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(568, 29);
            this.label27.TabIndex = 85;
            this.label27.Text = "Выберите запись для изменения или удаления";
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.White;
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button16.Location = new System.Drawing.Point(102, 122);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(207, 62);
            this.button16.TabIndex = 86;
            this.button16.Text = "Вывести всех клиентов";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox12.Location = new System.Drawing.Point(378, 241);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(207, 24);
            this.textBox12.TabIndex = 87;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.White;
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button17.Location = new System.Drawing.Point(102, 222);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(207, 62);
            this.button17.TabIndex = 88;
            this.button17.Text = "Найти по фамилии";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox13.Location = new System.Drawing.Point(378, 317);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(207, 24);
            this.textBox13.TabIndex = 89;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Black;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(98, 318);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(251, 23);
            this.label28.TabIndex = 90;
            this.label28.Text = "Введите паспорт клиента";
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.White;
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button18.Location = new System.Drawing.Point(102, 373);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(207, 62);
            this.button18.TabIndex = 91;
            this.button18.Text = "Изменить запись";
            this.button18.UseVisualStyleBackColor = false;
            
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.White;
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button19.Location = new System.Drawing.Point(378, 373);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(207, 62);
            this.button19.TabIndex = 92;
            this.button19.Text = "Удалить запись";
            this.button19.UseVisualStyleBackColor = false;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.White;
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button20.Location = new System.Drawing.Point(102, 466);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(483, 62);
            this.button20.TabIndex = 93;
            this.button20.Text = "Выйти в главное меню";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
        } //метод который загружает восьмой интерфейс



        private void button1_Click(object sender, EventArgs e) // Кнопка осуществляет переход в интерфейс для записи гостя
        {
            knopka = 1;
            if (kol_pers > kol_strok) // проверка на количество гостей
            {
                stop_1(); // закрываем первый интерфейс
                zags_2(); // загружаем второй интерфейс
            }
            else
            {
                zags_1(); // загружаем первый интерфейс
                MessageBox.Show("Гостиница переполнена", "уведомление");//выводим сообщение
            }

        }



        private void button2_Click(object sender, EventArgs e) // Кнопка осуществляет переход в интерфейс для просмотра и поиска данных
        {
            stop_1();// закрываем первый интерфейс
            zags_6();// загружаем шестой интерфейс
        }

        private void button3_Click(object sender, EventArgs e) // Кнопка осуществляет переход в интерфейс для изменения и  удаления данных
        {
            stop_1();// закрываем первый интерфейс
            zags_8();// загружаем восьмой интерфейс

        }

        private void button4_Click(object sender, EventArgs e) // Кнопка осуществляет переход в интерфейс для импортирта данных
        {
            stop_1();// закрываем первый интерфейс
            zags_3();// загружаем третий интерфейс
        }

        //=====================================================================================
        private void label3_Click(object sender, EventArgs e)
        {

        }
        //=====================================================================================

        private void button5_Click(object sender, EventArgs e)//кнопка осуществляет запись данных в объект спомогательного класса гость 2 и переход в интерфейс выбора номера
        {
            if (knopka == 1) //проверка счётчика для определения функционала кнопки
            {//кнопка записывает данные гостя
                if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == "") || (radioButton1.Checked == false && radioButton2.Checked == false)) //проверка на заполненность данных
                {
                    MessageBox.Show("Заполните все поля", "Уведомление");
                }
                else
                {
                    if ((textBox1.Text.Any(char.IsDigit) == true) || (textBox2.Text.Any(char.IsDigit) == true) || (textBox3.Text.Any(char.IsDigit) == true)) //проверка на содержание цифр
                    {
                        MessageBox.Show("В полях фамилия имя и отчество не должны содержаться цифры", "Уведомление");
                    }
                    else if ((long.TryParse(textBox4.Text, out nn) == false) || (long.TryParse(textBox8.Text, out nn) == false))//проверка на содержание букв
                    {
                        MessageBox.Show("В полях номер паспорта и номер телефона не должны содержаться буквы", "Уведомление");
                        
                    }
                    else if ((radioButton1.Checked == true) && ((textBox4.Text.Length != 10) || (textBox4.Text.StartsWith(" ")) || (textBox4.Text.EndsWith(" ")))) //проверка на количество цифр в серии и номере паспорта
                    {

                        MessageBox.Show("Серия и номер паспорта должны быть записаны без пробелов и содержать 10 цифр", "Уведомление");      
                    }
                    else if ((radioButton2.Checked == true) && ((textBox4.Text.Length != 9) || (textBox4.Text.StartsWith(" ")) || (textBox4.Text.EndsWith(" ")))) //проверка на количество цифр в серии и номере паспорта
                    {
                        MessageBox.Show("Серия и номер паспорта должны быть записаны без пробелов и содержать 9 цифр", "Уведомление");
                    }
                    else //запись даныых в объект вспомогательного класса гость2
                    {
                        perszap.Name = textBox2.Text;
                        perszap.SeName = textBox1.Text;
                        perszap.FatherName = textBox3.Text;
                        if (radioButton1.Checked == true)
                        {
                            perszap.Grazgdanstvo = "РФ";
                        }
                        else if (radioButton2.Checked == true)
                        {
                            perszap.Grazgdanstvo = "Иностранное";
                        }
                        try //обработка исключений
                        {
                            perszap.Pasport = textBox4.Text;
                            string ss1 = textBox5.Text;
                            string[] den = ss1.Split(new char[] { ' ' });
                            perszap.InDay = int.Parse(den[0]);
                            perszap.InMonth = int.Parse(den[1]);
                            perszap.InYear = int.Parse(den[2]);

                            ss1 = textBox6.Text;
                            string[] den1 = ss1.Split(new char[] { ' ' });
                            perszap.OutDay = int.Parse(den1[0]);
                            perszap.OutMonth = int.Parse(den1[1]);
                            perszap.OutYear = int.Parse(den1[2]);

                            ss1 = textBox7.Text;
                            string[] den2 = ss1.Split(new char[] { ' ' });
                            perszap.DayBirth = int.Parse(den2[0]);
                            perszap.MonhBirth = int.Parse(den2[1]);
                            perszap.YearBirth = int.Parse(den2[2]);

                            if(perszap.OutYear < perszap.InYear) // проверка на даты
                            {
                                MessageBox.Show("Вы ошибилисть с хронологией", "Уведомление");
                            }
                            else if (perszap.OutYear == perszap.InYear && perszap.OutMonth < perszap.InMonth)
                            {
                                MessageBox.Show("Вы ошибилисть с хронологией", "Уведомление");
                            }
                            else if (perszap.OutMonth == perszap.InMonth && perszap.OutDay < perszap.InDay)
                            {
                                MessageBox.Show("Вы ошибилисть с хронологией", "Уведомление");
                            }
                            else
                            {
                                stop_2();//закрываем второй интерфейс
                                zags_4();//загружаем четвёртый интерфейс
                            }
                            
                        }
                        catch //в случе возникновения исключения выполняется следующий блок кода
                        {
                            MessageBox.Show("Введите дату в формате 1 1 2022", "Уведомление");
                        }
                        perszap.NumberPhon = textBox8.Text;
                    }
                }
            }

            if (knopka == 2)
            {//кнопка изменяет данные о госте
                if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == "") || (radioButton1.Checked == false && radioButton2.Checked == false)) //проверка на заполненность данных
                {
                    MessageBox.Show("Заполните все поля", "Уведомление");
                }
                else
                {
                    if ((textBox1.Text.Any(char.IsDigit) == true) || (textBox2.Text.Any(char.IsDigit) == true) || (textBox3.Text.Any(char.IsDigit) == true)) //проверка на содержание цифр
                    {
                        MessageBox.Show("В полях фамилия имя и отчество не должны содержаться цифры", "Уведомление");
                    }
                    else if ((long.TryParse(textBox4.Text, out nn) == false) || (long.TryParse(textBox8.Text, out nn) == false)) //проверка на содержание букв
                    {
                        MessageBox.Show("В полях номер паспорта и номер телефона не должны содержаться буквы", "Уведомление");
                    }
                    else if ((radioButton1.Checked == true) && ((textBox4.Text.Length != 10) || (textBox4.Text.StartsWith(" ")) || (textBox4.Text.EndsWith(" ")))) //проверка на количество цифр в серии и номере паспорта
                    {

                        MessageBox.Show("Серия и номер паспорта должны быть записаны без пробелов, должно быть 10 цифр", "Уведомление");
                    }
                    else if ((radioButton2.Checked == true) && ((textBox4.Text.Length != 9) || (textBox4.Text.StartsWith(" ")) || (textBox4.Text.EndsWith(" ")))) //проверка на количество цифр в серии и номере паспорта
                    {
                        MessageBox.Show("Серия и номер паспорта должны быть записаны без пробелов, должно быть 9 цифр", "Уведомление");
                    }
                    else //запись даныых в объект класса гость
                    {
                        try //обработка исключений
                        {
                            pers[izmen].Name = textBox2.Text;
                            pers[izmen].SeName = textBox1.Text;
                            pers[izmen].FatherName = textBox3.Text;
                            if (radioButton1.Checked == true)
                            {
                                pers[izmen].Grazgdanstvo = "РФ";
                            }
                            else if (radioButton2.Checked == true)
                            {
                                pers[izmen].Grazgdanstvo = "Иностранное";
                            }
                            pers[izmen].Pasport = textBox4.Text;
                            string ss1 = textBox5.Text;
                            string[] den = ss1.Split(new char[] { ' ' });
                            pers[izmen].InDay = int.Parse(den[0]);
                            pers[izmen].InMonth = int.Parse(den[1]);
                            pers[izmen].InYear = int.Parse(den[2]);

                            ss1 = textBox6.Text;
                            string[] den1 = ss1.Split(new char[] { ' ' });
                            pers[izmen].OutDay = int.Parse(den1[0]);
                            pers[izmen].OutMonth = int.Parse(den1[1]);
                            pers[izmen].OutYear = int.Parse(den1[2]);

                            ss1 = textBox7.Text;
                            string[] den2 = ss1.Split(new char[] { ' ' });
                            pers[izmen].DayBirth = int.Parse(den2[0]);
                            pers[izmen].MonhBirth = int.Parse(den2[1]);
                            pers[izmen].YearBirth = int.Parse(den2[2]);

                            pers[izmen].NumberPhon = textBox8.Text;

                            MessageBox.Show("Данные изменены", "Уведомление");

                            stop_2();//закрываем второй интерфейс
                            zags_8();//загружаем восьмой интерфейс
                        }
                        catch //в случе возникновения исключения выполняется следующий блок кода
                        {
                            MessageBox.Show("Введите дату в формате 1 1 2022", "Уведомление");
                        }
                    }
                }
            }


        }

        private void button6_Click(object sender, EventArgs e) // кнопка импортирует данные из указанного файла
        {
            zapolnenie(); //импортируем данные
        }

        private void button7_Click(object sender, EventArgs e) // кнопка находит номер по заданным параметрам
        {
            stop_4(); //закрываем четвёртый интерфейс
            zags_5(); //загружаем пятый интерфейс
            int i1 = 0; //счётчик
            bool x1; //вспомогательные переменные
            bool x2;
            bool x3;
            nazad = 1; //счётчик

            if (comboBox1.Text == "Эконом") //если выбран номер экномом
            {
                for (int i = 10; i < kol_nom; i++) //проверяем выбранные параметры
                {
                    if (comboBox2.Text == "")
                    {
                        x1 = true;
                    }
                    else
                    {
                        x1 = nom[i].KolvoMest == int.Parse(comboBox2.Text);
                    }
                    if (comboBox4.Text == "")
                    {
                        x2 = true;
                    }
                    else
                    {
                        x2 = nom[i].KolBedroom == int.Parse(comboBox4.Text);
                    }
                    if (comboBox7.Text == "")
                    {
                        x3 = true;
                    }
                    else
                    {
                        x3 = nom[i].Storey == int.Parse(comboBox7.Text);
                    }

                    //проверяем выбранные параметры
                    if ((x1) && (nom[i].Vid == comboBox3.Text || comboBox3.Text == "") && (x2) && (nom[i].Seif == comboBox5.Text || comboBox5.Text == "") && (nom[i].Internet == comboBox6.Text || comboBox6.Text == "") && (x3))
                    {
                        //выводим в таблицу данные о номерах соответствующих выбранным параметрам
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i1].Cells["Column1"].Value = nom[i].Prise;
                        dataGridView1.Rows[i1].Cells["Column2"].Value = nom[i].Storey;
                        dataGridView1.Rows[i1].Cells["Column3"].Value = nom[i].KolvoMest;
                        dataGridView1.Rows[i1].Cells["Column4"].Value = nom[i].Vid;
                        dataGridView1.Rows[i1].Cells["Column5"].Value = nom[i].KolBedroom;
                        dataGridView1.Rows[i1].Cells["Column6"].Value = nom[i].Seif;
                        dataGridView1.Rows[i1].Cells["Column7"].Value = nom[i].Internet;
                        dataGridView1.Rows[i1].Cells["Column8"].Value = nom[i].Namber;
                        dataGridView1.Rows[i1].Cells["Column9"].Value = nom[i].DataOt;

                        i1++;
                    }

                }
                if (i1 == 0) // если номеров по выбранным параметрам нет выводи уведомление
                {
                    MessageBox.Show("Совпадений нет", "Уведомление");
                }

            }
            else if (comboBox1.Text == "Люкс") //если выбран люкс
            {
                for (int j = 0; j < 10; j++) //выводим в таблицу люксовые номера
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[j].Cells["Column1"].Value = nom[j].Prise;
                    dataGridView1.Rows[j].Cells["Column2"].Value = nom[j].Storey;
                    dataGridView1.Rows[j].Cells["Column3"].Value = nom[j].KolvoMest;
                    dataGridView1.Rows[j].Cells["Column4"].Value = nom[j].Vid;
                    dataGridView1.Rows[j].Cells["Column5"].Value = nom[j].KolBedroom;
                    dataGridView1.Rows[j].Cells["Column6"].Value = nom[j].Seif;
                    dataGridView1.Rows[j].Cells["Column7"].Value = nom[j].Internet;
                    dataGridView1.Rows[j].Cells["Column8"].Value = nom[j].Namber;
                    dataGridView1.Rows[j].Cells["Column9"].Value = nom[j].DataOt;


                }
            }
            else //если не выбран ни люкс ни эконом выводим все номера
            {
                for (int j = 0; j < kol_nom; j++)//выводим в таблицу все номера
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[j].Cells["Column1"].Value = nom[j].Prise;
                    dataGridView1.Rows[j].Cells["Column2"].Value = nom[j].Storey;
                    dataGridView1.Rows[j].Cells["Column3"].Value = nom[j].KolvoMest;
                    dataGridView1.Rows[j].Cells["Column4"].Value = nom[j].Vid;
                    dataGridView1.Rows[j].Cells["Column5"].Value = nom[j].KolBedroom;
                    dataGridView1.Rows[j].Cells["Column6"].Value = nom[j].Seif;
                    dataGridView1.Rows[j].Cells["Column7"].Value = nom[j].Internet;
                    dataGridView1.Rows[j].Cells["Column8"].Value = nom[j].Namber;
                    dataGridView1.Rows[j].Cells["Column9"].Value = nom[j].DataOt;


                }
            }

        }

        private void button8_Click(object sender, EventArgs e)// кнопка записывает гостя в номер и переходит в первый интерфейс
        {
            bool nomx = true; //вспомогательная переменная
            if (textBox10.Text != "") //проверка на заполненость поля номер
            {
                try//обработка исключений
                {
                    for (int i = 0; i < kol_nom; i++) //проверка на занятость номера
                    {
                        if (nom[int.Parse(textBox10.Text) - 1].DataOt != "") //если номер занят выводим уведомление
                        {
                            nomx = false; //показывает что номер занят
                            MessageBox.Show("Этот номер занят введите свободный", "Уведомление");
                            break;//выход из цикла
                        }
                    }
                }
                catch // при возникновении исключения реализуется следующий блок кода
                {
                    nomx = false;
                    MessageBox.Show("Введите корректный номер", "Уведомление");
                }
                if (nomx) //если номер свободен то записываем данные гостя
                {
                    pers[kol_strok].Name = perszap.Name;
                    pers[kol_strok].SeName = perszap.SeName;
                    pers[kol_strok].FatherName = perszap.FatherName;
                    pers[kol_strok].Grazgdanstvo = perszap.Grazgdanstvo;
                    pers[kol_strok].Pasport = perszap.Pasport;
                    pers[kol_strok].InDay = perszap.InDay;
                    pers[kol_strok].InMonth = perszap.InMonth;
                    pers[kol_strok].InYear = perszap.InYear;
                    pers[kol_strok].OutDay = perszap.OutDay;
                    pers[kol_strok].OutMonth = perszap.OutMonth;
                    pers[kol_strok].OutYear = perszap.OutYear;
                    pers[kol_strok].DayBirth = perszap.DayBirth;
                    pers[kol_strok].MonhBirth = perszap.MonhBirth;
                    pers[kol_strok].YearBirth = perszap.YearBirth;
                    pers[kol_strok].NumberPhon = perszap.NumberPhon;
                    pers[kol_strok].PersNomer = int.Parse(textBox10.Text);
                    nom[pers[kol_strok].PersNomer - 1].DataOt = perszap.OutDay + " " + perszap.OutMonth + " " + perszap.OutYear;

                    kol_strok++;
                    MessageBox.Show("Гость успешно записан", "Уведомление");//выводим уведомление
                    stop_4();//закрываем четвёртый интерфейс
                    zags_1();//загружаем первый интерфейс
                }
            }
            else // если поле номер не заполнено выводим сообщение
            {
                MessageBox.Show("Введите номер для заселения", "Уведомление");
            }
        }

        private void button9_Click(object sender, EventArgs e) //кнопка закрывает интерфейс с таблицей данных 
        {
            if (nazad == 1) //проверка, из какого интерфейса был вызван пятый интерфейс
            {
                stop_5();//закрывает пятый интерфейс
                zags_4();//загружает четвёртый интерфейс
                dataGridView1.Rows.Clear(); // очищает таблицу
            }
            else
            {
                stop_5();//закрывает пятый интерфейс
                zags_6();//загружает шестой интерфейс
                dataGridView1.Rows.Clear();// очищает таблицу
            }

        }
        //======================================
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //=============================================================

        private void button10_Click(object sender, EventArgs e) // кнопка осуществляет выход в главное меню из четвёртого интерфейса
        {
            stop_4();//закрываем четвёртый интерфейс
            zags_1();//загружаем первый интерфейс
        }

        private void button11_Click(object sender, EventArgs e)//кнопка осуществляет вывод всех данных о номере
        {
            stop_6();//закрываем шестой интерфейс

            zags_5();//загружаем пятый интерфейс
            nazad = -1;//изменяем счётчик

            for (int j = 0; j < kol_nom; j++)//выводим данные о номерах в таблицу
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells["Column1"].Value = nom[j].Prise;
                dataGridView1.Rows[j].Cells["Column2"].Value = nom[j].Storey;
                dataGridView1.Rows[j].Cells["Column3"].Value = nom[j].KolvoMest;
                dataGridView1.Rows[j].Cells["Column4"].Value = nom[j].Vid;
                dataGridView1.Rows[j].Cells["Column5"].Value = nom[j].KolBedroom;
                dataGridView1.Rows[j].Cells["Column6"].Value = nom[j].Seif;
                dataGridView1.Rows[j].Cells["Column7"].Value = nom[j].Internet;
                dataGridView1.Rows[j].Cells["Column8"].Value = nom[j].Namber;
                dataGridView1.Rows[j].Cells["Column9"].Value = nom[j].DataOt;
            }
        }

        private void button12_Click(object sender, EventArgs e)//кнопка осуществляет вывод всех данных о клиентах
        {
            nazad2 = 1;//изменяем счётчик
            stop_5();//закрываем пятый интерфейс
            zags_7();//загружаем седьмой интерфейс
            this.button15.Location = new System.Drawing.Point(-300, -500);//перемещаем кнопку
            for (int j = 0; j < kol_strok; j++)//выводим данные о всех клиентах в таблицу
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[j].Cells["Column11"].Value = pers[j].SeName;
                dataGridView2.Rows[j].Cells["Column10"].Value = pers[j].Name;
                dataGridView2.Rows[j].Cells["Column12"].Value = pers[j].FatherName;
                dataGridView2.Rows[j].Cells["Column13"].Value = pers[j].Grazgdanstvo;
                dataGridView2.Rows[j].Cells["Column14"].Value = pers[j].Pasport;
                dataGridView2.Rows[j].Cells["Column15"].Value = pers[j].DayBirth + " " + pers[j].MonhBirth + " " + pers[j].YearBirth;
                dataGridView2.Rows[j].Cells["Column16"].Value = pers[j].InDay + " " + pers[j].InMonth + " " + pers[j].InYear;
                dataGridView2.Rows[j].Cells["Column17"].Value = pers[j].OutDay + " " + pers[j].OutMonth + " " + pers[j].OutYear;
                dataGridView2.Rows[j].Cells["Column18"].Value = pers[j].NumberPhon;
                dataGridView2.Rows[j].Cells["Column19"].Value = pers[j].PersNomer;
            }
        }

        private void button13_Click(object sender, EventArgs e)//кнопка осуществляет поиск клиента по фамилии
        {
            nazad2 = 1;//изменяем счётчик
            int j1 = 0;
            stop_6(); // закрываем шестой интерфейс
            zags_7();//загружаем седьмой интерфейс
            for (int j = 0; j < kol_strok; j++) //перебираем всех гостей
            {
                dataGridView2.Rows.Add();
                if (textBox11.Text == pers[j].SeName) //сравниваем фамилии гостей с введённой фамилией
                {
                    //выводим данные о госте
                    dataGridView2.Rows[j1].Cells["Column11"].Value = pers[j].SeName;
                    dataGridView2.Rows[j1].Cells["Column10"].Value = pers[j].Name;
                    dataGridView2.Rows[j1].Cells["Column12"].Value = pers[j].FatherName;
                    dataGridView2.Rows[j1].Cells["Column13"].Value = pers[j].Grazgdanstvo;
                    dataGridView2.Rows[j1].Cells["Column14"].Value = pers[j].Pasport;
                    dataGridView2.Rows[j1].Cells["Column15"].Value = pers[j].DayBirth + " " + pers[j].MonhBirth + " " + pers[j].YearBirth;
                    dataGridView2.Rows[j1].Cells["Column16"].Value = pers[j].InDay + " " + pers[j].InMonth + " " + pers[j].InYear;
                    dataGridView2.Rows[j1].Cells["Column17"].Value = pers[j].OutDay + " " + pers[j].OutMonth + " " + pers[j].OutYear;
                    dataGridView2.Rows[j1].Cells["Column18"].Value = pers[j].NumberPhon;
                    dataGridView2.Rows[j1].Cells["Column19"].Value = pers[j].PersNomer;
                    j1++;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)//кнопка закрывает интерфейс с таблицей данных 
        {
            if (nazad2 == 1) //проверка, какими действиями был вызван седьмой интерфейс
            {
                stop_7();//закрываем седьмой интерфейс
                zags_6();//загружаем шестой интерфейс
                dataGridView2.Rows.Clear();//очищаем таблицу
                textBox11.Text = ""; //очищаем текстовое поле
            }
            else
            {
                stop_7();//закрываем седьмой интерфейс
                zags_8();//загружаем восьмой интерфейс
                dataGridView2.Rows.Clear();//очищаем таблицу
                textBox12.Text = "";//очищаем текстовое поле
                textBox13.Text = "";//очищаем текстовое поле
            }
        }

        private void button15_Click(object sender, EventArgs e)//кнопка осуществляет выход в главное меню из шестого интерфейса
        {
            stop_6();//закрывает шестой интерфейс
            zags_1();//загружает первый интерфейс
        }

        private void button16_Click(object sender, EventArgs e)//кнопка осуществляет вывод данных всех гостей в восьмом интерфейсе
        {
            nazad2 = 0;//изменяем счётчик

            stop_8();//закрываем восьмой интерфейс
            zags_7();//загружаем седьмой интерфейс
            this.button15.Location = new System.Drawing.Point(-300, -500);//перемещаем кнопку
            for (int j = 0; j < kol_strok; j++)//выводим данные гостей в таблицу
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[j].Cells["Column11"].Value = pers[j].SeName;
                dataGridView2.Rows[j].Cells["Column10"].Value = pers[j].Name;
                dataGridView2.Rows[j].Cells["Column12"].Value = pers[j].FatherName;
                dataGridView2.Rows[j].Cells["Column13"].Value = pers[j].Grazgdanstvo;
                dataGridView2.Rows[j].Cells["Column14"].Value = pers[j].Pasport;
                dataGridView2.Rows[j].Cells["Column15"].Value = pers[j].DayBirth + " " + pers[j].MonhBirth + " " + pers[j].YearBirth;
                dataGridView2.Rows[j].Cells["Column16"].Value = pers[j].InDay + " " + pers[j].InMonth + " " + pers[j].InYear;
                dataGridView2.Rows[j].Cells["Column17"].Value = pers[j].OutDay + " " + pers[j].OutMonth + " " + pers[j].OutYear;
                dataGridView2.Rows[j].Cells["Column18"].Value = pers[j].NumberPhon;
                dataGridView2.Rows[j].Cells["Column19"].Value = pers[j].PersNomer;
            }
        }

        private void button17_Click(object sender, EventArgs e)//кнопка осуществляет поиск по фамилии в восьмом интерфейсе
        {
            nazad2 = 0;//изменяем счётчик
            stop_8();//закрываем восьмой интерфейс
            zags_7();//загружаем седьмой интерфейс
            int j1 = 0;
            for (int j = 0; j < kol_strok; j++)//перебираем фамилии всех гостей
            {
                dataGridView2.Rows.Add();
                if (textBox12.Text == pers[j].SeName) // сравниваем фамилию гостя с заданной пользователем фвмилии
                {
                    //выводим данные о госте
                    dataGridView2.Rows[j1].Cells["Column11"].Value = pers[j].SeName;
                    dataGridView2.Rows[j1].Cells["Column10"].Value = pers[j].Name;
                    dataGridView2.Rows[j1].Cells["Column12"].Value = pers[j].FatherName;
                    dataGridView2.Rows[j1].Cells["Column13"].Value = pers[j].Grazgdanstvo;
                    dataGridView2.Rows[j1].Cells["Column14"].Value = pers[j].Pasport;
                    dataGridView2.Rows[j1].Cells["Column15"].Value = pers[j].DayBirth + " " + pers[j].MonhBirth + " " + pers[j].YearBirth;
                    dataGridView2.Rows[j1].Cells["Column16"].Value = pers[j].InDay + " " + pers[j].InMonth + " " + pers[j].InYear;
                    dataGridView2.Rows[j1].Cells["Column17"].Value = pers[j].OutDay + " " + pers[j].OutMonth + " " + pers[j].OutYear;
                    dataGridView2.Rows[j1].Cells["Column18"].Value = pers[j].NumberPhon;
                    dataGridView2.Rows[j1].Cells["Column19"].Value = pers[j].PersNomer;
                    j1++;
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)//кнопка переходит в интерфейс для изменения данных о госте
        {
            knopka = 2;//изменяем счётчик  
            button5.Text = "Изменить"; //изменяем название кнопки
            for (int j = 0; j < kol_strok; j++)//находим номер записи которую надо изменить
            {
                if (textBox13.Text == pers[j].Pasport)// сравниваем значение паспорта со значением введённым пользователем
                {
                    izmen = j;
                    stop_8();//закрываем восьмой интерфейс
                    zags_2();//загружаем второй интерфейс
                    break;//выходим из цикла
                }
            }

            if (izmen != -1)//если гость найден выводим на форму его текущие данный
            {
                textBox2.Text = pers[izmen].Name;
                textBox1.Text = pers[izmen].SeName;
                textBox3.Text = pers[izmen].FatherName;
                if (pers[izmen].Grazgdanstvo == "РФ")
                {
                    radioButton1.Checked = true;
                }
                if (pers[izmen].Grazgdanstvo == "Иностранное")
                {
                    radioButton2.Checked = true;
                }
                textBox4.Text = pers[izmen].Pasport;
                textBox5.Text = pers[izmen].InDay + " " + pers[izmen].InMonth + " " + pers[izmen].InYear;
                textBox6.Text = pers[izmen].OutDay + " " + pers[izmen].OutMonth + " " + pers[izmen].OutYear;
                textBox7.Text = pers[izmen].DayBirth + " " + pers[izmen].MonhBirth + " " + pers[izmen].YearBirth;
                textBox8.Text = pers[izmen].NumberPhon;

                textBox13.Text = "";
            }
            else//если гость не найден
            {
                MessageBox.Show("Гость не найден", "Уведомление");
            }
        }

        private void button19_Click(object sender, EventArgs e)//кнопка осуществляет удаление записи 
        {

            for (int j = 0; j < kol_strok; j++)//перебираем данные паспорта всех гостей
            {
                if (textBox13.Text == pers[j].Pasport) //сравниваем значение паспорта со значением введённым пользователем
                {
                    ydalit = j;//изменяем счётчик
                    break;//выходим из цикла
                }
            }

            if (ydalit != -1)//если есть совпадение
            {
                for (int j = ydalit; j < kol_strok; j++) //удаляем данные гостя путём сдвига всех данных гостей, которые находятся выше удяляемого, на один вниз
                {
                    pers[j].Name = pers[j + 1].Name;
                    pers[j].SeName = pers[j + 1].SeName;
                    pers[j].FatherName = pers[j + 1].FatherName;
                    pers[j].Grazgdanstvo = pers[j + 1].Grazgdanstvo;
                    pers[j].Pasport = pers[j + 1].Pasport;
                    pers[j].InDay = pers[j + 1].InDay;
                    pers[j].InMonth = pers[j + 1].InMonth;
                    pers[j].InYear = pers[j + 1].InYear;
                    pers[j].OutDay = pers[j + 1].OutDay;
                    pers[j].OutMonth = pers[j + 1].OutMonth;
                    pers[j].OutYear = pers[j + 1].OutYear;
                    pers[j].DayBirth = pers[j + 1].DayBirth;
                    pers[j].MonhBirth = pers[j + 1].MonhBirth;
                    pers[j].YearBirth = pers[j + 1].YearBirth;
                    pers[j].NumberPhon = pers[j + 1].NumberPhon;
                    pers[j].PersNomer = pers[j + 1].PersNomer;
                    nom[pers[j + 1].PersNomer].DataOt = pers[j + 1].OutDay + " " + pers[j + 1].OutMonth + " " + pers[j + 1].OutYear;
                }
                nom[ydalit].DataOt = "";

                kol_strok--;//изменяем счётчик
                MessageBox.Show("Запись удалена", "Уведомление");//выводим сообщение
                textBox13.Text = "";//очищаем поле
            }
            else//если гость не найден выводим сообщение
            {
                MessageBox.Show("Гость не найден", "Уведомление");
            }
        }

        private void button20_Click(object sender, EventArgs e) //кнопка осуществляет выход в главное меню из восьмого интерфейса
        {
            stop_8();//закрываем восьмой интерфейс
            zags_1();//загружаем первый интерфейс
        }

        //========================================
        private void button21_Click(object sender, EventArgs e)
        {
            
        }
        //========================================

        private void button22_Click(object sender, EventArgs e)//Кнопка осуществляет закрытие приложения 
        {
            Close();//закрывает форму
        }

        private void button23_Click(object sender, EventArgs e) //кнопка осуществляет выход в главное меню из третьего интерфейса
        {
            stop_3();//закрываем третий интерфейс
            zags_1();//загружаем первый интерфейс
        }     
    }
}
