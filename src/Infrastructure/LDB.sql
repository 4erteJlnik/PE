-- MySQL dump 10.16  Distrib 10.1.26-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: db
-- ------------------------------------------------------
-- Server version	10.1.26-MariaDB-0+deb9u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `AspNetRoleClaims`
--

DROP TABLE IF EXISTS `AspNetRoleClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoleClaims` (
  `Id` varchar(0) DEFAULT NULL,
  `RoleId` varchar(0) DEFAULT NULL,
  `ClaimType` varchar(0) DEFAULT NULL,
  `ClaimValue` varchar(0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetRoleClaims`
--

LOCK TABLES `AspNetRoleClaims` WRITE;
/*!40000 ALTER TABLE `AspNetRoleClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoleClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetRoles`
--

DROP TABLE IF EXISTS `AspNetRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoles` (
  `Id` varchar(36) DEFAULT NULL,
  `Name` varchar(9) DEFAULT NULL,
  `NormalizedName` varchar(9) DEFAULT NULL,
  `ConcurrencyStamp` varchar(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetRoles`
--

LOCK TABLES `AspNetRoles` WRITE;
/*!40000 ALTER TABLE `AspNetRoles` DISABLE KEYS */;
INSERT INTO `AspNetRoles` VALUES ('54688F85-05DD-4D2B-ADF0-3D8232E8791C','admin','ADMIN','8bd7961e-10e0-4464-b374-d6f3caf66e3c'),('90982210-0A9A-42AF-AC19-4C7452B3049D','user','USER','a0c1661d-34b3-43a6-bcbc-dc8923b62788'),('48CD671A-A080-4C4D-829F-E6F06B3198A7','moderator','MODERATOR','d1f44349-bf87-4c4b-a603-eba115d109ea');
/*!40000 ALTER TABLE `AspNetRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserClaims`
--

DROP TABLE IF EXISTS `AspNetUserClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserClaims` (
  `Id` varchar(0) DEFAULT NULL,
  `UserId` varchar(0) DEFAULT NULL,
  `ClaimType` varchar(0) DEFAULT NULL,
  `ClaimValue` varchar(0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserClaims`
--

LOCK TABLES `AspNetUserClaims` WRITE;
/*!40000 ALTER TABLE `AspNetUserClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserLogins`
--

DROP TABLE IF EXISTS `AspNetUserLogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(0) DEFAULT NULL,
  `ProviderKey` varchar(0) DEFAULT NULL,
  `ProviderDisplayName` varchar(0) DEFAULT NULL,
  `UserId` varchar(0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserLogins`
--

LOCK TABLES `AspNetUserLogins` WRITE;
/*!40000 ALTER TABLE `AspNetUserLogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserLogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserRoles`
--

DROP TABLE IF EXISTS `AspNetUserRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(36) DEFAULT NULL,
  `RoleId` varchar(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserRoles`
--

LOCK TABLES `AspNetUserRoles` WRITE;
/*!40000 ALTER TABLE `AspNetUserRoles` DISABLE KEYS */;
INSERT INTO `AspNetUserRoles` VALUES ('7C6F900F-6DF1-4BC5-8F96-373B156AF049','54688F85-05DD-4D2B-ADF0-3D8232E8791C'),('D8A3AD82-DD08-44D8-89D5-960532A71748','54688F85-05DD-4D2B-ADF0-3D8232E8791C');
/*!40000 ALTER TABLE `AspNetUserRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserTokens`
--

DROP TABLE IF EXISTS `AspNetUserTokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(0) DEFAULT NULL,
  `LoginProvider` varchar(0) DEFAULT NULL,
  `Name` varchar(0) DEFAULT NULL,
  `Value` varchar(0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserTokens`
--

LOCK TABLES `AspNetUserTokens` WRITE;
/*!40000 ALTER TABLE `AspNetUserTokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserTokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUsers`
--

DROP TABLE IF EXISTS `AspNetUsers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUsers` (
  `Id` varchar(36) DEFAULT NULL,
  `UserName` varchar(12) DEFAULT NULL,
  `NormalizedUserName` varchar(12) DEFAULT NULL,
  `Email` varchar(26) DEFAULT NULL,
  `NormalizedEmail` varchar(26) DEFAULT NULL,
  `EmailConfirmed` tinyint(4) DEFAULT NULL,
  `PasswordHash` varchar(84) DEFAULT NULL,
  `SecurityStamp` varchar(32) DEFAULT NULL,
  `ConcurrencyStamp` varchar(36) DEFAULT NULL,
  `PhoneNumber` varchar(0) DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(4) DEFAULT NULL,
  `TwoFactorEnabled` tinyint(4) DEFAULT NULL,
  `LockoutEnd` varchar(0) DEFAULT NULL,
  `LockoutEnabled` tinyint(4) DEFAULT NULL,
  `AccessFailedCount` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUsers`
--

LOCK TABLES `AspNetUsers` WRITE;
/*!40000 ALTER TABLE `AspNetUsers` DISABLE KEYS */;
INSERT INTO `AspNetUsers` VALUES ('7C6F900F-6DF1-4BC5-8F96-373B156AF049','po@gmail.com','PO@GMAIL.COM','po@gmail.com','PO@GMAIL.COM',0,'AQAAAAEAACcQAAAAEKuyPnV7d9hG21CEGbVpyo1aJ7tuovUzOsVLioPStp3r9dfpp27MDo44lcq4tGrnPw==','7XZQKIVQHAGWG6LYRBR2VCMXIKTIN3YJ','38b67fb9-f214-40d9-802e-14bc556aa2fd','',0,0,'',1,0),('D8A3AD82-DD08-44D8-89D5-960532A71748','admin','ADMIN','ItsSimpleAdmin@admin.store','ITSSIMPLEADMIN@ADMIN.STORE',0,'AQAAAAEAACcQAAAAEAqYW50l9HOZZFBFlz5Teiba+FITvzPIws5QjHm0cI+/qKsGtuSBs4G95NulvkqMLw==','QVKEGQP2GDHK2QEGRTPKEWFDA3LASHUL','9c111209-d56b-4d0c-88c2-74fbb9b8da93','',0,0,'',1,0);
/*!40000 ALTER TABLE `AspNetUsers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Categorydto`
--

DROP TABLE IF EXISTS `Categorydto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Categorydto` (
  `ID` varchar(36) DEFAULT NULL,
  `Name` varchar(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Categorydto`
--

LOCK TABLES `Categorydto` WRITE;
/*!40000 ALTER TABLE `Categorydto` DISABLE KEYS */;
INSERT INTO `Categorydto` VALUES ('00000000-0000-0000-0000-000000000000','No');
/*!40000 ALTER TABLE `Categorydto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Filedto`
--

DROP TABLE IF EXISTS `Filedto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Filedto` (
  `ID` varchar(0) DEFAULT NULL,
  `Autorid` varchar(0) DEFAULT NULL,
  `DateOfCreate` varchar(0) DEFAULT NULL,
  `Lenght` varchar(0) DEFAULT NULL,
  `postid` varchar(0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Filedto`
--

LOCK TABLES `Filedto` WRITE;
/*!40000 ALTER TABLE `Filedto` DISABLE KEYS */;
/*!40000 ALTER TABLE `Filedto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Peopledto`
--

DROP TABLE IF EXISTS `Peopledto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Peopledto` (
  `ID` varchar(36) DEFAULT NULL,
  `Avatar` varchar(0) DEFAULT NULL,
  `DateOfCreate` varchar(27) DEFAULT NULL,
  `Rating` tinyint(4) DEFAULT NULL,
  `FIO` varchar(7) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Peopledto`
--

LOCK TABLES `Peopledto` WRITE;
/*!40000 ALTER TABLE `Peopledto` DISABLE KEYS */;
INSERT INTO `Peopledto` VALUES ('7C6F900F-6DF1-4BC5-8F96-373B156AF049','','2021-11-25 16:37:28.9769145',0,'NewUser');
/*!40000 ALTER TABLE `Peopledto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PostCommentdto`
--

DROP TABLE IF EXISTS `PostCommentdto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `PostCommentdto` (
  `ID` varchar(0) DEFAULT NULL,
  `DateOfCreate` varchar(0) DEFAULT NULL,
  `Description` varchar(0) DEFAULT NULL,
  `PostId` varchar(0) DEFAULT NULL,
  `UserId` varchar(0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PostCommentdto`
--

LOCK TABLES `PostCommentdto` WRITE;
/*!40000 ALTER TABLE `PostCommentdto` DISABLE KEYS */;
/*!40000 ALTER TABLE `PostCommentdto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Postdto`
--

DROP TABLE IF EXISTS `Postdto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Postdto` (
  `ID` varchar(36) DEFAULT NULL,
  `CategoryId` varchar(36) DEFAULT NULL,
  `City` varchar(6) DEFAULT NULL,
  `Cost` smallint(6) DEFAULT NULL,
  `CreatorId` varchar(36) DEFAULT NULL,
  `DateOfCreate` varchar(23) DEFAULT NULL,
  `Description` varchar(6) DEFAULT NULL,
  `Name` varchar(8) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Postdto`
--

LOCK TABLES `Postdto` WRITE;
/*!40000 ALTER TABLE `Postdto` DISABLE KEYS */;
INSERT INTO `Postdto` VALUES ('3FA85F64-5717-4562-B3FC-2C963F66AFA6','00000000-0000-0000-0000-000000000000','string',0,'7C6F900F-6DF1-4BC5-8F96-373B156AF049','2021-11-26 10:15:30.171','string','string'),('3FA85F64-5717-4562-B3FC-2C963F66AFA7','00000000-0000-0000-0000-000000000000','string',100,'7C6F900F-6DF1-4BC5-8F96-373B156AF049','2021-11-26 10:55:45.645','string','ВАЗ 2107');
/*!40000 ALTER TABLE `Postdto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(23) DEFAULT NULL,
  `ProductVersion` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20211022163734_First','5.0.9'),('20211022164716_Second','5.0.9'),('20211022165933_Third','5.0.9'),('20211106080726_Files','5.0.9'),('20211106082044_Files2','5.0.9'),('20211106082650_Files3','5.0.9'),('20211114032505_Category','5.0.9'),('20211126102112_Catrg','5.0.9');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sqlite_sequence`
--

DROP TABLE IF EXISTS `sqlite_sequence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sqlite_sequence` (
  `name` varchar(0) DEFAULT NULL,
  `seq` varchar(0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sqlite_sequence`
--

LOCK TABLES `sqlite_sequence` WRITE;
/*!40000 ALTER TABLE `sqlite_sequence` DISABLE KEYS */;
/*!40000 ALTER TABLE `sqlite_sequence` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-22 15:20:28
