using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Json;
using LitJson;

namespace TestJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            A test = new A();
            test.a = new B();
            test.a.sss = new C[2];
            test.a.sss[0] = new C();
            test.a.sss[1] = new C();

            StringBuilder sb = new StringBuilder();
            JsonSerializer.serialize(sb, test);

            string text = sb.ToString();

            A answer = JsonMapper.ToObject<A>(new JsonReader(text));

            //A answer = (A)JsonDeserializer.deserialize(text,typeof(A));
        }
    }

    public class A
    {
        public B a;
        public B c;
        public long dafasd;
    }

    public class B
    {
        public string text = "hello";
        public C[] sss;
    }
    public class C
    {
        public int g = 0;
        public bool r = false;
        public long test = (long)(int.MaxValue)+2;
        public string h = "";
    }
}