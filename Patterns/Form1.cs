namespace Patterns
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IProductFactory factory;
            if (radioButton1.Checked)
            {
                factory = new ConcreteProductAFactory();
            }
            else
            {
                factory = new ConcreteProductBFactory();
            }

            IProduct product = factory.CreateProduct();
            MessageBox.Show(product.GetInfo());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
    interface IProduct
    {
        string GetInfo();
    }
    class ConcreteProductA : IProduct
    {
        public string GetInfo()
        {
            return "Product A";
        }
    }
    class ConcreteProductB : IProduct
    {
        public string GetInfo()
        {
            return "Product B";
        }
    }
    interface IProductFactory
    {
        IProduct CreateProduct();
    }
    class ConcreteProductAFactory : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteProductBFactory : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new ConcreteProductB();
        }
    }
}