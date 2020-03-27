using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CSPress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//როდესაც რომელიმე ჩეკბოქსი მოინიშნება
        {
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)//თუ რომელიმე ჩეკბოქსი მონიშნულია
                comboBox1.Visible = true;//გამოჩნდეს კომბობოქსი
            else
                comboBox1.Visible = false;//თუ არცერთია მონიშნული, კომბობოქსიც გაქრეს
        }

        private void Form1_Load(object sender, EventArgs e)//ეს მეთოდი გამოიძახება,როცა ჩაიტვირთება ფორმა
        {
            IEnumerable<string> families = FontFamily.Families.Select(o => o.Name);//დაინსტალირებული ფონტების სახელების აღება
            /*Select(o=>o.Name), ამას ეწოდება ლამბდა. Families-ის არის კოლექცია ანუ მასივი
             * მონიშნავს კოლექციის ელემენტების კონკრეტულ თვისებას, ჩვენ შემთხევევაში სახელს ფონტებისას
             * o წარმოადგენს სათითაოდ ყველა ელემენტს Families-ში,ხოლო o.Name აბრუნებს ყველა ელემენტის Name თვისებას
             * ამ ყველაფერს,კოლექციებთან მუშაობას ახორციელებს Linq "ბიბლიოთეკა"(მაღლა გვიწერია,using System.Linq)
             */

             /*IEnumerable წარმოადგენს ყველაზე მაღალ საფეხურს კოლექციებისას(ლისტების და მასივების). 
              * ის არის ყველა კოლექციის მშობელი კლასი(უფროსწორად ინტერფეისი,მაგრამ ეგ ჯერ არ გვისწავლია)*/

            //კომპიუტერზე დაინსტალირებული ფონტების დამატება კომბობქსში სათითაოდ
            foreach (var item in families)
                comboBox1.Items.Add(item);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//გამოიძახება,როცა კომბობოქსში ახალი აითემი აირჩევა
        {
            if (checkBox1.Checked)//თუ მონიშნულია პირველი ჩეკბოქსი
                SetFont(this);//გამოიძახება SetFont მეთოდი და გადაეცემა მთლიანად ფორმა პარამეტრად
            //this აღნიშნავს ამ მომენტში აქტიური ფორმის ობიექტს ანუ ფორმის საკუთარ თავს
            if (checkBox2.Checked)
                SetFont(textBox1);//გამოიძახება SetFont მეთოდი და გადაეცემა ტექსტბოქსი
            if (checkBox3.Checked)
                SetFont(label1);//გამოიძახება SetFont მეთოდი და გადაეცემა ლეიბლი
        }

        /* რადგან SetFont_მა არ იცის,რა ტიპის პარამეტრი მიიღოს,ვიყენებთ მემკვიდრეობითობის პრინციპს
         * და ვიღებთ პარამეტრად იმ ტიპს,რომელიც არის ყველა გადმოცემული ტიპის მშობელი
         * მთლიანი ფორმის,ტექსტბოქსის და ლეიბლის მშობელი კლასი არის Control,ამიტომაც SetFont იღებს Control
         * ტიპის ობიექტს და არ აქვს პრობლემა არცერთ ჩამოთვლილ ტიპზე */

        private void SetFont(Control control)
        {
            ComboBox comboBox = comboBox1;//კომბობოქსზე წვდომა
            string font = comboBox1.SelectedItem as string;//კომბობოქსში მონიშნული აითემის აღება და წვდომა მასზე როგორც string-ზე(ფონტის სახელი)
            control.Font = new Font(font,control.Font.Size,FontStyle.Regular);//ფონტის მინიჭება გადმოცემულ კონტროლზე
            /*ზომის პარამეტრში გადაეცემა control.Font.Size, რაც აღნიშნავს
            უკვე მინიჭებულ ზომას,რათა ზომა არ შეიცვალოს ფონტის შეცვლის დროს*/
        }
    }
}
