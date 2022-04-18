-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema dnevnik_ishrane
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema dnevnik_ishrane
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `dnevnik_ishrane` ;
USE `dnevnik_ishrane` ;

-- -----------------------------------------------------
-- Table `dnevnik_ishrane`.`KORISNIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dnevnik_ishrane`.`KORISNIK` (
  `idKORISNIK` INT NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(45) NOT NULL,
  `Prezime` VARCHAR(45) NOT NULL,
  `KorisnickoIme` VARCHAR(45) NOT NULL,
  `Lozinka` VARCHAR(45) NOT NULL,
  `Godiste` INT NOT NULL,
  `Tema` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idKORISNIK`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dnevnik_ishrane`.`TRENER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dnevnik_ishrane`.`TRENER` (
  `KORISNIK_idKORISNIK` INT NOT NULL,
  PRIMARY KEY (`KORISNIK_idKORISNIK`),
  CONSTRAINT `fk_TRENER_KORISNIK1`
    FOREIGN KEY (`KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`KORISNIK` (`idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dnevnik_ishrane`.`KANDIDAT`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dnevnik_ishrane`.`KANDIDAT` (
  `KORISNIK_idKORISNIK` INT NOT NULL,
  PRIMARY KEY (`KORISNIK_idKORISNIK`),
  CONSTRAINT `fk_KANDIDAT_KORISNIK`
    FOREIGN KEY (`KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`KORISNIK` (`idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dnevnik_ishrane`.`PLAN_ISHRANE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dnevnik_ishrane`.`PLAN_ISHRANE` (
  `idPLAN_ISHRANE` INT NOT NULL AUTO_INCREMENT,
  `DatumVrijeme` DATETIME NOT NULL,
  `Opis` VARCHAR(700) NOT NULL,
  `TRENER_KORISNIK_idKORISNIK` INT NOT NULL,
  `KANDIDAT_KORISNIK_idKORISNIK` INT NOT NULL,
  `Dan` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idPLAN_ISHRANE`, `Dan`),
  INDEX `fk_PLAN_ISHRANE_TRENER1_idx` (`TRENER_KORISNIK_idKORISNIK` ASC) VISIBLE,
  INDEX `fk_PLAN_ISHRANE_KANDIDAT1_idx` (`KANDIDAT_KORISNIK_idKORISNIK` ASC) VISIBLE,
  CONSTRAINT `fk_PLAN_ISHRANE_TRENER1`
    FOREIGN KEY (`TRENER_KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`TRENER` (`KORISNIK_idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PLAN_ISHRANE_KANDIDAT1`
    FOREIGN KEY (`KANDIDAT_KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`KANDIDAT` (`KORISNIK_idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dnevnik_ishrane`.`PLAN_VJEZBANJA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dnevnik_ishrane`.`PLAN_VJEZBANJA` (
  `idPLAN_VJEZBANJA` INT NOT NULL AUTO_INCREMENT,
  `DatumVrijeme` DATETIME NOT NULL,
  `Opis` VARCHAR(700) NOT NULL,
  `TRENER_KORISNIK_idKORISNIK` INT NOT NULL,
  `KANDIDAT_KORISNIK_idKORISNIK` INT NOT NULL,
  `Dan` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idPLAN_VJEZBANJA`, `Dan`),
  INDEX `fk_PLAN_VJEZBANJA_TRENER1_idx` (`TRENER_KORISNIK_idKORISNIK` ASC) VISIBLE,
  INDEX `fk_PLAN_VJEZBANJA_KANDIDAT1_idx` (`KANDIDAT_KORISNIK_idKORISNIK` ASC) VISIBLE,
  CONSTRAINT `fk_PLAN_VJEZBANJA_TRENER1`
    FOREIGN KEY (`TRENER_KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`TRENER` (`KORISNIK_idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PLAN_VJEZBANJA_KANDIDAT1`
    FOREIGN KEY (`KANDIDAT_KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`KANDIDAT` (`KORISNIK_idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dnevnik_ishrane`.`NAMIRNICA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dnevnik_ishrane`.`NAMIRNICA` (
  `idNAMIRNICA` INT NOT NULL AUTO_INCREMENT,
  `Naziv` VARCHAR(45) NOT NULL,
  `Kolicina` DECIMAL NOT NULL DEFAULT 100,
  `KalorijskaVrijednost` DECIMAL(4,1) NOT NULL,
  `Proteini` DECIMAL(3,1) NOT NULL,
  `Masti` DECIMAL(3,1) NOT NULL,
  `UgljikoHidrati` DECIMAL(3,1) NOT NULL,
  PRIMARY KEY (`idNAMIRNICA`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dnevnik_ishrane`.`MJERENJE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dnevnik_ishrane`.`MJERENJE` (
  `TRENER_KORISNIK_idKORISNIK` INT NOT NULL,
  `KANDIDAT_KORISNIK_idKORISNIK` INT NOT NULL,
  `DatumVrijeme` DATETIME NOT NULL,
  `Tezina` DECIMAL(4,1) NOT NULL,
  PRIMARY KEY (`TRENER_KORISNIK_idKORISNIK`, `KANDIDAT_KORISNIK_idKORISNIK`),
  INDEX `fk_TRENER_has_KANDIDAT_KANDIDAT1_idx` (`KANDIDAT_KORISNIK_idKORISNIK` ASC) VISIBLE,
  INDEX `fk_TRENER_has_KANDIDAT_TRENER1_idx` (`TRENER_KORISNIK_idKORISNIK` ASC) VISIBLE,
  CONSTRAINT `fk_TRENER_has_KANDIDAT_TRENER1`
    FOREIGN KEY (`TRENER_KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`TRENER` (`KORISNIK_idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TRENER_has_KANDIDAT_KANDIDAT1`
    FOREIGN KEY (`KANDIDAT_KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`KANDIDAT` (`KORISNIK_idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dnevnik_ishrane`.`OBROK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dnevnik_ishrane`.`OBROK` (
  `KANDIDAT_KORISNIK_idKORISNIK` INT NOT NULL,
  `NAMIRNICA_idNAMIRNICA` INT NOT NULL,
  `Kolicina` DECIMAL(5,1) NOT NULL,
  `TipObroka` VARCHAR(45) NOT NULL,
  `Datum` DATE NOT NULL,
  PRIMARY KEY (`KANDIDAT_KORISNIK_idKORISNIK`, `NAMIRNICA_idNAMIRNICA`, `TipObroka`, `Datum`),
  INDEX `fk_KANDIDAT_has_NAMIRNICA_NAMIRNICA1_idx` (`NAMIRNICA_idNAMIRNICA` ASC) VISIBLE,
  INDEX `fk_KANDIDAT_has_NAMIRNICA_KANDIDAT1_idx` (`KANDIDAT_KORISNIK_idKORISNIK` ASC) VISIBLE,
  CONSTRAINT `fk_KANDIDAT_has_NAMIRNICA_KANDIDAT1`
    FOREIGN KEY (`KANDIDAT_KORISNIK_idKORISNIK`)
    REFERENCES `dnevnik_ishrane`.`KANDIDAT` (`KORISNIK_idKORISNIK`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_KANDIDAT_has_NAMIRNICA_NAMIRNICA1`
    FOREIGN KEY (`NAMIRNICA_idNAMIRNICA`)
    REFERENCES `dnevnik_ishrane`.`NAMIRNICA` (`idNAMIRNICA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
