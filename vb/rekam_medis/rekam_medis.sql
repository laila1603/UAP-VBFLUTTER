-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 04 Apr 2021 pada 17.33
-- Versi server: 10.4.14-MariaDB
-- Versi PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rekam_medis`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_admin`
--

CREATE TABLE `tb_admin` (
  `id_admin` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_admin`
--

INSERT INTO `tb_admin` (`id_admin`, `nama`, `username`, `password`) VALUES
(2, 'Admin', 'admin', '1'),
(9, 'samsul', 'samsul', '123'),
(10, 'Sulailah', 'sulailah', '1');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_dokter`
--

CREATE TABLE `tb_dokter` (
  `id_dokter` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `jk` varchar(20) NOT NULL,
  `spesialis` varchar(100) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_dokter`
--

INSERT INTO `tb_dokter` (`id_dokter`, `nama`, `jk`, `spesialis`, `username`, `password`) VALUES
(1, 'Dr. Indrayanto', 'Laki - laki', 'UMUM', 'dr1', '1'),
(2, 'Dr. Susi', 'Perempuan', 'ANAK', 'dr2', '2'),
(5, 'Dr.JONO', 'Laki - laki', 'UMUM', 'dr3', 'dr4'),
(6, 'Dr. Arif', 'Laki - laki', 'KEJIWAAN', 'drA', '1'),
(7, 'Andini', 'Perempuan', 'bedah', 'andini', '123');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_obat`
--

CREATE TABLE `tb_obat` (
  `id_obat` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_obat`
--

INSERT INTO `tb_obat` (`id_obat`, `nama`) VALUES
(1, 'PARACETAMOL 500MG'),
(2, 'PARACETAMOL 250MG'),
(4, 'PANADOL'),
(5, 'konimex');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_pasien`
--

CREATE TABLE `tb_pasien` (
  `id_pasien` int(11) NOT NULL,
  `no_kartu` varchar(100) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `jk` varchar(20) NOT NULL,
  `umur` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_pasien`
--

INSERT INTO `tb_pasien` (`id_pasien`, `no_kartu`, `nama`, `jk`, `umur`) VALUES
(1, '34564', 'Agus', 'Laki - laki', 45),
(5, '3456', 'Risqi', 'Laki - laki', 67),
(6, '1234', 'Yusuf', 'Laki - laki', 44),
(14, '233', 'samsul', 'Laki - Laki', 15),
(15, '234', 'diki', 'Laki - Laki', 20),
(16, '2156', 'Rahmat', 'Laki - Laki', 21);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_rekam_medis`
--

CREATE TABLE `tb_rekam_medis` (
  `id_rekam` int(11) NOT NULL,
  `id_pasien` int(11) NOT NULL,
  `keluhan` text NOT NULL,
  `diagnosa` text NOT NULL,
  `tanggal` date NOT NULL,
  `id_dokter` int(11) NOT NULL,
  `id_admin` int(11) NOT NULL,
  `status` enum('pendaftaran','pemeriksaan','tebus_obat','selesai') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_rekam_medis`
--

INSERT INTO `tb_rekam_medis` (`id_rekam`, `id_pasien`, `keluhan`, `diagnosa`, `tanggal`, `id_dokter`, `id_admin`, `status`) VALUES
(9, 5, 'Pusing, demam,', 'kurang vit C', '2021-03-08', 1, 1, 'selesai'),
(10, 6, 'sakit hati', 'kurang tidur', '2021-03-08', 2, 7, ''),
(11, 1, 'gagal cinta', 'kurang tidur', '2021-08-03', 1, 7, 'tebus_obat'),
(12, 1, 'susah tidur', 'kebanyakan ngopi', '2021-03-27', 1, 7, 'tebus_obat'),
(13, 3, 'anu', '', '2021-03-27', 1, 7, 'pendaftaran'),
(14, 13, 'l', '', '2021-03-27', 1, 7, 'pendaftaran'),
(15, 13, 'l', '', '2021-03-27', 1, 7, 'selesai'),
(16, 15, 'sakit kepala', 'kurang tidur', '2021-08-03', 5, 7, 'selesai'),
(17, 5, 'sakit pinggang', 'keseringan nguli', '2021-03-08', 1, 7, 'tebus_obat'),
(18, 6, 'susah tidur', 'ngopi', '2021-03-08', 1, 7, 'tebus_obat'),
(19, 14, 'pusing', 'tahu', '2021-03-08', 1, 7, 'selesai'),
(20, 16, 'sering pusing', 'kurang tidur', '2021-03-30', 1, 7, 'selesai');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_resep`
--

CREATE TABLE `tb_resep` (
  `id_resep` int(11) NOT NULL,
  `id_rekam` int(11) NOT NULL,
  `id_obat` int(11) NOT NULL,
  `keterangan` text NOT NULL,
  `nama` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_resep`
--

INSERT INTO `tb_resep` (`id_resep`, `id_rekam`, `id_obat`, `keterangan`, `nama`) VALUES
(1, 0, 0, '', 'PARACETAMOL 250MG'),
(2, 0, 0, '', 'PARACETAMOL 500MG'),
(3, 0, 0, '', 'PARACETAMOL 250MG'),
(4, 0, 0, '', 'PARACETAMOL 250MG'),
(5, 0, 0, '', 'PARACETAMOL 250MG'),
(6, 0, 0, '', 'PARACETAMOL 250MG'),
(7, 0, 0, '', 'PARACETAMOL 250MG'),
(8, 0, 0, '', 'PARACETAMOL 250MG'),
(9, 0, 0, '', 'PARACETAMOL 250MG'),
(10, 0, 0, '', 'PARACETAMOL 250MG'),
(11, 6, 0, '', 'PARACETAMOL 250MG'),
(12, 6, 0, '', 'PARACETAMOL 250MG'),
(13, 6, 0, '', 'PARACETAMOL 500MG'),
(14, 6, 0, '', 'PARACETAMOL 250MG'),
(15, 6, 0, '', 'PARACETAMOL 500MG'),
(16, 6, 0, '', 'PARACETAMOL 250MG'),
(17, 6, 0, '', 'PARACETAMOL 500MG'),
(18, 7, 0, '', 'PARACETAMOL 250MG'),
(19, 6, 0, '', 'PARACETAMOL 250MG'),
(20, 6, 0, '', 'PARACETAMOL 500MG'),
(21, 1, 0, '', 'PARACETAMOL 250MG'),
(22, 1, 0, '', 'PARACETAMOL 500MG'),
(23, 9, 0, '', 'PANADOL'),
(24, 9, 0, '', 'PARACETAMOL 250MG'),
(25, 15, 0, '', 'PARACETAMOL 500MG'),
(26, 15, 0, '', 'PARACETAMOL 250MG'),
(27, 16, 0, '', 'PARACETAMOL 250MG'),
(28, 16, 0, '', 'PANADOL'),
(29, 10, 0, '', 'PANADOL'),
(30, 11, 0, '', 'PANADOL'),
(31, 12, 0, '', 'PANADOL'),
(32, 19, 0, '', 'PANADOL'),
(33, 17, 0, '', 'PARACETAMOL 250MG'),
(34, 18, 0, '', 'PARACETAMOL 250MG'),
(35, 18, 0, '', 'PARACETAMOL 500MG'),
(36, 20, 0, '', 'PANADOL'),
(37, 20, 0, '', 'PARACETAMOL 250MG');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tb_admin`
--
ALTER TABLE `tb_admin`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indeks untuk tabel `tb_dokter`
--
ALTER TABLE `tb_dokter`
  ADD PRIMARY KEY (`id_dokter`);

--
-- Indeks untuk tabel `tb_obat`
--
ALTER TABLE `tb_obat`
  ADD PRIMARY KEY (`id_obat`);

--
-- Indeks untuk tabel `tb_pasien`
--
ALTER TABLE `tb_pasien`
  ADD PRIMARY KEY (`id_pasien`);

--
-- Indeks untuk tabel `tb_rekam_medis`
--
ALTER TABLE `tb_rekam_medis`
  ADD PRIMARY KEY (`id_rekam`);

--
-- Indeks untuk tabel `tb_resep`
--
ALTER TABLE `tb_resep`
  ADD PRIMARY KEY (`id_resep`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tb_admin`
--
ALTER TABLE `tb_admin`
  MODIFY `id_admin` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT untuk tabel `tb_dokter`
--
ALTER TABLE `tb_dokter`
  MODIFY `id_dokter` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT untuk tabel `tb_obat`
--
ALTER TABLE `tb_obat`
  MODIFY `id_obat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT untuk tabel `tb_pasien`
--
ALTER TABLE `tb_pasien`
  MODIFY `id_pasien` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT untuk tabel `tb_rekam_medis`
--
ALTER TABLE `tb_rekam_medis`
  MODIFY `id_rekam` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT untuk tabel `tb_resep`
--
ALTER TABLE `tb_resep`
  MODIFY `id_resep` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
