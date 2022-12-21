namespace lab13._1_graph_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        abstract class Goods            //����������� ����� �����
        {
            abstract public void PrintInf(TextBox text);               //����������� ����� ��� ������ ����������
            abstract public bool Kind(string keyword);     //����������� ����� ��� �������� ������ � �������
        }
        class Toy : Goods               //����� �������
        {
            string kind = "Toy";        //��� ������ (��� ������)
            string name;                //��������
            double price;               //����
            string producer;              //�������������
            string material;            //��������
            int age;                    //�������
            public Toy(string name, double price, string producer, string material, int age)
            {
                //this - ������������ ������ � �������� ���������� ������, �.�.
                this.name = name;                       //�������� �������� ������ ��� ��, ��� ���� ������ ������� ����
                this.price = price;
                this.producer = producer;
                this.material = material;
                this.age = age;
            }
            public override void PrintInf(TextBox text)                //��������������� ������ PrintInf() � ������� override
            {
                text.Text += "��� ������: " + kind + Environment.NewLine + "��������: " +
                    name + Environment.NewLine + "����: " + price + Environment.NewLine + "�������������: " +
                    producer + Environment.NewLine + "��������: " + material + Environment.NewLine + "�������: " + age + Environment.NewLine;
                text.Text += Environment.NewLine;
            }
            public override bool Kind(string keyword)
            {
                return keyword.Contains(kind);             //��������, ����������� �� ��������� ������ ������ ���� ������
            }
        }

        class Book : Goods              //����� �����
        {
            string kind = "Book";
            string name;
            string author;              //�����
            double price;
            string producer;             //������������
            int age;
            public Book(string name, string author, double price, string producer, int age)
            {
                this.name = name;
                this.author = author;
                this.price = price;
                this.producer = producer;
                this.age = age;
            }
            public override void PrintInf(TextBox text)                 //��������������� ������ PrintInf() � ������� override
            {
                text.Text += "��� ������: " + kind + Environment.NewLine + "��������: " +
                    name + Environment.NewLine + "�����: " + author + Environment.NewLine + "����: " +
                    price + Environment.NewLine + "������������: " + producer + Environment.NewLine + "�������: " + age + Environment.NewLine;
                text.Text += Environment.NewLine;
            }
            public override bool Kind(string keyword)
            {
                return keyword.Contains(kind);
            }
        }
        class Sport : Goods             //����� �����-���������
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
            public override void PrintInf(TextBox text)                 //��������������� ������ PrintInf() � ������� override
            {
                text.Text += "��� ������: " + kind + Environment.NewLine + "��������: " + name
                    + Environment.NewLine + "����: " + price + Environment.NewLine + "�������������: " + producer
                    + Environment.NewLine + "�������: " + age + Environment.NewLine;
                text.Text += Environment.NewLine;
            }
            public override bool Kind(string keyword)
            {
                return keyword.Contains(kind);
            }
        }
    
        Goods[] arrGood;        //������ �����
        int linesLen = File.ReadAllLines(@"D:\������� ��������\������� 13\lab13.1(graph)\lab13.1(graph)\textForm.txt").Length;

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;       //���������� ��������� �����������
            textBox3.ReadOnly = true;

            string[] str1;
            arrGood = new Goods[linesLen];  //������ �������

            using (StreamReader sr = new StreamReader(@"D:\������� ��������\������� 13\lab13.1(graph)\lab13.1(graph)\textForm.txt"))
            {
                int i = 0;
                while (sr.Peek() > -1)              //�����������, ��������� �� ����� �����
                {
                    str1 = sr.ReadLine().Split('|');    //��� �������� ��������� |

                    if (str1[0] == "Toy")
                    {
                        arrGood[i] = new Toy(str1[1], double.Parse(str1[2]), str1[3], str1[4], int.Parse(str1[5]));
                        //��������, ����, �������������, ��������, �������
                    }
                    else if (str1[0] == "Book")
                    {
                        arrGood[i] = new Book(str1[1], str1[2], double.Parse(str1[3]), str1[4], int.Parse(str1[5]));
                        //��������, �����, ����, ������������, �������
                    }
                    else if (str1[0] == "Sport")
                    {
                        arrGood[i] = new Sport(str1[1], double.Parse(str1[2]), str1[3], int.Parse(str1[4]));
                        //��������, ����, �������������, �������
                    }
                    i++;
                }
            }

            textBox1.Text += Environment.NewLine;           //����� ���� ���������� �� �����
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
                MessageBox.Show("������ ���� ������� � ���� ���", "������",
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