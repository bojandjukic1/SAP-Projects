CREATE DATABASE  IF NOT EXISTS `rfid_db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `rfid_db`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: rfid_db
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `feedback`
--

DROP TABLE IF EXISTS `feedback`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `feedback` (
  `feedbackID` int(11) NOT NULL,
  `feedbackQ` int(11) DEFAULT NULL,
  `feedbackAnswer` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`feedbackID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedback`
--

LOCK TABLES `feedback` WRITE;
/*!40000 ALTER TABLE `feedback` DISABLE KEYS */;
INSERT INTO `feedback` VALUES (0,0,'Welcome-Screen'),(1,1,'Gut'),(2,2,'Nein'),(3,3,'Gut'),(4,4,'Ja'),(5,0,'Digital Boardroom'),(6,1,'Gut'),(7,2,'Nein'),(8,3,'Gut'),(9,4,'Nein'),(10,0,'NetAtmo'),(11,1,'Schlecht'),(12,2,'Ja'),(13,3,'Schlecht'),(14,4,'Ja'),(15,0,'55 Zoll-Tisch'),(16,1,'Nichts besonderes'),(17,2,'Nein'),(18,3,'Gut'),(19,4,'Nein'),(20,0,'55 Zoll-Tisch'),(21,1,'Schlecht'),(22,2,'Ja'),(23,3,'Schlecht'),(24,4,'Ja'),(25,0,'55 Zoll-Tisch'),(26,1,'Schlecht'),(27,2,'Ja'),(28,3,'Schlecht'),(29,4,'Nein'),(30,0,'55 Zoll-Tisch'),(31,1,'Nichts besonderes'),(32,2,'Nein'),(33,3,'Schlecht'),(34,4,'Nein'),(35,0,'55 Zoll-Tisch'),(36,1,'Nichts besonderes'),(37,2,'Nein'),(38,3,'Schlecht'),(39,4,'Nein'),(40,0,'55 Zoll-Tisch'),(41,1,'Schlecht'),(42,2,'Ja'),(43,3,'Schlecht'),(44,4,'Nein'),(45,0,'Welcome-Screen'),(46,1,'Schlecht'),(47,2,'Nein'),(48,3,'Schlecht'),(49,4,'Ja'),(50,0,'55 Zoll-Tisch'),(51,1,'Nichts besonderes'),(52,2,'Nein'),(53,3,'Schlecht'),(54,4,'Nein'),(55,0,'55 Zoll-Tisch'),(56,1,'Nichts besonderes'),(57,2,'Nein'),(58,3,'Schlecht'),(59,4,'Nein'),(60,0,'55 Zoll-Tisch'),(61,1,'Schlecht'),(62,2,'Nein'),(63,3,'Schlecht'),(64,4,'Nein'),(65,0,'55 Zoll-Tisch'),(66,1,'Nichts besonderes'),(67,2,'Nein'),(68,3,'Schlecht'),(69,4,'Nein'),(70,0,'55 Zoll-Tisch'),(71,1,'Nichts besonderes'),(72,2,'Nein'),(73,3,'Schlecht'),(74,4,'Nein'),(75,0,'55 Zoll-Tisch'),(76,1,'Nichts besonderes'),(77,2,'Nein'),(78,3,'Schlecht'),(79,4,'Nein'),(80,0,'55 Zoll-Tisch'),(81,1,'Schlecht'),(82,2,'Ja'),(83,3,'Gut'),(84,4,'Nein'),(85,0,'55 Zoll-Tisch'),(86,1,'Gut'),(87,2,'Nein'),(88,3,'Schlecht'),(89,4,'Nein'),(90,0,'55 Zoll-Tisch'),(91,1,'Nichts besonderes'),(92,2,'Nein'),(93,3,'Schlecht'),(94,4,'Nein'),(95,0,'55 Zoll-Tisch'),(96,1,'Nichts besonderes'),(97,2,'Nein'),(98,3,'Schlecht'),(99,4,'Nein'),(100,0,'55 Zoll-Tisch'),(101,1,'Nichts besonderes'),(102,2,'Nein'),(103,3,'Schlecht'),(104,4,'Nein'),(105,0,'55 Zoll-Tisch'),(106,1,'Nichts besonderes'),(107,2,'Nein'),(108,3,'Schlecht'),(109,4,'Nein'),(110,0,'55 Zoll-Tisch'),(111,1,'Nichts besonderes'),(112,2,'Nein'),(113,3,'Schlecht'),(114,4,'Nein'),(115,0,'55 Zoll-Tisch'),(116,1,'Nichts besonderes'),(117,2,'Nein'),(118,3,'Schlecht'),(119,4,'Nein'),(120,0,'55 Zoll-Tisch'),(121,1,'Nichts besonderes'),(122,2,'Nein'),(123,3,'Schlecht'),(124,4,'Nein'),(125,0,'55 Zoll-Tisch'),(126,1,'Nichts besonderes'),(127,2,'Nein'),(128,3,'Schlecht'),(129,4,'Nein'),(130,0,'55 Zoll-Tisch'),(131,1,'Nichts besonderes'),(132,2,'Nein'),(133,3,'Schlecht'),(134,4,'Nein'),(135,0,'Welcome-Screen'),(136,1,'Schlecht'),(137,2,'Nein'),(138,3,'Schlecht'),(139,4,'Nein'),(140,0,'Welcome-Screen'),(141,1,'Gut'),(142,2,'Ja'),(143,3,'Gut'),(144,4,'Nein'),(145,0,'55 Zoll-Tisch'),(146,1,'Nichts besonderes'),(147,2,'Nein'),(148,3,'Schlecht'),(149,4,'Nein'),(150,0,'Welcome-Screen'),(151,1,'Schlecht'),(152,2,'Nein'),(153,3,'Schlecht'),(154,4,'Nein'),(155,0,'55 Zoll-Tisch'),(156,1,'Nichts besonderes'),(157,2,'Nein'),(158,3,'Schlecht'),(159,4,'Nein'),(160,0,'Welcome-Screen'),(161,1,'Schlecht'),(162,2,'Nein'),(163,3,'Schlecht'),(164,4,'Nein'),(165,0,'55 Zoll-Tisch'),(166,1,'Nichts besonderes'),(167,2,'Nein'),(168,3,'Schlecht'),(169,4,'Nein'),(170,0,'55 Zoll-Tisch'),(171,1,'Nichts besonderes'),(172,2,'Nein'),(173,3,'Schlecht'),(174,4,'Nein'),(175,0,'55 Zoll-Tisch'),(176,1,'Nichts besonderes'),(177,2,'Ja'),(178,3,'Schlecht'),(179,4,'Nein'),(180,0,'55 Zoll-Tisch'),(181,1,'Nichts besonderes'),(182,2,'Nein'),(183,3,'Schlecht'),(184,4,'Nein'),(185,0,'55 Zoll-Tisch'),(186,1,'Nichts besonderes'),(187,2,'Nein'),(188,3,'Schlecht'),(189,4,'Nein'),(190,0,'55 Zoll-Tisch'),(191,1,'Nichts besonderes'),(192,2,'Nein'),(193,3,'Schlecht'),(194,4,'Nein'),(195,0,'55 Zoll-Tisch'),(196,1,'Nichts besonderes'),(197,2,'Nein'),(198,3,'Schlecht'),(199,4,'Nein'),(200,0,'Welcome-Screen'),(201,1,'Sehr schlecht'),(202,2,'Ja'),(203,3,'Schlecht'),(204,4,'Ja'),(205,0,'55 Zoll-Tisch'),(206,1,'Nichts besonderes'),(207,2,'Nein'),(208,3,'Schlecht'),(209,4,'Nein'),(210,0,'Digital Boardroom'),(211,1,'Schlecht'),(212,2,'Nein'),(213,3,'Schlecht'),(214,4,'Nein'),(215,0,'55 Zoll-Tisch'),(216,1,'Nichts besonderes'),(217,2,'Nein'),(218,3,'Schlecht'),(219,4,'Nein'),(220,0,'Digital Boardroom'),(221,1,'Nichts besonderes'),(222,2,'Nein'),(223,3,'Schlecht'),(224,4,'Nein');
/*!40000 ALTER TABLE `feedback` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-26 10:45:47
