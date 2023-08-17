using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Gunluk
{
    public partial class Form1 : Form
    {
        private string path = "Gunluk.json", tempBaslik, tempIcerik;
        List<Gunluk> gunlukList; 
        public Form1()
        {
            InitializeComponent();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tempBaslik = txtBaslik.Text;

            tempIcerik = txtIcerik.Text;

            if (tempIcerik == string.Empty)
            {
                MessageBox.Show("Icerik bos birakilamaz");
                return;
            }

            if (tempBaslik == string.Empty)
                tempBaslik = DateTime.Now.ToLongDateString();

            if (gunlukList.Any(item => item.Baslik == tempBaslik))
            {
                MessageBox.Show("Baslik ayni olamaz");
                return;
            }
            foreach (var VARIABLE in gunlukList)
            {
                if (VARIABLE.Baslik == tempBaslik)
                    return;
            }
            gunlukList.Add(new Gunluk()
            {
                Baslik = tempBaslik,
                Icerik = tempIcerik,
            });

            gunlukList = gunlukList.OrderByDescending(item => item.dateTime).ToList();

            listBoxGunluk.Items.Clear();
            ListBoxMaker();

            ResetTxtBtn();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gunlukList = new List<Gunluk>();
            if (File.Exists(path))
            {
                if (File.ReadAllText(path).Length == 0)
                {
                    File.Delete(path);
                    return;
                }
                gunlukList = JsonSerializer.Deserialize<List<Gunluk>>(File.ReadAllText(path));

                gunlukList = gunlukList.OrderByDescending(item => item.dateTime).ToList();

                ListBoxMaker();

            }
        }
        private void ListBoxMaker()
        {
            foreach (var gunluk in gunlukList)
            {
                listBoxGunluk.Items.Add(gunluk.Baslik);
            }
        }
        private void listGunluk_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listIndex = listBoxGunluk.SelectedIndex;

            if (listIndex == -1)
            {
                return;
            }

            ResetTxtBtn();



            this.Text = gunlukList[listIndex].dateTime.ToString();

            txtIcerik.Text = gunlukList[listIndex].Icerik;

            txtBaslik.Text = gunlukList[listIndex].Baslik;

        }
        private void ResetTxtBtn()
        {
            txtIcerik.Clear();
            txtBaslik.Clear();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTxtBtn();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()

            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var temp = JsonSerializer.Serialize(gunlukList, options);

            File.WriteAllText(path, temp);
        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            var tempSelectedIndex = listBoxGunluk.SelectedIndex;

            if (tempSelectedIndex != -1)
            {
                if (gunlukList[tempSelectedIndex].Baslik != tempBaslik || gunlukList[tempSelectedIndex].Icerik != tempIcerik)
                {
                    if (txtIcerik != null)
                    {
                        var tempBaslikx = txtBaslik.Text != string.Empty ? txtBaslik.Text : DateTime.Now.ToString();
                        gunlukList[tempSelectedIndex].Baslik = tempBaslikx;
                        gunlukList[tempSelectedIndex].Icerik = txtIcerik.Text;
                        gunlukList[tempSelectedIndex].dateTime = DateTime.Now;
                    }
                }
            }
            listBoxGunluk.Items.Clear();
            ResetTxtBtn();
            ListBoxMaker();
        }

    }

    public class Gunluk
    {
        public string Baslik { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        public string Icerik { get; set; }
    }
}