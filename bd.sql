--
--  Project: SADEGEL STOCK
--  
--  Author: Adrià Alberich Jaume (info@webvers.net / alberichjaumeadria@gmail.com)
--

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+02:00";

--
-- Database: `SADEGEL_STOCK`
--

CREATE DATABASE IF NOT EXISTS SADEGEL_STOCK;

-- --------------------------------------------------------

USE SADEGEL_STOCK;

--
-- SADEGEL_STOCK_COUNTRY table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_COUNTRY` (
  `isoCode` varchar(10) NOT NULL,
  `countryName` varchar(32) NOT NULL,
  PRIMARY KEY (`isoCode`),
  UNIQUE (`countryName`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_SHOP table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_SHOP` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `shopName` varchar(32) NOT NULL,
  `type` ENUM ('owned','franchise','international') NOT NULL COMMENT 'The shop type',
  `address` text COMMENT 'JSON string',
  `tpv` varchar(32) NOT NULL COMMENT 'The TPV identifier',
  `countryIsoCode` varchar(10) NOT NULL COMMENT 'Country identifier',
  `createdAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `isDeleted` bit NOT NULL DEFAULT b'0',
  PRIMARY KEY (`id`),
  FOREIGN KEY (`countryIsoCode`) REFERENCES SADEGEL_STOCK_COUNTRY(isoCode)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_PRODUCT_CATEGORY table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_PRODUCT_CATEGORY` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(32) NOT NULL,
  `createdAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `isDeleted` bit NOT NULL DEFAULT b'0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_PRODUCT table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_PRODUCT` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `productName` varchar(64) NOT NULL,
  `type` ENUM ('raw','manufactured','consumable') NOT NULL COMMENT 'The product type',
  `weight` float NOT NULL COMMENT 'Weight of 1 unit of product',
  `baseunit` ENUM ('g', 'kg', 'l', 'ml') COMMENT 'Measurement unit',
  `categoryName` varchar(32) COMMENT 'The category identifier',
  `isIcecream` bit NOT NULL DEFAULT b'0',
  `createdAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `isDeleted` bit NOT NULL DEFAULT b'0',
  PRIMARY KEY (`id`),
  UNIQUE (`productName`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_SHOP_INVENTORY table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_SHOP_INVENTORY` (
  `shopId` int(11) NOT NULL,
  `productId` int(11) NOT NULL,
  `amount` float NOT NULL,
  PRIMARY KEY (`shopId`,`productId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_SHOP_PRODUCTION table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_SHOP_PRODUCTION` (
  `shopId` int(11) NOT NULL,
  `manufacturedProductId` int(11) NOT NULL,
  `quantity` float NOT NULL,
  `producedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`shopId`,`manufacturedProductId`,`producedAt`),
  FOREIGN KEY (`shopId`) REFERENCES SADEGEL_STOCK_SHOP(id),
  FOREIGN KEY (`manufacturedProductId`) REFERENCES SADEGEL_STOCK_PRODUCT(id)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_PRODUCT_INGREDIENT table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_PRODUCT_INGREDIENT` (
  `ingredientProductId` int(11) NOT NULL,
  `manufacturedProductId` int(11) NOT NULL,
  `ingredientQuantity` float NOT NULL,
  `unit` bit NOT NULL,
  PRIMARY KEY (`ingredientProductId`,`manufacturedProductId`),
  FOREIGN KEY (`ingredientProductId`) REFERENCES SADEGEL_STOCK_PRODUCT(id),
  FOREIGN KEY (`manufacturedProductId`) REFERENCES SADEGEL_STOCK_PRODUCT(id)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_PRODUCT_IDENTIFIER table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_PRODUCT_IDENTIFIER` (
  `productId` int(11) NOT NULL,
  `identifier` varchar(64) NOT NULL,
  PRIMARY KEY (`identifier`),
  FOREIGN KEY (`productId`) REFERENCES SADEGEL_STOCK_PRODUCT(id)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_PROVIDER table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_PROVIDER` (
  `providerName` varchar(32) NOT NULL,
  `id` varchar(32) NOT NULL COMMENT 'NIF or CIF',
  `email` varchar(64) COMMENT 'NIF or CIF',
  `phone` varchar(64) COMMENT 'NIF or CIF',
  `address` text COMMENT 'JSON string',
  `countryIsoCode` varchar(10) NOT NULL COMMENT 'Country identifier',
  `createdAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `isDeleted` bit NOT NULL DEFAULT b'0',
  PRIMARY KEY (`providerName`),
  UNIQUE (`id`),
  FOREIGN KEY (`countryIsoCode`) REFERENCES SADEGEL_STOCK_COUNTRY(isoCode)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_PRODUCT_PROVIDER table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_PRODUCT_PROVIDER` (
  `productId` int(11) NOT NULL,
  `providerName` varchar(32) NOT NULL,
  `price` float NOT NULL,
  `currency` ENUM ('EUR', 'USD') NOT NULL,
  PRIMARY KEY (`productId`,`providerName`),
  FOREIGN KEY (`providerName`) REFERENCES SADEGEL_STOCK_PROVIDER(providerName),
  FOREIGN KEY (`productId`) REFERENCES SADEGEL_STOCK_PRODUCT(id)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_ROLE table scheme (INCOMPLETE)
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_ROLE` (
  `roleName` varchar(32) NOT NULL,
  `isAdmin` bit NOT NULL DEFAULT b'0',
  `createdAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `isDeleted` bit NOT NULL DEFAULT b'0',
  PRIMARY KEY (`roleName`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_USER table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_USER` (
  `userName` varchar(32) NOT NULL,
  `realName` varchar(32),
  `surname` varchar(64),
  `position` varchar(32),
  `roleName` varchar(32),
  `password` varchar(64),
  `createdAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `isDeleted` bit NOT NULL DEFAULT b'0',
  PRIMARY KEY (`userName`),
  FOREIGN KEY (`roleName`) REFERENCES SADEGEL_STOCK_ROLE(roleName)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_EVENTLOG table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_EVENTLOG` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `message` text COMMENT 'The log message' NOT NULL,
  `origin` ENUM ('core','bot','stock') NOT NULL,
  `type` varchar(32) NOT NULL,
  `pcName` varchar(32) NOT NULL,
  `userName` varchar(32) NOT NULL,
  `shopId` int(11) NOT NULL DEFAULT '-1',
  `productId` int(11) NOT NULL DEFAULT '-1',
  `quantity` float NOT NULL DEFAULT '0',
  `relatedWith` int(11) NOT NULL DEFAULT '-1',
  `logDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- SADEGEL_STOCK_SETTINGS table scheme
--

CREATE TABLE IF NOT EXISTS `SADEGEL_STOCK_SETTINGS` (
  `key` varchar(32) NOT NULL,
  `value` text,
  PRIMARY KEY (`key`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

INSERT INTO SADEGEL_STOCK_SETTINGS VALUES ('use_of_stock','No');

-- --------------------------------------------------------