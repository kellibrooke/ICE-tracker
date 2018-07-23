-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 23, 2018 at 10:54 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ice_tracker`
--
CREATE DATABASE IF NOT EXISTS `ice_tracker` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ice_tracker`;

-- --------------------------------------------------------

--
-- Table structure for table `sightings`
--

CREATE TABLE `sightings` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `description` varchar(255) NOT NULL,
  `date_time` datetime NOT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `state` varchar(255) NOT NULL,
  `zip` varchar(255) NOT NULL,
  `lat` double NOT NULL,
  `lng` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sightings`
--

INSERT INTO `sightings` (`id`, `description`, `date_time`, `address`, `city`, `state`, `zip`, `lat`, `lng`) VALUES
(1, 'test', '2018-07-24 06:00:00', '22 SW 3rd Ave', 'Portland ', 'OR', '97204', 45.5226986, -122.6731252),
(2, 'Test Description', '2018-07-12 00:00:00', '8777 Mallard Ct', 'Gearhart', 'OR', '97138', 46.0510731, -123.9172036);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `phone_number` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `sightings`
--
ALTER TABLE `sightings`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `id_2` (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `sightings`
--
ALTER TABLE `sightings`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
