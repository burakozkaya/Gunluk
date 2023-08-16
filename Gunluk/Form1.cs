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
                tempBaslik = DateTime.Now.ToLongTimeString();

            gunlukList.Add(new Gunluk()
            {
                Baslik = tempBaslik,
                Icerik = tempIcerik,
            });
            StreamWriter streamWriter = new StreamWriter(path);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var temp = JsonSerializer.Serialize(gunlukList, options);

            streamWriter.WriteLine(temp);

            streamWriter.Close();
            listGunluk.Items.Add(gunlukList[gunlukList.Count - 1].Baslik);


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            gunlukList = new List<Gunluk>();
            if (File.Exists(path))
            {
                GunlukBaslatici();
            }
        }

        private void GunlukBaslatici()
        {
            gunlukList = JsonSerializer.Deserialize<List<Gunluk>>(File.ReadAllText(path));
            foreach (var gunluk in gunlukList)
            {
                listGunluk.Items.Add(gunluk.Baslik);
            }
        }

        private void listGunluk_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listIndex = listGunluk.SelectedIndex;
            ResetTxtBtn();
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
    }

    public class Gunluk
    {
        public string Baslik { get; set; }

        public DateTime dateTime { get; set; } = DateTime.Now;
        public string Icerik { get; set; }
    }
}