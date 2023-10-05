using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Patterns
{
    public partial class Form2 : Form
    {
        private ITextDecorator decorator = new DefaultTextDecorator();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = decorator.ApplyDecoration(textBox1.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                decorator = new BoldTextDecorator(decorator);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                decorator = new ItalicTextDecorator(decorator);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    interface ITextDecorator
    {
        string ApplyDecoration(string text);
    }
    class DefaultTextDecorator : ITextDecorator
    {
        public string ApplyDecoration(string text)
        {
            return text;
        }
    }
    abstract class TextDecorator : ITextDecorator
    {
        protected ITextDecorator decorator;
        public TextDecorator(ITextDecorator decorator)
        {
            this.decorator = decorator;
        }
        public abstract string ApplyDecoration(string text);
    }
    class BoldTextDecorator : TextDecorator
    {
        public BoldTextDecorator(ITextDecorator decorator) : base(decorator)
        {
        }
        public override string ApplyDecoration(string text)
        {
            return $"<b>{decorator.ApplyDecoration(text)}</b>";
        }
    }
    class ItalicTextDecorator : TextDecorator
    {
        public ItalicTextDecorator(ITextDecorator decorator) : base(decorator)
        {
        }
        public override string ApplyDecoration(string text)
        {
            return $"<i>{decorator.ApplyDecoration(text)}</i>";
        }
    }
}
