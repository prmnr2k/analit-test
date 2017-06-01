-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Июн 01 2017 г., 12:56
-- Версия сервера: 10.1.21-MariaDB
-- Версия PHP: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `analitform`
--

-- --------------------------------------------------------

--
-- Структура таблицы `t_check`
--

CREATE TABLE `t_check` (
  `id` varchar(120) NOT NULL,
  `datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `t_check`
--

INSERT INTO `t_check` (`id`, `datetime`) VALUES
('0aa0349a-4e8b-4750-af5e-10c7db7d016c', '2017-05-31 18:59:29'),
('73215db6-5096-4b7c-a4f8-87987b04bc03', '2017-05-31 19:02:18');

-- --------------------------------------------------------

--
-- Структура таблицы `t_check_list`
--

CREATE TABLE `t_check_list` (
  `id_check` varchar(120) NOT NULL,
  `id_product` varchar(120) NOT NULL,
  `count` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `t_check_list`
--

INSERT INTO `t_check_list` (`id_check`, `id_product`, `count`) VALUES
('0aa0349a-4e8b-4750-af5e-10c7db7d016c', '1', 1),
('0aa0349a-4e8b-4750-af5e-10c7db7d016c', '3', 2),
('0aa0349a-4e8b-4750-af5e-10c7db7d016c', '4', 4),
('0aa0349a-4e8b-4750-af5e-10c7db7d016c', '6', 1),
('0aa0349a-4e8b-4750-af5e-10c7db7d016c', '7', 1),
('73215db6-5096-4b7c-a4f8-87987b04bc03', '1', 1),
('73215db6-5096-4b7c-a4f8-87987b04bc03', '3', 2),
('73215db6-5096-4b7c-a4f8-87987b04bc03', '4', 4),
('73215db6-5096-4b7c-a4f8-87987b04bc03', '6', 1),
('73215db6-5096-4b7c-a4f8-87987b04bc03', '1', 23);

-- --------------------------------------------------------

--
-- Структура таблицы `t_product`
--

CREATE TABLE `t_product` (
  `product_id` varchar(120) NOT NULL DEFAULT 'Rand(120)',
  `product_name` varchar(120) NOT NULL,
  `price` double NOT NULL,
  `stock_count` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `t_product`
--

INSERT INTO `t_product` (`product_id`, `product_name`, `price`, `stock_count`) VALUES
('1', 'Мороженое детское', 30, 1),
('2', 'Пельмени', 100, 10),
('3', 'Печенье', 30, 6),
('4', 'Конфеты', 45, 7),
('5', 'Кофе', 59.99, 20),
('6', 'Чай', 50.5, 9),
('7', 'Корова', 999.99, 0);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `t_check`
--
ALTER TABLE `t_check`
  ADD UNIQUE KEY `id` (`id`);

--
-- Индексы таблицы `t_product`
--
ALTER TABLE `t_product`
  ADD PRIMARY KEY (`product_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
