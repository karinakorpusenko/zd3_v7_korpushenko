namespace pr3_up
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int ind;
        private void button1_Click(object sender, EventArgs e)//проверка на пустые поля
        {if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != ""
                && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                if (PrStr(textBox1.Text) && PrStr(textBox5.Text))//проверка на буквы

                {
                    if (PrCH(textBox2.Text) && PrCH(textBox3.Text)&& PrCH(textBox6.Text) && PrCH(textBox7.Text) && PrCH(textBox8.Text))//проверка на числы

                    {
                        if (Prbool(textBox4.Text))//проверка на true/false
                        {
                            string type = textBox1.Text;
                            int wireCount = Convert.ToInt32(textBox2.Text);
                            double diameter = Convert.ToDouble(textBox3.Text);
                            bool hasSheath;
                            if (textBox4.Text == "имеется") hasSheath = true;
                            else hasSheath = false;
                            string manufacturer = textBox5.Text;
                            int voltage = Convert.ToInt32(textBox6.Text);
                            int currentRating = Convert.ToInt32(textBox7.Text);
                            double length = Convert.ToDouble(textBox8.Text);


                            var newCable = new PowerCable(type, wireCount, diameter, hasSheath, manufacturer, voltage, currentRating, length);

                            Cable.AddCable(newCable);
                            UpdateCableList();
                        }else MessageBox.Show("В поле *Наличие оплетки разрешено ввести только имеется/не имеется");
                    }
                    else MessageBox.Show("Корректно заполните поля *Кол-во жил*, *Диаметр*, *Макс.напряжение*, *Бакс.ток*, *Длина*");
                }
                else MessageBox.Show("Корректно заполните поля *Тип* и *Производитель*");
            }
            else MessageBox.Show("Заполните все поля");


        }
        private void UpdateCableList()//обноыление листа
        {
            listBox1.Items.Clear();

            // добавление после очистки
            foreach (var cable in Cable.cables)
            {
                PowerCable pc = (PowerCable)cable;

                listBox1.Items.Add("Качество: " + cable.CalculateQuality() + ", " + pc.PrintInfo());
                listBox1.HorizontalScrollbar = true;
            }
        }


        string selectedCableInfo;
        private void button2_Click(object sender, EventArgs e)
        {//удаление
            string type = textBox1.Text;
            int wireCount = Convert.ToInt32(textBox2.Text);
            double diameter = Convert.ToDouble(textBox3.Text);
          
            Cable cableToRemove = new Cable(type, wireCount, diameter);
            Cable.RemoveCable(cableToRemove);
            listBox1.Items.Remove(selectedCableInfo);


        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //присваивание значений по индексу
            if (listBox1.SelectedItem != null)
            {
                selectedCableInfo = listBox1.SelectedItem.ToString();

                // Разделяем строку на значения
                string[] contactDetails = selectedCableInfo.Split(new[] { ": ", " ", ", " }, StringSplitOptions.None);
                ind = listBox1.SelectedIndex;//индекс
                // Заполняем текстовые поля

                textBox1.Text = contactDetails[9];
                textBox2.Text = contactDetails[12];
                textBox3.Text = contactDetails[14];
             
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//удаление по типу
            string type = textBox1.Text;
            Cable.RemoveCable(type);
            UpdateCableList();
        }

        private void button4_Click(object sender, EventArgs e)
        {//удаление по индексу
            Cable.RemoveCable(ind);
            UpdateCableList();
        }

        public bool PrStr(string text)
        {//проверка на буквы
            int rez = 0; 
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                    rez++;
            }
            if (rez == 0)
                return true;
            else return false;
        }
        public bool PrCH(string text)
        {//проверка на числа
            int rez = 0; 
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    rez++;
            }
            if (rez == 0)
                return true;
            else return false;
        }
        public bool Prbool(string text)
        {//проверка на true/false
            int rez = 0;
            if (text == "имеется") rez = 1;
            else if (text == "не имеется") rez = 2;
            else rez = 0;
            if (rez == 0)
                return false;
            else return true;
        }
    }
}
