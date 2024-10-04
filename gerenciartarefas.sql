-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Oct 04, 2024 at 12:06 PM
-- Server version: 5.7.11
-- PHP Version: 7.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gerenciartarefas`
--
CREATE DATABASE IF NOT EXISTS `gerenciartarefas` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `gerenciartarefas`;

-- --------------------------------------------------------

--
-- Table structure for table `tarefas`
--

DROP TABLE IF EXISTS `tarefas`;
CREATE TABLE IF NOT EXISTS `tarefas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Tarefa` varchar(300) NOT NULL,
  `Concluido` varchar(3) DEFAULT NULL,
  `data` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

--
-- Truncate table before insert `tarefas`
--

TRUNCATE TABLE `tarefas`;
--
-- Dumping data for table `tarefas`
--

INSERT DELAYED IGNORE INTO `tarefas` (`id`, `Tarefa`, `Concluido`, `data`) VALUES
(4, 'iuuu', 'sim', '2024-11-06'),
(5, 'eba', NULL, '23/10/2024'),
(7, 'Guardar o carregador', NULL, '02/10/2024'),
(8, 'aaa', NULL, '17/10/2024'),
(9, 'aaaaaaaaa', NULL, '22/10/2024'),
(10, 'aaaaaaaaaaa', NULL, '29/10/2024'),
(11, 'aaaaaaaaa', NULL, '07/10/2024'),
(12, 'aaaaaaaaaaaa', NULL, '31/10/2024'),
(13, 'asadsadd', NULL, '03/10/2024');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
