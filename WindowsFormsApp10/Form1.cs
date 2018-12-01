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
        FormAddInfo formAddInfo;
        public List<string> ListCountryFormAdd; //для формы добавления данных

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
        private async Task LoadComboboxCountriesAsync()
        {
            ListCountryFormAdd = new List<string>();
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

            foreach(var item in JsonConvert.DeserializeObject<List<Country>>(responseJson))
            {
                comboBox1.Items.Add(item.countryName);
                ListCountryFormAdd.Add(item.countryName);
            }
            if(comboBox1.Items.Count>0)
            comboBox1.SelectedIndex = 0;

            //comboBox1.DataSource = JsonConvert.DeserializeObject<List<Country>>(responseJson).Select(c => c.countryName).ToList<string>();
        }
        private async Task GetCityAsync()
        {
            comBoxCity.Items.Clear();
            comBoxCity.ResetText();
            comboBoxHotel.Items.Clear();
            comboBoxHotel.ResetText();
            listBox1.Items.Clear();
            textBoxStars.Text = "";
            textBoxPrice.Text = "";

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
            
            foreach (var item in JsonConvert.DeserializeObject<List<City>>(responseJson))
            {
                comBoxCity.Items.Add(item.cityName);
            }
            if(comBoxCity.Items.Count>0)
            comBoxCity.SelectedIndex = 0;
            //comBoxCity.DataSource= JsonConvert.DeserializeObject<List<City>>(responseJson).Select(c => c.cityName).ToList<string>();
        }

        private async Task GetHotelsAsync()
        {
            comboBoxHotel.Items.Clear();
            comboBoxHotel.ResetText();

            WebRequest request = WebRequest.Create("http://localhost:81/travel_agancy.loc/apiExem/api.php");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = $"token=ps_rpo_2&param=GetHotels&cities={comBoxCity.SelectedItem.ToString()}";
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

            foreach (var item in JsonConvert.DeserializeObject<List<Hotel>>(responseJson))
            {
                comboBoxHotel.Items.Add(item.hotelName);
            }
            if (comboBoxHotel.Items.Count > 0)
                comboBoxHotel.SelectedIndex = 0;
            //comboBoxHotel.DataSource = JsonConvert.DeserializeObject<List<Hotel>>(responseJson).Select(c => c.hotelName).ToList<string>();
            GetHotelInfo();
        }

        private void GetHotelInfo()
        {
            foreach (var item in JsonConvert.DeserializeObject<List<Hotel>>(responseJson))
            {
                if (comboBoxHotel.SelectedItem.ToString() == item.hotelName)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(item.info);
                    textBoxStars.Text = item.stars.ToString()+"*";
                    textBoxPrice.Text = item.cost.ToString()+" y.e";
                }
            }
        }

        private async Task InsertCountriesAsync()
        {
            WebRequest request = WebRequest.Create("http://localhost:81/travel_agancy.loc/apiExem/api.php");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = $"token=ps_rpo_2&param=insCountries&object={JsonConvert.SerializeObject(new Country { countryName="Bolgaria3"})}";
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
                MessageBox.Show("Запись добавлена");
            }
        }    

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  //Country
        {

            //await LoadComboboxCountriesAsync();
       
            listBox1.Items.Clear();
            textBoxStars.Text = "";
            textBoxPrice.Text = "";
            await GetCityAsync();
        }

        private async void comBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBoxStars.Text = "";
            textBoxPrice.Text = "";
            await GetHotelsAsync();
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetHotelInfo();
        }

        private void buttonAddInfo_Click(object sender, EventArgs e)
        {
            FormAddInfo formAddInfo = new FormAddInfo(this);
            formAddInfo.Show();
        }

        public void AddComboCountryFromForm2(string country)
        {
            comboBox1.Items.Add(country);
        }
    }
}
