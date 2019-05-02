-- Mentor Webshop Database
-- Copyright Shakal Bears

-- -----------------------------------------------------
-- Schema mentorwebshop
-- -----------------------------------------------------

CREATE SCHEMA IF NOT EXISTS `mentorwebshop` DEFAULT CHARACTER SET utf8;

USE `mentorwebshop`;

DROP TABLE IF EXISTS category;
DROP TABLE IF EXISTS orderline;
DROP TABLE IF EXISTS image;
DROP TABLE IF EXISTS product;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS user;

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mentorwebshop
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mentorwebshop
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mentorwebshop` DEFAULT CHARACTER SET utf8 ;
USE `mentorwebshop` ;

-- -----------------------------------------------------
-- Table `mentorwebshop`.`category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mentorwebshop`.`category` (
  `category_id` INT(11) NOT NULL AUTO_INCREMENT,
  `category_name` VARCHAR(1000) NULL DEFAULT NULL,
  PRIMARY KEY (`category_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mentorwebshop`.`product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mentorwebshop`.`product` (
  `product_id` INT(11) NOT NULL AUTO_INCREMENT,
  `product_name` VARCHAR(1000) NULL DEFAULT NULL,
  `product_description` VARCHAR(1000) NULL DEFAULT NULL,
  `product_price` DOUBLE NULL DEFAULT NULL,
  `product_image` VARCHAR(1000) NULL DEFAULT NULL,
  `fk_category_id` INT(11) NOT NULL,
  PRIMARY KEY (`product_id`, `fk_category_id`),
  INDEX `fk_product_category1_idx` (`fk_category_id` ASC),
  CONSTRAINT `fk_product_category1`
    FOREIGN KEY (`fk_category_id`)
    REFERENCES `mentorwebshop`.`category` (`category_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

-- -----------------------------------------------------
-- Table `mentorwebshop`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mentorwebshop`.`user` (
  `user_id` INT(11) NOT NULL AUTO_INCREMENT,
  `user_name` VARCHAR(1000) NOT NULL,
  `user_password` VARCHAR(1000) NOT NULL,
  PRIMARY KEY (`user_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mentorwebshop`.`orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mentorwebshop`.`orders` (
  `orders_id` INT(11) NOT NULL AUTO_INCREMENT,
  `orders_status` VARCHAR(1000) NOT NULL,
  `orders_recived` DATETIME NOT NULL,
  `orders_sent` DATETIME NOT NULL,
  `fk_user_id` INT(11) NOT NULL,
  PRIMARY KEY (`orders_id`, `fk_user_id`),
  INDEX `fk_orders_user_idx` (`fk_user_id` ASC),
  CONSTRAINT `fk_orders_user`
    FOREIGN KEY (`fk_user_id`)
    REFERENCES `mentorwebshop`.`user` (`user_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mentorwebshop`.`orderline`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mentorwebshop`.`orderline` (
  `orderline_quantity` INT(11) NOT NULL,
  `fk_orders_id` INT(11) NOT NULL,
  `fk_product_orderline_id` INT(11) NOT NULL,
  PRIMARY KEY (`fk_orders_id`, `fk_product_orderline_id`),
  INDEX `fk_orderline_product1_idx` (`fk_product_orderline_id` ASC),
  CONSTRAINT `fk_orderline_orders1`
    FOREIGN KEY (`fk_orders_id`)
    REFERENCES `mentorwebshop`.`orders` (`orders_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_orderline_product1`
    FOREIGN KEY (`fk_product_orderline_id`)
    REFERENCES `mentorwebshop`.`product` (`product_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



-- User
INSERT INTO `mentorwebshop`.`user` (`user_name`, `user_password`) VALUES ('Casper', '1234');
INSERT INTO `mentorwebshop`.`user` (`user_name`, `user_password`) VALUES ('Stephan', '1234');
INSERT INTO `mentorwebshop`.`user` (`user_name`, `user_password`) VALUES ('Admin', '1234');

-- Category
INSERT INTO `mentorwebshop`.`category` (`category_name`) VALUES ('Gambling');
INSERT INTO `mentorwebshop`.`category` (`category_name`) VALUES ('Eletronics');
INSERT INTO `mentorwebshop`.`category` (`category_name`) VALUES ('Indoors');
INSERT INTO `mentorwebshop`.`category` (`category_name`) VALUES ('Outdoors');

-- Product
INSERT INTO `mentorwebshop`.`product` (`product_name`, `product_description`, `product_price`, `product_image`, `fk_category_id`) VALUES ('Novomatic Slot Machine', 'A slot machine with 12 nice games', '10000', 'whatever.png', '1');
INSERT INTO `mentorwebshop`.`product` (`product_name`, `product_description`, `product_price`, `product_image`, `fk_category_id`) VALUES ('MSI Dragon area-51-xx', 'A brand new computer with all the things you need', '5000', 'whatever.png', '2');
INSERT INTO `mentorwebshop`.`product` (`product_name`, `product_description`, `product_price`, `product_image`, `fk_category_id`) VALUES ('Lemon Tree', 'A very nice tree for indoors', '30', 'whatever.png', '3');
INSERT INTO `mentorwebshop`.`product` (`product_name`, `product_description`, `product_price`, `product_image`, `fk_category_id`) VALUES ('Tree house', 'A tree house with all the fun you want', '500', 'whatever.png', '4');

-- Orders
INSERT INTO `mentorwebshop`.`orders` (`orders_status`, `orders_recived`, `orders_sent`, `fk_user_id`) VALUES ('Godkendt', '2019-02-11', '2019-02-11', '1');
INSERT INTO `mentorwebshop`.`orders` (`orders_status`, `orders_recived`, `orders_sent`, `fk_user_id`) VALUES ('Godkendt', '2019-02-11', '2019-02-11', '1');
INSERT INTO `mentorwebshop`.`orders` (`orders_status`, `orders_recived`, `orders_sent`, `fk_user_id`) VALUES ('Godkendt', '2019-02-11', '2019-02-11', '2');

-- Orderline
INSERT INTO `mentorwebshop`.`orderline` (`orderline_quantity`, `fk_orders_id`, `fk_product_orderline_id`) VALUES ('1', '1', '1');
INSERT INTO `mentorwebshop`.`orderline` (`orderline_quantity`, `fk_orders_id`, `fk_product_orderline_id`) VALUES ('2', '2', '2');

