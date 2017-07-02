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
-- Table structure for table `feedbackqs`
--

DROP TABLE IF EXISTS `feedbackqs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `feedbackqs` (
  `questionID` int(11) NOT NULL,
  `yOrNo` int(11) NOT NULL,
  `question` varchar(300) DEFAULT NULL,
  `optionA` varchar(300) DEFAULT NULL,
  `optionB` varchar(300) DEFAULT NULL,
  `optionC` varchar(300) DEFAULT NULL,
  `optionD` varchar(300) DEFAULT NULL,
  `optionE` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`questionID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedbackqs`
--

LOCK TABLES `feedbackqs` WRITE;
/*!40000 ALTER TABLE `feedbackqs` DISABLE KEYS */;
INSERT INTO `feedbackqs` VALUES (0,0,'Welches Feature im Airstream hat Ihnen am besten gefallen?','Alexa','NetAtmo','55 Zoll-Tisch','Welcome-Screen','Digital Boardroom'),(1,0,'Wie war Ihr Gesamteindruck?','Sehr gut','Gut','Nichts besonderes','Schlecht','Sehr schlecht'),(2,1,'Hat die Kaffeebestellung mit Alexa funktioniert?','null','Ja','null','Nein','null'),(3,0,'Wie gut hat der Touchscreen vom TouchTable funktioniert?','Sehr gut','Gut','Nichts besonderes','Schlecht','Sehr schlecht'),(4,1,'Hat die RFID-Erkennung einwandfrei funktioniert?','`','Ja','null','Nein','null');
/*!40000 ALTER TABLE `feedbackqs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-26 10:45:46
