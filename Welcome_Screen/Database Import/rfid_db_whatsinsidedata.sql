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
-- Table structure for table `whatsinsidedata`
--

DROP TABLE IF EXISTS `whatsinsidedata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `whatsinsidedata` (
  `dataID` int(11) NOT NULL,
  `item` varchar(200) DEFAULT NULL,
  `data` mediumtext,
  `technical_specs` mediumtext,
  `filepath` mediumtext,
  PRIMARY KEY (`dataID`),
  UNIQUE KEY `dataID_UNIQUE` (`dataID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `whatsinsidedata`
--

LOCK TABLES `whatsinsidedata` WRITE;
/*!40000 ALTER TABLE `whatsinsidedata` DISABLE KEYS */;
INSERT INTO `whatsinsidedata` VALUES (0,'Coffee Machine','Beschreibung:\r\n\r\no Bereitet Ihnen auf Wunsch Kaffee, Espresso oder heißes Wasser für Tee zu\r\no Einfache Sprachsteuerung über Amazon Alexa. Sagen sie z.B. Alexa, starte Kaffeemaschine und mache mir 1 oder 2 Kaffee / Espresso\r\n','Technische Daten:\r\n\r\no Eversys Modell Shotmaster\r\no Gewicht: 60kg\r\no 8 Farb Touchscreen\r\no Abmessungen: 713 x 280 x 600 mm (H x B x T)\r\n','default_1.jpg'),(1,'Touch Table','Beschreibung:\r\n\r\no Gemeinsames Betrachten von Präsentationen oder Dokumenten  auch wenn Sie sich gegenüber sitzen\r\n','N/A','default_1.jpg'),(2,'Digital Boardroom','Beschreibung:\r\n\r\no Stellt relevante Geschäftsinformationen Live zur Verfügung\r\no Kompetente Entscheidungen in Echtzeit treffen\r\no Ad-hoc Analysen durchführen\r\n','N/A','default_1.jpg'),(3,'Alexa','Beschreibung:\r\n\r\no	Smarte Alltags Assistentin\r\no	Beantwortet / Reagiert auf Fragen wie: \r\n    - Alexa, starte Kaffeemaschine und mache mir einen Kaffee und einen Espresso\r\n    - Alexa, wie wird das Wetter heute Abend?\r\n    - Alexa, rechne 67 Grad Fahrenheit in Celsius um\r\n    - .. und vieles mehr\r\n','Technische Daten:\r\n\r\no WLAN: 802.11 a/b/g/n\r\no Audio: 63mm Woofer und 50mm Hochtonlkautsprecher\r\no Gewicht: 1064 Gramm\r\no Abmessungen: 235 x 83,5 x 83,5 mm (H x B x T)\r\no 7 eingebaute Mikrofone\r\n','default_1.jpg'),(4,'NetAtmo','Beschreibung:\r\n\r\no Smarte Wetterstation\r\no Misst Daten wie Luftfeuchtigkeit, Temparatur und Geräuschpegel sowohl innerhalb des Airstreams als auch außerhalb  alles in Echtzeit.\r\n','Technische Daten:\r\n\r\no Abmessungen: 155 x 45 x 45 mm (H x B x T)\r\no WLAN: 802.11 b/g/n\r\no Material: Aluminum und UV beständiger Kunststoff\r\n','default_1.jpg'),(5,'DJI Mavic Pro Drohne','Beschreibung:\r\n\r\no kleine aber sehr Leistungsfähige Drohne (27 min Flugzeit, bis zu 65km/h, bis zu 7 km Reichweite\r\no 1080p Videostreaming\r\no 4K Videoaufnahme\r\no Nimmt Hindernisse auf bis zu 15m Entfernung selbst wahr\r\n','Technische Daten:\r\n\r\no Gewicht: 743 Gramm\r\no Max. Höhe: 5000m\r\no 3 Achsen Gimbal\r\no Positionsbestimmung: GPS\r\n','default_1.jpg'),(6,'Microsoft Hololens','Beschreibung:\r\n\r\no Mixed Reality Brille, die es dem Benutzer elaubt interaktive 3D Projektionen in der direkten Umgebung darzustellen\r\no Bedienung über Gesten, Sprache, Kopfbewegung und Knöpfe\r\n','Technische Daten:\r\n\r\no Betriebssystem: Windows 10\r\no CPU: Quad Core Intel Atom x5-Z8100, 1.04 GHz, Intel Airmont (14nm)\r\no RAM: 2GB\r\no Speicher: 64GB\r\n','default_1.jpg');
/*!40000 ALTER TABLE `whatsinsidedata` ENABLE KEYS */;
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
