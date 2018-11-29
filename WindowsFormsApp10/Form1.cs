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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        private string responseJson;
        private string responseJsonCities;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadComboboxCountriesAsync();
            //await GetCityAsync();
            //await InsertCountriesAsync();
        }

        private async Task GetCityAsync()
        {
            WebRequest request = WebRequest.Create("http://localhost:81/travel_agancy.loc/apiExem/api.php");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = $"token=ps_rpo_2&param=GetCity&country={comboBox1.SelectedItem.ToString()}";
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
           comBoxCity.DataSource= JsonConvert.DeserializeObject<List<City>>(responseJson).Select(c => c.cityName).ToList<string>();
        }

        private async Task InsertCountriesAsync()
        {
            WebRequest request = WebRequest.Create("http://localhost:81/travel_agancy.loc/apiExem/api.php");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = $"token=ps_rpo_2&param=insCountries&object={JsonConvert.SerializeObject(new Country { countryName="Bolivia"})}";
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
            if (responseJson == "200") {
                MessageBox.Show("Страна добавлена!");
            }
        }

        private async Task LoadComboboxCountriesAsync()
        {
            WebRequest request = WebRequest.Create("http://localhost:81/travel_agancy.loc/apiExem/api.php");       
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = "token=ps_rpo_2&param=getCountries";
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

            comboBox1.DataSource = JsonConvert.DeserializeObject<List<Country>>(responseJson).Select(c => c.countryName).ToList<string>();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  //Country
        {
            await GetCityAsync();
             //MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

       


        private void comBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await GetCityAsync();
        }
    }
}
