using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Patterns
{
    public partial class Form3 : Form
    {
        private Subject subject = new Subject();
        private List<IObserver> observers = new List<IObserver>();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            subject.NotifyObservers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IObserver observer = new ConcreteObserver(textBox1.Text);
            subject.Attach(observer);
            observers.Add(observer);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    interface IObserver
    {
        void Update(string message);
    }

    class ConcreteObserver : IObserver
    {
        private string name;

        public ConcreteObserver(string name)
        {
            this.name = name;
        }

        public void Update(string message)
        {
            MessageBox.Show($"{name} received a message: {message}");
        }
    }

    class Subject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update("Button clicked!");
            }
        }
    }
}
