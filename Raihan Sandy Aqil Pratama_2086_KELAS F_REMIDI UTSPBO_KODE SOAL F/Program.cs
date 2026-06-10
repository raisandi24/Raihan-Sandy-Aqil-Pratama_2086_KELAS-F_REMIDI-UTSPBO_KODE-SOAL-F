using System;
using System.Collections.Generic;

namespace OOPLib
{
    abstract class PinjamBuku
    {
        private string namaAnggota;
        private string idAnggota;
        private string judulBuku;

        protected List<RiwayatPinjam> riwayat =
            new List<RiwayatPinjam>();

        public PinjamBuku(string nama, string id, string buku)
        {
            namaAnggota = nama;
            idAnggota = id;
            judulBuku = buku;
        }

        public string NamaAnggota
        {
            get { return namaAnggota; }
            set { namaAnggota = value; }
        }

        public string IdAnggota
        {
            get { return idAnggota; }
            set { idAnggota = value; }
        }

        public string JudulBuku
        {
            get { return judulBuku; }
            set { judulBuku = value; }
        }

        public void TampilInfo()
        {
            Console.WriteLine(
                $"Anggota: {namaAnggota} | ID: {idAnggota} | Buku: {judulBuku}");
        }

        public abstract double HitungBiayaPinjam(int lamaHari);

        public void TambahPinjam(RiwayatPinjam data)
        {
            riwayat.Add(data);
        }

        public void CetakRiwayat()
        {
            int no = 1;

            foreach (var item in riwayat)
            {
                Console.WriteLine(
                    $"{no}. {item.JenisBuku} | {item.LamaHari} Hari | {item.TanggalPinjam:dd-MM-yyyy}");
                no++;
            }
        }
    }

    class BukuReferensi : PinjamBuku
    {
        private double biayaPerHari;
        private double biayaAsuransi;

        public BukuReferensi(
            string nama,
            string id,
            string buku,
            double biayaPerHari,
            double biayaAsuransi)
            : base(nama, id, buku)
        {
            this.biayaPerHari = biayaPerHari;
            this.biayaAsuransi = biayaAsuransi;
        }

        public override double HitungBiayaPinjam(int lamaHari)
        {
            return (lamaHari * biayaPerHari)
                   + biayaAsuransi;
        }
    }

    class RiwayatPinjam
    {
        public string JenisBuku { get; set; }
        public int LamaHari { get; set; }
        public DateTime TanggalPinjam { get; set; }

        public RiwayatPinjam(
            string jenis,
            int hari,
            DateTime tanggal)
        {
            JenisBuku = jenis;
            LamaHari = hari;
            TanggalPinjam = tanggal;
        }
    }

    class Program
    {
        static void Main()
        {
            BukuReferensi buku =
                new BukuReferensi(
                    "Joko",
                    "A102",
                    "Ensiklopedia",
                    5000,
                    25000);

            int lamaHari = 5;

            buku.TampilInfo();

            Console.WriteLine(
                $"Total Biaya: Rp {buku.HitungBiayaPinjam(lamaHari)}");

            Console.WriteLine();

            buku.TambahPinjam(
                new RiwayatPinjam(
                    "Referensi",
                    5,
                    new DateTime(2025, 10, 15)));

            buku.CetakRiwayat();
        }
    }
}