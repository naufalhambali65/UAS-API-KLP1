using System.Security.Policy;
using UASKELOMPOK1API;
using static UASKELOMPOK1API.API;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            API api = API.Instance;

            string input = textBox1.Text;
            string input2 = textBox2.Text;

            double nilai1 = 0;
            double nilai2 = 0;
            double hasil = 0;

            if (double.TryParse(input, out nilai1) || double.TryParse(input2, out nilai2))
            {
                nilai1 = Double.Parse(input);
                if (input2 != "")
                {
                    nilai2 = Double.Parse(input2);
                }


                if (comboBox1.Text == "Hitung Volume Kubus")
                {
                    BangunRuang.Shape Vkubus = api.BuatBangunRuang(ShapeCategory.Kubus, nilai1);
                    hasil = Vkubus.HitungVolume();
                }
                else if (comboBox1.Text == "Hitung Luas Permukaan Kubus")
                {
                    BangunRuang.Shape LPKubus = api.BuatBangunRuang(ShapeCategory.Kubus, nilai1, nilai2);
                    hasil = LPKubus.HitungLuasPermukaan();
                }
                else if (comboBox1.Text == "Hitung Volume Bola")
                {
                    BangunRuang.Shape VBola = api.BuatBangunRuang(ShapeCategory.Bola, nilai1);
                    hasil = VBola.HitungVolume();
                }
                else if (comboBox1.Text == "Hitung Luas Permukaan Bola")
                {
                    BangunRuang.Shape LPBola = api.BuatBangunRuang(ShapeCategory.Bola, nilai1);
                    hasil = LPBola.HitungLuasPermukaan();
                }
                else if (comboBox1.Text == "Hitung Volume Tabung")
                {
                    BangunRuang.Shape VTabung = api.BuatBangunRuang(ShapeCategory.Tabung, nilai1, nilai2);
                    hasil = VTabung.HitungVolume();
                }
                else if (comboBox1.Text == "Hitung Luas Permukaan Tabung")
                {
                    BangunRuang.Shape LPTabung = api.BuatBangunRuang(ShapeCategory.Tabung, nilai1, nilai2);
                    hasil = LPTabung.HitungLuasPermukaan();
                }
                else if (comboBox1.Text == "Hitung Kecepatan")
                {
                    Fisika.Hitung kecepatan = api.HitungRumusFisika(RumusCategory.Kecepatan, nilai1, nilai2);
                    hasil = kecepatan.HitungRumus();
                }
                else if (comboBox1.Text == "Hitung Gaya")
                {
                    Fisika.Hitung gaya = api.HitungRumusFisika(RumusCategory.Gaya, nilai1, nilai2);
                    hasil = gaya.HitungRumus();
                }
                else if (comboBox1.Text == "Hitung Daya")
                {
                    Fisika.Hitung daya = api.HitungRumusFisika(RumusCategory.Daya, nilai1, nilai2);
                    hasil = daya.HitungRumus();
                }
                else if (comboBox1.Text == "Hitung Debit Air")
                {
                    Fisika.Hitung debit = api.HitungRumusFisika(RumusCategory.Debit, nilai1, nilai2);
                    hasil = debit.HitungRumus();
                }
                else if (comboBox1.Text == "Hitung Arus Listrik")
                {
                    Fisika.Hitung arus = api.HitungRumusFisika(RumusCategory.Arus, nilai1, nilai2);
                    hasil = arus.HitungRumus();
                }

            }
            else if (comboBox2.Text == "Rumus Statistika Dasar")
            {
                if (comboBox1.Text == "Hitung Mean")
                {
                    Statistika.Data mean = api.HitungDataStatistik(StatistikCategory.Mean, input);
                    hasil = mean.HitungData();
                }
                else if (comboBox1.Text == "Hitung Median")
                {
                    Statistika.Data median = api.HitungDataStatistik(StatistikCategory.Median, input);
                    hasil = median.HitungData();
                }
                else if (comboBox1.Text == "Hitung Jangkauan")
                {
                    Statistika.Data jangkauan = api.HitungDataStatistik(StatistikCategory.Jangkauan, input);
                    hasil = jangkauan.HitungData();
                }
                else if (comboBox1.Text == "Hitung Simpangan Baku")
                {
                    Statistika.Data simpanganbaku = api.HitungDataStatistik(StatistikCategory.SimpanganBaku, input);
                    hasil = simpanganbaku.HitungData();
                }
                else if (comboBox1.Text == "Hitung Simpangan Rata Rata")
                {
                    Statistika.Data simpanganrata = api.HitungDataStatistik(StatistikCategory.SimpanganRataRata, input);
                    hasil = simpanganrata.HitungData();
                }
            }
            else
            {
                MessageBox.Show("Input tidak valid. Harap masukkan Inputan yang benar!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox3.Text = hasil.ToString("F2");
            label4.Text = "Hasil";

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Enabled = true;
            label4.Text = "";

            if (comboBox1.Text == "Hitung Volume Kubus" || comboBox1.Text == "Hitung Luas Permukaan Kubus")
            {

                textBox2.Enabled = false;
                label2.Text = "";
                label1.Text = "Sisi";
            }
            else if (comboBox1.Text == "Hitung Volume Bola" || comboBox1.Text == "Hitung Luas Permukaan Bola")
            {

                textBox2.Enabled = false;
                label2.Text = "";
                label1.Text = "Jari Jari";

            }
            else if (comboBox1.Text == "Hitung Volume Tabung" || comboBox1.Text == "Hitung Luas Permukaan Tabung")
            {

                textBox2.Enabled = true;
                label1.Text = "Jari Jari";
                label2.Text = "Tinggi";
            }
            else if (comboBox1.Text == "Hitung Kecepatan")
            {

                textBox2.Enabled = true;
                label1.Text = "Jarak";
                label2.Text = "Waktu";
            }
            else if (comboBox1.Text == "Hitung Gaya")
            {

                textBox2.Enabled = true;
                label1.Text = "Massa";
                label2.Text = "Percepatan";
            }
            else if (comboBox1.Text == "Hitung Daya")
            {

                textBox2.Enabled = true;
                label1.Text = "Usaha";
                label2.Text = "Waktu";
            }
            else if (comboBox1.Text == "Hitung Debit Air")
            {

                textBox2.Enabled = true;
                label1.Text = "Volume";
                label2.Text = "Waktu";
            }
            else if (comboBox1.Text == "Hitung Arus Listrik")
            {

                textBox2.Enabled = true;
                label1.Text = "Tegangan";
                label2.Text = "Hambatan";
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label1.Text = "";
            label2.Text = "";
            label4.Text = "";
            if (comboBox2.Text == "Rumus Bangun Ruang")
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox1.Enabled = true;
                comboBox1.Items.AddRange(new object[] { "Hitung Volume Kubus", "Hitung Luas Permukaan Kubus", "Hitung Volume Bola", "Hitung Luas Permukaan Bola", "Hitung Volume Tabung", "Hitung Luas Permukaan Tabung" });
            }
            else if (comboBox2.Text == "Rumus Fisika")
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox1.Enabled = true;
                comboBox1.Items.AddRange(new object[] { "Hitung Kecepatan", "Hitung Gaya", "Hitung Daya", "Hitung Debit Air", "Hitung Arus Listrik" });

            }
            else if (comboBox2.Text == "Rumus Statistika Dasar")
            {
                label1.Text = "Himpunan Data\n dibatasi dengan (spasi)";
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox1.Enabled = true;
                comboBox1.Items.AddRange(new object[] { "Hitung Mean", "Hitung Median", "Hitung Jangkauan", "Hitung Simpangan Baku", "Hitung Simpangan Rata Rata" });
            }
        }
    }
}