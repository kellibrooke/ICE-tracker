-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 26, 2018 at 06:50 PM
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
  `type` varchar(255) NOT NULL,
  `date_time` datetime NOT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `state` varchar(255) NOT NULL,
  `lat` double NOT NULL,
  `lng` double NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sightings`
--

INSERT INTO `sightings` (`id`, `description`, `type`, `date_time`, `address`, `city`, `state`, `lat`, `lng`, `user_id`) VALUES
(14, 'Group of 5 ICE agents arresting individuals at Pioneer Courthouse Square. Do not take this MAX station.', 'Checkpoint', '2018-07-26 10:07:35', '3747 SE 11th Ave', 'Portland', 'OR', 45.4956708, -122.6549685, 7),
(15, 'Group of agents checking for papers in local business.', 'Business', '2018-07-26 10:08:38', '711 SE 11th Ave', 'Portland', 'OR', 45.5176303, -122.6549279, 7),
(16, 'Checkpoint raid occurring on bus near submitted location.', 'Checkpoint', '2018-07-26 10:09:25', '1331 NW Lovejoy', 'Portland', 'OR', 45.5302716, -122.685221, 7),
(17, 'People being detained outside of local business.', 'Business', '2018-07-26 10:10:08', '4949 SW Landing Dr', 'Portland', 'OR', 45.4878395, -122.6745653, 7),
(18, 'Large disturbance with ICE agents stopping cars', 'Checkpoint', '2018-07-26 10:11:49', '7676 N Decatur St. ', 'Portland', 'OR', 45.5832462, -122.7486, 3),
(19, 'Aggressive agents populating area, no detained people yet', 'Checkpoint', '2018-07-26 10:12:53', '1425 SE Alder St', 'Portland', 'OR', 45.5179955, -122.6509124, 3),
(20, '3 agents checking for papers', 'Checkpoint', '2018-07-26 10:13:49', '1200 SE Morrison St', 'Portland', 'OR', 45.5170276, -122.6534107, 3),
(21, 'Agents checking for papers at local business', 'Checkpoint', '2018-07-26 10:14:53', '1567 NE Burnside Rd', 'Gresham', 'OR', 45.5040353, -122.4159425, 3),
(22, 'Businesses being raided by 5 agents', 'Business', '2018-07-26 10:16:18', '17525 Stafford Rd', 'Lake Oswego', 'OR', 45.400373, -122.689381, 3),
(23, 'Businesses being raided', 'Business', '2018-07-26 10:17:05', '13000 SW 2nd St', 'Beaverton', 'OR', 45.4865695, -122.8116603, 3),
(24, 'gtdfgtgftdf', 'Checkpoint', '2018-07-26 11:12:00', '3747 SE 11th Ave', 'Portland', 'OR', 45.4956708, -122.6549685, 3),
(25, 'Hi guys', 'Checkpoint', '2018-07-26 11:47:17', '23', '32', 'WA', 47.7510741, -120.7401385, 16),
(26, 'Hi guys', 'Checkpoint', '2018-07-26 11:47:18', '23', '32', 'WA', 47.7510741, -120.7401385, 16),
(27, 'Hi guys', 'Checkpoint', '2018-07-26 11:47:19', '23', '32', 'WA', 47.7510741, -120.7401385, 16);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `phone_number` varchar(10) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `phone_number`, `first_name`, `last_name`) VALUES
(1, '5039848762', 'Nikki', 'Boyd'),
(3, '5034407074', 'Ryan', 'Haha'),
(7, '4156539036', 'Kelli', 'McCloskey'),
(8, '5038631605', 'Renee', 'Sarley'),
(11, '5036798659', 'Devin', 'Mounts'),
(13, '5034407074', 'Anonymous', 'Anonymous'),
(14, '5034407074', 'Anonymous', 'Anonymous'),
(15, '5034407074', 'Anonymous', 'Anonymous');

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
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
