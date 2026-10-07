using System.Windows;
using System.Windows.Controls;

namespace StudentRegistrationApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSimpan_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNim.Text))
            {
                MessageBox.Show("NIM harus diisi!");
                txtNim.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama harus diisi!");
                txtNama.Focus();
                return;
            }

            if (cmbProdi.SelectedItem == null)
            {
                MessageBox.Show("Pilih program studi!");
                return;
            }

            if (rbLaki.IsChecked != true && rbPerempuan.IsChecked != true)
            {
                MessageBox.Show("Pilih jenis kelamin!");
                return;
            }

            string nim = txtNim.Text;
            string nama = txtNama.Text;

            string prodi = "";
            if (cmbProdi.SelectedItem is ComboBoxItem item)
            {
                prodi = item.Content.ToString();
            }

            string jenisKelamin = rbLaki.IsChecked == true
                ? "Laki-laki"
                : "Perempuan";

            string data = $"{nim} | {nama} | {prodi} | {jenisKelamin}";
            lstMahasiswa.Items.Add(data);

            UpdateJumlah();

            MessageBox.Show(
                "Data mahasiswa berhasil disimpan!",
                "Informasi",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            BtnReset_Click(sender, e);
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            txtNim.Clear();
            txtNama.Clear();
            cmbProdi.SelectedIndex = -1;
            rbLaki.IsChecked = false;
            rbPerempuan.IsChecked = false;
            txtNim.Focus();
        }

        private void BtnHapus_Click(object sender, RoutedEventArgs e)
        {
            if (lstMahasiswa.SelectedItem == null)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            MessageBoxResult hasil = MessageBox.Show(
                "Yakin ingin menghapus data ini?",
                "Konfirmasi",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (hasil == MessageBoxResult.Yes)
            {
                lstMahasiswa.Items.Remove(lstMahasiswa.SelectedItem);
                UpdateJumlah();
            }
        }

        private void UpdateJumlah()
        {
            txtJumlah.Text = $"Jumlah Mahasiswa: {lstMahasiswa.Items.Count}";
        }
    }
}
