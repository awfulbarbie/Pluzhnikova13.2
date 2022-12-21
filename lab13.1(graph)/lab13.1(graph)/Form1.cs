namespace lab13._1_graph_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        abstract class Goods            //абстрактный класс Товар
        {
            abstract public void PrintInf(TextBox text);               //абстрактный метод для вывода информации
            abstract public bool Kind(string keyword);     //абстрактный метод для проверки данных в массиве
        }
        class Toy : Goods               //класс игрушка
        {
            string kind = "Toy";        //тип товара (для поиска)
            string name;                //название
            double price;               //цена
            string producer;              //производитель
            string material;            //материал
            int age;                    //возраст
            public Toy(string name, double price, string producer, string material, int age)
            {
                //this - обеспечивает доступ к текущему экземпляру класса, т.к.
                this.name = name;                       //входящий параметр назван так же, как поле данных данного типа
                this.price = price;
                this.producer = producer;
                this.material = material;
                this.age = age;
            }
            public override void PrintInf(TextBox text)                //переопределение метода PrintInf() с помощью override
            {
                text.Text += "Тип товара: " + kind + Environment.NewLine + "Название: " +
                    name + Environment.NewLine + "Цена: " + price + Environment.NewLine + "Производитель: " +
                    producer + Environment.NewLine + "Материал: " + material + Environment.NewLine + "Возраст: " + age + Environment.NewLine;
                text.Text += Environment.NewLine;
            }
            public override bool Kind(string keyword)
            {
                return keyword.Contains(kind);             //проверка, встречается ли указанный символ внутри этой строки
            }
        }

        class Book : Goods              //Класс книга
        {
            string kind = "Book";
            string name;
            string author;              //автор
            double price;
            string producer;             //издательство
            int age;
            public Book(string name, string author, double price, string producer, int age)
            {
                this.name = name;
                this.author = author;
                this.price = price;
                this.producer = producer;
                this.age = age;
            }
            public override void PrintInf(TextBox text)                 //переопределение метода PrintInf() с помощью override
            {
                text.Text += "Тип товара: " + kind + Environment.NewLine + "Название: " +
                    name + Environment.NewLine + "Автор: " + author + Environment.NewLine + "Цена: " +
                    price + Environment.NewLine + "Издательство: " + producer + Environment.NewLine + "Возраст: " + age + Environment.NewLine;
                text.Text += Environment.NewLine;
            }
            public override bool Kind(string keyword)
            {
                return keyword.Contains(kind);
            }
        }
        class Sport : Goods             //Класс спорт-инвертарь
        {
            string kind = "Sport";
            string name;
            double price;
            string producer;
            int age;
            public Sport(string name, double price, string producer, int age)
            {
                this.name = name;
                this.price = price;
                this.producer = producer;
                this.age = age;
            }
            public override void PrintInf(TextBox text)                 //переопределение метода PrintInf() с помощью override
            {
                text.Text += "Тип товара: " + kind + Environment.NewLine + "Название: " + name
                    + Environment.NewLine + "Цена: " + price + Environment.NewLine + "Производитель: " + producer
                    + Environment.NewLine + "Возраст: " + age + Environment.NewLine;
                text.Text += Environment.NewLine;
            }
            public override bool Kind(string keyword)
            {
                return keyword.Contains(kind);
            }
        }
    
        Goods[] arrGood;        //чтение файла
        int linesLen = File.ReadAllLines(@"D:\Учебная практика\Задание 13\lab13.1(graph)\lab13.1(graph)\textForm.txt").Length;

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;       //невозможно изменение содержимого
            textBox3.ReadOnly = true;

            string[] str1;
            arrGood = new Goods[linesLen];  //массив товаров

            using (StreamReader sr = new StreamReader(@"D:\Учебная практика\Задание 13\lab13.1(graph)\lab13.1(graph)\textForm.txt"))
            {
                int i = 0;
                while (sr.Peek() > -1)              //определение, достигнут ли конец файла
                {
                    str1 = sr.ReadLine().Split('|');    //все элементы разделены |

                    if (str1[0] == "Toy")
                    {
                        arrGood[i] = new Toy(str1[1], double.Parse(str1[2]), str1[3], str1[4], int.Parse(str1[5]));
                        //название, цена, производитель, материал, возраст
                    }
                    else if (str1[0] == "Book")
                    {
                        arrGood[i] = new Book(str1[1], str1[2], double.Parse(str1[3]), str1[4], int.Parse(str1[5]));
                        //название, автор, цена, издательство, возраст
                    }
                    else if (str1[0] == "Sport")
                    {
                        arrGood[i] = new Sport(str1[1], double.Parse(str1[2]), str1[3], int.Parse(str1[4]));
                        //название, цена, производитель, возраст
                    }
                    i++;
                }
            }

            textBox1.Text += Environment.NewLine;           //вывод всей информации из файла
            for (int i = 0; i < linesLen; i++)
            {
                arrGood[i].PrintInf(textBox1);
            }
            textBox1.Text += Environment.NewLine;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text += " ";
            int flag = 0;
            string keyword = textBox2.Text;
            for (int i = 0; i < linesLen; i++)
            {
                if (arrGood[i].Kind(keyword))
                {
                    arrGood[i].PrintInf(textBox3);
                    flag++;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("Такого типа товаров в базе нет", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox3.Clear();
        }
    }
}