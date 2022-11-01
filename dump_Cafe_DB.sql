-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: cafe
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `avtorizacia`
--

DROP TABLE IF EXISTS `avtorizacia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avtorizacia` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `login` varchar(10) NOT NULL,
  `password` varchar(10) NOT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avtorizacia`
--

LOCK TABLES `avtorizacia` WRITE;
/*!40000 ALTER TABLE `avtorizacia` DISABLE KEYS */;
INSERT INTO `avtorizacia` VALUES (1,'111','111'),(2,'333','333');
/*!40000 ALTER TABLE `avtorizacia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `list_ord`
--

DROP TABLE IF EXISTS `list_ord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `list_ord` (
  `id_order` int DEFAULT NULL,
  `id_menu` int DEFAULT NULL,
  `amount` int DEFAULT NULL,
  `sum` double(7,2) DEFAULT NULL,
  KEY `fk_list_ord_menu` (`id_menu`),
  KEY `fk_list_ord_orders` (`id_order`),
  CONSTRAINT `fk_list_ord_menu` FOREIGN KEY (`id_menu`) REFERENCES `menu` (`id_menu`),
  CONSTRAINT `fk_list_ord_orders` FOREIGN KEY (`id_order`) REFERENCES `orders` (`id_order`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `list_ord`
--

LOCK TABLES `list_ord` WRITE;
/*!40000 ALTER TABLE `list_ord` DISABLE KEYS */;
/*!40000 ALTER TABLE `list_ord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu` (
  `id_menu` int NOT NULL AUTO_INCREMENT,
  `name_menu` varchar(50) NOT NULL,
  `cost_menu` double(7,2) NOT NULL,
  `type_menu` int NOT NULL,
  PRIMARY KEY (`id_menu`),
  KEY `fk_menu_types` (`type_menu`),
  CONSTRAINT `fk_menu_types` FOREIGN KEY (`type_menu`) REFERENCES `types` (`id_type`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,'Гнездо глухаря 150 гр.',80.00,1),(2,'Сельдь под шубой 200 гр.',75.00,1),(3,'Оливье 200 гр.',80.00,1),(4,'Винегрет овощной 200 гр.',45.00,1),(5,'Нежность 150 гр.',80.00,1),(6,'Чафан 180 гр.',85.00,1),(7,'Суп лапша куриная 500гр.',100.00,2),(8,'Борщ со сметаной 500 гр.',100.00,2),(9,'Рассольник 500 гр.',100.00,2),(10,'Солянка сборная мясная 500 гр.',110.00,2),(11,'Уха \"Царская\" 500 гр.',100.00,2),(12,'Суп грибной с гренками 500 гр.',105.00,2),(13,'Шницель из куриной грудки 100гр.',100.00,3),(14,'Котлеты по-домашнему 100 гр.',90.00,3),(15,'Плов из курицы 300 гр.',100.00,3),(16,'Минтай жареный 500 гр.',110.00,3),(17,'Эскалоп 100 гр.',100.00,3),(18,'Тефтели 100 гр.',105.00,3),(19,'Курица отварная 100 гр.',95.00,3),(20,'Голубцы 100 гр.',105.00,3),(21,'Картофельное пюре 150гр.',90.00,4),(22,'Гречневая каша с маслом 150 гр.',90.00,4),(23,'Макароны отварные 150 гр.',80.00,4),(24,'Рис отварной с вощами 150 гр.',80.00,4),(25,'Картофель фри 150 гр.',110.00,4),(26,'Молочный коктейль 300 мл',110.00,5),(27,'Вафельные трубочки 100 гр.',110.00,5),(28,'Блинчики со сметаной 100 гр.',90.00,5),(29,'Блинчики с джемом 100 гр.',90.00,5),(30,'Блинчики со сгущеным молоком 100 гр.',90.00,5),(31,'Оладьи со сметаной 100 гр.',90.00,5),(32,'Оладьи с джемом 100 гр.',90.00,5),(33,'Оладьи со сгущеным молоком 100 гр.',90.00,5),(34,'Штрудель с яблоками 10 гр.',110.00,5),(35,'Сырники со сметаной 100 гр.',90.00,5),(36,'Сырники с джемом 100 гр.',90.00,5),(37,'Сырники со сгущеным молоком 100 гр.',90.00,5),(38,'Чай черный с сахаром 200 мл',30.00,6),(39,'Чай черный с сахаром и лимоном 200 мл',35.00,6),(40,'Чай зеленый 200 мл',30.00,6),(41,'Кофе Эспрессо 150 мл',80.00,6),(42,'Кофе Американо 150 мл',80.00,6),(43,'Кофе Капучино 150 мл',80.00,6),(44,'Сок яблочный 200 мл',60.00,6),(45,'Сок мультифруктовый 200 мл',60.00,6),(46,'Сок персиковый 200 мл',60.00,6),(47,'Компот 200 мл',60.00,6),(48,'Морс брусничный 200 мл',60.00,6),(49,'Морс клюквенный 200 мл',60.00,6),(50,'Кисель ягодный 200 мл',45.00,6),(51,'Соус сметанный 50 гр.',50.00,7),(52,'Горчица русская 20 гр.',30.00,7),(53,'Томатный соус 50 гр.',50.00,7),(54,'Соус Тар-тар 50 гр.',50.00,7),(55,'Майонез домашний 30 гр.',30.00,7);
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `id_order` int NOT NULL AUTO_INCREMENT,
  `total_order` double(7,2) NOT NULL,
  `worker_order` int NOT NULL,
  `date_order` date NOT NULL,
  PRIMARY KEY (`id_order`),
  KEY `fk_orders_workers` (`worker_order`),
  CONSTRAINT `fk_orders_workers` FOREIGN KEY (`worker_order`) REFERENCES `workers` (`id_worker`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (7,550.00,2,'2022-10-31'),(8,370.00,2,'2022-10-31'),(9,420.00,2,'2022-10-31'),(10,830.00,6,'2022-11-01'),(11,750.00,6,'2022-11-01'),(12,680.00,6,'2022-11-01'),(13,150.00,1,'2022-11-02'),(14,620.00,1,'2022-11-02'),(15,90.00,1,'2022-11-02'),(16,595.00,2,'2022-11-02');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `id_position` int NOT NULL AUTO_INCREMENT,
  `name_position` varchar(20) NOT NULL,
  PRIMARY KEY (`id_position`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'Директор'),(2,'Бармен'),(3,'Шеф-повар'),(4,'Повар'),(5,'Кондитер'),(6,'Официант'),(7,'Помощник повара');
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `types`
--

DROP TABLE IF EXISTS `types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `types` (
  `id_type` int NOT NULL AUTO_INCREMENT,
  `name_type` varchar(20) NOT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `types`
--

LOCK TABLES `types` WRITE;
/*!40000 ALTER TABLE `types` DISABLE KEYS */;
INSERT INTO `types` VALUES (1,'Салаты'),(2,'Супы'),(3,'Вторые блюда'),(4,'Гарнир'),(5,'Десерты'),(6,'Напитки'),(7,'Соусы');
/*!40000 ALTER TABLE `types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workers`
--

DROP TABLE IF EXISTS `workers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workers` (
  `id_worker` int NOT NULL AUTO_INCREMENT,
  `fio_worker` varchar(100) NOT NULL,
  `position_worker` int NOT NULL,
  PRIMARY KEY (`id_worker`),
  KEY `fk_workers_positions` (`position_worker`),
  CONSTRAINT `fk_workers_positions` FOREIGN KEY (`position_worker`) REFERENCES `positions` (`id_position`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workers`
--

LOCK TABLES `workers` WRITE;
/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
INSERT INTO `workers` VALUES (1,'Громова Алиса Фёдоровна',1),(2,'Миронов Андрей Юрьевич',2),(3,'Белов Тимур Алексеевич',3),(4,'Белова Анна Павловна',4),(5,'Волкова Ольга Викторовна',5),(6,'Спицына Любовь Ивановна',6),(7,'Орлова Елена Алексеевна',6),(8,'Фролова София Артёмовна',7);
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-02  4:12:47
