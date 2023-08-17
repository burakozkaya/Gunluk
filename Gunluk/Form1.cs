using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Gunluk
{
    public partial class Form1 : Form
    {
        private string path = "Gunluk.json", tempBaslik, tempIcerik, readAllTemp, passPath = ".Path.txt";
        List<Gunluk> gunlukList;
        public Form1()
        {

            InitializeComponent();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tempBaslik = txtBaslik.Text == string.Empty ?
                tempBaslik = DateTime.Now.ToLongDateString() : txtBaslik.Text;

            tempIcerik = txtIcerik.Text;

            if (GetValue()) return;

            gunlukList.Add(new Gunluk()
            {
                Baslik = tempBaslik,
                Icerik = tempIcerik,
            });

            gunlukList = gunlukList.OrderByDescending(item => item.dateTime).ToList();

            listBoxUpdate();

            ResetTxtBtn("ignore");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnDuzenle.Enabled = false;
            gunlukList = new List<Gunluk>();
            if (File.Exists(path))
                ReadJsonFromTxt();
        }
        private void listGunluk_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listIndex = listBoxGunluk.SelectedIndex;

            if (listIndex == -1)
                return;

            ResetTxtBtn("allwaystrue");

            this.Text = gunlukList[listIndex].dateTime.ToString();

            txtIcerik.Text = gunlukList[listIndex].Icerik;

            txtBaslik.Text = gunlukList[listIndex].Baslik;

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTxtBtn("true");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteGunlukToJson();
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
                        UpdateItem(tempSelectedIndex);
                        ResetTxtBtn("true");
                    }
                }
            }
        }
        private void ReadJsonFromTxt()
        {
            readAllTemp = File.ReadAllText(path);
            var readPassKey = File.ReadAllText(passPath).Split(":");
            var readPassKeyFinal = int.Parse(readPassKey[0]) - int.Parse(readPassKey[1]);
            if (readAllTemp.Length == 0)
                return;
            var charArray = readAllTemp.ToCharArray();
            for (var i = 0; i < charArray.Length; i++)
            {
                charArray[i] = (char)((int)charArray[i] + readPassKeyFinal);
            }

            readAllTemp = new string(charArray);

            gunlukList = JsonSerializer.Deserialize<List<Gunluk>>(readAllTemp);


            ListBoxMaker(gunlukList.OrderByDescending(item => item.dateTime).ToList());
        }
        private void WriteGunlukToJson()
        {
            Random rnd = new Random();
            var tempPassKey = rnd.Next(0, 20);
            var tempPassKeyRnd = rnd.Next(0, 20);
            JsonSerializerOptions options = new JsonSerializerOptions()

            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var temp = JsonSerializer.Serialize(gunlukList, options);

            var charArray = temp.ToCharArray();
            for (var i = 0; i < charArray.Length; i++)
            {
                charArray[i] = (char)((int)charArray[i] - tempPassKey);
            }

            tempPassKey += tempPassKeyRnd;
            File.WriteAllText(passPath, tempPassKey.ToString() + ":" + tempPassKeyRnd.ToString());
            temp = new string(charArray);
            File.WriteAllText(path, temp);
        }
        private void listBoxUpdate()
        {
            listBoxGunluk.Items.Clear();
            ListBoxMaker(gunlukList);
        }
        private bool GetValue()
        {
            if (tempIcerik == string.Empty)
            {
                MessageBox.Show("Icerik bos birakilamaz");
                return true;
            }
            if (gunlukList.Any(item => item.Baslik == tempBaslik))
            {
                MessageBox.Show("Baslik ayni olamaz");
                return true;
            }
            return false;
        }
        private void UpdateItem(int tempSelectedIndex)
        {
            var tempBaslikx = txtBaslik.Text != string.Empty ? txtBaslik.Text : DateTime.Now.ToString();
            gunlukList[tempSelectedIndex].Baslik = tempBaslikx;
            gunlukList[tempSelectedIndex].Icerik = txtIcerik.Text;
            gunlukList[tempSelectedIndex].dateTime = DateTime.Now;
            listBoxUpdate();
        }
        private void ListBoxMaker(List<Gunluk> gunlukList)
        {
            foreach (var gunluk in gunlukList)
                listBoxGunluk.Items.Add(gunluk.Baslik);
        }
        private void ResetTxtBtn(string flag)
        {
            txtIcerik.Clear();
            txtBaslik.Clear();
            this.Text = "Form1";
            if (flag == "ignore")
                return;
            else if (flag == "true")
            {
                btnDuzenle.Enabled = false;
                listBoxGunluk.SelectedIndex = -1;
                return;
            }
            else
                btnDuzenle.Enabled = true;
        }
    }
}