using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class FormAddInfo : Form
    {
        string responseJson;
        Form1 form;
        public FormAddInfo(Form1 form1)
        {
            this.form = form1;
            InitializeComponent();
            foreach (var item in form1.ListCountryFormAdd)
            comboBoxCountryAdd.Items.Add(item);
            if (comboBoxCountryAdd.Items.Count > 0)
            {
                comboBoxCountryAdd.SelectedIndex = 0;
            }
        }

        private async Task InsertCountriesAsync()
        {
            WebRequest request = WebRequest.Create("http://localhost:81/travel_agancy.loc/apiExem/api.php");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = $"token=ps_rpo_2&param=insCountries&object={JsonConvert.SerializeObject(new Country { countryName = $"{TextBoxAddCountry.Text}" })}";
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/x-www-form-urlencoded";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseJson = reader.ReadToEnd();
                }
            }
            response.Close();
            if (responseJson == "200")
            {
                comboBoxCountryAdd.Items.Add(TextBoxAddCountry.Text);
                form.AddComboCountryFromForm2(TextBoxAddCountry.Text);
                MessageBox.Show("Запись добавлена");
            }
        }

        private async Task InsertCityAsync()
        {
            WebRequest request = WebRequest.Create("http://localhost:81/travel_agancy.loc/apiExem/api.php");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = $"token=ps_rpo_2&param=insCity&insCountry={comboBoxCountryAdd.SelectedItem}&insCityName={textBoxAddCity.Text}";
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/x-www-form-urlencoded";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseJson = reader.ReadToEnd();
                }
            }
            response.Close();
            if (responseJson == "200")
            {
                MessageBox.Show("Запись добавлена");
            }
        }

        private async void BtnAddCountry_Click(object sender, EventArgs e)
        {
            await InsertCountriesAsync();
        }

        private void comboBoxCountryAdd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void buttonAddCity_Click(object sender, EventArgs e)
        {
            await InsertCityAsync();
        }
    }
}
