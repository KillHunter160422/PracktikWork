-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
SHOW WARNINGS;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Authors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Authors` (
  `authorId` INT NOT NULL,
  `surname` VARCHAR(50) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `country` VARCHAR(50) NOT NULL DEFAULT 'Россия',
  PRIMARY KEY (`authorId`),
  UNIQUE INDEX `UQ_surname_name` (`surname` ASC, `name` ASC) VISIBLE)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `mydb`.`Books`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Books` (
  `bookId` INT NOT NULL,
  `authorId` INT NOT NULL,
  `title` VARCHAR(50) NOT NULL,
  `genre` ENUM('Проза', 'Поэзия', 'Другое') NOT NULL DEFAULT 'Проза',
  `price` DECIMAL(6,2) NOT NULL DEFAULT 0,
  `weight` DECIMAL(4,3) NOT NULL DEFAULT 0,
  `page` SMALLINT NOT NULL DEFAULT 0,
  `manufactureYear` YEAR NULL,
  PRIMARY KEY (`bookId`),
  INDEX `authorId_idx` (`authorId` ASC) VISIBLE,
  CONSTRAINT `authorId`
    FOREIGN KEY (`authorId`)
    REFERENCES `mydb`.`Authors` (`authorId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `mydb`.`Customers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Customers` (
  `customerId` INT NOT NULL,
  `login` VARCHAR(20) NOT NULL,
  `surname` VARCHAR(50) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `address` VARCHAR(100) NOT NULL,
  `numberPhone` VARCHAR(20) NULL,
  PRIMARY KEY (`customerId`),
  UNIQUE INDEX `login_UNIQUE` (`login` ASC) VISIBLE,
  UNIQUE INDEX `UQ_surname_name` (`surname` ASC, `name` ASC) VISIBLE)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `mydb`.`Orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Orders` (
  `orderId` INT NOT NULL,
  `customerId` INT NOT NULL,
  `DataTime` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`orderId`),
  INDEX `customerId_idx` (`customerId` ASC) VISIBLE,
  CONSTRAINT `customerId`
    FOREIGN KEY (`customerId`)
    REFERENCES `mydb`.`Customers` (`customerId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `mydb`.`Compound`
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Table `mydb`.`Compound`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Compound` (
  `orderId` INT NOT NULL,
  `bookId` INT NOT NULL,
  `com_count` TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (`orderId`, `bookId`),
  INDEX `bookId_idx` (`bookId` ASC) VISIBLE,
  CONSTRAINT `orderId`
    FOREIGN KEY (`orderId`)
    REFERENCES `mydb`.`Orders` (`orderId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `bookId`
    FOREIGN KEY (`bookId`)
    REFERENCES `mydb`.`Books` (`bookId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT check_count CHECK (com_count > 0 AND com_count <= 100)
) ENGINE = InnoDB;

SHOW WARNINGS;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
