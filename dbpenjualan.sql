-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 01, 2026 at 06:51 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbpenjualan`
--

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int(11) NOT NULL,
  `categoryDesc` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `categoryDesc`) VALUES
(1, 'ATK'),
(2, 'Sembako'),
(3, 'Perkakas'),
(4, 'Elektronik'),
(5, 'Makanan'),
(6, 'Minuman'),
(7, 'Pakaian'),
(8, 'Kecantkan');

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `itemID` varchar(12) NOT NULL,
  `itemDesc` varchar(100) NOT NULL,
  `itemCate` int(11) NOT NULL,
  `unit` varchar(15) NOT NULL,
  `salesPrice` int(11) NOT NULL,
  `purchasePrice` int(11) DEFAULT NULL,
  `minStock` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`id`, `itemID`, `itemDesc`, `itemCate`, `unit`, `salesPrice`, `purchasePrice`, `minStock`) VALUES
(1, 'B0001', 'Buku Tulis', 1, 'Pcs', 5000, NULL, 10),
(2, 'B0002', 'Penghapus', 1, 'Pcs', 1500, NULL, 20),
(5, 'B0003', 'Gula', 2, 'Kg', 20000, NULL, 10),
(6, 'B0004', 'Kalkulator', 4, 'Pcs', 25000, NULL, 25),
(7, 'B0005', 'sabun', 2, 'Pcs', 4000, 0, 20);

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswa`
--

CREATE TABLE `mahasiswa` (
  `id` int(11) NOT NULL,
  `nim` varchar(12) NOT NULL,
  `nama` varchar(60) NOT NULL,
  `jurusan` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `mahasiswa`
--

INSERT INTO `mahasiswa` (`id`, `nim`, `nama`, `jurusan`) VALUES
(1, '111', 'heri', 'dd'),
(2, '333', 'dede', 'dd'),
(3, '666', 'desi', 'dd');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `kode` varchar(5) NOT NULL,
  `produk` varchar(100) NOT NULL,
  `harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `purchase`
--

CREATE TABLE `purchase` (
  `idTrans` varchar(20) NOT NULL,
  `purchaseDate` datetime DEFAULT NULL,
  `totalPurchase` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `purchase`
--

INSERT INTO `purchase` (`idTrans`, `purchaseDate`, `totalPurchase`) VALUES
('PUR0001', '2025-12-30 22:33:21', 40000),
('PUR0002', '2025-12-30 22:35:11', 15000),
('PUR0003', '2025-12-30 23:00:14', 100),
('PUR0004', '2025-12-30 23:03:24', 16500),
('PUR0005', '2025-12-30 23:07:07', 10000),
('PUR0006', '2025-12-30 23:42:22', 73500),
('PUR0007', '2025-12-30 23:46:48', 1600),
('PUR0008', '2026-01-01 13:59:47', 1200),
('PUR0009', '2026-01-02 00:27:52', 1000000);

-- --------------------------------------------------------

--
-- Table structure for table `purchasedetail`
--

CREATE TABLE `purchasedetail` (
  `id` int(11) NOT NULL,
  `idTrans` varchar(20) DEFAULT NULL,
  `itemID` int(11) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `subtotal` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `purchasedetail`
--

INSERT INTO `purchasedetail` (`id`, `idTrans`, `itemID`, `qty`, `price`, `subtotal`) VALUES
(1, 'PUR0001', 1, 20, 2000, 40000),
(2, 'PUR0002', 2, 50, 300, 15000),
(3, 'PUR0003', 1, 2, 50, 100),
(4, 'PUR0004', 1, 55, 300, 16500),
(5, 'PUR0005', 1, 20, 500, 10000),
(6, 'PUR0006', 1, 24, 3000, 72000),
(7, 'PUR0006', 6, 5, 300, 1500),
(8, 'PUR0007', 1, 4, 400, 1600),
(9, 'PUR0008', 1, 3, 400, 1200),
(10, 'PUR0009', 5, 50, 20000, 1000000);

-- --------------------------------------------------------

--
-- Table structure for table `sale`
--

CREATE TABLE `sale` (
  `idTrans` varchar(12) NOT NULL,
  `saleDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sale`
--

INSERT INTO `sale` (`idTrans`, `saleDate`) VALUES
('TRX0001', '2025-12-10 13:18:27'),
('TRX0002', '2025-12-10 13:22:00'),
('TRX0003', '2025-12-17 19:29:17'),
('TRX0004', '2025-12-23 17:12:01'),
('TRX0005', '2025-12-23 17:36:06'),
('TRX0006', '2025-12-23 17:37:11'),
('TRX0007', '2025-12-24 18:49:11'),
('TRX0008', '2025-12-25 21:39:11'),
('TRX0009', '2025-12-25 22:30:04'),
('TRX0010', '2025-12-25 23:23:55'),
('TRX0011', '2025-12-30 20:31:00'),
('TRX0012', '2025-12-30 22:01:05'),
('TRX0013', '2025-12-30 22:26:06'),
('TRX0014', '2025-12-30 22:59:55'),
('TRX0015', '2025-12-30 23:06:40'),
('TRX0016', '2025-12-30 23:41:31'),
('TRX0017', '2025-12-30 23:47:03'),
('TRX0018', '2026-01-01 13:59:30');

-- --------------------------------------------------------

--
-- Table structure for table `saledetail`
--

CREATE TABLE `saledetail` (
  `id` int(11) NOT NULL,
  `idSale` varchar(12) NOT NULL,
  `itemID` int(11) NOT NULL,
  `qtySale` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `subtotal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `saledetail`
--

INSERT INTO `saledetail` (`id`, `idSale`, `itemID`, `qtySale`, `price`, `subtotal`) VALUES
(1, 'TRX0001', 1, 5, 5000, 25000),
(2, 'TRX0001', 2, 5, 1500, 7500),
(3, 'TRX0002', 2, 100, 1500, 150000),
(4, 'TRX0003', 1, 56, 5000, 280000),
(5, 'TRX0003', 2, 1, 1500, 1500),
(6, 'TRX0004', 1, 2, 5000, 10000),
(7, 'TRX0005', 2, 4, 1500, 6000),
(8, 'TRX0006', 1, 5, 5000, 25000),
(9, 'TRX0006', 2, 10, 1500, 15000),
(10, 'TRX0007', 1, 4, 5000, 20000),
(11, 'TRX0008', 1, 3, 5000, 15000),
(12, 'TRX0008', 2, 5, 1500, 7500),
(13, 'TRX0009', 1, 1, 5000, 5000),
(14, 'TRX0010', 1, 4, 5000, 20000),
(15, 'TRX0011', 1, 3, 5000, 15000),
(16, 'TRX0012', 1, 2, 5000, 10000),
(17, 'TRX0012', 6, 55, 25000, 1375000),
(18, 'TRX0013', 1, 1, 5000, 5000),
(19, 'TRX0013', 5, 5, 20000, 100000),
(20, 'TRX0013', 6, 6, 25000, 150000),
(21, 'TRX0014', 1, 1, 5000, 5000),
(22, 'TRX0015', 1, 10, 5000, 50000),
(23, 'TRX0016', 1, 3, 5000, 15000),
(24, 'TRX0017', 1, 1, 5000, 5000),
(25, 'TRX0018', 1, 2, 5000, 10000);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` varchar(20) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `role`, `created_at`) VALUES
(1, 'admin', '0192023a7bbd73250516f069df18b500', 'admin', '2025-12-23 10:08:05');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`idTrans`);

--
-- Indexes for table `purchasedetail`
--
ALTER TABLE `purchasedetail`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idTrans` (`idTrans`);

--
-- Indexes for table `sale`
--
ALTER TABLE `sale`
  ADD PRIMARY KEY (`idTrans`);

--
-- Indexes for table `saledetail`
--
ALTER TABLE `saledetail`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `purchasedetail`
--
ALTER TABLE `purchasedetail`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `saledetail`
--
ALTER TABLE `saledetail`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `purchasedetail`
--
ALTER TABLE `purchasedetail`
  ADD CONSTRAINT `purchasedetail_ibfk_1` FOREIGN KEY (`idTrans`) REFERENCES `purchase` (`idTrans`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
