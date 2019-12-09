-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: tallerf
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `beneficiario`
--

DROP TABLE IF EXISTS `beneficiario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `beneficiario` (
  `IDBeneficiario` int(11) NOT NULL AUTO_INCREMENT,
  `IDContrato` int(11) DEFAULT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `DNIBeneficiario` int(11) NOT NULL,
  `Mail` varchar(45) NOT NULL,
  `CUIL` int(11) NOT NULL,
  `Escolaridad` varchar(45) NOT NULL,
  PRIMARY KEY (`IDBeneficiario`),
  KEY `IDContrato` (`IDContrato`),
  CONSTRAINT `IDContrato` FOREIGN KEY (`IDContrato`) REFERENCES `contrato` (`IDContrato`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `beneficiario`
--

LOCK TABLES `beneficiario` WRITE;
/*!40000 ALTER TABLE `beneficiario` DISABLE KEYS */;
INSERT INTO `beneficiario` VALUES (2,NULL,'Gabriel','Ramos Santana',33444555,'asd@live.com',334445557,'Secundario'),(3,NULL,'Juan Pablo','Parrilla',44555666,'dsa@live.com',445553667,'Universitario');
/*!40000 ALTER TABLE `beneficiario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contrato`
--

DROP TABLE IF EXISTS `contrato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contrato` (
  `IDContrato` int(11) NOT NULL AUTO_INCREMENT,
  `FechaInicio` datetime NOT NULL,
  `FechaFin` datetime NOT NULL,
  `Cargo` varchar(45) NOT NULL,
  `Empresa` varchar(45) NOT NULL,
  PRIMARY KEY (`IDContrato`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contrato`
--

LOCK TABLES `contrato` WRITE;
/*!40000 ALTER TABLE `contrato` DISABLE KEYS */;
INSERT INTO `contrato` VALUES (3,'2019-11-24 00:00:00','2019-12-23 00:00:00','Secretaria','Anses'),(6,'2019-12-14 00:00:00','2020-01-11 00:00:00','Conserje','EMI');
/*!40000 ALTER TABLE `contrato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cursados`
--

DROP TABLE IF EXISTS `cursados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cursados` (
  `ID_Beneficiario` int(11) NOT NULL,
  `ID_CursosC` int(11) NOT NULL,
  PRIMARY KEY (`ID_Beneficiario`,`ID_CursosC`),
  KEY `ID_CursoC_idx` (`ID_CursosC`),
  CONSTRAINT `ID_Beneficiario` FOREIGN KEY (`ID_Beneficiario`) REFERENCES `beneficiario` (`IDBeneficiario`),
  CONSTRAINT `ID_CursoC` FOREIGN KEY (`ID_CursosC`) REFERENCES `cursos` (`IDCurso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cursados`
--

LOCK TABLES `cursados` WRITE;
/*!40000 ALTER TABLE `cursados` DISABLE KEYS */;
INSERT INTO `cursados` VALUES (2,8);
/*!40000 ALTER TABLE `cursados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cursos`
--

DROP TABLE IF EXISTS `cursos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cursos` (
  `IDCurso` int(11) NOT NULL AUTO_INCREMENT,
  `NombreC` varchar(45) NOT NULL,
  `Tematica` varchar(100) NOT NULL,
  PRIMARY KEY (`IDCurso`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cursos`
--

LOCK TABLES `cursos` WRITE;
/*!40000 ALTER TABLE `cursos` DISABLE KEYS */;
INSERT INTO `cursos` VALUES (1,'Laboratorio II','Base de datos - PHP'),(4,'Algebra','Matrices'),(8,'Arquitectura','Leyes de Morgan'),(9,'Fisica','MRU - MRUV');
/*!40000 ALTER TABLE `cursos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dictado`
--

DROP TABLE IF EXISTS `dictado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dictado` (
  `IDDictado` int(11) NOT NULL AUTO_INCREMENT,
  `IDInstructor` int(11) NOT NULL,
  `IDTutor` int(11) NOT NULL,
  `FechaD` date NOT NULL,
  `Objetivos` varchar(300) NOT NULL,
  `ID_Curso` int(11) NOT NULL,
  PRIMARY KEY (`IDDictado`,`IDInstructor`,`IDTutor`),
  KEY `IDInstructor` (`IDInstructor`),
  KEY `IDTutor` (`IDTutor`),
  KEY `ID_Curso_idx` (`ID_Curso`),
  CONSTRAINT `IDInstructor` FOREIGN KEY (`IDInstructor`) REFERENCES `instructor` (`IDInstructor`),
  CONSTRAINT `IDTutor` FOREIGN KEY (`IDTutor`) REFERENCES `tutor` (`IDTutor`),
  CONSTRAINT `ID_Curso` FOREIGN KEY (`ID_Curso`) REFERENCES `cursos` (`IDCurso`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dictado`
--

LOCK TABLES `dictado` WRITE;
/*!40000 ALTER TABLE `dictado` DISABLE KEYS */;
INSERT INTO `dictado` VALUES (1,3,7,'2019-12-07','Repaso General',8),(2,2,3,'2019-12-22','Nuevo Proyecto',1),(3,3,2,'2019-12-15','Recuperacion',1),(4,3,2,'2019-12-22','Pre Examen',4),(7,1,11,'2019-12-21','La Ultima',4);
/*!40000 ALTER TABLE `dictado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instructor`
--

DROP TABLE IF EXISTS `instructor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instructor` (
  `IDInstructor` int(11) NOT NULL AUTO_INCREMENT,
  `DNII` int(11) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Reparticion` varchar(45) NOT NULL,
  PRIMARY KEY (`IDInstructor`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instructor`
--

LOCK TABLES `instructor` WRITE;
/*!40000 ALTER TABLE `instructor` DISABLE KEYS */;
INSERT INTO `instructor` VALUES (1,33333555,'Martin','Quintana','Prueba Instruc'),(2,33333555,'Martin','Quintana','Prueba Instruc'),(3,33333555,'Martin','Quintana','Prueba Instruc'),(5,44555665,'Francisco','Godoy','Yerba Buena');
/*!40000 ALTER TABLE `instructor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logueo`
--

DROP TABLE IF EXISTS `logueo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logueo` (
  `user` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  PRIMARY KEY (`user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logueo`
--

LOCK TABLES `logueo` WRITE;
/*!40000 ALTER TABLE `logueo` DISABLE KEYS */;
INSERT INTO `logueo` VALUES ('asd','123');
/*!40000 ALTER TABLE `logueo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tutor`
--

DROP TABLE IF EXISTS `tutor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tutor` (
  `IDTutor` int(11) NOT NULL AUTO_INCREMENT,
  `DNIT` int(11) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Reparticion` varchar(45) NOT NULL,
  PRIMARY KEY (`IDTutor`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tutor`
--

LOCK TABLES `tutor` WRITE;
/*!40000 ALTER TABLE `tutor` DISABLE KEYS */;
INSERT INTO `tutor` VALUES (1,123,'Sergio','Lopez','Prueba4'),(2,1234,'Sergio','Sanchez','San Miguel de Tucuman'),(3,123,'Sergio','Lopez','Prueba4'),(4,123,'Sergio','Lopez','Prueba4'),(5,123,'Sergio','Lopez','Prueba4'),(6,123,'Sergio','Lopez','Prueba4'),(7,123,'Sergio','Lopez','Prueba4'),(9,33444555,'Gabriel','Ramos','Banda del Rio Sali'),(11,65544888,'Jose','Diaz','Banda del Rio Sali');
/*!40000 ALTER TABLE `tutor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-04 14:29:24
