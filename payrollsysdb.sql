-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 12, 2024 at 12:12 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `payrollsysdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `empattendance`
--

CREATE TABLE `empattendance` (
  `empID` int(20) NOT NULL,
  `timeIN` datetime DEFAULT NULL,
  `timeOUT` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `empdata`
--

CREATE TABLE `empdata` (
  `empID` int(20) NOT NULL,
  `empFirstName` varchar(255) DEFAULT NULL,
  `empLastName` varchar(255) DEFAULT NULL,
  `empMiddleName` varchar(255) DEFAULT NULL,
  `empAdd` varchar(255) DEFAULT NULL,
  `empCon` int(20) DEFAULT NULL,
  `empStat` text DEFAULT NULL,
  `empPlaceb` varchar(255) DEFAULT NULL,
  `empGen` text DEFAULT NULL,
  `empBirth` date DEFAULT NULL,
  `empAge` int(99) DEFAULT NULL,
  `empEmerg` int(20) DEFAULT NULL,
  `empDailyRate` decimal(65,30) DEFAULT NULL,
  `empPos` varchar(255) DEFAULT NULL,
  `empHire` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `emplog`
--

CREATE TABLE `emplog` (
  `empName` varchar(255) DEFAULT NULL,
  `empPass` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `emplog`
--

INSERT INTO `emplog` (`empName`, `empPass`) VALUES
('user', 'user');

-- --------------------------------------------------------

--
-- Table structure for table `emppay`
--

CREATE TABLE `emppay` (
  `empID` int(20) NOT NULL,
  `pay` varchar(255) NOT NULL,
  `workDay` int(31) NOT NULL,
  `payRate` int(11) NOT NULL,
  `rateWage` varchar(255) NOT NULL,
  `overtimeHour` double(65,30) DEFAULT NULL,
  `overtimeRegular` double(65,30) DEFAULT NULL,
  `holidayDaily` double(65,30) DEFAULT NULL,
  `holidayPay` double(65,30) DEFAULT NULL,
  `grossInc` double(65,30) DEFAULT NULL,
  `netInc` double(65,30) DEFAULT NULL,
  `deducPagibig` double(65,30) DEFAULT NULL,
  `deducPhillhealth` double(65,30) DEFAULT NULL,
  `deducSSS` double(65,30) DEFAULT NULL,
  `deducLate` int(11) DEFAULT NULL,
  `deducAbsent` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `empattendance`
--
ALTER TABLE `empattendance`
  ADD KEY `empID` (`empID`);

--
-- Indexes for table `empdata`
--
ALTER TABLE `empdata`
  ADD PRIMARY KEY (`empID`),
  ADD KEY `empID` (`empID`);

--
-- Indexes for table `emppay`
--
ALTER TABLE `emppay`
  ADD KEY `empID` (`empID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
